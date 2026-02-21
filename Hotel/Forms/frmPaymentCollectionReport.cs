using Hotel.Dtos;
using Hotel.Dtos.PaymentDtos;
using Hotel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class frmPaymentCollectionReport : Form
    {
        
        private readonly IPaymentService paymentService;

        public frmPaymentCollectionReport(IPaymentService paymentService)
        {
            InitializeComponent();
            dtpMonthYear.Format = DateTimePickerFormat.Custom;
            dtpMonthYear.CustomFormat = "MMMM yyyy";
            dtpMonthYear.ShowUpDown = true;
            this.paymentService = paymentService;
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
           var report = await paymentService.MonthlyPaymentCollectionReport(dtpMonthYear.Value.Month, dtpMonthYear.Value.Year);

            await webView21.EnsureCoreWebView2Async();

            string finalHtml = GetHtmlTemplate(report);
            webView21.NavigateToString(finalHtml);
        }
        private string GetHtmlTemplate(PaymentCollectionReportDto dto)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in dto.paymentCollectionReportDetails)
            {
                string s1 = $@"
                <div class='date'>
                            <h3>{item.TitleDate}</h3>
                            <h3>{item.DateTotal}</h3>
                    </div>
                <table>
                ";
                sb.Append(s1);

                foreach (var row in item.DateTable)
                {
                    string s2 = $@"
                            <tr>
                                <td>{row.GuestName}</td>
                                <td style='text-align:center;'>{row.RoomNumber}</td>
                                 <td>{row.InvoiceNumber}</td>
                                <td style='text-align:right;'>{row.PaymentAmount:N2}</td>
                            </tr>
                    ";
                    sb.Append(s2);
                }

                sb.Append("</table>");
            }


            return $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Report1</title>
    <style>
        *{{
            padding: 0;
            margin: 0;
            box-sizing: border-box;
        }}
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 40px;
            color: #333;
        }}

        p {{
            margin: 0;
            padding: 0;
        }}

        table {{
            margin-top: 0px;
            border: 0;
            margin-bottom: 10px;
        }}

        th {{
            background-color: #f2f2f2;
            text-align: left;
        }}

        td{{
            padding: 2px 5px 0 0;
        }}
        @media print {{

            /* Hide the UI buttons when printing */
            .no-print {{
                display: none;
            }}

            /* Prevent page breaks inside a table row */
            tr {{
                page-break-inside: avoid;
            }}

            /* Force a margin on the printed page */
            @page {{
                margin: 1cm;
            }}
        }}
        .header{{
            text-align: center;
            border-bottom: 2px solid;
            padding: 5px 0;
        }}
        .date{{
            display: flex;
            justify-content: space-between;
        }}
        .date h3{{
            font-weight: 600;
            font-size: 18px;
        }}
    </style>
</head>

<body>
    <div class=""header"">
        <h1>{dto.HotelName}</h1>
        <p>Plot No:69, Ambika Nagar Society, Opp. Radhey Residency, Icchapore-3</p>
        <p>Gujarat, 394510, Ichhapore Surat. 394510, India.</p>
        <p>Phone: 72799 77977, Email: drajani09@gmail.com</p><br>
    </div>
    <div class=""header"">
        <h3>Payment Collection Report - {dtpMonthYear.Value.ToString("MMM")} - {dtpMonthYear.Value.ToString("yyyy")}</h3>
    </div>
   {sb.ToString()}
    <hr>
    <div class=""date"">
            <h3>Total</h3>
            <h3>{dto.ReportTotal}</h3>
    </div>
</body>

</html>";
        }

    }
}
