namespace Hotel.Forms
{
    partial class FrmDateWiseRoomView
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
            panelTop = new Panel();
            btnRefresh = new Button();
            dtpTodate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            lblFormTitle = new Label();
            mainPanel = new FlowLayoutPanel();
            dgvRoomGrid = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomGrid).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.SkyBlue;
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(dtpTodate);
            panelTop.Controls.Add(dtpFromDate);
            panelTop.Controls.Add(lblFormTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1349, 58);
            panelTop.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1184, 19);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dtpTodate
            // 
            dtpTodate.Location = new Point(978, 19);
            dtpTodate.Name = "dtpTodate";
            dtpTodate.Size = new Size(200, 23);
            dtpTodate.TabIndex = 2;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new Point(757, 19);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(200, 23);
            dtpFromDate.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.Location = new Point(24, 17);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(148, 25);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Date Wise View";
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(91, 484);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1039, 213);
            mainPanel.TabIndex = 2;
            // 
            // dgvRoomGrid
            // 
            dgvRoomGrid.AllowUserToAddRows = false;
            dgvRoomGrid.AllowUserToDeleteRows = false;
            dgvRoomGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomGrid.Dock = DockStyle.Fill;
            dgvRoomGrid.Location = new Point(0, 58);
            dgvRoomGrid.Name = "dgvRoomGrid";
            dgvRoomGrid.ReadOnly = true;
            dgvRoomGrid.RowTemplate.Height = 60;
            dgvRoomGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvRoomGrid.Size = new Size(1349, 675);
            dgvRoomGrid.TabIndex = 3;
            dgvRoomGrid.CellClick += dgvRoomGrid_CellClick;
            dgvRoomGrid.CellPainting += dgvRoomGrid_CellPainting;
            dgvRoomGrid.CellToolTipTextNeeded += dgvRoomGrid_CellToolTipTextNeeded;
            // 
            // FrmDateWiseRoomView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 733);
            Controls.Add(dgvRoomGrid);
            Controls.Add(mainPanel);
            Controls.Add(panelTop);
            Name = "FrmDateWiseRoomView";
            Text = "FrmDateWiseRoomView";
            Load += FrmDateWiseRoomView_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblFormTitle;
        private FlowLayoutPanel mainPanel;
        private Button btnRefresh;
      
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpTodate;
        private DataGridView dgvRoomGrid;
    }
}