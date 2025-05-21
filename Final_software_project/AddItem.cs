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
    public partial class AddItem: Form
    {
        public AddItem()
        {
            InitializeComponent();
            AddItemStocks();
            LoadStockData();

            dgvAddItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                    // Clear and refresh the DataGridView
                    dgvAddItem.DataSource = null;  // Reset
                    dgvAddItem.DataSource = dt;    // Reload
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void AddItemStocks()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Item"; // VIEW එක Query කරනවා
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAddItem.DataSource = dt; // Data Grid View එකට Load කරනවා
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


       

      
        

        private void updateItem_Load(object sender, EventArgs e)
        {
            dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAddItem.MultiSelect = false;
            dgvAddItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAddItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAddItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAddItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;



        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Read data from textboxes
            string itemName = txtItemName.Text.Trim();
            string itemSize = txtSize.Text.Trim();
            int initialQuantity;

            // Validate if the quantity is a number
            if (!int.TryParse(txtQty.Text.Trim(), out initialQuantity))
            {
                MessageBox.Show("Please enter a valid number for Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert data into MySQL database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Item (Item_Name, Item_Size, Initial_Quantity) VALUES (@name, @size, @quantity)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Use parameters to prevent SQL Injection
                    cmd.Parameters.AddWithValue("@name", itemName);
                    cmd.Parameters.AddWithValue("@size", itemSize);
                    cmd.Parameters.AddWithValue("@quantity", initialQuantity);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear textboxes after adding data
                    txtItemName.Clear();
                    txtSize.Clear();
                    txtQty.Clear();

                    // Refresh data grid (if applicable)
                    LoadStockData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dgvAddItem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                btnAdd.PerformClick(); // Simulate button click
            }
        }
    }
}

