using Hotel.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.UserControls
{
    public partial class HotelRoomAvailable : UserControl
    {
        private readonly IServiceProvider serviceProvider;
        private readonly MainForm mainForm;
        private DateTime _selectedCheckInDate;
        public HotelRoomAvailable(IServiceProvider serviceProvider, MainForm mainForm)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.mainForm = mainForm;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedCheckInDate
        {
            get => _selectedCheckInDate;
            set => _selectedCheckInDate = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomNumber
        {
            get => lblRoomNumber.Text;
            set => lblRoomNumber.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomTitle
        {
            get => lblRoomTitle.Text;
            set => lblRoomTitle.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Capacity
        {
            get => Convert.ToInt32(lblCapacity);
            set => lblCapacity.Text = value.ToString();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RoomId
        {
            get => Convert.ToInt32(lblRoomId.Text);
            set => lblRoomId.Text = value.ToString();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal ChargesPerNight
        {
            get => Convert.ToDecimal(lblCharges);
            set => lblCharges.Text = value.ToString();
        }

        private void btnBookNow_Click(object sender, EventArgs e)
        {
            var bookNow = serviceProvider.GetRequiredService<frmBookNow>();
            
            if (bookNow != null)
            {

                bookNow.SelectedRoomId = RoomId;
                bookNow.SelectedCheckInDate = SelectedCheckInDate;
                bookNow.MdiParent = this.mainForm;
                bookNow.WindowState = FormWindowState.Maximized;

                foreach (var form in mainForm.MdiChildren)
                {
                    if (form is frmBookNow)
                    {
                        continue;
                    }
                    form.Close();
                }

                bookNow.Show();
            }
        }
    }
}
