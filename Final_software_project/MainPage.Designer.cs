namespace Final_software_project
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnTransactHistory = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.sidepanel = new System.Windows.Forms.Panel();
            this.btnPrintStock = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.btnaddItems = new System.Windows.Forms.Button();
            this.btncheckStocks = new System.Windows.Forms.Button();
            this.toppanel = new System.Windows.Forms.Panel();
            this.centerpanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMrReport = new System.Windows.Forms.Button();
            this.leftPanel.SuspendLayout();
            this.centerpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.leftPanel.Controls.Add(this.btnMrReport);
            this.leftPanel.Controls.Add(this.btnTransactHistory);
            this.leftPanel.Controls.Add(this.btnExit);
            this.leftPanel.Controls.Add(this.sidepanel);
            this.leftPanel.Controls.Add(this.btnPrintStock);
            this.leftPanel.Controls.Add(this.btnTransaction);
            this.leftPanel.Controls.Add(this.btnDeleteItem);
            this.leftPanel.Controls.Add(this.btnUpdateItem);
            this.leftPanel.Controls.Add(this.btnaddItems);
            this.leftPanel.Controls.Add(this.btncheckStocks);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(208, 780);
            this.leftPanel.TabIndex = 0;
            // 
            // btnTransactHistory
            // 
            this.btnTransactHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactHistory.FlatAppearance.BorderSize = 0;
            this.btnTransactHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactHistory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactHistory.ForeColor = System.Drawing.Color.White;
            this.btnTransactHistory.Location = new System.Drawing.Point(12, 402);
            this.btnTransactHistory.Name = "btnTransactHistory";
            this.btnTransactHistory.Size = new System.Drawing.Size(193, 59);
            this.btnTransactHistory.TabIndex = 5;
            this.btnTransactHistory.Text = "Transaction History";
            this.btnTransactHistory.UseVisualStyleBackColor = true;
            this.btnTransactHistory.Click += new System.EventHandler(this.btnTransactHistory_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(12, 587);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(196, 55);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // sidepanel
            // 
            this.sidepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.sidepanel.Location = new System.Drawing.Point(3, 100);
            this.sidepanel.Name = "sidepanel";
            this.sidepanel.Size = new System.Drawing.Size(10, 55);
            this.sidepanel.TabIndex = 1;
            // 
            // btnPrintStock
            // 
            this.btnPrintStock.FlatAppearance.BorderSize = 0;
            this.btnPrintStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintStock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintStock.ForeColor = System.Drawing.Color.White;
            this.btnPrintStock.Location = new System.Drawing.Point(12, 466);
            this.btnPrintStock.Name = "btnPrintStock";
            this.btnPrintStock.Size = new System.Drawing.Size(196, 55);
            this.btnPrintStock.TabIndex = 6;
            this.btnPrintStock.Text = "Print Stock Balance";
            this.btnPrintStock.UseVisualStyleBackColor = true;
            this.btnPrintStock.Click += new System.EventHandler(this.btnPrintStock_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Location = new System.Drawing.Point(12, 344);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(196, 55);
            this.btnTransaction.TabIndex = 4;
            this.btnTransaction.Text = "Do Transactions";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.FlatAppearance.BorderSize = 0;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.ForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.Location = new System.Drawing.Point(12, 283);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(196, 55);
            this.btnDeleteItem.TabIndex = 3;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.FlatAppearance.BorderSize = 0;
            this.btnUpdateItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateItem.ForeColor = System.Drawing.Color.White;
            this.btnUpdateItem.Location = new System.Drawing.Point(12, 222);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(196, 55);
            this.btnUpdateItem.TabIndex = 2;
            this.btnUpdateItem.Text = "Update Item";
            this.btnUpdateItem.UseVisualStyleBackColor = true;
            this.btnUpdateItem.Click += new System.EventHandler(this.btnUpdateItem_Click);
            // 
            // btnaddItems
            // 
            this.btnaddItems.FlatAppearance.BorderSize = 0;
            this.btnaddItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddItems.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddItems.ForeColor = System.Drawing.Color.White;
            this.btnaddItems.Location = new System.Drawing.Point(12, 161);
            this.btnaddItems.Name = "btnaddItems";
            this.btnaddItems.Size = new System.Drawing.Size(196, 55);
            this.btnaddItems.TabIndex = 1;
            this.btnaddItems.Text = "Add Item";
            this.btnaddItems.UseVisualStyleBackColor = true;
            this.btnaddItems.Click += new System.EventHandler(this.btnaddItems_Click);
            // 
            // btncheckStocks
            // 
            this.btncheckStocks.FlatAppearance.BorderSize = 0;
            this.btncheckStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncheckStocks.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheckStocks.ForeColor = System.Drawing.Color.White;
            this.btncheckStocks.Location = new System.Drawing.Point(12, 100);
            this.btncheckStocks.Name = "btncheckStocks";
            this.btncheckStocks.Size = new System.Drawing.Size(196, 55);
            this.btncheckStocks.TabIndex = 0;
            this.btncheckStocks.Text = "Stock Available";
            this.btncheckStocks.UseVisualStyleBackColor = true;
            this.btncheckStocks.Click += new System.EventHandler(this.btncheckStocks_Click);
            // 
            // toppanel
            // 
            this.toppanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toppanel.Location = new System.Drawing.Point(208, 0);
            this.toppanel.Name = "toppanel";
            this.toppanel.Size = new System.Drawing.Size(1122, 13);
            this.toppanel.TabIndex = 1;
            // 
            // centerpanel
            // 
            this.centerpanel.BackColor = System.Drawing.Color.Transparent;
            this.centerpanel.Controls.Add(this.pictureBox1);
            this.centerpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerpanel.Location = new System.Drawing.Point(208, 13);
            this.centerpanel.Name = "centerpanel";
            this.centerpanel.Size = new System.Drawing.Size(1122, 767);
            this.centerpanel.TabIndex = 4;
            this.centerpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.centerpanel_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Final_software_project.Properties.Resources.inventory;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1122, 767);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnMrReport
            // 
            this.btnMrReport.FlatAppearance.BorderSize = 0;
            this.btnMrReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMrReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMrReport.ForeColor = System.Drawing.Color.White;
            this.btnMrReport.Location = new System.Drawing.Point(12, 526);
            this.btnMrReport.Name = "btnMrReport";
            this.btnMrReport.Size = new System.Drawing.Size(196, 55);
            this.btnMrReport.TabIndex = 8;
            this.btnMrReport.Text = "Create MR Report";
            this.btnMrReport.UseVisualStyleBackColor = true;
            this.btnMrReport.Click += new System.EventHandler(this.btnMrReport_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 780);
            this.Controls.Add(this.centerpanel);
            this.Controls.Add(this.toppanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.leftPanel.ResumeLayout(false);
            this.centerpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel sidepanel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrintStock;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.Button btnaddItems;
        private System.Windows.Forms.Button btncheckStocks;
        private System.Windows.Forms.Panel toppanel;
        private System.Windows.Forms.Panel centerpanel;
        private System.Windows.Forms.Button btnTransactHistory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMrReport;
    }
}