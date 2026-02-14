namespace Hotel.UserControls
{
    partial class RoomBox
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
            SuspendLayout();
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomNumber.Location = new Point(13, 9);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(74, 17);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "RoomNum";
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.AutoSize = true;
            lblRoomTitle.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomTitle.Location = new Point(13, 27);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(32, 17);
            lblRoomTitle.TabIndex = 0;
            lblRoomTitle.Text = "Title";
            // 
            // DateViewBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblRoomTitle);
            Controls.Add(lblRoomNumber);
            Name = "DateViewBox";
            Size = new Size(167, 80);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomNumber;
        private Label lblRoomTitle;
    }
}
