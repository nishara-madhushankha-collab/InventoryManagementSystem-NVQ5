using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_software_project
{
    public partial class MRreport : Form
    {
        public MRreport()
        {
            InitializeComponent();
            LoadStockData();

            // Initialize MR Data Table
            mrTable.Columns.Add("StockItemDescription", typeof(string));
            mrTable.Columns.Add("Unit", typeof(string));
            mrTable.Columns.Add("QtyRequested", typeof(int));
            mrTable.Columns.Add("QtyIssued", typeof(int));
            mrTable.Columns.Add("QtyToBePurchased", typeof(int));
        }

        string connectionString = "server=localhost;user=root;password=1234;database=InventorySystemWaterBoard;";
        DataTable mrTable = new DataTable();

        public void LoadStockData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Item";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvChechStocks.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }

        private void ClearTextbox_Click(object sender, EventArgs e)
        {
            txtItemName.Clear();
            txtSize.Clear();
            txtQty.Clear();
            txtprepareName.Clear();
            txtSearchItem.Clear();
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string searchQuery = "SELECT * FROM Item WHERE Item_Name LIKE @ItemName";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@ItemName", "%" + txtSearchItem.Text + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvChechStocks.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void addItemToMR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) || string.IsNullOrWhiteSpace(txtSize.Text) || string.IsNullOrWhiteSpace(txtQty.Text))
            {
                MessageBox.Show("Please fill Item Name, Size and Quantity.");
                return;
            }

            DataRow newRow = mrTable.NewRow();
            newRow["StockItemDescription"] = txtSize.Text + " " + txtItemName.Text;
            newRow["Unit"] = "nr";
            newRow["QtyRequested"] = int.Parse(txtQty.Text);
            newRow["QtyIssued"] = 0;
            newRow["QtyToBePurchased"] = 0;
            mrTable.Rows.Add(newRow);

            MessageBox.Show("Item added to MR Report.");
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            string itemNameToDelete = txtItemName.Text;
            string itemSizeToDelete = txtSize.Text;

            if (string.IsNullOrWhiteSpace(itemNameToDelete) || string.IsNullOrWhiteSpace(itemSizeToDelete))
            {
                MessageBox.Show("Please enter Item Name and Size to delete.");
                return;
            }

            string fullDescription = itemSizeToDelete + " " + itemNameToDelete;

            foreach (DataRow row in mrTable.Rows)
            {
                if (row["StockItemDescription"].ToString() == fullDescription)
                {
                    mrTable.Rows.Remove(row);
                    MessageBox.Show("Item deleted from MR Report.");
                    return;
                }
            }

            MessageBox.Show("Item not found in MR Report.");
        }

        private void ViewReport_Click(object sender, EventArgs e)
        {
            dgvChechStocks.DataSource = mrTable;
        }

        private void PrintMR_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            printDoc.PrintPage += new PrintPageEventHandler(PrintMRDocument);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 1000,
                Height = 800
            };
            previewDialog.ShowDialog();
        }

        private void PrintMRDocument(object sender, PrintPageEventArgs e)
        {
            int margin = 40;
            int y = margin;
            int pageWidth = e.PageBounds.Width - (2 * margin);
            int colCount = 5;
            int colWidth = pageWidth / colCount;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font contentFont = new Font("Arial", 10);
            Pen pen = new Pen(Color.Black);

            // Title
            e.Graphics.DrawString("NATIONAL WATER SUPPLY & DRAINAGE BOARD\n           Material Requisition Report", titleFont, Brushes.Black, new RectangleF(margin + 150, y, pageWidth - 300, 100));
            y += 100;

            // Header Row
            int x = margin;
            string[] headers = { "Stock Item Description", "Unit", "Qty Requested", "Qty Issued", "Qty to be Purchased" };
            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawRectangle(pen, x, y, colWidth, 30);
                e.Graphics.DrawString(headers[i], headerFont, Brushes.Black, new RectangleF(x + 5, y + 5, colWidth - 10, 20));
                x += colWidth;
            }

            y += 30;

            // Content Rows
            foreach (DataRow row in mrTable.Rows)
            {
                x = margin;
                for (int i = 0; i < colCount; i++)
                {
                    e.Graphics.DrawRectangle(pen, x, y, colWidth, 30);
                    string text = "";

                    if (i == 0) text = row["StockItemDescription"].ToString();
                    else if (i == 1) text = row["Unit"].ToString();
                    else if (i == 2) text = row["QtyRequested"].ToString();
                    else if (i == 3) text = row["QtyIssued"].ToString();
                    else if (i == 4) text = row["QtyToBePurchased"].ToString();

                    e.Graphics.DrawString(text, contentFont, Brushes.Black, new RectangleF(x + 5, y + 5, colWidth - 10, 20));
                    x += colWidth;
                }
                y += 30;
            }

            // Prepared by and Date at the bottom
            float bottomY = e.PageBounds.Height - margin - 30;
            e.Graphics.DrawString($"Prepared by: {txtprepareName.Text}", contentFont, Brushes.Black, new PointF(margin, bottomY));
            e.Graphics.DrawString($"Date: {DateTime.Now.ToShortDateString()}", contentFont, Brushes.Black, new PointF(e.PageBounds.Width - margin - 150, bottomY));
        }

        private void dgvChechStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChechStocks.Rows[e.RowIndex];
                txtItemName.Text = row.Cells["Item_Name"].Value.ToString();
                txtSize.Text = row.Cells["Item_Size"].Value.ToString();
                txtQty.Text = row.Cells["Initial_Quantity"].Value.ToString();
            }
        }
    }
}
