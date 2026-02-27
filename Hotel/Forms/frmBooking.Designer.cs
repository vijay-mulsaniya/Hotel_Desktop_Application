namespace Hotel.Forms
{
    partial class frmBooking
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooking));
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelTop = new Panel();
            btnRefresh = new Button();
            dtpDate = new DateTimePicker();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            lblDormatryCount = new Label();
            lblStandardRoomCount = new Label();
            lblTotalRooms = new Label();
            lblAvailableTotal = new Label();
            lblBookedTotal = new Label();
            lblAsOn = new Label();
            lblDeluxeTotal = new Label();
            label2 = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(0, 64);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1259, 483);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(dtpDate);
            panelTop.Controls.Add(label9);
            panelTop.Controls.Add(label8);
            panelTop.Controls.Add(label7);
            panelTop.Controls.Add(label6);
            panelTop.Controls.Add(label4);
            panelTop.Controls.Add(label3);
            panelTop.Controls.Add(lblDormatryCount);
            panelTop.Controls.Add(lblStandardRoomCount);
            panelTop.Controls.Add(lblTotalRooms);
            panelTop.Controls.Add(lblAvailableTotal);
            panelTop.Controls.Add(lblBookedTotal);
            panelTop.Controls.Add(lblAsOn);
            panelTop.Controls.Add(lblDeluxeTotal);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1259, 58);
            panelTop.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(279, 9);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(119, 9);
            dtpDate.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(154, 23);
            dtpDate.TabIndex = 2;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Location = new Point(1168, 9);
            label9.Name = "label9";
            label9.Size = new Size(33, 15);
            label9.TabIndex = 1;
            label9.Text = "Total";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(1089, 9);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 1;
            label8.Text = "Available";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(1024, 9);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 1;
            label7.Text = "Booked";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(926, 9);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 1;
            label6.Text = "As On";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(753, 9);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 1;
            label4.Text = "Dormitory";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(585, 9);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 1;
            label3.Text = "Standard Room";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDormatryCount
            // 
            lblDormatryCount.Anchor = AnchorStyles.Top;
            lblDormatryCount.AutoSize = true;
            lblDormatryCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDormatryCount.Location = new Point(734, 34);
            lblDormatryCount.Name = "lblDormatryCount";
            lblDormatryCount.Size = new Size(99, 15);
            lblDormatryCount.TabIndex = 1;
            lblDormatryCount.Text = "Booked 43 of 43";
            lblDormatryCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStandardRoomCount
            // 
            lblStandardRoomCount.Anchor = AnchorStyles.Top;
            lblStandardRoomCount.AutoSize = true;
            lblStandardRoomCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStandardRoomCount.Location = new Point(580, 34);
            lblStandardRoomCount.Name = "lblStandardRoomCount";
            lblStandardRoomCount.Size = new Size(99, 15);
            lblStandardRoomCount.TabIndex = 1;
            lblStandardRoomCount.Text = "Booked 40 of 40";
            lblStandardRoomCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalRooms
            // 
            lblTotalRooms.Anchor = AnchorStyles.Top;
            lblTotalRooms.AutoSize = true;
            lblTotalRooms.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRooms.Location = new Point(1177, 34);
            lblTotalRooms.Name = "lblTotalRooms";
            lblTotalRooms.Size = new Size(14, 15);
            lblTotalRooms.TabIndex = 1;
            lblTotalRooms.Text = "0";
            lblTotalRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvailableTotal
            // 
            lblAvailableTotal.Anchor = AnchorStyles.Top;
            lblAvailableTotal.AutoSize = true;
            lblAvailableTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvailableTotal.Location = new Point(1109, 34);
            lblAvailableTotal.Name = "lblAvailableTotal";
            lblAvailableTotal.Size = new Size(14, 15);
            lblAvailableTotal.TabIndex = 1;
            lblAvailableTotal.Text = "0";
            lblAvailableTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBookedTotal
            // 
            lblBookedTotal.Anchor = AnchorStyles.Top;
            lblBookedTotal.AutoSize = true;
            lblBookedTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookedTotal.Location = new Point(1040, 34);
            lblBookedTotal.Name = "lblBookedTotal";
            lblBookedTotal.Size = new Size(14, 15);
            lblBookedTotal.TabIndex = 1;
            lblBookedTotal.Text = "0";
            lblBookedTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAsOn
            // 
            lblAsOn.Anchor = AnchorStyles.Top;
            lblAsOn.AutoSize = true;
            lblAsOn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAsOn.Location = new Point(926, 34);
            lblAsOn.Name = "lblAsOn";
            lblAsOn.Size = new Size(39, 15);
            lblAsOn.TabIndex = 1;
            lblAsOn.Text = "Today";
            lblAsOn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDeluxeTotal
            // 
            lblDeluxeTotal.Anchor = AnchorStyles.Top;
            lblDeluxeTotal.AutoSize = true;
            lblDeluxeTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeluxeTotal.Location = new Point(440, 34);
            lblDeluxeTotal.Name = "lblDeluxeTotal";
            lblDeluxeTotal.Size = new Size(85, 15);
            lblDeluxeTotal.TabIndex = 1;
            lblDeluxeTotal.Text = "Booked 2 of 4";
            lblDeluxeTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(445, 9);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 1;
            label2.Text = "Deluxe Room";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 0;
            label1.Text = "All Rooms";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 960000;
            timer1.Tick += timer1_Tick;
            // 
            // frmBooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 548);
            Controls.Add(panelTop);
            Controls.Add(flowLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmBooking";
            Text = "Booking";
            Load += frmBooking_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelTop;
        private Label label1;
        private DateTimePicker dtpDate;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label lblDeluxeTotal;
        private Label lblStandardRoomCount;
        private Label lblDormatryCount;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        
        
        private Label lblBookedTotal;
        private Label lblAsOn;
        private Label lblAvailableTotal;
        private Label lblTotalRooms;
        private Button btnRefresh;
        private System.Windows.Forms.Timer timer1;
    }
}