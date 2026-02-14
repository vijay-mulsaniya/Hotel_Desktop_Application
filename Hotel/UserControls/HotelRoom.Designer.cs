namespace Hotel.UserControls
{
    partial class HotelRoom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblRoomNumber = new Label();
            lblRoomTitle = new Label();
            lblGuestName = new Label();
            lblCheckinDate = new Label();
            lblPendingAmount = new Label();
            lblCheckoutDate = new Label();
            lblNightCount = new Label();
            label5 = new Label();
            lblTotalAmount = new Label();
            lblPaidAmount = new Label();
            lblPersonCount = new Label();
            btnView = new Button();
            lblRoomId = new Label();
            SuspendLayout();
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.BackColor = Color.DarkGray;
            lblRoomNumber.Dock = DockStyle.Top;
            lblRoomNumber.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomNumber.Location = new Point(0, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(350, 54);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "402";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.BackColor = Color.LightGray;
            lblRoomTitle.Dock = DockStyle.Top;
            lblRoomTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRoomTitle.Location = new Point(0, 54);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(350, 37);
            lblRoomTitle.TabIndex = 1;
            lblRoomTitle.Text = "Super Deluxe";
            lblRoomTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGuestName
            // 
            lblGuestName.BackColor = Color.Silver;
            lblGuestName.Dock = DockStyle.Top;
            lblGuestName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblGuestName.Location = new Point(0, 91);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(350, 41);
            lblGuestName.TabIndex = 2;
            lblGuestName.Text = "Mr. Krishnakant Vadodariya";
            lblGuestName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCheckinDate
            // 
            lblCheckinDate.AutoSize = true;
            lblCheckinDate.BackColor = Color.DarkGray;
            lblCheckinDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCheckinDate.Location = new Point(9, 18);
            lblCheckinDate.Name = "lblCheckinDate";
            lblCheckinDate.Size = new Size(114, 17);
            lblCheckinDate.TabIndex = 3;
            lblCheckinDate.Text = "Mon, 19, Jan 2026";
            lblCheckinDate.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPendingAmount
            // 
            lblPendingAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPendingAmount.AutoSize = true;
            lblPendingAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPendingAmount.ForeColor = Color.Red;
            lblPendingAmount.Location = new Point(147, 217);
            lblPendingAmount.Name = "lblPendingAmount";
            lblPendingAmount.Size = new Size(46, 21);
            lblPendingAmount.TabIndex = 4;
            lblPendingAmount.Text = "4200";
            lblPendingAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCheckoutDate
            // 
            lblCheckoutDate.AutoSize = true;
            lblCheckoutDate.BackColor = Color.DarkGray;
            lblCheckoutDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCheckoutDate.Location = new Point(218, 18);
            lblCheckoutDate.Name = "lblCheckoutDate";
            lblCheckoutDate.Size = new Size(105, 17);
            lblCheckoutDate.TabIndex = 3;
            lblCheckoutDate.Text = "Sun, 25 Jan 2026";
            lblCheckoutDate.TextAlign = ContentAlignment.TopRight;
            // 
            // lblNightCount
            // 
            lblNightCount.AutoSize = true;
            lblNightCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblNightCount.Location = new Point(6, 196);
            lblNightCount.Name = "lblNightCount";
            lblNightCount.Size = new Size(38, 45);
            lblNightCount.TabIndex = 4;
            lblNightCount.Text = "6";
            lblNightCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(9, 179);
            label5.Name = "label5";
            label5.Size = new Size(46, 17);
            label5.TabIndex = 3;
            label5.Text = "Nights";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(61, 196);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(41, 19);
            lblTotalAmount.TabIndex = 4;
            lblTotalAmount.Text = "7200";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPaidAmount
            // 
            lblPaidAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPaidAmount.AutoSize = true;
            lblPaidAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPaidAmount.ForeColor = Color.LimeGreen;
            lblPaidAmount.Location = new Point(61, 217);
            lblPaidAmount.Name = "lblPaidAmount";
            lblPaidAmount.Size = new Size(47, 19);
            lblPaidAmount.TabIndex = 4;
            lblPaidAmount.Text = "-3000";
            lblPaidAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPersonCount
            // 
            lblPersonCount.AutoSize = true;
            lblPersonCount.BackColor = Color.White;
            lblPersonCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersonCount.Location = new Point(134, 132);
            lblPersonCount.Name = "lblPersonCount";
            lblPersonCount.Padding = new Padding(5);
            lblPersonCount.Size = new Size(73, 27);
            lblPersonCount.TabIndex = 3;
            lblPersonCount.Text = "A: 2, C: 1";
            lblPersonCount.TextAlign = ContentAlignment.TopRight;
            // 
            // btnView
            // 
            btnView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnView.Location = new Point(242, 207);
            btnView.Name = "btnView";
            btnView.Size = new Size(96, 34);
            btnView.TabIndex = 6;
            btnView.Text = "View Detail";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // lblRoomId
            // 
            lblRoomId.AutoSize = true;
            lblRoomId.Location = new Point(161, 171);
            lblRoomId.Name = "lblRoomId";
            lblRoomId.Size = new Size(22, 25);
            lblRoomId.TabIndex = 7;
            lblRoomId.Text = "0";
            lblRoomId.Visible = false;
            // 
            // HotelRoom
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblRoomId);
            Controls.Add(btnView);
            Controls.Add(lblPaidAmount);
            Controls.Add(lblTotalAmount);
            Controls.Add(lblPendingAmount);
            Controls.Add(lblCheckoutDate);
            Controls.Add(label5);
            Controls.Add(lblPersonCount);
            Controls.Add(lblCheckinDate);
            Controls.Add(lblGuestName);
            Controls.Add(lblRoomTitle);
            Controls.Add(lblRoomNumber);
            Controls.Add(lblNightCount);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(10);
            Name = "HotelRoom";
            Size = new Size(350, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomNumber;
        private Label lblRoomTitle;
        private Label lblGuestName;
       
       
        private Label lblCheckoutDate;
        private Label lblNightCount;
        private Label label5;
        private Label lblTotalAmount;
        private Label lblPaidAmount;
        private Label lblPersonCount;
        private Label lblPendingAmount;
        private Button btnView;
        private Label lblCheckinDate;
        private Label lblRoomId;
    }
}
