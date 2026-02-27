using Hotel.Common;
using Hotel.Dtos.PaymentDtos;
using Hotel.Models;
using Hotel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class FrmPaymentEdit : Form
    {
        private readonly IPaymentService paymentService;
        private PaymentDetailsDto _data = null!;
        public FrmPaymentEdit(IPaymentService paymentService)
        {
            InitializeComponent();
            this.paymentService = paymentService;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PaymentDetailsDto Data
        {
            get => _data;
            set => _data = value;
        }

        private async void FrmPaymentEdit_Load(object sender, EventArgs e)
        {
            dtpPaymentDate.Value = _data.PaymentDate;

            cmbPaymentMethods.Items.Clear();
            cmbPaymentMethods.DataSource = Enum.GetValues(typeof(PaymentMethod))
                                            .Cast<PaymentMethod>()
                                            .Select(e => new {
                                                Value = e,
                                                DisplayName = CommonMethods.GetEnumDescription(e)
                                            }).ToList();

            cmbPaymentMethods.DisplayMember = "DisplayName";
            cmbPaymentMethods.ValueMember = "Value";

            cmbRoom.DataSource = await paymentService.RoomsByInvoice(_data.BookingMasterID);
            cmbRoom.DisplayMember = "DisplayName";
            cmbRoom.ValueMember = "ID";
            cmbRoom.SelectedValue = _data.RoomID!;

            txtAmountPaid.Text = _data.Amount.ToString();
            txtOnlineRefNumber.Text = _data.OnlineTransactionRefNumber;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentDetailsDto modal = new PaymentDetailsDto
                {
                    ID = _data.ID,
                    BookingMasterID = _data.BookingMasterID,
                    Amount = txtAmountPaid.Text == "" ? 0 : Convert.ToDecimal(txtAmountPaid.Text),
                    PaymentDate = dtpPaymentDate.Value,

                    PaymentMethod = cmbPaymentMethods.SelectedValue != null
                                        ? (PaymentMethod)cmbPaymentMethods.SelectedValue
                                        : PaymentMethod.Cash,

                    OnlineTransactionRefNumber = txtOnlineRefNumber.Text,
                    RoomID = _data.RoomID,
                };

                var result = paymentService.EditPayments(modal);

                MessageBox.Show("Save Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while paymet edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
