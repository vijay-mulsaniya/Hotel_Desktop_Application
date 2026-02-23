namespace Hotel.Forms
{
    partial class FrmPaymentEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentEdit));
            lblFormTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpPaymentDate = new DateTimePicker();
            cmbPaymentMethods = new ComboBox();
            txtOnlineRefNumber = new TextBox();
            txtAmountPaid = new TextBox();
            btnSave = new Button();
            label5 = new Label();
            cmbRoom = new ComboBox();
            SuspendLayout();
            // 
            // lblFormTitle
            // 
            lblFormTitle.BackColor = Color.DarkRed;
            lblFormTitle.Dock = DockStyle.Top;
            lblFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = SystemColors.Control;
            lblFormTitle.Location = new Point(0, 0);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(429, 51);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Edit Payments";
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 113);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 1;
            label1.Text = "Payment Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 150);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 1;
            label2.Text = "Payment Method";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 224);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 1;
            label3.Text = "Amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 187);
            label4.Name = "label4";
            label4.Size = new Size(109, 15);
            label4.TabIndex = 1;
            label4.Text = "Online Ref Number";
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Location = new Point(195, 110);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(200, 23);
            dtpPaymentDate.TabIndex = 1;
            // 
            // cmbPaymentMethods
            // 
            cmbPaymentMethods.FormattingEnabled = true;
            cmbPaymentMethods.Location = new Point(195, 147);
            cmbPaymentMethods.Name = "cmbPaymentMethods";
            cmbPaymentMethods.Size = new Size(200, 23);
            cmbPaymentMethods.TabIndex = 2;
            // 
            // txtOnlineRefNumber
            // 
            txtOnlineRefNumber.Location = new Point(195, 184);
            txtOnlineRefNumber.Name = "txtOnlineRefNumber";
            txtOnlineRefNumber.Size = new Size(200, 23);
            txtOnlineRefNumber.TabIndex = 3;
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmountPaid.Location = new Point(195, 221);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(200, 23);
            txtAmountPaid.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(196, 266);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(199, 33);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 73);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 1;
            label5.Text = "Room";
            // 
            // cmbRoom
            // 
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(195, 70);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(200, 23);
            cmbRoom.TabIndex = 0;
            // 
            // FrmPaymentEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 325);
            Controls.Add(btnSave);
            Controls.Add(txtAmountPaid);
            Controls.Add(txtOnlineRefNumber);
            Controls.Add(cmbRoom);
            Controls.Add(cmbPaymentMethods);
            Controls.Add(dtpPaymentDate);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(lblFormTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmPaymentEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment Edit";
            Load += FrmPaymentEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFormTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpPaymentDate;
        private ComboBox cmbPaymentMethods;
        private TextBox txtOnlineRefNumber;
        private TextBox txtAmountPaid;
        private Button btnSave;
        private Label label5;
        private ComboBox cmbRoom;
    }
}