namespace Final_software_project
{
    partial class checkStore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SubtopPanel = new System.Windows.Forms.Panel();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTopic = new System.Windows.Forms.Label();
            this.dgvChechStocks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CheckLowInventory = new Guna.UI2.WinForms.Guna2Button();
            this.Refresh_btn = new Guna.UI2.WinForms.Guna2Button();
            this.SubtopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChechStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // SubtopPanel
            // 
            this.SubtopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.SubtopPanel.Controls.Add(this.Refresh_btn);
            this.SubtopPanel.Controls.Add(this.CheckLowInventory);
            this.SubtopPanel.Controls.Add(this.txtSearchItem);
            this.SubtopPanel.Controls.Add(this.label1);
            this.SubtopPanel.Controls.Add(this.lblTopic);
            this.SubtopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubtopPanel.Location = new System.Drawing.Point(0, 0);
            this.SubtopPanel.Name = "SubtopPanel";
            this.SubtopPanel.Size = new System.Drawing.Size(1062, 100);
            this.SubtopPanel.TabIndex = 2;
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchItem.Location = new System.Drawing.Point(210, 59);
            this.txtSearchItem.Multiline = true;
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(366, 35);
            this.txtSearchItem.TabIndex = 1;
            this.txtSearchItem.TextChanged += new System.EventHandler(this.txtSearchItem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search by Item Name";
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTopic.Location = new System.Drawing.Point(422, 9);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(304, 25);
            this.lblTopic.TabIndex = 0;
            this.lblTopic.Text = "Find out what\'s currently in stock";
            // 
            // dgvChechStocks
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChechStocks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChechStocks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChechStocks.ColumnHeadersHeight = 4;
            this.dgvChechStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChechStocks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChechStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChechStocks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChechStocks.Location = new System.Drawing.Point(0, 100);
            this.dgvChechStocks.Name = "dgvChechStocks";
            this.dgvChechStocks.RowHeadersVisible = false;
            this.dgvChechStocks.Size = new System.Drawing.Size(1062, 627);
            this.dgvChechStocks.TabIndex = 3;
            this.dgvChechStocks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChechStocks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChechStocks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChechStocks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChechStocks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChechStocks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChechStocks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChechStocks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChechStocks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChechStocks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChechStocks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChechStocks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChechStocks.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvChechStocks.ThemeStyle.ReadOnly = false;
            this.dgvChechStocks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChechStocks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChechStocks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChechStocks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChechStocks.ThemeStyle.RowsStyle.Height = 22;
            this.dgvChechStocks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChechStocks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // CheckLowInventory
            // 
            this.CheckLowInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CheckLowInventory.BorderColor = System.Drawing.Color.DimGray;
            this.CheckLowInventory.BorderThickness = 2;
            this.CheckLowInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckLowInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CheckLowInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CheckLowInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CheckLowInventory.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(3)));
            this.CheckLowInventory.ForeColor = System.Drawing.Color.Black;
            this.CheckLowInventory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CheckLowInventory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CheckLowInventory.Location = new System.Drawing.Point(582, 59);
            this.CheckLowInventory.Name = "CheckLowInventory";
            this.CheckLowInventory.Size = new System.Drawing.Size(316, 34);
            this.CheckLowInventory.TabIndex = 2;
            this.CheckLowInventory.Text = "Click To Check Low Inventory";
            this.CheckLowInventory.Click += new System.EventHandler(this.CheckLowInventory_Click);
            // 
            // Refresh_btn
            // 
            this.Refresh_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Refresh_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Refresh_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Refresh_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Refresh_btn.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(3)));
            this.Refresh_btn.ForeColor = System.Drawing.Color.Black;
            this.Refresh_btn.Location = new System.Drawing.Point(912, 59);
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.Size = new System.Drawing.Size(138, 34);
            this.Refresh_btn.TabIndex = 3;
            this.Refresh_btn.Text = "Refresh";
            this.Refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            // 
            // checkStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 727);
            this.Controls.Add(this.dgvChechStocks);
            this.Controls.Add(this.SubtopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "checkStore";
            this.Text = "checkStore";
            this.SubtopPanel.ResumeLayout(false);
            this.SubtopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChechStocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel SubtopPanel;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChechStocks;
        private Guna.UI2.WinForms.Guna2Button CheckLowInventory;
        private Guna.UI2.WinForms.Guna2Button Refresh_btn;
    }
}