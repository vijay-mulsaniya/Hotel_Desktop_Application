namespace Hotel.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMenu = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            menuFileExit = new ToolStripMenuItem();
            menuHelp = new ToolStripMenuItem();
            menuHelpAbout = new ToolStripMenuItem();
            mainToolStrip = new ToolStrip();
            btnAddGuest = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            btnMembers = new ToolStripButton();
            btnReceipt = new ToolStripButton();
            btnTransactions = new ToolStripButton();
            btnBookNow = new ToolStripButton();
            btnReports = new ToolStripButton();
            btnChangePassword = new ToolStripButton();
            mainStatusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            statusLabelUserName = new ToolStripStatusLabel();
            btnHistory = new ToolStripButton();
            mainMenu.SuspendLayout();
            mainToolStrip.SuspendLayout();
            mainStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { menuFile, menuHelp });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(1164, 24);
            mainMenu.TabIndex = 1;
            mainMenu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { logoutToolStripMenuItem, menuFileExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(37, 20);
            menuFile.Text = "&File";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(112, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += menuFileLogout_Click;
            // 
            // menuFileExit
            // 
            menuFileExit.Name = "menuFileExit";
            menuFileExit.Size = new Size(112, 22);
            menuFileExit.Text = "E&xit";
            menuFileExit.Click += menuFileExit_Click;
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new ToolStripItem[] { menuHelpAbout });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new Size(44, 20);
            menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            menuHelpAbout.Name = "menuHelpAbout";
            menuHelpAbout.Size = new Size(107, 22);
            menuHelpAbout.Text = "&About";
            menuHelpAbout.Click += menuHelpAbout_Click;
            // 
            // mainToolStrip
            // 
            mainToolStrip.Items.AddRange(new ToolStripItem[] { btnAddGuest, toolStripButton1, btnMembers, btnReceipt, btnTransactions, btnBookNow, btnReports, btnHistory, btnChangePassword });
            mainToolStrip.Location = new Point(0, 24);
            mainToolStrip.Name = "mainToolStrip";
            mainToolStrip.Size = new Size(1164, 57);
            mainToolStrip.TabIndex = 2;
            mainToolStrip.Text = "toolStrip1";
            // 
            // btnAddGuest
            // 
            btnAddGuest.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAddGuest.Image = Properties.Resources.Guest_1;
            btnAddGuest.ImageScaling = ToolStripItemImageScaling.None;
            btnAddGuest.ImageTransparentColor = Color.Magenta;
            btnAddGuest.Name = "btnAddGuest";
            btnAddGuest.Size = new Size(54, 54);
            btnAddGuest.Text = "toolStripButton1";
            btnAddGuest.ToolTipText = "Add Guest Information";
            btnAddGuest.Click += btnAddGuest_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.Mobile_1;
            toolStripButton1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(54, 54);
            toolStripButton1.Text = "ID Card Upload";
            toolStripButton1.TextAlign = ContentAlignment.TopRight;
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // btnMembers
            // 
            btnMembers.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMembers.Image = Properties.Resources.Booking;
            btnMembers.ImageScaling = ToolStripItemImageScaling.None;
            btnMembers.ImageTransparentColor = Color.Magenta;
            btnMembers.Name = "btnMembers";
            btnMembers.Size = new Size(54, 54);
            btnMembers.Text = "Booking";
            btnMembers.ToolTipText = "Today's Booking";
            btnMembers.Click += btnMembers_Click;
            // 
            // btnReceipt
            // 
            btnReceipt.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnReceipt.Image = Properties.Resources.Calander;
            btnReceipt.ImageScaling = ToolStripItemImageScaling.None;
            btnReceipt.ImageTransparentColor = Color.Magenta;
            btnReceipt.Name = "btnReceipt";
            btnReceipt.Size = new Size(54, 54);
            btnReceipt.Text = "Date View";
            btnReceipt.ToolTipText = "Date Wise View";
            btnReceipt.Click += btnReceipt_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnTransactions.Image = Properties.Resources.Invoice_3;
            btnTransactions.ImageScaling = ToolStripItemImageScaling.None;
            btnTransactions.ImageTransparentColor = Color.Magenta;
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(54, 54);
            btnTransactions.Text = "Invoice";
            btnTransactions.ToolTipText = "Invoice And Payments";
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnBookNow
            // 
            btnBookNow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnBookNow.Image = Properties.Resources.Time_2;
            btnBookNow.ImageScaling = ToolStripItemImageScaling.None;
            btnBookNow.ImageTransparentColor = Color.Magenta;
            btnBookNow.Name = "btnBookNow";
            btnBookNow.Size = new Size(54, 54);
            btnBookNow.Text = "Add Room Booking";
            btnBookNow.ToolTipText = "New Room Booking";
            btnBookNow.Click += btnBookNow_Click;
            // 
            // btnReports
            // 
            btnReports.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnReports.Image = (Image)resources.GetObject("btnReports.Image");
            btnReports.ImageScaling = ToolStripItemImageScaling.None;
            btnReports.ImageTransparentColor = Color.Magenta;
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(54, 54);
            btnReports.Text = "Reports";
            btnReports.Click += btnReports_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnChangePassword.Image = Properties.Resources.Key_1;
            btnChangePassword.ImageScaling = ToolStripItemImageScaling.None;
            btnChangePassword.ImageTransparentColor = Color.Magenta;
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(54, 54);
            btnChangePassword.Text = "Change Password";
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // mainStatusStrip
            // 
            mainStatusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, statusLabelUserName });
            mainStatusStrip.Location = new Point(0, 629);
            mainStatusStrip.Name = "mainStatusStrip";
            mainStatusStrip.Size = new Size(1164, 22);
            mainStatusStrip.TabIndex = 3;
            mainStatusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Ready";
            // 
            // statusLabelUserName
            // 
            statusLabelUserName.Name = "statusLabelUserName";
            statusLabelUserName.Size = new Size(65, 17);
            statusLabelUserName.Text = "User Name";
            // 
            // btnHistory
            // 
            btnHistory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnHistory.Image = Properties.Resources.History;
            btnHistory.ImageScaling = ToolStripItemImageScaling.None;
            btnHistory.ImageTransparentColor = Color.Magenta;
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(54, 54);
            btnHistory.Text = "History";
            btnHistory.Click += btnHistory_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1164, 651);
            Controls.Add(mainStatusStrip);
            Controls.Add(mainToolStrip);
            Controls.Add(mainMenu);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = mainMenu;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            mainToolStrip.ResumeLayout(false);
            mainToolStrip.PerformLayout();
            mainStatusStrip.ResumeLayout(false);
            mainStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStrip mainToolStrip;
        private StatusStrip mainStatusStrip;
        private ToolStripStatusLabel lblStatus;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuFileExit;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem menuHelpAbout;
        private ToolStripButton btnMembers;
        private ToolStripButton btnReceipt;
        private ToolStripButton btnReports;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripButton btnTransactions;
        private ToolStripButton btnBookNow;
        private ToolStripButton btnAddGuest;
        private ToolStripButton btnChangePassword;
        private ToolStripStatusLabel statusLabelUserName;
        private ToolStripButton toolStripButton1;
        private ToolStripButton btnHistory;
    }
}
