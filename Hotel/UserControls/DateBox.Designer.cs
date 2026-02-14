namespace Hotel.UserControls
{
    partial class DateBox
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
            lblDt = new Label();
            lblmonthYear = new Label();
            lblGuest = new Label();
            SuspendLayout();
            // 
            // lblDt
            // 
            lblDt.Dock = DockStyle.Top;
            lblDt.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDt.Location = new Point(0, 0);
            lblDt.Name = "lblDt";
            lblDt.Size = new Size(80, 40);
            lblDt.TabIndex = 0;
            lblDt.Text = "25";
            lblDt.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblmonthYear
            // 
            lblmonthYear.Dock = DockStyle.Top;
            lblmonthYear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblmonthYear.Location = new Point(0, 40);
            lblmonthYear.Name = "lblmonthYear";
            lblmonthYear.Size = new Size(80, 15);
            lblmonthYear.TabIndex = 1;
            lblmonthYear.Text = "label1";
            lblmonthYear.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblGuest
            // 
            lblGuest.AutoEllipsis = true;
            lblGuest.Dock = DockStyle.Bottom;
            lblGuest.Font = new Font("Segoe UI", 8F);
            lblGuest.ForeColor = SystemColors.ControlText;
            lblGuest.Location = new Point(0, 55);
            lblGuest.Name = "lblGuest";
            lblGuest.Size = new Size(80, 25);
            lblGuest.TabIndex = 2;
            lblGuest.Text = "Mr. Vijay Mulsaniya";
            lblGuest.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DateBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblGuest);
            Controls.Add(lblmonthYear);
            Controls.Add(lblDt);
            Name = "DateBox";
            Size = new Size(80, 80);
            ResumeLayout(false);
        }

        #endregion

        private Label lblDt;
        private Label lblmonthYear;
        private Label lblGuest;
    }
}
