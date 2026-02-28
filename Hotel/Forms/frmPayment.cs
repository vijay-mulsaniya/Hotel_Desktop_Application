using Hotel.Common;
using Hotel.Data;
using Hotel.Dtos;
using Hotel.Dtos.PaymentDtos;
using Hotel.Models;
using Hotel.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private bool _isLoadingDetails = false;

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
            try
            {
                _isLoadingDetails = true;
                grdBilling.AutoGenerateColumns = false;
                AddBillingGridColumns();
                AddDetailsGridColumns();
                AddPaymentGridColumns();
                ApplyPermissions();

                _allBillingData = await paymentService.BillingGrid();
                grdBilling.DataSource = _allBillingData;

                if (CurrentBookingID > 0)
                {
                    foreach (DataGridViewRow row in grdBilling.Rows)
                    {
                        if (row.DataBoundItem is BillingDto dto && dto.BookingMasterID == CurrentBookingID)
                        {
                            grdBilling.CurrentCell = row.Cells[2];
                            row.Selected = true;
                            _currentBookingMasterID = dto.BookingMasterID;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on payment page load\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoadingDetails = false;

                if (grdBilling.CurrentRow != null)
                {
                    grdBilling_SelectionChanged(this, EventArgs.Empty);
                }
            }
        }
        private async Task RefreshMainGridAsync()
        {
            await _lock.WaitAsync();
            try
            {
                _allBillingData = await paymentService.BillingGrid();
                grdBilling.DataSource = null;
                grdBilling.DataSource = _allBillingData;
                if (_currentBookingMasterID > 0)
                {
                    foreach (DataGridViewRow row in grdBilling.Rows)
                    {
                        if (row.DataBoundItem is BillingDto dto && dto.BookingMasterID == _currentBookingMasterID)
                        {
                            grdBilling.CurrentCell = row.Cells[2]; // Focus on Guest Name
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}");
            }
            finally
            {
                _lock.Release();
            }
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
                FillWeight = 55,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
            });
            gridRoomDetail.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FillWeight = 55,
                Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager")
            });
            gridRoomDetail.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colCheckout",
                HeaderText = "Action", // Use the same header as Edit/Delete to group them
                Text = "Checkout",
                UseColumnTextForButtonValue = false, // Set to false so CellFormatting can control text
                FillWeight = 70,
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

        private void UpdatePaymentLabels(BillingDto summary, List<RoomBookingDto> details)
        {
            lblInvoiceNumber.Text = summary.InvoiceNumber;
            lblGuestName.Text = summary.GuestName;
            lblTotalAmount.Text = summary.PayableAmount.ToString("C0");
            lblPaidAmount.Text = summary.Paid.ToString("C0");

            decimal pendingAmount = summary.Pending;
            decimal taxAmount = 0;

            if (summary.IsGSTApplicable)
            {
                // Calculate tax based on room total minus discount
                var lineItemSum = details.Sum(x => x.Amount);
                var afterDiscountTotal = lineItemSum - summary.Discount;
                taxAmount = afterDiscountTotal * 5 / 100;

                pendingAmount += taxAmount;
            }

            lblTaxAmount.Text = taxAmount.ToString("C2");
            lblPendingAmount.Text = pendingAmount.ToString("C0");
            lblPendingAmount.ForeColor = pendingAmount > 0 ? Color.Red : Color.Green;
        }

        private async void grdBilling_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoadingDetails || grdBilling.CurrentRow == null) return;
            await _lock.WaitAsync();

            try
            {
                _isLoadingDetails = true;

                if (grdBilling.CurrentRow?.DataBoundItem is BillingDto row)
                {
                    _currentBookingMasterID = row.BookingMasterID;

                    var roomsTask = paymentService.RoomBookings(_currentBookingMasterID);
                    var paymentsTask = paymentService.GetPaymentDetails(_currentBookingMasterID);

                    await Task.WhenAll(roomsTask, roomsTask); // Run both queries at once

                    var roomData = await roomsTask ?? new List<RoomBookingDto>();
                    var paymentData = await paymentsTask ?? new List<PaymentDetailsDto>();

                    gridRoomDetail.DataSource = roomData;
                    grdPaymentDetail.DataSource = paymentData;

                    UpdatePaymentLabels(row, roomData);
                    fillRoomsCombo(roomData);

                    await invoiceModelPopup(row, roomData, paymentData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading details: {ex.Message}");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _isLoadingDetails = false;
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
            searchTimer.Stop();
            searchTimer.Start();
        }
        private void ApplyFilter()
        {
            string searchText = txtSearch.Text.Trim();

            var filtered = string.IsNullOrWhiteSpace(searchText)
                ? _allBillingData
                : _allBillingData.Where(x => x.GuestName.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();

            _isLoadingDetails = true;

            grdBilling.DataSource = null;
            grdBilling.DataSource = filtered;

            if (_currentBookingMasterID > 0)
            {
                foreach (DataGridViewRow row in grdBilling.Rows)
                {
                    if (row.DataBoundItem is BillingDto dto && dto.BookingMasterID == _currentBookingMasterID)
                    {
                        row.Selected = true;
                        grdBilling.CurrentCell = row.Cells[2]; // Focus back to Guest Name
                        break;
                    }
                }
            }

            _isLoadingDetails = false;
        }
        private async void btnAddPayment_Click(object sender, EventArgs e)
        {
            bool lockAcquired = false;

            try
            {
                await _lock.WaitAsync();
                lockAcquired = true;

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
                    _lock.Release();
                    lockAcquired = false;

                    txtAmount.Clear();
                    cmbPaymentMethod.SelectedIndex = 0;
                    txtOnlineRefNumber.Clear();

                    txtSearch.Focus();
                    MessageBox.Show("Payment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await RefreshMainGridAsync();
                }
                else
                {
                    MessageBox.Show("Failed to add payment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while add payment button click" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (lockAcquired) _lock.Release();
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

            if (columnName == "colEdit")
            {
                using (var frm = new FrmRoomBookingEdit())
                {
                    frm.BookingData = row;
                    frm.StartPosition = FormStartPosition.CenterParent;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await RefreshMainGridAsync();
                    }
                }
            }
            else if (columnName == "colDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await _lock.WaitAsync();
                    try
                    {
                        var success = await paymentService.DeleteRoomBookingAsync(row.ID);
                        if (success) MessageBox.Show("Deleted Successfully");
                    }
                    finally
                    {
                        _lock.Release(); // 2. Release lock so Refresh can start
                    }

                    await RefreshMainGridAsync();
                }
            }
            else if (columnName == "colCheckout")
            {
                var rowData = gridRoomDetail.Rows[e.RowIndex].DataBoundItem as RoomBookingDto;
                if (rowData != null && rowData.CheckoutButton)
                {
                    await ProcessRoomCheckout(rowData.ID);
                    MessageBox.Show($"Checkout for Room {rowData.RoomNumber}", "Checkout Done.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void grdBilling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = grdBilling.Rows[e.RowIndex].DataBoundItem as BillingDto;
            if (row == null) return;
            string columnName = grdBilling.Columns[e.ColumnIndex].Name;

            if (columnName == "colEdit" || columnName == "colDelete")
            {
                if (columnName == "colDelete")
                {
                    var confirm = MessageBox.Show("Delete Invoice and ALL related data?", "Warning", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        await _lock.WaitAsync();
                        try
                        {
                            var success = await paymentService.DeleteInvoiceMasterAsync(row.ID);
                            if (success)
                            {
                                _currentBookingMasterID = 0; // Clear selection
                                MessageBox.Show("Invoice and all related data deleted.");
                            }
                        }
                        finally
                        {
                            _lock.Release();
                        }

                        await RefreshMainGridAsync();
                    }
                }
                else // Edit
                {
                    using (var frm = new FrmRoomBookingMasterEdit(paymentService))
                    {
                        frm.Data = row;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            await RefreshMainGridAsync();
                        }
                    }
                }
            }
        }
        private async void grdPaymentDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                var confirm = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await _lock.WaitAsync();
                    try
                    {
                        var success = await paymentService.DeletePaymentsAsync(row.ID);
                        if (success) MessageBox.Show("Deleted Successfully");
                    }
                    finally
                    {
                        _lock.Release();
                    }

                    await RefreshMainGridAsync();
                }
            }

        }
        private void gridRoomDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (gridRoomDetail.Columns[e.ColumnIndex].Name == "colCheckout")
            {
                var rowData = gridRoomDetail.Rows[e.RowIndex].DataBoundItem as RoomBookingDto;
                if (rowData != null)
                {
                    // If it's the last row, show "Checkout", otherwise leave it blank
                    e.Value = rowData.CheckoutButton ? "Checkout" : "";
                }
            }
        }
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        public async Task ProcessRoomCheckout(int roomBookingId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var lastNightEntry = db.RoomBookings.Include(x => x.Room)
                                           .Where(rb => rb.ID == roomBookingId)
                                           .FirstOrDefault();

                    if (lastNightEntry != null)
                    {
                        lastNightEntry.IsCheckedOut = true;
                        lastNightEntry.Room!.IsAvailable = true; // Make the room available immediately for new bookings
                        lastNightEntry.ActualCheckOutTime = DateTime.UtcNow.GetIndianTime(); // Records the exact moment

                        // 3. Mark as Dirty (Needs cleaning)
                        lastNightEntry.IsCleaned = false;

                        db.SaveChanges();
                        await RefreshMainGridAsync();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while process room checkout", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
