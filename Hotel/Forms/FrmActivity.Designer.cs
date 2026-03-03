namespace Hotel.Forms
{
    partial class FrmActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActivity));
            label1 = new Label();
            treeView1 = new TreeView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.DarkOrchid;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1225, 46);
            label1.TabIndex = 0;
            label1.Text = "History";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            treeView1.Location = new Point(0, 46);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(1225, 654);
            treeView1.TabIndex = 1;
            // 
            // FrmActivity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1225, 700);
            Controls.Add(treeView1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmActivity";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "History Tracking";
            Load += FrmActivity_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TreeView treeView1;
    }
}