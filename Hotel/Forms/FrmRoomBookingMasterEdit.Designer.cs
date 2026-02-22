namespace Hotel.Forms
{
    partial class FrmRoomBookingMasterEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoomBookingMasterEdit));
            label1 = new Label();
            cmbGuestList = new ComboBox();
            lblGuest = new Label();
            lblDiscount = new Label();
            txtDiscount = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtpInvoiceDate = new DateTimePicker();
            label6 = new Label();
            txtInvoiceNumber = new TextBox();
            label7 = new Label();
            cmbGuestState = new ComboBox();
            btnSave = new Button();
            lblGuestName = new Label();
            chkTaxApply = new CheckBox();
            chkInputTaxCredit = new CheckBox();
            chkIsTaxInclusive = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.DarkMagenta;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(464, 53);
            label1.TabIndex = 0;
            label1.Text = "Invoice Edit";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbGuestList
            // 
            cmbGuestList.FormattingEnabled = true;
            cmbGuestList.Location = new Point(153, 187);
            cmbGuestList.Name = "cmbGuestList";
            cmbGuestList.Size = new Size(270, 23);
            cmbGuestList.TabIndex = 2;
            cmbGuestList.SelectedIndexChanged += cmbGuestList_SelectedIndexChanged;
            // 
            // lblGuest
            // 
            lblGuest.AutoSize = true;
            lblGuest.Location = new Point(25, 190);
            lblGuest.Name = "lblGuest";
            lblGuest.Size = new Size(99, 15);
            lblGuest.TabIndex = 2;
            lblGuest.Text = "Guest New Name";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(25, 229);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(54, 15);
            lblDiscount.TabIndex = 3;
            lblDiscount.Text = "Discount";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(153, 226);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(270, 23);
            txtDiscount.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 292);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 3;
            label2.Text = "GST Calculate";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 335);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 3;
            label3.Text = "Input Tax Credit";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 378);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 3;
            label4.Text = "Tax Inxclusive";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 151);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 3;
            label5.Text = "Invoice Date";
            // 
            // dtpInvoiceDate
            // 
            dtpInvoiceDate.Location = new Point(153, 148);
            dtpInvoiceDate.Name = "dtpInvoiceDate";
            dtpInvoiceDate.Size = new Size(270, 23);
            dtpInvoiceDate.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 112);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 3;
            label6.Text = "Invoice Number";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(153, 109);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(270, 23);
            txtInvoiceNumber.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 423);
            label7.Name = "label7";
            label7.Size = new Size(66, 15);
            label7.TabIndex = 3;
            label7.Text = "Guest State";
            // 
            // cmbGuestState
            // 
            cmbGuestState.FormattingEnabled = true;
            cmbGuestState.Location = new Point(153, 420);
            cmbGuestState.Name = "cmbGuestState";
            cmbGuestState.Size = new Size(270, 23);
            cmbGuestState.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(153, 489);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(270, 27);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuestName.Location = new Point(22, 72);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(83, 17);
            lblGuestName.TabIndex = 3;
            lblGuestName.Text = "Guest Name";
            // 
            // chkTaxApply
            // 
            chkTaxApply.AutoSize = true;
            chkTaxApply.Location = new Point(153, 291);
            chkTaxApply.Name = "chkTaxApply";
            chkTaxApply.Size = new Size(43, 19);
            chkTaxApply.TabIndex = 4;
            chkTaxApply.Text = "Yes";
            chkTaxApply.UseVisualStyleBackColor = true;
            chkTaxApply.CheckedChanged += chkTaxApply_CheckedChanged;
            // 
            // chkInputTaxCredit
            // 
            chkInputTaxCredit.AutoSize = true;
            chkInputTaxCredit.Location = new Point(153, 334);
            chkInputTaxCredit.Name = "chkInputTaxCredit";
            chkInputTaxCredit.Size = new Size(43, 19);
            chkInputTaxCredit.TabIndex = 5;
            chkInputTaxCredit.Text = "Yes";
            chkInputTaxCredit.UseVisualStyleBackColor = true;
            chkInputTaxCredit.CheckedChanged += chkInputTaxCredit_CheckedChanged;
            // 
            // chkIsTaxInclusive
            // 
            chkIsTaxInclusive.AutoSize = true;
            chkIsTaxInclusive.Location = new Point(153, 377);
            chkIsTaxInclusive.Name = "chkIsTaxInclusive";
            chkIsTaxInclusive.Size = new Size(43, 19);
            chkIsTaxInclusive.TabIndex = 6;
            chkIsTaxInclusive.Text = "Yes";
            chkIsTaxInclusive.UseVisualStyleBackColor = true;
            chkIsTaxInclusive.CheckedChanged += chkIsTaxInclusive_CheckedChanged;
            // 
            // FrmRoomBookingMasterEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 549);
            Controls.Add(chkIsTaxInclusive);
            Controls.Add(chkInputTaxCredit);
            Controls.Add(chkTaxApply);
            Controls.Add(btnSave);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(dtpInvoiceDate);
            Controls.Add(lblGuestName);
            Controls.Add(txtDiscount);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblDiscount);
            Controls.Add(lblGuest);
            Controls.Add(cmbGuestState);
            Controls.Add(cmbGuestList);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRoomBookingMasterEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Invoice Edit";
            Load += FrmRoomBookingMasterEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbGuestList;
        private Label lblGuest;
        private Label lblDiscount;
        private TextBox txtDiscount;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpInvoiceDate;
        private Label label6;
        private Label label7;
        private ComboBox cmbGuestState;
        private Button btnSave;
        private Label lblGuestName;
        private CheckBox chkTaxApply;
        private CheckBox chkInputTaxCredit;
        private CheckBox chkIsTaxInclusive;
        private TextBox txtInvoiceNumber;

    }
}