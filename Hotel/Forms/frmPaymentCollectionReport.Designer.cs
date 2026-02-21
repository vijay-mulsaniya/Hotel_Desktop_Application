namespace Hotel.Forms
{
    partial class frmPaymentCollectionReport
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
            dtpMonthYear = new DateTimePicker();
            btnShow = new Button();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // dtpMonthYear
            // 
            dtpMonthYear.Location = new Point(577, 21);
            dtpMonthYear.Name = "dtpMonthYear";
            dtpMonthYear.Size = new Size(200, 23);
            dtpMonthYear.TabIndex = 0;
            dtpMonthYear.Value = new DateTime(2026, 2, 1, 0, 0, 0, 0);
            // 
            // btnShow
            // 
            btnShow.Location = new Point(795, 21);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(123, 23);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show Report";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(12, 70);
            webView21.Name = "webView21";
            webView21.Size = new Size(1170, 491);
            webView21.TabIndex = 2;
            webView21.ZoomFactor = 1D;
            // 
            // frmPaymentCollectionReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 573);
            Controls.Add(webView21);
            Controls.Add(btnShow);
            Controls.Add(dtpMonthYear);
            Name = "frmPaymentCollectionReport";
            Text = "frmPaymentCollectionReport";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpMonthYear;
        private Button btnShow;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}