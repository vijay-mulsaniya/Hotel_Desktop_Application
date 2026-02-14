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
    public partial class DateBox : UserControl
    {
        public DateBoxDto Data { get; private set; }
        public event EventHandler<DateBoxDto> DateBoxClicked = null!;

        public DateBox(DateBoxDto dto)
        {
            InitializeComponent();
            Data = dto;
            this.BackColor = dto.BackgoundColor;
            lblDt.Text = dto.DateLabel;
            lblmonthYear.Text = dto.MonthLabel;
            lblGuest.Text = dto.GuestName;

            this.Click += OnControlClicked!;
            lblDt.Click += OnControlClicked!;
            lblmonthYear.Click += OnControlClicked!;

            if (dto.IsBooked)
            {
                lblDt.ForeColor = Color.White;
                lblmonthYear.ForeColor = Color.White;
            }
                      
        }

        private void OnControlClicked(object sender, EventArgs e)
        {
            // Fire the custom event
            DateBoxClicked?.Invoke(this, this.Data);
        }
    }
}
