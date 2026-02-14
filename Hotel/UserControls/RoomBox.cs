using Hotel.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.UserControls
{
    public partial class RoomBox : UserControl
    {
        public RoomBox(RoomBoxDto dto, Color bgColor)
        {
            InitializeComponent();
            this.BackColor = bgColor;
            lblRoomNumber.Text = dto.Number;
            lblRoomTitle.Text = dto.Title;
        }
    }
}
