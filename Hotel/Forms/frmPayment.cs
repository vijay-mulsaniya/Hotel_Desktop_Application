using Hotel.Common;
using Hotel.Dtos;
using Hotel.Dtos.PaymentDtos;
using Hotel.Models;
using Hotel.Services;
using Microsoft.Data.SqlClient;
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
            gridRoomDetail.CellContentClick += gridRoomDetail_CellContentClick!;
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
                    grdBilling.CurrentCell = row.Cells[10]; // any visible cell to select the row....
                    row.Selected = true;
                    break;
                }
            }

            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            // Example: Only Admins can see the Settings button
            btnAddPayment.Enabled = AppSession.IsInRole("Admin");
        }

        #region Grid Column Generation

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
                DataPropertyName = "GuestName",
                HeaderText = "Guest Name",
                FillWeight = 280
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceNumber",
                HeaderText = "Invoice Number",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GuestStateCode",
                HeaderText = "Guest State Code",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HotelStateCode",
                HeaderText = "Hotel State Code",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsGSTApplicable",
                HeaderText = "Is GST Applicable",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsTaxInclusive",
                HeaderText = "Is Tax Inclusive",
                Visible = false
            });

            grdBilling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InputTaxCredit",
                HeaderText = "Input Tax Credit",
                Visible = false
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

            grdBilling.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "Action",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                FillWeight = 60,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
            });

            grdBilling.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FillWeight = 60,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
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

            gridRoomDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TaxPercentage",
                HeaderText = "Tax Percentage",
                Visible = false
            });

            gridRoomDetail.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "Action",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                FillWeight = 60,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
            });
            gridRoomDetail.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FillWeight = 60,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
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
                DataPropertyName = "RoomID",
                HeaderText = "Room ID",
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

            grdPaymentDetail.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "Action",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                FillWeight = 60,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
            });
            grdPaymentDetail.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FillWeight = 60,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
            });
        }
        #endregion

        private void DeleteRoomBooking(int id)
        {
            try
            {
                string query = "DELETE FROM RoomBookings WHERE ID = @ID";

                using (SqlConnection con = new SqlConnection(CommonMethods.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while delete room booking", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteInvoiceMaster(int id)
        {
            string query = @"
                    DELETE FROM Payments WHERE BookingMasterID = @ID;
                    DELETE FROM RoomBookings WHERE BookingMasterID = @ID;
                    DELETE FROM BookingMasters WHERE ID = @ID;";

            using (SqlConnection con = new SqlConnection(CommonMethods.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        cmd.Transaction = transaction;
                        int rowsAffected = cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error occurred: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeletePayments(int id)
        {
            try
            {
                string query = "DELETE FROM Payments WHERE ID = @ID";

                using (SqlConnection con = new SqlConnection(CommonMethods.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while delete payments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void grdBilling_SelectionChanged(object sender, EventArgs e)
        {
            await _lock.WaitAsync();

            try
            {

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

                    if (row.IsGSTApplicable)
                    {
                        var discount = row.Discount;
                        var lineItemSum = data.Sum(x => x.Amount);
                        var afterDiscountTotal = lineItemSum - discount;
                        var taxAmount = afterDiscountTotal * 5 / 100;

                        lblTaxAmount.Text = taxAmount.ToString("C2");
                        lblPendingAmount.Text = (row.Pending + taxAmount).ToString("C0");
                    }

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
                GuestStateCode = billingSummary.GuestStateCode,

                RoomBookings = roomDetails,
                Payments = payments,

                IsGSTApplicable = billingSummary.IsGSTApplicable,
                IsTaxInclusive = billingSummary.IsTaxInclusive,
                Discount = billingSummary.Discount
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
            try
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
            catch (Exception)
            {
                MessageBox.Show("Error while add payment button click", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void gridRoomDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = gridRoomDetail.Rows[e.RowIndex].DataBoundItem as RoomBookingDto;
            if (row == null) return;

            string columnName = gridRoomDetail.Columns[e.ColumnIndex].Name;

            // ================= EDIT =================
            if (columnName == "colEdit")
            {
                using (var frm = new FrmRoomBookingEdit())
                {
                    frm.BookingData = row;
                    frm.StartPosition = FormStartPosition.CenterParent;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frmPayment_Load(sender, e);
                    }
                }
            }

            // ================= DELETE =================
            else if (columnName == "colDelete")
            {
                var confirm = MessageBox.Show(
                     "Are you sure you want to delete this booking?",
                     "Confirm Delete",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    DeleteRoomBooking(row.ID);
                    MessageBox.Show("Deleted Successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    frmPayment_Load(sender, e);
                }
            }

        }
        private void grdBilling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = grdBilling.Rows[e.RowIndex].DataBoundItem as BillingDto;
            if (row == null) return;
            string columnName = grdBilling.Columns[e.ColumnIndex].Name;

            if (columnName == "colEdit")
            {
                using (var frm = new FrmRoomBookingMasterEdit(paymentService))
                {
                    frm.Data = row;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frmPayment_Load(sender, e);
                    }
                }
            }

            else if (columnName == "colDelete")
            {
                var confirm = MessageBox.Show(
                   "Are you sure you want to delete this Invoice?,\nAll **Peyments**, and **Room bookings** releated to this invoce will be delted.",
                   "Confirm Delete",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    DeleteInvoiceMaster(row.ID);
                    MessageBox.Show("Deleted Successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    frmPayment_Load(sender, e);
                }
            }


        }
        private void grdPaymentDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = grdPaymentDetail.Rows[e.RowIndex].DataBoundItem as PaymentDetailsDto;
            if (row == null) return;
            string columnName = grdPaymentDetail.Columns[e.ColumnIndex].Name;

            if (columnName == "colEdit")
            {
                using (var frm = new FrmPaymentEdit(paymentService))
                {
                    frm.Data = row;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frmPayment_Load(sender, e);
                    }
                }
            }

            else if (columnName == "colDelete")
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this booking?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    DeletePayments(row.ID);
                    MessageBox.Show("Deleted Successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    frmPayment_Load(sender, e);
                }
            }

        }
    }
}
