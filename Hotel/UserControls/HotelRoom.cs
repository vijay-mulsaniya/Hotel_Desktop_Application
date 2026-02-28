using Hotel.Data;
using Hotel.Forms;
using Hotel.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

namespace Hotel.UserControls
{
    public partial class HotelRoom : UserControl
    {
        private int? _bookingMasterId;
        private bool _isCheckOutCard;
        public HotelRoom()
        {
            InitializeComponent();
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
        public string GuestName
        {
            get => lblGuestName.Text;
            set => lblGuestName.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal TotalAmount
        {
            get => decimal.Parse(lblTotalAmount.Text.TrimStart('₹'));
            set => lblTotalAmount.Text = "₹" + value.ToString("F2");
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal PaidAmount
        {
            get => decimal.Parse(lblPaidAmount.Text.TrimStart('₹'));
            set => lblPaidAmount.Text = "₹" + value.ToString("F2");
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal PendingAmount
        {
            get => decimal.Parse(lblPendingAmount.Text.TrimStart('₹'));
            set => lblPendingAmount.Text = "₹" + value.ToString("F2");
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? NightCount
        {
            get => Convert.ToInt32(lblNightCount.Text);
            set => lblNightCount.Text = value.ToString();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? BookingMasterId
        {
            get => _bookingMasterId;
            set => _bookingMasterId = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? RoomId
        {
            get => Convert.ToInt32(lblRoomId.Text);
            set => lblRoomId.Text = value.ToString();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? CheckinDate
        {
            get => Convert.ToDateTime(lblCheckinDate.Text);
            set => lblCheckinDate.Text = value?.ToString("ddd, dd-MM-yyyy");
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? CheckoutDate
        {
            get => Convert.ToDateTime(lblCheckoutDate.Text);
            set => lblCheckoutDate.Text = value?.ToString("ddd, dd-MM-yyyy");
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCheckOutCard
        {
            get => _isCheckOutCard;
            set
            {
                _isCheckOutCard = value;
                UpdateStatusUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PersonCount
        {
            get => lblPersonCount.Text;
            set => lblPersonCount.Text = value;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var factory = Program.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
            IPaymentService service = new PaymentService(factory);
            using (frmPayment paymentForm = new frmPayment(service))
            {
                paymentForm.CurrentBookingID = BookingMasterId ?? 0;
                paymentForm.StartPosition = FormStartPosition.CenterParent;
                paymentForm.WindowState = FormWindowState.Maximized;
               
                DialogResult result = paymentForm.ShowDialog();
            }
        }

        private void UpdateStatusUI()
        {
            if (_isCheckOutCard)
            {
                // High visibility for rooms leaving today
                this.BackColor = Color.FromArgb(255, 255, 235, 238); // Very light red/pink background
                lblRoomNumber.BackColor = Color.Maroon;
                lblRoomNumber.ForeColor = Color.White;

                // Optional: Add a "Checking Out" label or change a border
                // lblStatusIndicator.Text = "CHECKING OUT";
                // lblStatusIndicator.Visible = true;
            }
            else
            {
                //this.BackColor = Color.White;
                //lblRoomNumber.BackColor = Color.SeaGreen; // Or your default booked color
                //lblRoomNumber.ForeColor = Color.White;
            }
        }

    }
}
