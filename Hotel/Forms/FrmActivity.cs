using Hotel.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class FrmActivity : Form
    {
        public FrmActivity()
        {
            InitializeComponent();
            treeView1.AfterSelect += treeView1_AfterSelect!;
        }
        private void FrmActivity_Load(object sender, EventArgs e)
        {
            LoadActivities();
        }
        private void LoadActivities()
        {
            using (var context = new AppDbContext())
            {
                var activities = context.Activities
                                        .OrderByDescending(a => a.ActivityTime)   
                                        .Take(1000)                              
                                        .Select(a => new
                                        {
                                            Date = a.ActivityTime.Date,
                                            ChildNode = $"{a.ActivityTime:hh:mm tt} - {a.ActivityDescription}"
                                        })
                                        .AsEnumerable()                          
                                        .GroupBy(a => a.Date)
                                        .OrderByDescending(g => g.Key)
                                        .ToList();

                treeView1.Nodes.Clear();

                foreach (var group in activities)
                {
                    TreeNode dateNode = new TreeNode(group.Key.ToString("dd-MMM-yyyy"));
                    dateNode.Tag = group.Key;

                    foreach (var item in group)
                    {
                        TreeNode activityNode = new TreeNode(item.ChildNode);
                        activityNode.Tag = item;

                        dateNode.Nodes.Add(activityNode);
                    }

                    treeView1.Nodes.Add(dateNode);
                }
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Level == 0)
            {
                e.Node.Expand();
            }
        }
    }
}


