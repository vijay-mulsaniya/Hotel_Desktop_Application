namespace Hotel.Forms
{
    partial class frmGuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuest));
            dgvBooking = new DataGridView();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            btnGuestSave = new Button();
            label13 = new Label();
            label6 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtCountry = new TextBox();
            txtPhone2 = new TextBox();
            txtState = new TextBox();
            txtArea = new TextBox();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            txtEmail = new TextBox();
            txtGuestName = new TextBox();
            txtMobileNumber = new TextBox();
            panelTop = new Panel();
            label1 = new Label();
            picIDBox = new PictureBox();
            groupBox2 = new GroupBox();
            btnCapture = new Button();
            btnStartCam = new Button();
            cmbCameras = new ComboBox();
            btnIDSave = new Button();
            btnUploadID = new Button();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label19 = new Label();
            label20 = new Label();
            txtIDCountry = new TextBox();
            txtIDState = new TextBox();
            txtIssueDate = new TextBox();
            txtExpiryDate = new TextBox();
            txtProofNumber = new TextBox();
            txtProofType = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvBooking).BeginInit();
            groupBox1.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIDBox).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBooking
            // 
            dgvBooking.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvBooking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooking.Location = new Point(6, 420);
            dgvBooking.Name = "dgvBooking";
            dgvBooking.Size = new Size(1158, 239);
            dgvBooking.TabIndex = 13;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(btnGuestSave);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCountry);
            groupBox1.Controls.Add(txtPhone2);
            groupBox1.Controls.Add(txtState);
            groupBox1.Controls.Add(txtArea);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(txtCity);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtGuestName);
            groupBox1.Controls.Add(txtMobileNumber);
            groupBox1.Location = new Point(6, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(589, 343);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Guest Information";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(511, 31);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(55, 19);
            radioButton3.TabIndex = 3;
            radioButton3.Text = "Other";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(427, 31);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 19);
            radioButton2.TabIndex = 2;
            radioButton2.Text = "Female";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(359, 30);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(51, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Male";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnGuestSave
            // 
            btnGuestSave.Location = new Point(139, 288);
            btnGuestSave.Name = "btnGuestSave";
            btnGuestSave.Size = new Size(169, 28);
            btnGuestSave.TabIndex = 12;
            btnGuestSave.Text = "Save";
            btnGuestSave.UseVisualStyleBackColor = true;
            btnGuestSave.Click += btnGuestSave_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(75, 245);
            label13.Name = "label13";
            label13.Size = new Size(50, 15);
            label13.TabIndex = 1;
            label13.Text = "Country";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(333, 250);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 1;
            label6.Text = "Phone - 2";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(358, 209);
            label12.Name = "label12";
            label12.Size = new Size(33, 15);
            label12.TabIndex = 1;
            label12.Text = "State";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(94, 206);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 1;
            label11.Text = "City";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(91, 172);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 1;
            label10.Text = "Area";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(73, 138);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 1;
            label5.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 99);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 1;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 63);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 1;
            label3.Text = "Guest Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 30);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "Mobile Number";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(139, 242);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(169, 23);
            txtCountry.TabIndex = 10;
            txtCountry.Text = "India";
            // 
            // txtPhone2
            // 
            txtPhone2.AutoCompleteCustomSource.AddRange(new string[] { "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal" });
            txtPhone2.Location = new Point(397, 242);
            txtPhone2.Name = "txtPhone2";
            txtPhone2.Size = new Size(169, 23);
            txtPhone2.TabIndex = 11;
            // 
            // txtState
            // 
            txtState.AutoCompleteCustomSource.AddRange(new string[] { "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal" });
            txtState.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtState.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtState.Location = new Point(397, 206);
            txtState.Name = "txtState";
            txtState.Size = new Size(169, 23);
            txtState.TabIndex = 9;
            // 
            // txtArea
            // 
            txtArea.Location = new Point(139, 169);
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(169, 23);
            txtArea.TabIndex = 7;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(139, 135);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(427, 23);
            txtAddress.TabIndex = 6;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(139, 203);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(169, 23);
            txtCity.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(139, 99);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(427, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtGuestName
            // 
            txtGuestName.Location = new Point(139, 60);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(427, 23);
            txtGuestName.TabIndex = 4;
            // 
            // txtMobileNumber
            // 
            txtMobileNumber.Location = new Point(139, 27);
            txtMobileNumber.Name = "txtMobileNumber";
            txtMobileNumber.Size = new Size(169, 23);
            txtMobileNumber.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1172, 58);
            panelTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(241, 25);
            label1.TabIndex = 0;
            label1.Text = "Guest And Id Information";
            // 
            // picIDBox
            // 
            picIDBox.Location = new Point(632, 246);
            picIDBox.Name = "picIDBox";
            picIDBox.Size = new Size(249, 152);
            picIDBox.TabIndex = 15;
            picIDBox.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCapture);
            groupBox2.Controls.Add(btnStartCam);
            groupBox2.Controls.Add(cmbCameras);
            groupBox2.Controls.Add(btnIDSave);
            groupBox2.Controls.Add(btnUploadID);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(txtIDCountry);
            groupBox2.Controls.Add(txtIDState);
            groupBox2.Controls.Add(txtIssueDate);
            groupBox2.Controls.Add(txtExpiryDate);
            groupBox2.Controls.Add(txtProofNumber);
            groupBox2.Controls.Add(txtProofType);
            groupBox2.Location = new Point(601, 71);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(563, 343);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Identity Info";
            groupBox2.Visible = false;
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(368, 291);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(174, 36);
            btnCapture.TabIndex = 9;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnStartCam
            // 
            btnStartCam.Location = new Point(370, 243);
            btnStartCam.Name = "btnStartCam";
            btnStartCam.Size = new Size(174, 32);
            btnStartCam.TabIndex = 9;
            btnStartCam.Text = "Start Camera";
            btnStartCam.UseVisualStyleBackColor = true;
            btnStartCam.Click += btnStartCam_Click;
            // 
            // cmbCameras
            // 
            cmbCameras.FormattingEnabled = true;
            cmbCameras.Location = new Point(368, 201);
            cmbCameras.Name = "cmbCameras";
            cmbCameras.Size = new Size(176, 23);
            cmbCameras.TabIndex = 8;
            // 
            // btnIDSave
            // 
            btnIDSave.Location = new Point(367, 136);
            btnIDSave.Name = "btnIDSave";
            btnIDSave.Size = new Size(177, 28);
            btnIDSave.TabIndex = 7;
            btnIDSave.Text = "Save";
            btnIDSave.UseVisualStyleBackColor = true;
            btnIDSave.Click += btnIDSave_Click;
            // 
            // btnUploadID
            // 
            btnUploadID.Location = new Point(31, 135);
            btnUploadID.Name = "btnUploadID";
            btnUploadID.Size = new Size(249, 30);
            btnUploadID.TabIndex = 6;
            btnUploadID.Text = "Upload ID Card";
            btnUploadID.UseVisualStyleBackColor = true;
            btnUploadID.Click += btnUploadID_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(314, 102);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 1;
            label14.Text = "Country";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(72, 107);
            label15.Name = "label15";
            label15.Size = new Size(33, 15);
            label15.TabIndex = 1;
            label15.Text = "State";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(299, 68);
            label16.Name = "label16";
            label16.Size = new Size(65, 15);
            label16.TabIndex = 1;
            label16.Text = "Expiry Date";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(45, 67);
            label17.Name = "label17";
            label17.Size = new Size(60, 15);
            label17.TabIndex = 1;
            label17.Text = "Issue Date";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(292, 30);
            label19.Name = "label19";
            label19.Size = new Size(65, 15);
            label19.TabIndex = 1;
            label19.Text = "ID Number";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(31, 30);
            label20.Name = "label20";
            label20.Size = new Size(74, 15);
            label20.TabIndex = 1;
            label20.Text = "ID Card Type";
            // 
            // txtIDCountry
            // 
            txtIDCountry.Location = new Point(367, 99);
            txtIDCountry.Name = "txtIDCountry";
            txtIDCountry.Size = new Size(177, 23);
            txtIDCountry.TabIndex = 5;
            // 
            // txtIDState
            // 
            txtIDState.Location = new Point(111, 99);
            txtIDState.Name = "txtIDState";
            txtIDState.Size = new Size(169, 23);
            txtIDState.TabIndex = 4;
            // 
            // txtIssueDate
            // 
            txtIssueDate.Location = new Point(111, 63);
            txtIssueDate.Name = "txtIssueDate";
            txtIssueDate.Size = new Size(169, 23);
            txtIssueDate.TabIndex = 2;
            // 
            // txtExpiryDate
            // 
            txtExpiryDate.Location = new Point(370, 63);
            txtExpiryDate.Name = "txtExpiryDate";
            txtExpiryDate.Size = new Size(177, 23);
            txtExpiryDate.TabIndex = 3;
            // 
            // txtProofNumber
            // 
            txtProofNumber.Location = new Point(370, 27);
            txtProofNumber.Name = "txtProofNumber";
            txtProofNumber.Size = new Size(177, 23);
            txtProofNumber.TabIndex = 1;
            // 
            // txtProofType
            // 
            txtProofType.Location = new Point(111, 27);
            txtProofType.Name = "txtProofType";
            txtProofType.Size = new Size(169, 23);
            txtProofType.TabIndex = 0;
            // 
            // frmGuest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 663);
            Controls.Add(picIDBox);
            Controls.Add(groupBox2);
            Controls.Add(dgvBooking);
            Controls.Add(groupBox1);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmGuest";
            Text = "Insert And View Guest Information";
            FormClosing += frmGuest_FormClosing;
            Load += frmGuest_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBooking).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIDBox).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBooking;
        private GroupBox groupBox1;
        private Button btnGuestSave;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label5;
        private Label label3;
        private Label label2;
        private TextBox txtCountry;
        private TextBox txtState;
        private TextBox txtArea;
        private TextBox txtAddress;
        private TextBox txtCity;
        private TextBox txtGuestName;
        private TextBox txtMobileNumber;
        private Panel panelTop;
        private Label label1;
        private PictureBox picIDBox;
        private GroupBox groupBox2;
        private Button btnIDSave;
        private Button btnUploadID;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label19;
        private Label label20;
        private TextBox txtIDCountry;
        private TextBox txtIDState;
        private TextBox txtIssueDate;
        private TextBox txtProofType;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label4;
        private TextBox txtEmail;
        private Label label6;
        private TextBox txtPhone2;
        private TextBox txtExpiryDate;
        private TextBox txtProofNumber;
        private Button btnCapture;
        private Button btnStartCam;
        private ComboBox cmbCameras;
    }
}