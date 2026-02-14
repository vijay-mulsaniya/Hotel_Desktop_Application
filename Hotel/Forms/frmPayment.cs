using Hotel.Common;
using Hotel.Dtos;
using Hotel.Dtos.PaymentDtos;
using Hotel.Models;
using Hotel.Services;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class frmPayment : Form
    {
        private readonly IPaymentService paymentService;
        private List<BillingDto> _allBillingData = new List<BillingDto>();
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private int _currentBookingMasterID = 0;
        private static int HotelID = 1;
        private BookingInvoiceDto invoiceModel = null!;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentBookingID
        {
            get => _currentBookingMasterID;
            set => _currentBookingMasterID = value;
        }

        public frmPayment(IPaymentService paymentService)
        {
            InitializeComponent();
            this.paymentService = paymentService;
        }

        private async void frmPayment_Load(object sender, EventArgs e)
        {
            grdBilling.AutoGenerateColumns = false;
            AddBillingGridColumns();
            _allBillingData = await paymentService.BillingGrid();
            grdBilling.DataSource = _allBillingData;
            AddDetailsGridColumns();
            AddPaymentGridColumns();

            foreach (DataGridViewRow row in grdBilling.Rows)
            {
                if (Convert.ToInt32(row.Cells[1].Value) == CurrentBookingID)
                {
                    grdBilling.CurrentCell = row.Cells[3];
                    row.Selected = true;
                    break;
                }
            }
        }

        private void AddBillingGridColumns()
        {
            grdBilling.Columns.Clear();
            grdBilling.RowHeadersVisible = false;
            grdBilling.MultiSelect = false;
            grdBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grdBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookingMasterID",
                HeaderText = "Booking MasterID",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceNumber",
                HeaderText = "Invoice Number",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GuestName",
                HeaderText = "Guest Name",
                FillWeight = 280
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BillDate",
                HeaderText = "Bill Date",
                FillWeight = 130
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C0"
                }
            });
            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Discount",
                HeaderText = "Discount",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C0"
                }
            });
            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PayableAmount",
                HeaderText = "Payable Amount",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C0"
                }
            });
            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Paid",
                HeaderText = "Paid",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C0"
                }
            });
            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Pending",
                HeaderText = "Pending",
                ValueType = typeof(decimal),
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C0"
                },
                SortMode = DataGridViewColumnSortMode.Automatic
            });

        }
        private void AddDetailsGridColumns()
        {
            gridRoomDetail.Columns.Clear();
            gridRoomDetail.RowHeadersVisible = false;
            gridRoomDetail.MultiSelect = false;
            gridRoomDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRoomDetail.AutoGenerateColumns = false;
            gridRoomDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Visible = false
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HotelID",
                HeaderText = "Hotel ID",
                Visible = false
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookingMasterID",
                HeaderText = "Booking Master ID",
                Visible = false
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomID",
                HeaderText = "Room ID",
                Visible = false
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Guest ID",
                HeaderText = "Guest ID",
                Visible = false
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GuestName",
                HeaderText = "Guest Name",
                FillWeight = 150
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomNumber",
                HeaderText = "Room Number",
                FillWeight = 80
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomTitle",
                HeaderText = "Room Title",
                FillWeight = 100
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Date",
                FillWeight = 110
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NightStaySymbol",
                HeaderText = "Night",
                FillWeight = 30
            });

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AdultCount",
                HeaderText = "Adult",
                FillWeight = 30,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
            });
            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ChildCount",
                HeaderText = "Child",
                FillWeight = 30,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
            });
            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Amount",
                ValueType = typeof(decimal),
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C0"
                },
            });
        }
        private void AddPaymentGridColumns()
        {
            grdPaymentDetail.Columns.Clear();
            grdPaymentDetail.RowHeadersVisible = false;
            grdPaymentDetail.MultiSelect = false;
            grdPaymentDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdPaymentDetail.AutoGenerateColumns = false;
            grdPaymentDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Visible = false
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookingMasterID",
                HeaderText = "Booking MasterID",
                Visible = false
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomBookingID",
                HeaderText = "RoomBooking ID",
                Visible = false
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceNumber",
                HeaderText = "Invoice Number"
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentDate",
                HeaderText = "Payment Date"
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Amount Paid"
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomNumber",
                HeaderText = "Room Number",
                Width = 80
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentMethod",
                HeaderText = "Payment By"
            });

            grdPaymentDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OnlineTransactionRefNumber",
                HeaderText = "Pay.Rf Number"
            });
        }

        private async void grdBilling_SelectionChanged(object sender, EventArgs e)
        {
            await _lock.WaitAsync();

            try
            {
                await Task.Delay(200);
                if (grdBilling.CurrentRow?.DataBoundItem is BillingDto row)
                {
                    if (row.BookingMasterID == 0) return;
                    lblInvoiceNumber.Text = row.InvoiceNumber;
                    lblGuestName.Text = row.GuestName;
                    _currentBookingMasterID = row.BookingMasterID;
                    lblTotalAmount.Text = row.PayableAmount.ToString("C0");
                    lblPaidAmount.Text = row.Paid.ToString("C0");
                    lblPendingAmount.Text = row.Pending.ToString("C0");
                    lblPendingAmount.ForeColor = row.Pending > 0 ? Color.Red : Color.Green;

                    var data = await paymentService.RoomBookings(row.BookingMasterID);
                    gridRoomDetail.DataSource = data;

                    fillRoomsCombo(data);

                    var paymentData = await paymentService.GetPaymentDetails(_currentBookingMasterID);
                    grdPaymentDetail.DataSource = paymentData;

                    await invoiceModelPopup(row, data, paymentData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task invoiceModelPopup(BillingDto billingSummary, List<RoomBookingDto> roomDetails, List<PaymentDetailsDto> payments)
        {
            invoiceModel = new BookingInvoiceDto
            {
                InvoiceNumber = billingSummary.InvoiceNumber!,
                InvoiceDate = DateTime.Now,
                GuestName = billingSummary.GuestName,
               
                HotelName = "Hotel Comfort",
                HotelStateCode = "GJ", 
                GuestStateCode = "GJ", 

                RoomBookings = roomDetails,
                Payments = payments,

                IsGSTApplicable = true,
                IsTaxInclusive = false, // Set based on your business logic
                Discount = 0 // Map if you have a discount field in BillingDto
            };
        }

        private void fillRoomsCombo(List<RoomBookingDto> bookingDetail)
        {
            var distinctRooms = bookingDetail
                                 .GroupBy(x => new { x.RoomID, x.RoomNumber, x.RoomTitle })
                                 .Select(g => new ListboxItemAvailableRooms
                                 {
                                     ID = g.Key.RoomID,
                                     RoomNumber = g.Key.RoomNumber,
                                     DisplayName = g.Key.RoomNumber + " - " + g.Key.RoomTitle,
                                     IsCheckoutToday = false
                                 })
                                 .OrderBy(r => r.RoomNumber)
                                 .ToList();

            cmbRoomNumber.DataSource = distinctRooms;
            cmbRoomNumber.DisplayMember = "DisplayName";
            cmbRoomNumber.ValueMember = "ID";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filtered = _allBillingData
                           .Where(x => x.GuestName
                           .Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase))
                           .ToList();

            grdBilling.DataSource = filtered;
        }

        private async void btnAddPayment_Click(object sender, EventArgs e)
        {
            var paymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";

            PaymentMethod pmt = paymentMethod switch
            {
                "Cash" => PaymentMethod.Cash,
                "Online Transfer" => PaymentMethod.OnlinePayment,
                "Credit Card" => PaymentMethod.CreditCard,
                "Debit Card" => PaymentMethod.DebitCard,
                _ => PaymentMethod.Cash
            };

            int selectedRoomId = 0;
            if (cmbRoomNumber.SelectedValue is int roomId)
                selectedRoomId = roomId;

            if (selectedRoomId <= 0)
            {
                MessageBox.Show("Please select room for payment", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = await paymentService.AddPayment(new PaymentDetailsDto
            {
                HotelID = HotelID,
                RoomID = selectedRoomId,
                BookingMasterID = _currentBookingMasterID,
                Amount = Convert.ToDecimal(txtAmount.Text),
                PaymentDate = DateTime.UtcNow.GetIndianTime(),
                PaymentMethod = pmt,
                OnlineTransactionRefNumber = txtOnlineRefNumber.Text
            });

            if (result != null)
            {
                txtAmount.Clear();
                cmbPaymentMethod.SelectedIndex = 0;
                txtOnlineRefNumber.Clear();

                txtSearch.Focus();
                MessageBox.Show("Payment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPayment_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Failed to add payment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowInvoice_Click(object sender, EventArgs e)
        {
            if (invoiceModel == null)
            {
                MessageBox.Show("Please select a billing record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new frmInvoice(invoiceModel);
            frm.ShowDialog();
        }
    }
}
