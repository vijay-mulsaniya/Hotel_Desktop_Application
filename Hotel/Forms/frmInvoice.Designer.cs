namespace Hotel.Forms
{
    partial class frmInvoice
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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnSavePdf = new Button();
            btnPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(1, 58);
            webView21.Name = "webView21";
            webView21.Size = new Size(1016, 762);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // btnSavePdf
            // 
            btnSavePdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSavePdf.Location = new Point(766, 12);
            btnSavePdf.Name = "btnSavePdf";
            btnSavePdf.Size = new Size(111, 23);
            btnSavePdf.TabIndex = 1;
            btnSavePdf.Text = "Save PDF";
            btnSavePdf.UseVisualStyleBackColor = true;
            btnSavePdf.Click += btnSavePdf_Click;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrint.Location = new Point(883, 12);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(120, 23);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // frmInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 820);
            Controls.Add(btnPrint);
            Controls.Add(btnSavePdf);
            Controls.Add(webView21);
            Name = "frmInvoice";
            Text = "frmInvoice";
            Load += frmInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button btnSavePdf;
        private Button btnPrint;
    }
}