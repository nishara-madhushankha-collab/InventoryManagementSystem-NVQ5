using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_software_project
{
    public partial class deleteItem : Form
    {
        public deleteItem()
        {
            InitializeComponent();
            LoadStockData();
        }
        string connectionString = "server=localhost;user=root;password=1234;database=InventorySystemWaterBoard;";

        public void LoadStockData(string searchQuery = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Item_ID, Item_Name, Item_Size FROM Item"; // Fetch only necessary columns

                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        query = $"SELECT Item_ID, Item_Name, Item_Size FROM Item WHERE Item_Name LIKE '%{searchQuery}%'";
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDeleteItem.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void lblTopic_Click(object sender, EventArgs e)
        {

        }

        private void dgvDeleteItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDeleteItem.Rows[e.RowIndex];
                lblItemID.Text = row.Cells["Item_ID"].Value.ToString(); // Store Item_ID
                txtItemName.Text = row.Cells["Item_Name"].Value.ToString(); // Populate Item Name
                txtSize.Text = row.Cells["Item_Size"].Value.ToString(); // Populate Item Size
            }

        }
        private void updateItem_Load(object sender, EventArgs e)
        {
            dgvDeleteItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeleteItem.MultiSelect = false;
            dgvDeleteItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDeleteItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvDeleteItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeleteItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;



        }
        private void txtSearchitem_TextChanged(object sender, EventArgs e)
        {
            LoadStockData(txtSearchitem.Text.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
                string.IsNullOrWhiteSpace(txtSize.Text) ||
                string.IsNullOrWhiteSpace(lblItemID.Text))
            {
                MessageBox.Show("Please select an item before deleting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    /* First, delete related records from the Transaction table
                    string deleteTransactionQuery = "DELETE FROM Transaction WHERE Item_ID=@id";
                    using (MySqlCommand cmdTransaction = new MySqlCommand(deleteTransactionQuery, conn))
                    {
                        cmdTransaction.Parameters.AddWithValue("@id", lblItemID.Text.Trim());
                        cmdTransaction.ExecuteNonQuery();
                    }*/

                    // Now, delete the item
                    string deleteItemQuery = "DELETE FROM Item WHERE Item_ID=@id";
                    using (MySqlCommand cmdItem = new MySqlCommand(deleteItemQuery, conn))
                    {
                        cmdItem.Parameters.AddWithValue("@id", lblItemID.Text.Trim());

                        int rowsAffected = cmdItem.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStockData(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Delete failed. Please check the item selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
