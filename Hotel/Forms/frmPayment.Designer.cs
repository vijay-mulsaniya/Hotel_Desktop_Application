namespace Hotel.Forms
{
    partial class frmPayment
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
            pictureBox1 = new PictureBox();
            lblFormTitle = new Label();
            grdBilling = new DataGridView();
            splitContainer1 = new SplitContainer();
            btnShowInvoice = new Button();
            txtSearch = new TextBox();
            groupBoxPayment = new GroupBox();
            cmbRoomNumber = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label9 = new Label();
            label2 = new Label();
            lblPendingAmount = new Label();
            btnAddPayment = new Button();
            label6 = new Label();
            cmbPaymentMethod = new ComboBox();
            lblPaidAmount = new Label();
            txtOnlineRefNumber = new TextBox();
            label5 = new Label();
            txtAmount = new TextBox();
            lblInvoiceNumber = new Label();
            lblGuestName = new Label();
            lblAmount_ = new Label();
            lblTotalAmount = new Label();
            label1 = new Label();
            grdPaymentDetail = new DataGridView();
            label8 = new Label();
            label7 = new Label();
            gridRoomDetail = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdBilling).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPaymentDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridRoomDetail).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.LightSeaGreen;
            panelTop.Controls.Add(pictureBox1);
            panelTop.Controls.Add(lblFormTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1675, 58);
            panelTop.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Money1;
            pictureBox1.Location = new Point(4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.Location = new Point(58, 18);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(209, 25);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Invoice And Payments";
            // 
            // grdBilling
            // 
            grdBilling.AllowUserToAddRows = false;
            grdBilling.AllowUserToDeleteRows = false;
            grdBilling.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grdBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdBilling.Location = new Point(12, 44);
            grdBilling.Name = "grdBilling";
            grdBilling.ReadOnly = true;
            grdBilling.Size = new Size(1001, 196);
            grdBilling.TabIndex = 1;
            grdBilling.CellContentClick += grdBilling_CellContentClick;
            grdBilling.SelectionChanged += grdBilling_SelectionChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 58);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnShowInvoice);
            splitContainer1.Panel1.Controls.Add(txtSearch);
            splitContainer1.Panel1.Controls.Add(grdBilling);
            splitContainer1.Panel1.Controls.Add(groupBoxPayment);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grdPaymentDetail);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(gridRoomDetail);
            splitContainer1.Size = new Size(1675, 787);
            splitContainer1.SplitterDistance = 260;
            splitContainer1.TabIndex = 4;
            // 
            // btnShowInvoice
            // 
            btnShowInvoice.Location = new Point(850, 12);
            btnShowInvoice.Name = "btnShowInvoice";
            btnShowInvoice.Size = new Size(163, 23);
            btnShowInvoice.TabIndex = 6;
            btnShowInvoice.Text = "Show Invoice";
            btnShowInvoice.UseVisualStyleBackColor = true;
            btnShowInvoice.Click += btnShowInvoice_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(60, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(270, 23);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // groupBoxPayment
            // 
            groupBoxPayment.Controls.Add(cmbRoomNumber);
            groupBoxPayment.Controls.Add(label4);
            groupBoxPayment.Controls.Add(label3);
            groupBoxPayment.Controls.Add(label9);
            groupBoxPayment.Controls.Add(label2);
            groupBoxPayment.Controls.Add(lblPendingAmount);
            groupBoxPayment.Controls.Add(btnAddPayment);
            groupBoxPayment.Controls.Add(label6);
            groupBoxPayment.Controls.Add(cmbPaymentMethod);
            groupBoxPayment.Controls.Add(lblPaidAmount);
            groupBoxPayment.Controls.Add(txtOnlineRefNumber);
            groupBoxPayment.Controls.Add(label5);
            groupBoxPayment.Controls.Add(txtAmount);
            groupBoxPayment.Controls.Add(lblInvoiceNumber);
            groupBoxPayment.Controls.Add(lblGuestName);
            groupBoxPayment.Controls.Add(lblAmount_);
            groupBoxPayment.Controls.Add(lblTotalAmount);
            groupBoxPayment.Location = new Point(1019, 45);
            groupBoxPayment.Name = "groupBoxPayment";
            groupBoxPayment.Size = new Size(644, 192);
            groupBoxPayment.TabIndex = 2;
            groupBoxPayment.TabStop = false;
            groupBoxPayment.Text = "Add Payment";
            // 
            // cmbRoomNumber
            // 
            cmbRoomNumber.FormattingEnabled = true;
            cmbRoomNumber.Location = new Point(129, 18);
            cmbRoomNumber.Name = "cmbRoomNumber";
            cmbRoomNumber.Size = new Size(224, 23);
            cmbRoomNumber.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 124);
            label4.Name = "label4";
            label4.Size = new Size(109, 15);
            label4.TabIndex = 4;
            label4.Text = "Online Ref Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 90);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 4;
            label3.Text = "Payment Method";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(61, 22);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 4;
            label9.Text = "Room No";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 56);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Amount";
            // 
            // lblPendingAmount
            // 
            lblPendingAmount.AutoSize = true;
            lblPendingAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPendingAmount.Location = new Point(456, 145);
            lblPendingAmount.Name = "lblPendingAmount";
            lblPendingAmount.Size = new Size(14, 15);
            lblPendingAmount.TabIndex = 4;
            lblPendingAmount.Text = "0";
            // 
            // btnAddPayment
            // 
            btnAddPayment.Location = new Point(128, 154);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(225, 27);
            btnAddPayment.TabIndex = 3;
            btnAddPayment.Text = "Add Payment";
            btnAddPayment.UseVisualStyleBackColor = true;
            btnAddPayment.Click += btnAddPayment_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(395, 145);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 4;
            label6.Text = "Pending";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Online Transfer", "Credit Card", "Debit Card" });
            cmbPaymentMethod.Location = new Point(129, 86);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(225, 23);
            cmbPaymentMethod.TabIndex = 1;
            // 
            // lblPaidAmount
            // 
            lblPaidAmount.AutoSize = true;
            lblPaidAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPaidAmount.Location = new Point(456, 116);
            lblPaidAmount.Name = "lblPaidAmount";
            lblPaidAmount.Size = new Size(14, 15);
            lblPaidAmount.TabIndex = 4;
            lblPaidAmount.Text = "0";
            // 
            // txtOnlineRefNumber
            // 
            txtOnlineRefNumber.Location = new Point(128, 120);
            txtOnlineRefNumber.Name = "txtOnlineRefNumber";
            txtOnlineRefNumber.Size = new Size(225, 23);
            txtOnlineRefNumber.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(416, 116);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 4;
            label5.Text = "Paid";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(128, 52);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(225, 23);
            txtAmount.TabIndex = 0;
            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.AutoSize = true;
            lblInvoiceNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInvoiceNumber.Location = new Point(366, 26);
            lblInvoiceNumber.Name = "lblInvoiceNumber";
            lblInvoiceNumber.Size = new Size(97, 15);
            lblInvoiceNumber.TabIndex = 4;
            lblInvoiceNumber.Text = "Invoice Number";
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGuestName.Location = new Point(366, 58);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(40, 15);
            lblGuestName.TabIndex = 4;
            lblGuestName.Text = "Name";
            // 
            // lblAmount_
            // 
            lblAmount_.AutoSize = true;
            lblAmount_.Location = new Point(366, 87);
            lblAmount_.Name = "lblAmount_";
            lblAmount_.Size = new Size(80, 15);
            lblAmount_.TabIndex = 4;
            lblAmount_.Text = "Total Amount";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(456, 87);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(14, 15);
            lblTotalAmount.TabIndex = 4;
            lblTotalAmount.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Search";
            // 
            // grdPaymentDetail
            // 
            grdPaymentDetail.AllowUserToAddRows = false;
            grdPaymentDetail.AllowUserToDeleteRows = false;
            grdPaymentDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdPaymentDetail.Location = new Point(873, 26);
            grdPaymentDetail.Name = "grdPaymentDetail";
            grdPaymentDetail.ReadOnly = true;
            grdPaymentDetail.Size = new Size(790, 485);
            grdPaymentDetail.TabIndex = 2;
            grdPaymentDetail.CellContentClick += grdPaymentDetail_CellContentClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(877, 8);
            label8.Name = "label8";
            label8.Size = new Size(109, 15);
            label8.TabIndex = 1;
            label8.Text = "Payments Received";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 6);
            label7.Name = "label7";
            label7.Size = new Size(124, 15);
            label7.TabIndex = 1;
            label7.Text = "Room Booking Details";
            // 
            // gridRoomDetail
            // 
            gridRoomDetail.AllowUserToAddRows = false;
            gridRoomDetail.AllowUserToDeleteRows = false;
            gridRoomDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRoomDetail.Location = new Point(12, 26);
            gridRoomDetail.Name = "gridRoomDetail";
            gridRoomDetail.ReadOnly = true;
            gridRoomDetail.Size = new Size(855, 485);
            gridRoomDetail.TabIndex = 0;
            // 
            // frmPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1675, 845);
            Controls.Add(splitContainer1);
            Controls.Add(panelTop);
            Name = "frmPayment";
            Text = "Payments";
            Load += frmPayment_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdBilling).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxPayment.ResumeLayout(false);
            groupBoxPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdPaymentDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridRoomDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblFormTitle;
        private DataGridView grdBilling;
      
        private TextBox txtAmount;
       
        private Button btnAddPayment;
        private ComboBox cmbPaymentMethod;

        private SplitContainer splitContainer1;
        private GroupBox groupBoxPayment;
        
        private TextBox txtSearch;
        private Label label1;
        
        private TextBox txtOnlineRefNumber;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label lblAmount_;
        private Label label6;
        private Label lblPendingAmount;
        private Label lblPaidAmount;
        private Label lblGuestName;
        private Label lblTotalAmount;
        private Label label7;
        private DataGridView gridRoomDetail;
        private DataGridView grdPaymentDetail;
        private Label label8;
        private ComboBox cmbRoomNumber;
        private Label label9;
        private Label lblInvoiceNumber;
        private Button btnShowInvoice;
        private PictureBox pictureBox1;
    }
}