using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Final_software_project
{
    public partial class updateItem: Form
    {
        public updateItem()
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
                    dgvUpdateItem.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
                string.IsNullOrWhiteSpace(txtSize.Text)||
                string.IsNullOrWhiteSpace(lblItemID.Text))
            {
                MessageBox.Show("Please select an item and fill in all fields before updating.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Item SET Item_Name = @name, Item_Size = @size WHERE Item_ID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@size", txtSize.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", lblItemID.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStockData(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please check the item selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
                  

       

        private void updateItem_Load(object sender, EventArgs e)
        {
            dgvUpdateItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUpdateItem.MultiSelect = false;
            dgvUpdateItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUpdateItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvUpdateItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUpdateItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;



        }

        private void dgvUpdateItem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUpdateItem.Rows[e.RowIndex];
                lblItemID.Text = row.Cells["Item_ID"].Value.ToString(); // Store Item_ID
                txtItemName.Text = row.Cells["Item_Name"].Value.ToString(); // Populate Item Name
                txtSize.Text = row.Cells["Item_Size"].Value.ToString(); // Populate Item Size
            }

        }

        private void txtSearchitem_TextChanged_1(object sender, EventArgs e)
        {
            LoadStockData(txtSearchitem.Text.Trim());

        }
    }
}
