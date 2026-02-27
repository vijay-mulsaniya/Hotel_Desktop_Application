using Hotel.Common;
using Hotel.Data;
using Hotel.Dtos;
using Hotel.Services;
using Hotel.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class FrmDateWiseRoomView : Form
    {
        private readonly IRoomService roomService;
        private readonly IServiceProvider serviceProvider;
        private readonly MainForm mainForm;

        public FrmDateWiseRoomView(IRoomService roomService, IServiceProvider serviceProvider, MainForm mainForm)
        {
            InitializeComponent();
            this.roomService = roomService;
            this.serviceProvider = serviceProvider;
            this.mainForm = mainForm;
            dtpFromDate.Value = DateTime.Now.Date.AddDays(-5);
            dtpTodate.Value = DateTime.Now.Date.Date.AddDays(20);
            mainPanel.FlowDirection = FlowDirection.TopDown;
        }

        private async void FrmDateWiseRoomView_Load(object sender, EventArgs e)
        {
            // Basic Styling
            dgvRoomGrid.BackgroundColor = Color.White;
            dgvRoomGrid.BorderStyle = BorderStyle.None;
            dgvRoomGrid.CellBorderStyle = DataGridViewCellBorderStyle.None; // We will draw our own borders/spacing
            dgvRoomGrid.ColumnHeadersVisible = false; // Hide headers if you want the "clean" look
            dgvRoomGrid.RowHeadersVisible = false;
            dgvRoomGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvRoomGrid.DefaultCellStyle.SelectionBackColor = Color.Transparent; // Prevent blue highlight

            await PopulateGridData();
        }


        private async Task PopulateGridData()
        {
            DateWiseRoomViewDto data = await roomService.dateWiseRoomView(dtpFromDate.Value, dtpTodate.Value);
            PopulateGrid(data);
        }

        public void PopulateGrid2(DateWiseRoomViewDto data)
        {
            mainPanel.Controls.Clear();
            mainPanel.WrapContents = false;
            mainPanel.AutoScroll = true;

            foreach (var rowDto in data.dateWiseRowDtos)
            {
                FlowLayoutPanel rowPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = mainPanel.Width,
                    Height = 85, // Slightly taller than the controls
                    Margin = new Padding(0),
                    WrapContents = false
                };

                Color roomCol = rowDto.RoomBox.Number.Contains("3") ? Color.Orange : Color.LimeGreen;
                rowPanel.Controls.Add(new RoomBox(rowDto.RoomBox, roomCol));

                foreach (var dateDto in rowDto.DateBoxes)
                {
                    var dateBox = new DateBox(dateDto);
                    dateBox.DateBoxClicked += (s, clickedDto) =>
                    {
                        if (clickedDto.IsBooked)
                        {
                            MessageBox.Show($"Room is booked by: {clickedDto.GuestName}");
                        }
                        else
                        {
                            MessageBox.Show($"Opening booking form for {clickedDto.DateLabel}/{clickedDto.MonthLabel}");
                            // Open your Booking Dialog here
                        }
                    };

                    rowPanel.Controls.Add(dateBox);
                }

                mainPanel.Controls.Add(rowPanel);
            }
        }

        public void PopulateGrid(DateWiseRoomViewDto data)
        {
            dgvRoomGrid.Columns.Clear();
            dgvRoomGrid.Rows.Clear();

            // 1. Create the Room Column
            dgvRoomGrid.Columns.Add("Room", "Room Details");
            dgvRoomGrid.Columns[0].Width = 120;
            dgvRoomGrid.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 2. Create Date Columns (using the first row of data as a template)
            var firstRow = data.dateWiseRowDtos.FirstOrDefault();
            if (firstRow != null)
            {
                for (int i = 0; i < firstRow.DateBoxes.Count; i++)
                {
                    var colIndex = dgvRoomGrid.Columns.Add($"Date{i}", firstRow.DateBoxes[i].DateLabel);
                    dgvRoomGrid.Columns[colIndex].Width = 60;
                }
            }

            // 3. Fill Rows
            foreach (var rowDto in data.dateWiseRowDtos)
            {
                int rowIndex = dgvRoomGrid.Rows.Add();
                DataGridViewRow row = dgvRoomGrid.Rows[rowIndex];

                // Room Cell text
                row.Cells[0].Value = $"{rowDto.RoomBox.Number}\n{rowDto.RoomBox.Title}";

                // Color the Room Cell
                SetBackGroundColor(rowDto, row);
                row.Cells[0].Style.ForeColor = Color.White;

                // Date Cells
                for (int i = 0; i < rowDto.DateBoxes.Count; i++)
                {
                    var dateDto = rowDto.DateBoxes[i];
                    var cell = row.Cells[i + 1];

                    // Set values and colors
                    cell.Value = $"{dateDto.DateLabel}\n{dateDto.MonthLabel}";
                    cell.Style.BackColor = dateDto.BackgoundColor;
                    cell.Tag = dateDto; // Store the DTO in the Tag for later use!
                }
            }
        }

        private static void SetBackGroundColor(DateWiseRowDto rowDto, DataGridViewRow row)
        {

            if (rowDto.RoomBox.Title == "Deluxe Room")
                row.Cells[0].Style.BackColor = Color.Green;
            else if (rowDto.RoomBox.Title == "Standard Room")
                row.Cells[0].Style.BackColor = Color.MediumSeaGreen;
            else if (rowDto.RoomBox.Title == "Dormitory")
                row.Cells[0].Style.BackColor = Color.Teal;
            else
                row.Cells[0].Style.BackColor = Color.LimeGreen;

        }

        private void dgvRoomGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Skip headers
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 1. Fill the actual cell background with the Grid's background color 
            // This creates the "spacing" effect between the boxes we are about to draw.
            using (SolidBrush gridBackBrush = new SolidBrush(dgvRoomGrid.BackgroundColor))
            {
                e.Graphics!.FillRectangle(gridBackBrush, e.CellBounds);
            }

            // 2. Define the Box (the "Button" look)
            // Subtracting pixels from Width and Height creates the gap/spacing.
            int spacing = 4;
            Rectangle boxRect = new Rectangle(e.CellBounds.X + spacing / 2,
                                              e.CellBounds.Y + spacing / 2,
                                              e.CellBounds.Width - spacing,
                                              e.CellBounds.Height - spacing);

            // 3. Determine Colors based on Column and Booking Status
            Color boxColor;
            Color textColor = Color.White; // Default for Room labels and Booked dates

            if (e.ColumnIndex == 0)
            {
                // Room Column Style
                boxColor = e.CellStyle!.BackColor; // Green or Orange as set in PopulateGrid
            }
            else
            {
                // Date Column Style
                var dateDto = dgvRoomGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as DateBoxDto;
                boxColor = dateDto?.BackgoundColor ?? Color.LightGreen;

                // Requirement: Available Room Text should be Black
                if (dateDto != null && !dateDto.IsBooked)
                {
                    textColor = Color.Black;
                }
            }

            // 4. Draw the Box and Text
            using (SolidBrush brush = new SolidBrush(boxColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.FillRectangle(brush, boxRect);

                if (e.Value != null)
                {
                    string[] lines = e.Value.ToString()!.Split('\n');

                    // Draw Line 1 (Number/Date)
                    Font fontTop = new Font("Segoe UI", 12, FontStyle.Bold);
                    Size sizeTop = TextRenderer.MeasureText(lines[0], fontTop);
                    e.Graphics.DrawString(lines[0], fontTop, textBrush,
                        boxRect.X + (boxRect.Width - sizeTop.Width) / 2,
                        boxRect.Y + 8);

                    // Draw Line 2 (Title/Month)
                    if (lines.Length > 1)
                    {
                        Font fontBottom = new Font("Segoe UI", 8, FontStyle.Bold);
                        Size sizeBottom = TextRenderer.MeasureText(lines[1], fontBottom);
                        e.Graphics.DrawString(lines[1], fontBottom, textBrush,
                            boxRect.X + (boxRect.Width - sizeBottom.Width) / 2,
                            boxRect.Y + boxRect.Height - sizeBottom.Height - 8);
                    }
                }
            }

            e.Handled = true; // Prevent default painting
        }

        private void dgvRoomGrid_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                var dateDto = dgvRoomGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as DateBoxDto;
                if (dateDto != null && dateDto.IsBooked)
                {
                    e.ToolTipText = $"Guest: {dateDto.GuestName ?? "Unknown"}\nStatus: Occupied";
                }
            }
        }

        private void dgvRoomGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!AppSession.IsInRole("Admin")) return; // Ignore if user is not Admin

            if (e.RowIndex < 0 || e.ColumnIndex <= 0) return; // Ignore header or Room column

            var cell = dgvRoomGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Tag is DateBoxDto clickedDto)
            {
               
                if (clickedDto.IsBooked)
                {
                    MessageBox.Show($"Guest Name:\r\n {clickedDto.GuestName}", "Booked");
                    return;
                }

                var bookNow = serviceProvider.GetRequiredService<frmBookNow>();

                if (bookNow != null)
                {

                    bookNow.SelectedRoomId = clickedDto.RoomId;
                    bookNow.SelectedCheckInDate = clickedDto.BoxDate!.Value;
                    bookNow.MdiParent = this.MdiParent;

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

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpFromDate.Value;
            DateTime endDate = dtpTodate.Value;
            
            TimeSpan timeDifference = endDate.Subtract(startDate);
            var dayscount = timeDifference.TotalDays;

            if (dayscount > 31)
            {
                MessageBox.Show("Plsease select 30 days time", "Days limit exceed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await PopulateGridData();
        }
    }
}
