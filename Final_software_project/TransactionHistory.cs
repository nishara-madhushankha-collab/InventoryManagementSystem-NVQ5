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
using System.Drawing.Printing;



namespace Final_software_project
{
    public partial class TransactionHistory: Form
    {
        // Declare the PrintDialog and PrintDocument components
        private PrintDialog printDialog1;
        private PrintDocument printDocument1;
        public TransactionHistory()
        {
            InitializeComponent();
            LoadStockData();
            InitializeDateComboBoxes();

            printDialog1 = new PrintDialog();
            printDocument1 = new PrintDocument();

            // Set document to landscape
            printDocument1.DefaultPageSettings.Landscape = true;

            // Set default page size to A4
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169); // Width and Height in hundredths of an inch



            // Attach the PrintPage event handler
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

        }
        string connectionString = "server=localhost;user=root;password=1234;database=InventorySystemWaterBoard;";

        private void InitializeDateComboBoxes()
        {
            // Populate Year ComboBoxes (Range: 2020 - Current Year)
            int currentYear = DateTime.Now.Year;
            for (int year = 2020; year <= currentYear; year++)
            {
                cmbYearFrom.Items.Add(year);
                cmbYearTo.Items.Add(year);
            }

            // Populate Month ComboBoxes (1 to 12)
            for (int month = 1; month <= 12; month++)
            {
                cmbMonthFrom.Items.Add(month);
                cmbMonthTo.Items.Add(month);
            }

            // Populate Day ComboBoxes (1 to 31)
            for (int day = 1; day <= 31; day++)
            {
                cmbDayFrom.Items.Add(day);
                cmbDayTo.Items.Add(day);
            }

            // Set default values to current date
            cmbYearFrom.SelectedItem = currentYear;
            cmbMonthFrom.SelectedItem = DateTime.Now.Month;
            cmbDayFrom.SelectedItem = 1;

            cmbYearTo.SelectedItem = currentYear;
            cmbMonthTo.SelectedItem = DateTime.Now.Month;
            cmbDayTo.SelectedItem = DateTime.Now.Day;
        }


