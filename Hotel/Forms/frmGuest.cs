using Hotel.Data;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class frmGuest : Form
    {
        private readonly IRepository<TblGuest> guestRepository;
        private readonly IRepository<TblAddress> addressRepository;
        private readonly IRepository<TblCity> cityRepository;
        private List<TblGuest> guestList = new List<TblGuest>();
        private List<TblCity> cityList = new List<TblCity>();

        public frmGuest(IRepository<TblGuest> guestRepository, IRepository<TblAddress> addressRepository, IRepository<TblCity> cityRepository)
        {
            InitializeComponent();

            this.guestRepository = guestRepository;
            this.addressRepository = addressRepository;
            this.cityRepository = cityRepository;
        }

        private void fillGuestGrid()
        {
            guestList = guestRepository
                    .GetAll()
                    .Where(x => x.HotelID == 1)
                    .ToList();

            dgvBooking.AutoGenerateColumns = false;
            dgvBooking.Columns.Clear();

            dgvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "ID",
                Visible = false
            });

            dgvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HotelID",
                HeaderText = "Hotel ID",
                DataPropertyName = "HotelID",
                Visible = false
            });

            dgvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FirstName",
                HeaderText = "Guest Name",
                DataPropertyName = "FirstName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Mobile Number",
                DataPropertyName = "PhoneNumber",
                Width = 150
            });

            dgvBooking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvBooking.DataSource = guestList;
        }
        private void frmGuest_Load(object sender, EventArgs e)
        {
            fillGuestGrid();
            GetCityNames();

            var source = new AutoCompleteStringCollection();
            source.AddRange(cityList.Select(x => x.CityName).ToArray());

            if (guestList.Any())
            {
                var guestSource = new AutoCompleteStringCollection();
                guestSource.AddRange(guestList.Select(x => x!.FirstName).ToArray()!);
                txtGuestName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtGuestName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtGuestName.AutoCompleteCustomSource = guestSource;

                var mobileSource = new AutoCompleteStringCollection();
                mobileSource.AddRange(guestList.Select(x => x!.PhoneNumber).ToArray()!);
                txtMobileNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMobileNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtMobileNumber.AutoCompleteCustomSource = mobileSource;
            }

            txtCity.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCity.AutoCompleteCustomSource = source;
        }
        private void GetCityNames()
        {
            cityList = cityRepository.GetAll();
        }
        private void btnGuestSave_Click(object sender, EventArgs e)
        {
            TblGuest guest = new TblGuest
            {
                HotelID = 1,
                FirstName = txtGuestName.Text,
                PhoneNumber = txtMobileNumber.Text,
                PhoneNumber2 = txtPhone2.Text,
                Email = txtEmail.Text,
                Gender = Gender.Male
            };
            guestRepository.Add(guest);

            TblAddress address = new TblAddress
            {
                HotelID = 1,
                AddressLine1 = txtAddress.Text,
                AddressLine2 = txtArea.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Country = txtCountry.Text,
                GuestID = guest.ID,
                TableID = guest.ID,
                TableName = nameof(TblGuest)
            };

            addressRepository.Add(address);
            fillGuestGrid();
            MessageBox.Show("Guest information saved successfully.");
            clearTexBoxes();
        }
        private void clearTexBoxes() 
        {
            txtMobileNumber.Text = string.Empty;
            radioButton1.Checked = true;
            txtGuestName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = "India";
            txtPhone2.Text = string.Empty;
            txtMobileNumber.Focus();
        }
    }
}
