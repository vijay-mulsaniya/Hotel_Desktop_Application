namespace Hotel.UserControls
{
    partial class HotelRoomAvailable
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
            btnBookNow = new Button();
            label1 = new Label();
            lblCapacity = new Label();
            label3 = new Label();
            lblCharges = new Label();
            lblRoomId = new Label();
            SuspendLayout();
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomNumber.Location = new Point(137, 40);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(79, 65);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "A1";
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblRoomTitle.AutoSize = true;
            lblRoomTitle.Font = new Font("Segoe UI", 12F);
            lblRoomTitle.Location = new Point(117, 115);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(118, 21);
            lblRoomTitle.TabIndex = 1;
            lblRoomTitle.Text = "Standard Room";
            lblRoomTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBookNow
            // 
            btnBookNow.Location = new Point(117, 152);
            btnBookNow.Name = "btnBookNow";
            btnBookNow.Size = new Size(118, 37);
            btnBookNow.TabIndex = 2;
            btnBookNow.Text = "Book Now";
            btnBookNow.UseVisualStyleBackColor = true;
            btnBookNow.Click += btnBookNow_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 216);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 3;
            label1.Text = "Capicity:";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCapacity.Location = new Point(73, 218);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(14, 15);
            lblCapacity.TabIndex = 3;
            lblCapacity.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(251, 216);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 3;
            label3.Text = "Rate:";
            // 
            // lblCharges
            // 
            lblCharges.AutoSize = true;
            lblCharges.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCharges.Location = new Point(295, 217);
            lblCharges.Name = "lblCharges";
            lblCharges.Size = new Size(31, 15);
            lblCharges.TabIndex = 3;
            lblCharges.Text = "0.00";
            // 
            // lblRoomId
            // 
            lblRoomId.AutoSize = true;
            lblRoomId.Location = new Point(266, 53);
            lblRoomId.Name = "lblRoomId";
            lblRoomId.Size = new Size(13, 15);
            lblRoomId.TabIndex = 4;
            lblRoomId.Text = "0";
            lblRoomId.Visible = false;
            // 
            // HotelRoomAvailable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblRoomId);
            Controls.Add(lblCharges);
            Controls.Add(label3);
            Controls.Add(lblCapacity);
            Controls.Add(label1);
            Controls.Add(btnBookNow);
            Controls.Add(lblRoomTitle);
            Controls.Add(lblRoomNumber);
            Margin = new Padding(10);
            Name = "HotelRoomAvailable";
            Size = new Size(348, 248);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomNumber;
        private Label lblRoomTitle;
        private Button btnBookNow;
        private Label label1;
        private Label lblCapacity;
        private Label label3;
        private Label lblCharges;
        private Label lblRoomId;
    }
}
