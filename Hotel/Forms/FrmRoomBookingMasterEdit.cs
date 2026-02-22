using Hotel.Dtos.PaymentDtos;
using Hotel.Services;
using System.ComponentModel;
using System.Data;

namespace Hotel.Forms
{
    public partial class FrmRoomBookingMasterEdit : Form
    {
        private BillingDto _data = null!;
        private readonly IPaymentService paymentService;

        public FrmRoomBookingMasterEdit(IPaymentService paymentService)
        {
            InitializeComponent();
            this.paymentService = paymentService;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BillingDto Data
        {
            get => _data;
            set => _data = value;
        }

        private async void FrmRoomBookingMasterEdit_Load(object sender, EventArgs e)
        {
            dtpInvoiceDate.Format = DateTimePickerFormat.Custom;
            dtpInvoiceDate.CustomFormat = "dd/MM/yyyy hh:mm tt";

            await FillGuestComboBox();
            await FillStateComboBox();
            txtInvoiceNumber.Text = _data.InvoiceNumber;
            dtpInvoiceDate.Value = _data.BillDate;
            txtDiscount.Text = _data.Discount.ToString();
            cmbGuestList.SelectedValue = _data.GuestID;

            chkTaxApply.Checked = _data.IsGSTApplicable;
            chkIsTaxInclusive.Checked = _data.IsTaxInclusive;
            chkInputTaxCredit.Checked = _data.InputTaxCredit;

        }

        private async Task FillStateComboBox()
        {
            var stateData = await paymentService.GuestStates();
            cmbGuestState.DataSource = null;
            cmbGuestState.DataSource = stateData.Select(x => new { x.stateName, x.stateCode }).ToList();
            cmbGuestState.ValueMember = "stateCode";
            cmbGuestState.DisplayMember = "stateName";
            cmbGuestState.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbGuestState.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbGuestState.SelectedValue = _data.GuestStateCode;
        }

        private async Task FillGuestComboBox()
        {
            var guetsList = await paymentService.Guests();
            cmbGuestList.Items.Clear();
            cmbGuestList.DisplayMember = "DisplayName";
            cmbGuestList.ValueMember = "ID";
            cmbGuestList.DataSource = guetsList;
            cmbGuestList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbGuestList.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            BillingDto editInvoice = new BillingDto
            {
                ID = _data.ID,
                BookingMasterID = _data.BookingMasterID,
                InvoiceNumber = txtInvoiceNumber.Text,
                GuestName = lblGuestName.Text,
                GuestID = (int)cmbGuestList.SelectedValue!,
                GuestStateCode = cmbGuestState.SelectedValue!.ToString()!,
                BillDate = dtpInvoiceDate.Value,
                Discount = txtDiscount.Text == "" ? 0M : Convert.ToDecimal(txtDiscount.Text),
                InputTaxCredit = chkInputTaxCredit.Checked,
                HotelStateCode = _data.HotelStateCode,
                IsGSTApplicable = chkTaxApply.Checked,
                IsTaxInclusive = chkIsTaxInclusive.Checked
            };

            try
            {
                bool result = await paymentService.EditInvoiceMaster(editInvoice);
                if (result) {
                    MessageBox.Show("Invoice update success !", "Invoice Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTaxApply_CheckedChanged(object sender, EventArgs e)
        {
            chkTaxApply.Text = chkTaxApply.Checked ? "Yes" : "No";
        }
        private void chkInputTaxCredit_CheckedChanged(object sender, EventArgs e)
        {
            chkInputTaxCredit.Text = chkInputTaxCredit.Checked ? "Yes" : "No";
        }
        private void chkIsTaxInclusive_CheckedChanged(object sender, EventArgs e)
        {
            chkIsTaxInclusive.Text = chkIsTaxInclusive.Checked ? "Yes" : "No";
        }
        private void cmbGuestList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGuestList.SelectedItem is GuestComboBoxItem selectedGuest)
            {
                lblGuestName.Text = selectedGuest.DisplayName;
            }
        }
    }
}
