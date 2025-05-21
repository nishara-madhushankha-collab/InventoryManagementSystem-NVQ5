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
    public partial class MainPage: Form
    {

        public MainPage()
        {
            InitializeComponent();
            // Set form size to match screen resolution
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            // Optionally, set form location to start at (0,0)
            this.Location = new Point(0, 0);

            sidepanel.Height = btncheckStocks.Height;
        }
       
        public void changebtnBackColor(Button clickedButton)
        {
           foreach (var btn in new Button[] { btncheckStocks, btnaddItems, btnUpdateItem, btnDeleteItem, btnTransaction, btnPrintStock, btnExit, btnTransactHistory, btnMrReport })
            {
                if (btn != clickedButton)
                {
                    btn.BackColor = Color.FromArgb(41, 39, 40);
                }
            }
        }

        private void btncheckStocks_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btncheckStocks.Height;
            sidepanel.Top = btncheckStocks.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();

            //create an object of checkStore form
            checkStore checkStocks = new checkStore();

            //fit form on the panel
            checkStocks.TopLevel = false;
            checkStocks.Dock = DockStyle.Fill;

            // Add to panel and show
            centerpanel.Controls.Add(checkStocks);
            checkStocks.Show();

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btncheckStocks.BackColor = Color.FromArgb(0, 122, 204);

            changebtnBackColor(clickedButton);//pass the clicked button to changebtnBackColor method

        }

        private void btnaddItems_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnaddItems.Height;
            sidepanel.Top = btnaddItems.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();

            //create an object of addItem form
            AddItem additems = new AddItem();


            //fit form on the panel
            additems.TopLevel = false;
            additems.Dock = DockStyle.Fill;

            // Add to panel and show
            centerpanel.Controls.Add(additems);
            additems.Show();

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnaddItems.BackColor = Color.FromArgb(0, 122, 204);

            changebtnBackColor(clickedButton);//pass the clicked button to changebtnBackColor method    
        }

        private void centerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnUpdateItem.Height;
            sidepanel.Top = btnUpdateItem.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();           

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnUpdateItem.BackColor = Color.FromArgb(0, 122, 204);

            updateItem updateitem = new updateItem();
            updateitem.TopLevel = false;
            updateitem.Dock = DockStyle.Fill;
            centerpanel.Controls.Add(updateitem);
            updateitem.Show();

            changebtnBackColor(clickedButton);//pass the clicked    
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnDeleteItem.Height;
            sidepanel.Top = btnDeleteItem.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;            

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();
            
            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnDeleteItem.BackColor = Color.FromArgb(0, 122, 204);

            deleteItem deleteitem = new deleteItem();
            deleteitem.TopLevel = false;
            deleteitem.Dock = DockStyle.Fill;
            centerpanel.Controls.Add(deleteitem);
            deleteitem.Show();

            changebtnBackColor(clickedButton);//pass the clicked
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnTransaction.Height;
            sidepanel.Top = btnTransaction.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();            

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnTransaction.BackColor = Color.FromArgb(0, 122, 204);

            transaction transaction = new transaction();
            transaction.TopLevel = false;
            transaction.Dock = DockStyle.Fill;
            centerpanel.Controls.Add(transaction);
            transaction.Show();


            changebtnBackColor(clickedButton);//pass the clicked
        }

        private void btnPrintStock_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnPrintStock.Height;
            sidepanel.Top = btnPrintStock.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();
            
            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnPrintStock.BackColor = Color.FromArgb(0, 122, 204);

            PrintStockBalance printStockBalance = new PrintStockBalance();
            printStockBalance.TopLevel = false;
            printStockBalance.Dock = DockStyle.Fill;
            centerpanel.Controls.Add(printStockBalance);
            printStockBalance.Show();


            changebtnBackColor(clickedButton);//pass the clicked
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           /* Button clickedButton = (Button)sender;
            sidepanel.Height = btnExit.Height;
            sidepanel.Top = btnExit.Top;                  

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnExit.BackColor = Color.FromArgb(0, 122, 204);

            changebtnBackColor(clickedButton);//pass the clicked

            string message = "Do you Want to close this?";
            string title = "Exit Application";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //close the message box

            }*/
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnExit.Height;
            sidepanel.Top = btnExit.Top;

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnExit.BackColor = Color.FromArgb(0, 122, 204);

            changebtnBackColor(clickedButton);//pass the clicked

            string message = "Do you Want to close this?";
            string title = "Exit Application";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //close the message box

            }

        }

        private void btnTransactHistory_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnTransactHistory.Height;
            sidepanel.Top = btnTransactHistory.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnTransactHistory.BackColor = Color.FromArgb(0, 122, 204);

            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.TopLevel = false;
            transactionHistory.Dock = DockStyle.Fill;
            centerpanel.Controls.Add(transactionHistory);
            transactionHistory.Show();

            changebtnBackColor(clickedButton);//pass the clicked
        }

        private void btnMrReport_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            sidepanel.Height = btnMrReport.Height;
            sidepanel.Top = btnMrReport.Top;

            // Enable scrolling if content exceeds panel size
            centerpanel.AutoScroll = true;

            // Clear the panel before adding a new form
            centerpanel.Controls.Clear();

            // Change the color of toppanel
            toppanel.BackColor = Color.FromArgb(0, 122, 204);

            //change the button color
            btnMrReport.BackColor = Color.FromArgb(0, 122, 204);

            MRreport mrReport = new MRreport();
            mrReport.TopLevel = false;
            mrReport.Dock = DockStyle.Fill;
            centerpanel.Controls.Add(mrReport);
            mrReport.Show();

            changebtnBackColor(clickedButton);

        }
    }
}
