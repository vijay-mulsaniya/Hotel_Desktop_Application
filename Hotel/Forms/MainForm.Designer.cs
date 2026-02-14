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
            menuMasters = new ToolStripMenuItem();
            menuMasterMembers = new ToolStripMenuItem();
            menuTransactions = new ToolStripMenuItem();
            menuTransactionMaintenance = new ToolStripMenuItem();
            menuTransactionReceipts = new ToolStripMenuItem();
            incomeExpensesFundTransferToolStripMenuItem = new ToolStripMenuItem();
            menuReports = new ToolStripMenuItem();
            menuReportsMemberStatement = new ToolStripMenuItem();
            menuReportsLedgerStatement = new ToolStripMenuItem();
            menuHelp = new ToolStripMenuItem();
            menuHelpAbout = new ToolStripMenuItem();
            carCardToolStripMenuItem = new ToolStripMenuItem();
            mainToolStrip = new ToolStrip();
            btnMembers = new ToolStripButton();
            btnReceipt = new ToolStripButton();
            btnReports = new ToolStripButton();
            btnTransactions = new ToolStripButton();
            btnBookNow = new ToolStripButton();
            mainStatusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            btnAddGuest = new ToolStripButton();
            mainMenu.SuspendLayout();
            mainToolStrip.SuspendLayout();
            mainStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { menuFile, menuMasters, menuTransactions, menuReports, menuHelp });
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
            // menuMasters
            // 
            menuMasters.DropDownItems.AddRange(new ToolStripItem[] { menuMasterMembers });
            menuMasters.Name = "menuMasters";
            menuMasters.Size = new Size(60, 20);
            menuMasters.Text = "&Masters";
            // 
            // menuMasterMembers
            // 
            menuMasterMembers.Name = "menuMasterMembers";
            menuMasterMembers.Size = new Size(124, 22);
            menuMasterMembers.Text = "Members";
            menuMasterMembers.Click += menuMasterMembers_Click;
            // 
            // menuTransactions
            // 
            menuTransactions.DropDownItems.AddRange(new ToolStripItem[] { menuTransactionMaintenance, menuTransactionReceipts, incomeExpensesFundTransferToolStripMenuItem });
            menuTransactions.ImageTransparentColor = Color.White;
            menuTransactions.Name = "menuTransactions";
            menuTransactions.Size = new Size(85, 20);
            menuTransactions.Text = "&Transactions";
            // 
            // menuTransactionMaintenance
            // 
            menuTransactionMaintenance.Name = "menuTransactionMaintenance";
            menuTransactionMaintenance.Size = new Size(255, 22);
            menuTransactionMaintenance.Text = "Maintenance";
            // 
            // menuTransactionReceipts
            // 
            menuTransactionReceipts.Name = "menuTransactionReceipts";
            menuTransactionReceipts.Size = new Size(255, 22);
            menuTransactionReceipts.Text = "Receipts";
            // 
            // incomeExpensesFundTransferToolStripMenuItem
            // 
            incomeExpensesFundTransferToolStripMenuItem.Name = "incomeExpensesFundTransferToolStripMenuItem";
            incomeExpensesFundTransferToolStripMenuItem.Size = new Size(255, 22);
            incomeExpensesFundTransferToolStripMenuItem.Text = "Income - Expenses - Fund Transfer";
            incomeExpensesFundTransferToolStripMenuItem.Click += incomeExpensesFundTransferToolStripMenuItem_Click;
            // 
            // menuReports
            // 
            menuReports.DropDownItems.AddRange(new ToolStripItem[] { menuReportsMemberStatement, menuReportsLedgerStatement });
            menuReports.Name = "menuReports";
            menuReports.Size = new Size(59, 20);
            menuReports.Text = "&Reports";
            // 
            // menuReportsMemberStatement
            // 
            menuReportsMemberStatement.Name = "menuReportsMemberStatement";
            menuReportsMemberStatement.Size = new Size(176, 22);
            menuReportsMemberStatement.Text = "Member Statement";
            // 
            // menuReportsLedgerStatement
            // 
            menuReportsLedgerStatement.Name = "menuReportsLedgerStatement";
            menuReportsLedgerStatement.Size = new Size(176, 22);
            menuReportsLedgerStatement.Text = "Ledger Statement";
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new ToolStripItem[] { menuHelpAbout, carCardToolStripMenuItem });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new Size(44, 20);
            menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            menuHelpAbout.Name = "menuHelpAbout";
            menuHelpAbout.Size = new Size(116, 22);
            menuHelpAbout.Text = "&About";
            // 
            // carCardToolStripMenuItem
            // 
            carCardToolStripMenuItem.Name = "carCardToolStripMenuItem";
            carCardToolStripMenuItem.Size = new Size(116, 22);
            carCardToolStripMenuItem.Text = "car card";
            carCardToolStripMenuItem.Click += carCardToolStripMenuItem_Click;
            // 
            // mainToolStrip
            // 
            mainToolStrip.Items.AddRange(new ToolStripItem[] { btnMembers, btnReceipt, btnReports, btnTransactions, btnBookNow, btnAddGuest });
            mainToolStrip.Location = new Point(0, 24);
            mainToolStrip.Name = "mainToolStrip";
            mainToolStrip.Size = new Size(1164, 57);
            mainToolStrip.TabIndex = 2;
            mainToolStrip.Text = "toolStrip1";
            // 
            // btnMembers
            // 
            btnMembers.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMembers.Image = (Image)resources.GetObject("btnMembers.Image");
            btnMembers.ImageScaling = ToolStripItemImageScaling.None;
            btnMembers.ImageTransparentColor = Color.Magenta;
            btnMembers.Name = "btnMembers";
            btnMembers.Size = new Size(54, 54);
            btnMembers.Text = "Members";
            btnMembers.Click += btnMembers_Click;
            // 
            // btnReceipt
            // 
            btnReceipt.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnReceipt.Image = (Image)resources.GetObject("btnReceipt.Image");
            btnReceipt.ImageScaling = ToolStripItemImageScaling.None;
            btnReceipt.ImageTransparentColor = Color.Magenta;
            btnReceipt.Name = "btnReceipt";
            btnReceipt.Size = new Size(54, 54);
            btnReceipt.Text = "Receipts";
            btnReceipt.Click += btnReceipt_Click;
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
            // btnTransactions
            // 
            btnTransactions.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnTransactions.Image = (Image)resources.GetObject("btnTransactions.Image");
            btnTransactions.ImageScaling = ToolStripItemImageScaling.None;
            btnTransactions.ImageTransparentColor = Color.Magenta;
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(54, 54);
            btnTransactions.Text = "Transactions";
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnBookNow
            // 
            btnBookNow.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnBookNow.Image = Properties.Resources.Calander;
            btnBookNow.ImageScaling = ToolStripItemImageScaling.None;
            btnBookNow.ImageTransparentColor = Color.Magenta;
            btnBookNow.Name = "btnBookNow";
            btnBookNow.Size = new Size(54, 54);
            btnBookNow.Text = "toolStripButton1";
            btnBookNow.ToolTipText = "Add Booking";
            btnBookNow.Click += btnBookNow_Click;
            // 
            // mainStatusStrip
            // 
            mainStatusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
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
            // btnAddGuest
            // 
            btnAddGuest.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAddGuest.Image = Properties.Resources.Member;
            btnAddGuest.ImageScaling = ToolStripItemImageScaling.None;
            btnAddGuest.ImageTransparentColor = Color.Magenta;
            btnAddGuest.Name = "btnAddGuest";
            btnAddGuest.Size = new Size(54, 54);
            btnAddGuest.Text = "toolStripButton1";
            btnAddGuest.ToolTipText = "Add Guest Information";
            btnAddGuest.Click += btnAddGuest_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 651);
            Controls.Add(mainStatusStrip);
            Controls.Add(mainToolStrip);
            Controls.Add(mainMenu);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
        private ToolStripMenuItem menuMasters;
        private ToolStripMenuItem menuMasterMembers;
        private ToolStripMenuItem menuTransactions;
        private ToolStripMenuItem menuTransactionMaintenance;
        private ToolStripMenuItem menuTransactionReceipts;
        private ToolStripMenuItem menuReports;
        private ToolStripMenuItem menuReportsMemberStatement;
        private ToolStripMenuItem menuReportsLedgerStatement;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem menuHelpAbout;
        private ToolStripButton btnMembers;
        private ToolStripButton btnReceipt;
        private ToolStripButton btnReports;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem incomeExpensesFundTransferToolStripMenuItem;
        private ToolStripButton btnTransactions;
        private ToolStripMenuItem carCardToolStripMenuItem;
        private ToolStripButton btnBookNow;
        private ToolStripButton btnAddGuest;
    }
}
