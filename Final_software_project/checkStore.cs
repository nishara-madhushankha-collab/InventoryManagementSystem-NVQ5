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
    public partial class checkStore: Form
    {
        public checkStore()
        {
            InitializeComponent();
            LoadStockData();

        }
        string connectionString = "server=localhost;user=root;password=1234;database=InventorySystemWaterBoard;";

        public void LoadStockData()
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
                    dgvChechStocks.DataSource = dt; // Data Grid View එකට Load කරනවා
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
                    dgvChechStocks.DataSource = dt; // Update the DataGridView with search results
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvChechStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CheckLowInventory_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Item WHERE Initial_Quantity < 20"; // Only items with quantity less than 20
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvChechStocks.DataSource = dt; // Load filtered data into DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }
    }
}
