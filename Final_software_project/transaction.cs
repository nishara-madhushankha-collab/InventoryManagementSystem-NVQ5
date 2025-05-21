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
    public partial class transaction: Form
    {
        public transaction()
        {
            InitializeComponent();
            LoadStockData();
        }
        string connectionString = "server=localhost;user=root;password=1234;database=InventorySystemWaterBoard;";

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd;

                    int itemID = int.Parse(lblItemID.Text);
                    int quantity = int.Parse(txtQuantity.Text);
                    string transactionType = ComboTransaction.SelectedItem.ToString();
                    string projectName = txtProjectName.Text.Trim();

                    if (quantity <= 0)
                    {
                        MessageBox.Show("Quantity must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 1. Get current quantity
                    int currentQuantity = 0;
                    cmd = new MySqlCommand("SELECT Initial_Quantity FROM Item WHERE Item_ID = @itemID", conn);
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        currentQuantity = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Item not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Update item quantity based on transaction type
                    int newQuantity = currentQuantity;

                    if (transactionType == "Remove")
                    {
                        if (quantity > currentQuantity)
                        {
                            MessageBox.Show("Not enough stock available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        newQuantity -= quantity;
                    }
                    else if (transactionType == "Return")
                    {
                        newQuantity += quantity;
                    }

                    cmd = new MySqlCommand("UPDATE Item SET Initial_Quantity = @newQuantity WHERE Item_ID = @itemID", conn);
                    cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.ExecuteNonQuery();

                    // 3. Insert project if not exists (UPDATED)
                    int projectID = 0;
                    cmd = new MySqlCommand("SELECT Project_ID FROM Project WHERE Project_Name = @projectName", conn);
                    cmd.Parameters.AddWithValue("@projectName", projectName);
                    result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        projectID = Convert.ToInt32(result);
                    }
                    else
                    {
                        cmd = new MySqlCommand("INSERT INTO Project (Project_Name, Project_Timestamp) VALUES (@projectName, @timestamp)", conn);
                        cmd.Parameters.AddWithValue("@projectName", projectName);
                        cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);  // Automatically set timestamp
                        cmd.ExecuteNonQuery();
                        projectID = (int)cmd.LastInsertedId;
                    }

                    // 4. Insert transaction record
                    cmd = new MySqlCommand(@"
                INSERT INTO Transaction (Employee_ID, Item_ID, Project_ID, Transaction_Type, Quantity) 
                VALUES (@employeeID, @itemID, @projectID, @transactionType, @quantity)", conn);
                    cmd.Parameters.AddWithValue("@employeeID", 1);  // Set dynamically
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.Parameters.AddWithValue("@projectID", projectID);
                    cmd.Parameters.AddWithValue("@transactionType", transactionType);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaction recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStockData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void LoadStockData(string searchQuery = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Item_ID, Item_Name, Item_Size,Initial_Quantity FROM Item"; // Fetch only necessary columns

                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        query = $"SELECT Item_ID, Item_Name, Item_Size,Initial_Quantity FROM Item WHERE Item_Name LIKE '%{searchQuery}%'";
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTransactItem.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvTransactItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransactItem.Rows[e.RowIndex];
                lblItemID.Text = row.Cells["Item_ID"].Value.ToString(); // Store Item_ID
                txtItemName.Text = row.Cells["Item_Name"].Value.ToString(); // Populate Item Name
                txtSize.Text = row.Cells["Item_Size"].Value.ToString(); // Populate Item Size
            }
        }

        private void txtSearchitem_TextChanged(object sender, EventArgs e)
        {
            LoadStockData(txtSearchitem.Text.Trim());
        }
        private void updateItem_Load(object sender, EventArgs e)
        {
            dgvTransactItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactItem.MultiSelect = false;
            dgvTransactItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTransactItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTransactItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;



        }

        private void transaction_Load(object sender, EventArgs e)
        {
            ComboTransaction.Items.Add("Remove");
            ComboTransaction.Items.Add("Return");
            ComboTransaction.SelectedIndex = 0; // Default selection
        }

        private void sideLeftPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
