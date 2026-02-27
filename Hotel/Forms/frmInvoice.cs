using Hotel.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class frmInvoice : Form
    {
        
        private BookingInvoiceDto _invoice;

        public frmInvoice(BookingInvoiceDto invoiceDto)
        {
            InitializeComponent();
            _invoice = invoiceDto;
        }
        private async void frmInvoice_Load(object sender, EventArgs e)
        {

            await webView21.EnsureCoreWebView2Async();

            string finalHtml = GetHtmlTemplate(_invoice);
            webView21.NavigateToString(finalHtml);
        }


        public async void LoadInvoice(BookingInvoiceDto dto)
        {
            string filepath = "D:\\projects\\Hotel Software Screens\\HotelDeskTop\\Hotel\\Hotel\\Reports\\Invoice.html";

            string html = File.ReadAllText(filepath);
            //string html = File.ReadAllText(Path.Combine(Application.StartupPath, "Reports", "Invoice.html"));

            StringBuilder rowsHtml = new StringBuilder();
            foreach (var room in dto.RoomBookings)
            {
                rowsHtml.Append("<tr>");
                rowsHtml.Append($"<td>{room.RoomTitle} - Room {room.RoomNumber}</td>");
                rowsHtml.Append($"<td>{dto.SACCode}</td>");
                rowsHtml.Append($"<td>{room.Date:dd-MM-yyyy}</td>");
                rowsHtml.Append($"<td>{room.Amount:N2}</td>");
                rowsHtml.Append("</tr>");
            }

            html = html.Replace("{{HotelName}}", dto.HotelName)
                       .Replace("{{HotelStateCode}}", dto.HotelStateCode)
                       .Replace("{{GuestName}}", dto.GuestName)
                       .Replace("{{GuestStateCode}}", dto.GuestStateCode)
                       .Replace("{{InvoiceNumber}}", dto.InvoiceNumber)
                       .Replace("{{InvoiceDate}}", dto.InvoiceDate.ToString("dd-MMM-yyyy"))
                       .Replace("{{RoomRows}}", rowsHtml.ToString())
                       .Replace("{{GSTPercentage}}", dto.GSTPercentage.ToString())
                       .Replace("{{TaxableAmount}}", dto.AmountAfterDiscount.ToString("N2"))
                       .Replace("{{GSTAmount}}", dto.GSTAmount.ToString("N2"))
                       .Replace("{{NetPayable}}", dto.NetPayableAmount.ToString("N2"));

            await webView21.EnsureCoreWebView2Async();
            webView21.NavigateToString(html);
        }

        private string GetHtmlTemplate(BookingInvoiceDto dto)
        {
            StringBuilder rows = new StringBuilder();
            foreach (var rb in dto.RoomBookings)
            {
                rows.Append($@"
            <tr>
                <td>{rb.RoomNumber}: {rb.RoomTitle} </td>
                <td style='text-align:center;'>{dto.SACCode}</td>
                <td style='text-align:center;'>{rb.Date:dd-MMM-yyyy}</td>
                <td style='text-align:center;'>A: {rb.AdultCount}, C:{rb.ChildCount}</td>
                <td style='text-align:right;'>{rb.Amount:N2}</td>
            </tr>");
            }

            decimal totalPayments = 0;
            decimal grossAmount = dto.GrossAmount;
            if (dto.IsTaxInclusive)
            {
                grossAmount = dto.GrossAmount - dto.GSTAmount;
            }

            StringBuilder paymentRows = new StringBuilder();
            foreach (var p in dto.Payments)
            {
                totalPayments += p.Amount;
                paymentRows.Append($@"
            <tr>
               
                <td style='text-align:center;'>{p.PaymentDate}</td>
                <td style='text-align:right;'>{p.Amount:N2}</td>
            </tr>");
            }


            // Determine GST Breakdown
            string gstDetails = "";
            if (dto.IsInterState)
            {
                gstDetails = $"<tr><td colspan='3' style='text-align:right;'>IGST ({dto.GSTPercentage}%):</td><td style='text-align:right;'>{dto.IGSTAmount:N2}</td></tr>";
            }
            else
            {
                decimal halfRate = dto.GSTPercentage / 2;
                gstDetails = $@"
            <tr><td colspan='3' style='text-align:right;'>CGST ({halfRate}%):</td><td style='text-align:right;'>{dto.CGSTAmount:N2}</td></tr>
            <tr><td colspan='3' style='text-align:right;'>SGST ({halfRate}%):</td><td style='text-align:right;'>{dto.SGSTAmount:N2}</td></tr>";
            }

            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', sans-serif; margin: 20px; }}
        .header {{ text-align: center; border-bottom: 2px solid #000; padding-bottom: 10px; line-height: 0.5; }}
        .meta-info {{ display: flex; justify-content: space-between; margin-top: 20px; }}
        table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }}
        th {{ background: #f2f2f2; border: 1px solid #000; padding: 8px; }}
        td {{ border: 1px solid #000; padding: 8px; }}
        .footer-table {{ margin-top: 10px;  margin-left: auto; }}
        @media print {{ .no-print {{ display: none; }} }}
    </style>
</head>
<body>
    <div class='header'>
        <h1>{dto.HotelName}</h1>
        <p>Plot No:69, Ambika Nagar Society, Opp. Radhey Residency, Icchapore-3</p>
        <p>Gujarat, 394510, Ichhapore Surat. 394510, India.</p>
        <p>Phone: 72799 77977, Email: drajani09@gmail.com</p>
        <p>State Code: {dto.HotelStateCode}</p>
    </div>

    <div class='meta-info'>
        <div>
            <strong>Bill To:</strong> {dto.GuestName}<br/>
            <strong>State Code:</strong> {dto.GuestStateCode}
        </div>
        <div style='text-align:right;'>
            <strong>Invoice #:</strong> {dto.InvoiceNumber}<br/>
            <strong>Date:</strong> {dto.InvoiceDate:dd-MMM-yyyy}
        </div>
    </div>

    <table>
        <thead>
            <tr>
                <th>Description</th>
                <th>SAC</th>
                <th>Date</th>
                <th>PAX</th>
                <th>Amount (₹)</th>
            </tr>
        </thead>
        <tbody>
            {rows}
        </tbody>
    </table>

    <div class='meta-info'>
        <div>
            <table>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Payment</th>
                    </tr>
                </thead>
                <tbody>
                    {paymentRows}
                    <tr>
                        <th style='text-align:right;'><strong>Total</strong></th>
                        <th style='text-align:right;'>{totalPayments:C2}</th>
                    </tr>
                </tbody>
                
             </table>
        </div>
        <div>
            <table class='footer-table'>
                <tr>
                    <td colspan='3' style='text-align:right;'>Gross Amount:</td>
                    <td style='text-align:right;'>{grossAmount:N2}</td>
                </tr>
                <tr>
                    <td colspan='3' style='text-align:right;'>Discount:</td>
                    <td style='text-align:right;'>{dto.Discount:N2}</td>
                </tr>
                {gstDetails}
                <tr style='background:#eee; font-weight:bold;'>
                    <td colspan='3' style='text-align:right;'>Net Payable:</td>
                    <td style='text-align:right;'>{dto.NetPayableAmount:N2}</td>
                </tr>
            </table>
        </div>
    </div>
    <div style='margin-top:50px;'>
        <p><em>This is a computer-generated invoice.</em></p>
    </div>
</body>
</html>";
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            await webView21.ExecuteScriptAsync("window.print();");
        }

        private async void btnSavePdf_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.Title = "Save Invoice";
                    sfd.FileName = $"Invoice_{_invoice.InvoiceNumber}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // CoreWebView2.PrintToPdfAsync is the magic method here
                            await webView21.CoreWebView2.PrintToPdfAsync(sfd.FileName);
                            MessageBox.Show("Invoice saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving PDF: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while save Save PDF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