        private void LoadFilteredStockData(DateTime startDate, DateTime endDate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    t.Transaction_ID,
                    t.Employee_ID,
                    e.Employee_Name,
                    t.Item_ID,
                    i.Item_Name,
                    t.Project_ID,
                    p.Project_Name,
                    t.Transaction_Type,
                    t.Transaction_Date,
                    t.Quantity
                FROM transaction t
                JOIN item i ON t.Item_ID = i.Item_ID
                JOIN employee e ON t.Employee_ID = e.Employee_ID
                JOIN project p ON t.Project_ID = p.Project_ID
                WHERE t.Transaction_Date BETWEEN @StartDate AND @EndDate";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTransactHistory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void LoadStockData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // SQL query to fetch transaction data
                    string query = @"
                SELECT 
                    t.Transaction_ID,
                    t.Employee_ID,
                    e.Employee_Name,  -- Fetch Employee Name from employee table
                    t.Item_ID,
                    i.Item_Name,  -- Fetch Item Name
                    t.Project_ID,
                    p.Project_Name,  -- Fetch Project Name
                    t.Transaction_Type,
                    t.Transaction_Date,
                    t.Quantity
                FROM transaction t
                JOIN item i ON t.Item_ID = i.Item_ID
                JOIN employee e ON t.Employee_ID = e.Employee_ID  -- Join with employee table to get employee name
                JOIN project p ON t.Project_ID = p.Project_ID;  -- Join with project table to get project name
            "; // <-- Add the semicolon here

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the data to DataGridView
                    dgvTransactHistory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void updateItem_Load(object sender, EventArgs e)
        {
            dgvTransactHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactHistory.MultiSelect = false;
            dgvTransactHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTransactHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTransactHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;



        }


        private void txtSearchitem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchitem.Text)) // If search box is empty, reload original data
            {
                LoadStockData();
            }
            else
            {
                // Perform search when text is entered
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string searchQuery = "SELECT * FROM Current_Stocks1 WHERE Item_Name LIKE @ItemName";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, conn);
                        adapter.SelectCommand.Parameters.AddWithValue("@ItemName", "%" + txtSearchitem.Text + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTransactHistory.DataSource = dt; // Update the DataGridView with search results
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvTransactHistory.Rows.Count == 0)
            {
                MessageBox.Show("No transactions to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        // PrintPage event to define the content that will be printed
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Times New Roman", 11, FontStyle.Bold);
            Font printFont = new Font("Times New Roman", 10);
            Pen borderPen = new Pen(Color.Black, 1);
            Brush headerBrush = Brushes.LightGray;

            int rowHeight = 30; // Increased row height for better readability
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            float yPos = topMargin + 10;

            // Define column widths for better alignment
            Dictionary<string, int> columnWidths = new Dictionary<string, int>
    {
        { "Transaction_ID", 60 },
        { "Employee_Name", 120 },
        { "Item_ID", 50 },
        { "Item_Name", 100 },
        { "Project_ID", 50 },
        { "Project_Name", 200 }, // Increased for long names
        { "Transaction_Type", 110 },
        { "Transaction_Date", 160 }, // Ensures proper date format display
        { "Quantity", 50 }
    };

            // Draw table headers with bold text and background color
            foreach (DataGridViewColumn column in dgvTransactHistory.Columns)
            {
                int columnWidth = columnWidths.ContainsKey(column.HeaderText) ? columnWidths[column.HeaderText] : 100;

                // Draw header background
                e.Graphics.FillRectangle(headerBrush, new Rectangle(leftMargin, (int)yPos, columnWidth, rowHeight));
                e.Graphics.DrawRectangle(borderPen, leftMargin, yPos, columnWidth, rowHeight);

                // Center align text in header
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(column.HeaderText, headerFont, Brushes.Black, new Rectangle(leftMargin, (int)yPos, columnWidth, rowHeight), sf);

                leftMargin += columnWidth;
            }

            yPos += rowHeight; // Move to next row
            leftMargin = e.MarginBounds.Left; // Reset margin for data rows

            // Draw table rows
            foreach (DataGridViewRow row in dgvTransactHistory.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value != null ? cell.Value.ToString().Trim() : "";
                    int columnWidth = columnWidths.ContainsKey(dgvTransactHistory.Columns[cell.ColumnIndex].HeaderText)
                                      ? columnWidths[dgvTransactHistory.Columns[cell.ColumnIndex].HeaderText]
                                      : 100;

                    // Draw cell border
                    e.Graphics.DrawRectangle(borderPen, leftMargin, yPos, columnWidth, rowHeight);

                    // Align text properly based on column type
                    StringFormat textFormat = new StringFormat { LineAlignment = StringAlignment.Center };
                    if (dgvTransactHistory.Columns[cell.ColumnIndex].HeaderText == "Quantity" ||
                        dgvTransactHistory.Columns[cell.ColumnIndex].HeaderText == "Transaction_ID" ||
                        dgvTransactHistory.Columns[cell.ColumnIndex].HeaderText == "Employee_ID" ||
                        dgvTransactHistory.Columns[cell.ColumnIndex].HeaderText == "Item_ID" ||
                        dgvTransactHistory.Columns[cell.ColumnIndex].HeaderText == "Project_ID")
                    {
                        textFormat.Alignment = StringAlignment.Center; // Center-align numbers
                    }
                    else
                    {
                        textFormat.Alignment = StringAlignment.Near; // Left-align text
                    }

                    e.Graphics.DrawString(cellValue, printFont, Brushes.Black, new Rectangle(leftMargin + 5, (int)yPos, columnWidth - 10, rowHeight), textFormat);

                    leftMargin += columnWidth;
                }

                yPos += rowHeight;
                leftMargin = e.MarginBounds.Left;

                // If next row exceeds page, continue to next page
                if (yPos + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Ensure all combo boxes have selected values
            if (cmbYearFrom.SelectedItem == null || cmbMonthFrom.SelectedItem == null || cmbDayFrom.SelectedItem == null ||
                cmbYearTo.SelectedItem == null || cmbMonthTo.SelectedItem == null || cmbDayTo.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid date range.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construct the start and end date strings
            string startDateStr = $"{cmbYearFrom.SelectedItem}-{cmbMonthFrom.SelectedItem:D2}-{cmbDayFrom.SelectedItem:D2}";
            string endDateStr = $"{cmbYearTo.SelectedItem}-{cmbMonthTo.SelectedItem:D2}-{cmbDayTo.SelectedItem:D2}";

            // Convert to DateTime for validation
            if (!DateTime.TryParse(startDateStr, out DateTime startDate) || !DateTime.TryParse(endDateStr, out DateTime endDate))
            {
                MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after end date.", "Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load filtered data
            LoadFilteredStockData(startDate, endDate);
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {

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
    
