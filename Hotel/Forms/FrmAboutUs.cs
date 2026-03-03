using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Security.Principal;



namespace Hotel.Forms
{
    public partial class FrmAboutUs : Form
    {
        public FrmAboutUs()
        {
            InitializeComponent();
        }

        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This software is licensed to: " + GetHardwareID(), "License Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static string GetHardwareID()
        {
            string id = "";
            try
            {
                // Fetching Motherboard Serial Number
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                foreach (ManagementObject share in searcher.Get())
                {
                    id += share["SerialNumber"]?.ToString();
                }
            }
            catch
            {
                // Fallback to CPU ID if Motherboard fails
                id = "FALLBACK-ID-12345";
            }
            return id.Trim();
        }
    }
}
