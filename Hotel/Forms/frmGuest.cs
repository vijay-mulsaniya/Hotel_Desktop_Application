using Hotel.Data;
using Hotel.Models;
using System.Data;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Hotel.Forms
{
    public partial class frmGuest : Form
    {
        private readonly IRepository<TblGuest> guestRepository;
        private readonly IRepository<TblAddress> addressRepository;
        private readonly IRepository<TblCity> cityRepository;
        private List<TblGuest> guestList = new List<TblGuest>();
        private List<TblCity> cityList = new List<TblCity>();
        private string selectedFilePath = string.Empty;
        private string uploadsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GuestDocs");
        private FilterInfoCollection? videoDevices;
        private VideoCaptureDevice? videoSource;

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

            dgvBooking.DataSource = null;
            dgvBooking.DataSource = guestList;
        }

        private void frmGuest_Load(object sender, EventArgs e)
        {
            SetupGuestGrid();
            fillGuestGrid();
            GetCityNames();
            BindStates();

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

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                cmbCameras.Items.Add(device.Name);
            }
            if (cmbCameras.Items.Count > 0) cmbCameras.SelectedIndex = 0;
        }

        private void BindStates()
        {
            var statesList = new List<string> {
                "-- Select State --",
                "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh",
                "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand",
                "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur",
                "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan",
                "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh",
                "Uttarakhand", "West Bengal"
            };

            cmbStates.DataSource = statesList;
            cmbStates.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbStates.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbStates.DropDownStyle = ComboBoxStyle.DropDownList; // Prevents typing fake states
        }
        private void GetCityNames()
        {
            cityList = cityRepository.GetAll();
        }
        private void SetupGuestGrid()
        {
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
        }
        private void btnGuestSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flowControl = ValidateSaveAction();
                if (!flowControl) return;

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
                    State = cmbStates.SelectedItem!.ToString(),
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
            catch (Exception)
            {
                MessageBox.Show("Error while save Guest", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateSaveAction()
        {
            if (string.IsNullOrEmpty(txtGuestName.Text) || string.IsNullOrEmpty(txtMobileNumber.Text))
            {
                MessageBox.Show("Please enter both Guest Name and Mobile Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show("Please enter both City Name and State.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbStates.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a valid State.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
            cmbStates.SelectedIndex = 0;
            txtCountry.Text = "India";
            txtPhone2.Text = string.Empty;
            txtMobileNumber.Focus();
        }

        private void btnUploadID_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Guest ID Proof Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;

                    // Preview the image
                    // We use Image.FromFile wrapped in a way that doesn't "lock" the file
                    using (var stream = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                    {
                        picIDBox.Image = Image.FromStream(stream);
                        picIDBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }
        private void btnIDSave_Click(object sender, EventArgs e)
        {
            try
            {
                //// 1. Validation
                //if (string.IsNullOrEmpty(selectedFilePath))
                //{
                //    MessageBox.Show("Please upload an ID image first.");
                //    return;
                //}

                //// 2. Ensure Uploads directory exists
                //if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                //// 3. Create a unique filename to avoid overwriting (GuestID_Timestamp.jpg)
                //string extension = Path.GetExtension(selectedFilePath);
                //string fileName = $"ID_{this.GuestID}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                //string destinationPath = Path.Combine(uploadsFolder, fileName);

                //// 4. Copy the file to your app's folder
                //File.Copy(selectedFilePath, destinationPath, true);

                //// 5. Save to Database
                //using (var db = new AppDbContext())
                //{
                //    var proof = new TblIdentityProof
                //    {
                //        GuestID = this.GuestID, // Ensure you have this ID set in the form
                //        ProofType = txtProofType.Text,
                //        ProofNumber = txtProofNumber.Text,
                //        ExpiryDate = txtExpiryDate.Text,
                //        IssuingAuthority = $"{txtIDState.Text}, {txtIDCountry.Text}",
                //        DocumentUrl = destinationPath, // Saving the local path
                //        IsVerified = false,
                //        CreatedOn = DateTime.UtcNow.GetIndianTime(),
                //        CreatedbyId = AppSession.CurrentUser?.ID // From our Login logic
                //    };

                //    db.TblIdentityProofs.Add(proof);
                //    await db.SaveChangesAsync();
                //}

                MessageBox.Show("ID Proof saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void LoadGuestID(string path)
        {
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    picIDBox.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnStartCam_Click(object sender, EventArgs e)
        {
            if (cmbCameras.SelectedIndex < 0) return;

            videoSource = new VideoCaptureDevice(videoDevices?[cmbCameras.SelectedIndex].MonikerString);
            if (videoSource == null) return;
            videoSource.NewFrame += (s, eventArgs) =>
            {
                // Get the live frame
                Bitmap video = (Bitmap)eventArgs.Frame.Clone();
                // Display it in the picture box
                picIDBox.Image = video;
            };
            videoSource.Start();
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop(); // Freeze the frame
                string tempPath = Path.Combine(Path.GetTempPath(), "captured_id.jpg");

                if (picIDBox.Image != null)
                    picIDBox.Image.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                selectedFilePath = tempPath; // Set this for your existing Save logic
                MessageBox.Show("Photo Captured!");
            }
        }
        private void frmGuest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }
    }
}
