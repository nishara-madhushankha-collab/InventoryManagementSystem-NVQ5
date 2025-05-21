using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Final_software_project
{
    public partial class PrintStockBalance : Form
    {
        private PrintDialog printDialog1;
        private PrintDocument printDocument1;

        public PrintStockBalance()
        {
            InitializeComponent();
            LoadStockData();

            // Initialize printing components
            printDialog1 = new PrintDialog();
            printDocument1 = new PrintDocument();

            // Set document to landscape
            printDocument1.DefaultPageSettings.Landscape = true;

            // Set default page size to A4
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169); // Width and Height in hundredths of an inch



            // Attach PrintPage event handler
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        string connectionString = "server=localhost;user=root;password=1234;database=InventorySystemWaterBoard;";

        public void LoadStockData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Item"; // Fetch data
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStorebalance.DataSource = dt; // Load data into DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvStorebalance.Rows.Count == 0)
            {
                MessageBox.Show("No stock records to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Times New Roman", 11, FontStyle.Bold);
            Font printFont = new Font("Times New Roman", 10);
            Pen borderPen = new Pen(Color.Black, 1);
            Brush headerBrush = Brushes.LightGray;

            int rowHeight = 30;
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            float yPos = topMargin + 10;

            int totalWidth = e.MarginBounds.Width; // Get available width
            int columnCount = dgvStorebalance.Columns.Count;
            int columnWidth = totalWidth / columnCount; // Dynamic column width

            // Print headers
            foreach (DataGridViewColumn column in dgvStorebalance.Columns)
            {
                // Draw header background
                e.Graphics.FillRectangle(headerBrush, new Rectangle(leftMargin, (int)yPos, columnWidth, rowHeight));
                e.Graphics.DrawRectangle(borderPen, leftMargin, yPos, columnWidth, rowHeight);

                // Center align header text
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(column.HeaderText, headerFont, Brushes.Black, new Rectangle(leftMargin, (int)yPos, columnWidth, rowHeight), sf);

                leftMargin += columnWidth;
            }

            yPos += rowHeight;
            leftMargin = e.MarginBounds.Left;

            // Print rows
            foreach (DataGridViewRow row in dgvStorebalance.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value != null ? cell.Value.ToString().Trim() : "";

                    // Draw cell border
                    e.Graphics.DrawRectangle(borderPen, leftMargin, yPos, columnWidth, rowHeight);

                    // Align text properly
                    StringFormat textFormat = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near };
                    e.Graphics.DrawString(cellValue, printFont, Brushes.Black, new Rectangle(leftMargin + 5, (int)yPos, columnWidth - 10, rowHeight), textFormat);

                    leftMargin += columnWidth;
                }

                yPos += rowHeight;
                leftMargin = e.MarginBounds.Left;

                // If page limit reached, go to next page
                if (yPos + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
        }

        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                btnPrint.PerformClick(); // Simulate button click
            }
        }
    }
}
