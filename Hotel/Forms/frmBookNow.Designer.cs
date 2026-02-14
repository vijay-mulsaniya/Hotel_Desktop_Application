namespace Hotel.Forms
{
    partial class frmBookNow
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTop = new Panel();
            label1 = new Label();
            label18 = new Label();
            txtPricePerNight = new TextBox();
            label21 = new Label();
            label22 = new Label();
            txtAdult = new TextBox();
            txtChild = new TextBox();
            label23 = new Label();
            dtpFromDateTime = new DateTimePicker();
            dtpToDateTime = new DateTimePicker();
            btnAddToGrid = new Button();
            listBox1 = new ListBox();
            btnGo = new Button();
            cmbGuests = new ComboBox();
            label2 = new Label();
            lblSelectedRooms = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDiscount = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblTotalAmount = new Label();
            lblTotal = new Label();
            lblSGST = new Label();
            lblCGST = new Label();
            lblIGST = new Label();
            lblFinalTotal = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            grpBox = new GroupBox();
            gvBooking = new DataGridView();
            label10 = new Label();
            label11 = new Label();
            panelTop.SuspendLayout();
            grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvBooking).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.DarkSeaGreen;
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1523, 58);
            panelTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 17);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 0;
            label1.Text = "Book Now";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(29, 96);
            label18.Name = "label18";
            label18.Size = new Size(95, 15);
            label18.TabIndex = 13;
            label18.Text = "Available Rooms";
            // 
            // txtPricePerNight
            // 
            txtPricePerNight.Location = new Point(126, 61);
            txtPricePerNight.Name = "txtPricePerNight";
            txtPricePerNight.Size = new Size(119, 23);
            txtPricePerNight.TabIndex = 6;
            txtPricePerNight.KeyPress += txtPricePerNight_KeyPress;
            txtPricePerNight.Validating += txtPricePerNight_Validating;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(19, 65);
            label21.Name = "label21";
            label21.Size = new Size(98, 15);
            label21.TabIndex = 15;
            label21.Text = "Per Night Charge";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(254, 65);
            label22.Name = "label22";
            label22.Size = new Size(36, 15);
            label22.TabIndex = 16;
            label22.Text = "Adult";
            // 
            // txtAdult
            // 
            txtAdult.Location = new Point(299, 61);
            txtAdult.Name = "txtAdult";
            txtAdult.Size = new Size(41, 23);
            txtAdult.TabIndex = 7;
            txtAdult.KeyPress += txtAdult_KeyPress;
            txtAdult.Leave += txtAdult_Leave;
            // 
            // txtChild
            // 
            txtChild.Location = new Point(393, 61);
            txtChild.Name = "txtChild";
            txtChild.Size = new Size(41, 23);
            txtChild.TabIndex = 8;
            txtChild.KeyPress += txtChild_KeyPress;
            txtChild.Leave += txtChild_Leave;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(349, 65);
            label23.Name = "label23";
            label23.Size = new Size(35, 15);
            label23.TabIndex = 17;
            label23.Text = "Child";
            // 
            // dtpFromDateTime
            // 
            dtpFromDateTime.Format = DateTimePickerFormat.Custom;
            dtpFromDateTime.Location = new Point(287, 75);
            dtpFromDateTime.Name = "dtpFromDateTime";
            dtpFromDateTime.Size = new Size(200, 23);
            dtpFromDateTime.TabIndex = 1;
            dtpFromDateTime.Leave += dtpFromDateTime_Leave;
            // 
            // dtpToDateTime
            // 
            dtpToDateTime.Format = DateTimePickerFormat.Custom;
            dtpToDateTime.Location = new Point(588, 75);
            dtpToDateTime.Name = "dtpToDateTime";
            dtpToDateTime.Size = new Size(200, 23);
            dtpToDateTime.TabIndex = 2;
            // 
            // btnAddToGrid
            // 
            btnAddToGrid.Location = new Point(443, 61);
            btnAddToGrid.Name = "btnAddToGrid";
            btnAddToGrid.Size = new Size(129, 24);
            btnAddToGrid.TabIndex = 9;
            btnAddToGrid.Text = "Add";
            btnAddToGrid.UseVisualStyleBackColor = true;
            btnAddToGrid.Click += btnAddToGrid_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(29, 118);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.Size = new Size(179, 559);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnGo
            // 
            btnGo.Location = new Point(804, 75);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(97, 23);
            btnGo.TabIndex = 3;
            btnGo.Text = "Search";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // cmbGuests
            // 
            cmbGuests.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbGuests.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbGuests.FormattingEnabled = true;
            cmbGuests.Location = new Point(127, 25);
            cmbGuests.Name = "cmbGuests";
            cmbGuests.Size = new Size(307, 23);
            cmbGuests.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 28);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 14;
            label2.Text = "Guest Name";
            // 
            // lblSelectedRooms
            // 
            lblSelectedRooms.AutoSize = true;
            lblSelectedRooms.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectedRooms.Location = new Point(454, 25);
            lblSelectedRooms.Name = "lblSelectedRooms";
            lblSelectedRooms.Size = new Size(0, 25);
            lblSelectedRooms.TabIndex = 12;
            lblSelectedRooms.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(573, 363);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 18;
            label3.Text = "Total Amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(599, 391);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 19;
            label4.Text = "Discount";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(672, 391);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(92, 23);
            txtDiscount.TabIndex = 11;
            txtDiscount.TabStop = false;
            txtDiscount.Text = "0";
            txtDiscount.Leave += txtDiscount_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(620, 419);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 20;
            label5.Text = "Total";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(619, 447);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 21;
            label6.Text = "SGST";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(617, 475);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 22;
            label7.Text = "CGST";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(622, 503);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 23;
            label8.Text = "IGST";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(592, 531);
            label9.Name = "label9";
            label9.Size = new Size(61, 15);
            label9.TabIndex = 24;
            label9.Text = "Final Total";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(672, 363);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(13, 15);
            lblTotalAmount.TabIndex = 25;
            lblTotalAmount.Text = "0";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(672, 425);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(13, 15);
            lblTotal.TabIndex = 26;
            lblTotal.Text = "0";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSGST
            // 
            lblSGST.AutoSize = true;
            lblSGST.Location = new Point(672, 452);
            lblSGST.Name = "lblSGST";
            lblSGST.Size = new Size(13, 15);
            lblSGST.TabIndex = 27;
            lblSGST.Text = "0";
            lblSGST.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCGST
            // 
            lblCGST.AutoSize = true;
            lblCGST.Location = new Point(672, 479);
            lblCGST.Name = "lblCGST";
            lblCGST.Size = new Size(13, 15);
            lblCGST.TabIndex = 28;
            lblCGST.Text = "0";
            lblCGST.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIGST
            // 
            lblIGST.AutoSize = true;
            lblIGST.Location = new Point(672, 506);
            lblIGST.Name = "lblIGST";
            lblIGST.Size = new Size(13, 15);
            lblIGST.TabIndex = 29;
            lblIGST.Text = "0";
            lblIGST.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFinalTotal
            // 
            lblFinalTotal.AutoSize = true;
            lblFinalTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFinalTotal.Location = new Point(672, 533);
            lblFinalTotal.Name = "lblFinalTotal";
            lblFinalTotal.Size = new Size(15, 17);
            lblFinalTotal.TabIndex = 30;
            lblFinalTotal.Text = "0";
            lblFinalTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(443, 527);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 23);
            btnSave.TabIndex = 31;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(299, 527);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(133, 23);
            btnCancel.TabIndex = 31;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // grpBox
            // 
            grpBox.Controls.Add(btnCancel);
            grpBox.Controls.Add(btnSave);
            grpBox.Controls.Add(txtDiscount);
            grpBox.Controls.Add(cmbGuests);
            grpBox.Controls.Add(gvBooking);
            grpBox.Controls.Add(lblSelectedRooms);
            grpBox.Controls.Add(btnAddToGrid);
            grpBox.Controls.Add(txtChild);
            grpBox.Controls.Add(txtAdult);
            grpBox.Controls.Add(txtPricePerNight);
            grpBox.Controls.Add(label23);
            grpBox.Controls.Add(label22);
            grpBox.Controls.Add(label8);
            grpBox.Controls.Add(label7);
            grpBox.Controls.Add(label6);
            grpBox.Controls.Add(label5);
            grpBox.Controls.Add(label4);
            grpBox.Controls.Add(label9);
            grpBox.Controls.Add(lblFinalTotal);
            grpBox.Controls.Add(lblIGST);
            grpBox.Controls.Add(lblCGST);
            grpBox.Controls.Add(lblSGST);
            grpBox.Controls.Add(lblTotal);
            grpBox.Controls.Add(lblTotalAmount);
            grpBox.Controls.Add(label3);
            grpBox.Controls.Add(label2);
            grpBox.Controls.Add(label21);
            grpBox.Location = new Point(214, 108);
            grpBox.Name = "grpBox";
            grpBox.Size = new Size(908, 571);
            grpBox.TabIndex = 32;
            grpBox.TabStop = false;
            grpBox.Text = "Detail";
            // 
            // gvBooking
            // 
            gvBooking.AllowUserToAddRows = false;
            gvBooking.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            gvBooking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gvBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvBooking.BackgroundColor = SystemColors.ControlLight;
            gvBooking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvBooking.Location = new Point(19, 105);
            gvBooking.Name = "gvBooking";
            gvBooking.ReadOnly = true;
            gvBooking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvBooking.Size = new Size(854, 244);
            gvBooking.TabIndex = 10;
            gvBooking.TabStop = false;
            gvBooking.RowsAdded += gvBooking_RowsAdded;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(214, 79);
            label10.Name = "label10";
            label10.Size = new Size(57, 15);
            label10.TabIndex = 13;
            label10.Text = "Check-IN";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(503, 79);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 13;
            label11.Text = "Check-OUT";
            // 
            // frmBookNow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1523, 700);
            Controls.Add(grpBox);
            Controls.Add(btnGo);
            Controls.Add(listBox1);
            Controls.Add(dtpToDateTime);
            Controls.Add(dtpFromDateTime);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label18);
            Controls.Add(panelTop);
            Name = "frmBookNow";
            Text = "frmBookNow";
            Load += frmBookNow_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpBox.ResumeLayout(false);
            grpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvBooking).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label1;
        private TextBox txtDiscount;
        private Button btnGo;
        private Label label18;
        private Label label21;
        private Label label22;
        private Label label23;
        private TextBox txtPricePerNight;
        private TextBox txtAdult;
        private TextBox txtChild;
        private DateTimePicker dtpFromDateTime;
        private DateTimePicker dtpToDateTime;
        private Button btnAddToGrid;
        private DataGridView gvBooking;
        private ListBox listBox1;
        private ComboBox cmbGuests;
        private Label label2;
        private Label lblSelectedRooms;
        private Label label3;
        private Label label5;
        private Label lblTotalAmount;
        private Label lblTotal;
        private Label lblSGST;
        private Label lblCGST;
        private Label lblIGST;
        private Label lblFinalTotal;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox grpBox;
        private Label label10;
        private Label label11;
    }
}