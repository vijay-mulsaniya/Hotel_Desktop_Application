namespace Hotel.Forms
{
    partial class FrmIDUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIDUpload));
            groupBox2 = new GroupBox();
            dtpExpiryDate = new DateTimePicker();
            chkIsVerified = new CheckBox();
            cmbGuestNames = new ComboBox();
            btnIDSave = new Button();
            label16 = new Label();
            label17 = new Label();
            label19 = new Label();
            label1 = new Label();
            label20 = new Label();
            txtIssueAuthority = new TextBox();
            txtProofNumber = new TextBox();
            txtProofType = new TextBox();
            btnCapture = new Button();
            btnStartCam = new Button();
            cmbCameras = new ComboBox();
            btnUploadID = new Button();
            picIDBox = new PictureBox();
            lblFormTitle = new Label();
            lstGrid = new ListView();
            col_id = new ColumnHeader();
            col_gusetname = new ColumnHeader();
            col_mobile = new ColumnHeader();
            txtSearch = new TextBox();
            label2 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIDBox).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpExpiryDate);
            groupBox2.Controls.Add(chkIsVerified);
            groupBox2.Controls.Add(cmbGuestNames);
            groupBox2.Controls.Add(btnIDSave);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(txtIssueAuthority);
            groupBox2.Controls.Add(txtProofNumber);
            groupBox2.Controls.Add(txtProofType);
            groupBox2.Location = new Point(245, 592);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(651, 187);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Identity Info";
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Location = new Point(425, 66);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(200, 23);
            dtpExpiryDate.TabIndex = 4;
            // 
            // chkIsVerified
            // 
            chkIsVerified.AutoSize = true;
            chkIsVerified.Location = new Point(425, 104);
            chkIsVerified.Name = "chkIsVerified";
            chkIsVerified.Size = new Size(84, 19);
            chkIsVerified.TabIndex = 5;
            chkIsVerified.Text = "Is Verified ?";
            chkIsVerified.UseVisualStyleBackColor = true;
            // 
            // cmbGuestNames
            // 
            cmbGuestNames.FormattingEnabled = true;
            cmbGuestNames.Location = new Point(103, 32);
            cmbGuestNames.Name = "cmbGuestNames";
            cmbGuestNames.Size = new Size(233, 23);
            cmbGuestNames.TabIndex = 0;
            // 
            // btnIDSave
            // 
            btnIDSave.Location = new Point(422, 136);
            btnIDSave.Name = "btnIDSave";
            btnIDSave.Size = new Size(201, 28);
            btnIDSave.TabIndex = 6;
            btnIDSave.Text = "Save";
            btnIDSave.UseVisualStyleBackColor = true;
            btnIDSave.Click += btnIDSave_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(354, 68);
            label16.Name = "label16";
            label16.Size = new Size(65, 15);
            label16.TabIndex = 1;
            label16.Text = "Expiry Date";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(17, 107);
            label17.Name = "label17";
            label17.Size = new Size(80, 15);
            label17.TabIndex = 1;
            label17.Text = "Issu Authority";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(354, 35);
            label19.Name = "label19";
            label19.Size = new Size(65, 15);
            label19.TabIndex = 1;
            label19.Text = "ID Number";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 35);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 1;
            label1.Text = "Guest Name";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(23, 71);
            label20.Name = "label20";
            label20.Size = new Size(74, 15);
            label20.TabIndex = 1;
            label20.Text = "ID Card Type";
            // 
            // txtIssueAuthority
            // 
            txtIssueAuthority.Location = new Point(105, 104);
            txtIssueAuthority.Name = "txtIssueAuthority";
            txtIssueAuthority.Size = new Size(231, 23);
            txtIssueAuthority.TabIndex = 2;
            // 
            // txtProofNumber
            // 
            txtProofNumber.Location = new Point(425, 27);
            txtProofNumber.Name = "txtProofNumber";
            txtProofNumber.Size = new Size(201, 23);
            txtProofNumber.TabIndex = 3;
            // 
            // txtProofType
            // 
            txtProofType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProofType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProofType.Location = new Point(105, 68);
            txtProofType.Name = "txtProofType";
            txtProofType.Size = new Size(231, 23);
            txtProofType.TabIndex = 1;
            txtProofType.Leave += txtProofType_Leave;
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(39, 734);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(188, 36);
            btnCapture.TabIndex = 5;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnStartCam
            // 
            btnStartCam.Location = new Point(41, 686);
            btnStartCam.Name = "btnStartCam";
            btnStartCam.Size = new Size(188, 32);
            btnStartCam.TabIndex = 4;
            btnStartCam.Text = "Start Camera";
            btnStartCam.UseVisualStyleBackColor = true;
            btnStartCam.Click += btnStartCam_Click;
            // 
            // cmbCameras
            // 
            cmbCameras.FormattingEnabled = true;
            cmbCameras.Location = new Point(39, 644);
            cmbCameras.Name = "cmbCameras";
            cmbCameras.Size = new Size(190, 23);
            cmbCameras.TabIndex = 3;
            // 
            // btnUploadID
            // 
            btnUploadID.Location = new Point(39, 592);
            btnUploadID.Name = "btnUploadID";
            btnUploadID.Size = new Size(190, 30);
            btnUploadID.TabIndex = 0;
            btnUploadID.Text = "Upload ID Card";
            btnUploadID.UseVisualStyleBackColor = true;
            btnUploadID.Click += btnUploadID_Click;
            // 
            // picIDBox
            // 
            picIDBox.BorderStyle = BorderStyle.FixedSingle;
            picIDBox.Location = new Point(39, 73);
            picIDBox.Name = "picIDBox";
            picIDBox.Size = new Size(857, 472);
            picIDBox.SizeMode = PictureBoxSizeMode.Zoom;
            picIDBox.TabIndex = 16;
            picIDBox.TabStop = false;
            // 
            // lblFormTitle
            // 
            lblFormTitle.BackColor = Color.DodgerBlue;
            lblFormTitle.Dock = DockStyle.Top;
            lblFormTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = SystemColors.ButtonFace;
            lblFormTitle.Location = new Point(0, 0);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(1315, 56);
            lblFormTitle.TabIndex = 17;
            lblFormTitle.Text = "ID Information Upload";
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstGrid
            // 
            lstGrid.Columns.AddRange(new ColumnHeader[] { col_id, col_gusetname, col_mobile });
            lstGrid.FullRowSelect = true;
            lstGrid.GridLines = true;
            lstGrid.Location = new Point(923, 117);
            lstGrid.Name = "lstGrid";
            lstGrid.Size = new Size(362, 662);
            lstGrid.TabIndex = 2;
            lstGrid.UseCompatibleStateImageBehavior = false;
            lstGrid.View = View.Details;
            lstGrid.ItemSelectionChanged += lstGrid_ItemSelectionChanged;
            // 
            // col_id
            // 
            col_id.Text = "ID";
            col_id.Width = 30;
            // 
            // col_gusetname
            // 
            col_gusetname.Text = "Guest Name";
            col_gusetname.Width = 200;
            // 
            // col_mobile
            // 
            col_mobile.Text = "ID Proof";
            col_mobile.Width = 150;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(982, 73);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(303, 29);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(923, 81);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 20;
            label2.Text = "Search";
            // 
            // FrmIDUpload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 801);
            Controls.Add(label2);
            Controls.Add(txtSearch);
            Controls.Add(lstGrid);
            Controls.Add(lblFormTitle);
            Controls.Add(btnCapture);
            Controls.Add(picIDBox);
            Controls.Add(btnStartCam);
            Controls.Add(groupBox2);
            Controls.Add(cmbCameras);
            Controls.Add(btnUploadID);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmIDUpload";
            Text = "Upload ID Information";
            FormClosing += FrmIDUpload_FormClosing;
            Load += FrmIDUpload_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIDBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Button btnCapture;
        private Button btnStartCam;
        private ComboBox cmbCameras;
        private Button btnIDSave;
        private Button btnUploadID;
        private Label label16;
        private Label label17;
        private Label label19;
        private Label label20;
        private TextBox txtIssueAuthority;
        private TextBox txtProofNumber;
        private TextBox txtProofType;
        private PictureBox picIDBox;
        private Label lblFormTitle;
        private ComboBox cmbGuestNames;
        private Label label1;
        private CheckBox chkIsVerified;
        private ListView lstGrid;
        private ColumnHeader col_id;
        private ColumnHeader col_gusetname;
        private ColumnHeader col_mobile;
        private TextBox txtSearch;
        private Label label2;
        private DateTimePicker dtpExpiryDate;
    }
}