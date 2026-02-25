namespace Hotel.Forms
{
    partial class FrmRoomBookingEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoomBookingEdit));
            label1 = new Label();
            lblGuestName = new Label();
            label2 = new Label();
            cmbRoomNumbers = new ComboBox();
            label3 = new Label();
            dtpDate = new DateTimePicker();
            label5 = new Label();
            chkNightStay = new CheckBox();
            lblAdult = new Label();
            txtAdultCount = new TextBox();
            lblChild = new Label();
            txtChildCount = new TextBox();
            label6 = new Label();
            txtAmount = new TextBox();
            btnSave = new Button();
            grpEditDay = new GroupBox();
            grpAddNewDay = new GroupBox();
            btnAddNewDates = new Button();
            lblGuestExtend = new Label();
            txtChildExtend = new TextBox();
            txtAdultsExtend = new TextBox();
            txtPerNightCharge = new TextBox();
            dtpToDate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            cmbRoomNumbersExtend = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label4 = new Label();
            label7 = new Label();
            grpEditDay.SuspendLayout();
            grpAddNewDay.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(-2, 0);
            label1.Name = "label1";
            label1.Size = new Size(917, 60);
            label1.TabIndex = 0;
            label1.Text = "Edit Booking";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuestName.Location = new Point(32, 34);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(103, 21);
            lblGuestName.TabIndex = 1;
            lblGuestName.Text = "Guest Name";
            lblGuestName.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 116);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Room Number";
            // 
            // cmbRoomNumbers
            // 
            cmbRoomNumbers.FormattingEnabled = true;
            cmbRoomNumbers.Location = new Point(124, 113);
            cmbRoomNumbers.Name = "cmbRoomNumbers";
            cmbRoomNumbers.Size = new Size(200, 23);
            cmbRoomNumbers.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 81);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 2;
            label3.Text = "Booked Date";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(124, 75);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 153);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 6;
            label5.Text = "Night Stay";
            // 
            // chkNightStay
            // 
            chkNightStay.AutoSize = true;
            chkNightStay.Checked = true;
            chkNightStay.CheckState = CheckState.Checked;
            chkNightStay.Location = new Point(124, 154);
            chkNightStay.Name = "chkNightStay";
            chkNightStay.Size = new Size(43, 19);
            chkNightStay.TabIndex = 7;
            chkNightStay.Text = "Yes";
            chkNightStay.UseVisualStyleBackColor = true;
            chkNightStay.CheckedChanged += chkNightStay_CheckedChanged;
            // 
            // lblAdult
            // 
            lblAdult.AutoSize = true;
            lblAdult.Location = new Point(34, 194);
            lblAdult.Name = "lblAdult";
            lblAdult.Size = new Size(36, 15);
            lblAdult.TabIndex = 8;
            lblAdult.Text = "Adult";
            // 
            // txtAdultCount
            // 
            txtAdultCount.Location = new Point(126, 191);
            txtAdultCount.Name = "txtAdultCount";
            txtAdultCount.Size = new Size(200, 23);
            txtAdultCount.TabIndex = 9;
            txtAdultCount.KeyPress += txtAdultCount_KeyPress;
            // 
            // lblChild
            // 
            lblChild.AutoSize = true;
            lblChild.Location = new Point(34, 234);
            lblChild.Name = "lblChild";
            lblChild.Size = new Size(35, 15);
            lblChild.TabIndex = 10;
            lblChild.Text = "Child";
            // 
            // txtChildCount
            // 
            txtChildCount.Location = new Point(126, 231);
            txtChildCount.Name = "txtChildCount";
            txtChildCount.Size = new Size(200, 23);
            txtChildCount.TabIndex = 11;
            txtChildCount.Leave += txtChildCount_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 276);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 12;
            label6.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(126, 273);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(200, 25);
            txtAmount.TabIndex = 13;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(126, 317);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 30);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // grpEditDay
            // 
            grpEditDay.Controls.Add(btnSave);
            grpEditDay.Controls.Add(txtAmount);
            grpEditDay.Controls.Add(txtChildCount);
            grpEditDay.Controls.Add(txtAdultCount);
            grpEditDay.Controls.Add(chkNightStay);
            grpEditDay.Controls.Add(dtpDate);
            grpEditDay.Controls.Add(cmbRoomNumbers);
            grpEditDay.Controls.Add(label3);
            grpEditDay.Controls.Add(label6);
            grpEditDay.Controls.Add(lblChild);
            grpEditDay.Controls.Add(lblAdult);
            grpEditDay.Controls.Add(label5);
            grpEditDay.Controls.Add(label2);
            grpEditDay.Controls.Add(lblGuestName);
            grpEditDay.Location = new Point(20, 77);
            grpEditDay.Name = "grpEditDay";
            grpEditDay.Size = new Size(371, 369);
            grpEditDay.TabIndex = 1;
            grpEditDay.TabStop = false;
            grpEditDay.Text = "Edit One Day";
            // 
            // grpAddNewDay
            // 
            grpAddNewDay.Controls.Add(btnAddNewDates);
            grpAddNewDay.Controls.Add(lblGuestExtend);
            grpAddNewDay.Controls.Add(txtChildExtend);
            grpAddNewDay.Controls.Add(txtAdultsExtend);
            grpAddNewDay.Controls.Add(txtPerNightCharge);
            grpAddNewDay.Controls.Add(dtpToDate);
            grpAddNewDay.Controls.Add(dtpFromDate);
            grpAddNewDay.Controls.Add(cmbRoomNumbersExtend);
            grpAddNewDay.Controls.Add(label9);
            grpAddNewDay.Controls.Add(label8);
            grpAddNewDay.Controls.Add(label4);
            grpAddNewDay.Controls.Add(label7);
            grpAddNewDay.Location = new Point(412, 77);
            grpAddNewDay.Name = "grpAddNewDay";
            grpAddNewDay.Size = new Size(485, 369);
            grpAddNewDay.TabIndex = 2;
            grpAddNewDay.TabStop = false;
            grpAddNewDay.Text = "Extend Days";
            // 
            // btnAddNewDates
            // 
            btnAddNewDates.Location = new Point(117, 233);
            btnAddNewDates.Name = "btnAddNewDates";
            btnAddNewDates.Size = new Size(330, 32);
            btnAddNewDates.TabIndex = 13;
            btnAddNewDates.Text = "Save New Dates";
            btnAddNewDates.UseVisualStyleBackColor = true;
            btnAddNewDates.Click += btnAddNewDates_Click;
            // 
            // lblGuestExtend
            // 
            lblGuestExtend.AutoSize = true;
            lblGuestExtend.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuestExtend.Location = new Point(23, 34);
            lblGuestExtend.Name = "lblGuestExtend";
            lblGuestExtend.Size = new Size(103, 21);
            lblGuestExtend.TabIndex = 1;
            lblGuestExtend.Text = "Guest Name";
            lblGuestExtend.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtChildExtend
            // 
            txtChildExtend.Location = new Point(310, 153);
            txtChildExtend.Name = "txtChildExtend";
            txtChildExtend.Size = new Size(137, 23);
            txtChildExtend.TabIndex = 7;
            // 
            // txtAdultsExtend
            // 
            txtAdultsExtend.Location = new Point(115, 153);
            txtAdultsExtend.Name = "txtAdultsExtend";
            txtAdultsExtend.Size = new Size(108, 23);
            txtAdultsExtend.TabIndex = 5;
            // 
            // txtPerNightCharge
            // 
            txtPerNightCharge.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPerNightCharge.Location = new Point(115, 191);
            txtPerNightCharge.Name = "txtPerNightCharge";
            txtPerNightCharge.Size = new Size(332, 25);
            txtPerNightCharge.TabIndex = 8;
            txtPerNightCharge.KeyPress += txtPerNightCharge_KeyPress;
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(247, 73);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(200, 23);
            dtpToDate.TabIndex = 1;
            dtpToDate.Leave += dtpToDate_Leave;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(23, 73);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(200, 23);
            dtpFromDate.TabIndex = 0;
            dtpFromDate.Leave += dtpFromDate_Leave;
            // 
            // cmbRoomNumbersExtend
            // 
            cmbRoomNumbersExtend.FormattingEnabled = true;
            cmbRoomNumbersExtend.Location = new Point(115, 116);
            cmbRoomNumbersExtend.Name = "cmbRoomNumbersExtend";
            cmbRoomNumbersExtend.Size = new Size(332, 23);
            cmbRoomNumbersExtend.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(247, 157);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 6;
            label9.Text = "Childs";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 157);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 4;
            label8.Text = "Adults";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 121);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 2;
            label4.Text = "Room Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 194);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 12;
            label7.Text = "Night Charge";
            // 
            // FrmRoomBookingEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 466);
            Controls.Add(grpAddNewDay);
            Controls.Add(grpEditDay);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRoomBookingEdit";
            Text = "Edit Booking";
            Load += FrmRoomBookingEdit_Load;
            grpEditDay.ResumeLayout(false);
            grpEditDay.PerformLayout();
            grpAddNewDay.ResumeLayout(false);
            grpAddNewDay.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label lblGuestName;
        private Label label2;
        private ComboBox cmbRoomNumbers;
        private Label label3;
        private DateTimePicker dtpDate;
        private Label label5;
        private CheckBox chkNightStay;
        private Label lblAdult;
        private TextBox txtAdultCount;
        private Label lblChild;
        private TextBox txtChildCount;
        private Label label6;
        private TextBox txtAmount;
        private Button btnSave;
        private GroupBox grpEditDay;
        private GroupBox grpAddNewDay;
        private Label lblGuestExtend;
        private DateTimePicker dtpToDate;
        private DateTimePicker dtpFromDate;
        private ComboBox cmbRoomNumbersExtend;
        private Label label4;
        private TextBox txtPerNightCharge;
        private Label label7;
        private TextBox txtAdultsExtend;
        private Label label9;
        private Label label8;
        private Button btnAddNewDates;
        private TextBox txtChildExtend;
    }
}