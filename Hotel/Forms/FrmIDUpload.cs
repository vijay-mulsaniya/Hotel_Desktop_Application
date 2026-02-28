using AForge.Video.DirectShow;
using Hotel.Data;
using Hotel.Models;
using System.Data;


namespace Hotel.Forms
{
    public partial class FrmIDUpload : Form
    {
        private string selectedFilePath = string.Empty;
        private string uploadsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GuestDocs");
        private FilterInfoCollection? videoDevices;
        private VideoCaptureDevice? videoSource;
        private static int HotelID = 1;
        private List<GuestComboBoxItem> _guests = new List<GuestComboBoxItem>();
        private List<TblIdentityProof> _idData = new List<TblIdentityProof>();
        private int GuestID => cmbGuestNames.SelectedValue != null ? (int)cmbGuestNames.SelectedValue : -1;
        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

        public FrmIDUpload()
        {
            InitializeComponent();
        }

        private void FrmIDUpload_Load(object sender, EventArgs e)
        {
            FillGuestCombo();
            FillIdentityList();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                cmbCameras.Items.Add(device.Name);
            }
            if (cmbCameras.Items.Count > 0) cmbCameras.SelectedIndex = 0;

            collection.AddRange(new string[]
            {
                "Passport",
                "Driving License",
                "Aadhar Card",
                "Voter ID",
                "PAN Card"
            });
            txtProofType.AutoCompleteCustomSource = collection;

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Delete", null, Delete_Click!);

            lstGrid.ContextMenuStrip = menu;
            cmbGuestNames.SelectedIndex = -1;
        }
        private void FillGuestCombo()
        {
            using (var db = new AppDbContext())
            {
                var guests = db.Guests.Where(x => x.HotelID == HotelID).OrderBy(x => x.FirstName)
                            .Select(x => new GuestComboBoxItem
                            {
                                ID = x.ID,
                                DisplayName = $"{x.FirstName} - {x.PhoneNumber}"
                            }).ToList() ?? new List<GuestComboBoxItem>();

                _guests = guests;
                cmbGuestNames.DisplayMember = "DisplayName";
                cmbGuestNames.ValueMember = "ID";
                cmbGuestNames.DataSource = _guests;
                cmbGuestNames.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbGuestNames.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void FillIdentityList()
        {
            using (var db = new AppDbContext())
            {
                _idData = db.IdentityProofs.ToList();

                lstGrid.Items.Clear();
                lstGrid.DataBindings.Clear();
                foreach (var identity in _idData)
                {
                    var guest = _guests.FirstOrDefault(x => x.ID == identity.GuestID);
                    ListViewItem item = new ListViewItem(identity.ID.ToString());
                    item.SubItems.Add(guest!.DisplayName);
                    item.SubItems.Add(identity.ProofType);
                    item.Tag = guest.ID;
                    lstGrid.Items.Add(item);
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGrid.SelectedItems.Count == 0)
                    return;

                int identityId = Convert.ToInt32(lstGrid.SelectedItems[0].SubItems[0].Text!);

                using (var db = new AppDbContext())
                {
                    var identity = db.IdentityProofs.FirstOrDefault(x => x.ID == identityId);
                    if (identity != null)
                    {
                        db.IdentityProofs.Remove(identity);
                        db.SaveChanges();
                    }
                }

                FillIdentityList();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while delete ID Upload", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async void btnIDSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedFilePath))
                {
                    MessageBox.Show("Please upload an ID image first.");
                    return;
                }

                if (!IsRequiredFieldsFilled()) return;

                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string extension = Path.GetExtension(selectedFilePath);
                string fileName = $"ID_{this.GuestID}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                string destinationPath = Path.Combine(uploadsFolder, fileName);

                File.Copy(selectedFilePath, destinationPath, true);

                using (var db = new AppDbContext())
                {
                    var proof = new TblIdentityProof
                    {
                        GuestID = this.GuestID,
                        ProofType = txtProofType.Text,
                        ProofNumber = txtProofNumber.Text,
                        ExpiryDate = dtpExpiryDate.Value,
                        IssuingAuthority = txtIssueAuthority.Text,
                        DocumentUrl = destinationPath,
                        IsVerified = chkIsVerified.Checked
                    };

                    await db.IdentityProofs.AddAsync(proof);
                    await db.SaveChangesAsync();
                }

                MessageBox.Show("ID Proof saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private bool IsRequiredFieldsFilled()
        {
            if (cmbGuestNames.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a guest.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProofType.Text))
            {
                MessageBox.Show("Please enter the proof type.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProofNumber.Text))
            {
                MessageBox.Show("Please enter the proof number.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtIssueAuthority.Text))
            {
                MessageBox.Show("Please enter the issuing authority.");
                return false;
            }
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please upload an ID image.");
                return false;
            }
            return true;
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
        private void btnStartCam_Click(object sender, EventArgs e)
        {
            if (cmbCameras.SelectedIndex < 0) return;
            if (videoDevices == null) return;

            videoSource = new VideoCaptureDevice(videoDevices[cmbCameras.SelectedIndex].MonikerString);
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
            try
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop(); // Freeze the frame

                    // Save the current image to a temporary path so btnIDSave can use it
                    string tempPath = Path.Combine(Path.GetTempPath(), "captured_id.jpg");
                    if (picIDBox.Image == null) return;
                    picIDBox.Image.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    selectedFilePath = tempPath; // Set this for your existing Save logic
                    MessageBox.Show("Photo Captured!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while btn capture click", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lstGrid_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected)
                return;

            if (e.Item?.Tag == null) return;

            int guestId = (int)e.Item.Tag;

            var path = _idData
                .FirstOrDefault(x => x.GuestID == guestId)?
                .DocumentUrl;

            if (string.IsNullOrEmpty(path))
                return;

            LoadGuestID(path);
        }
        private void txtProofType_Leave(object sender, EventArgs e)
        {
            if (txtProofType.Text.Equals("Aadhar Card", StringComparison.OrdinalIgnoreCase) ||
                txtProofType.Text.Equals("Voter ID", StringComparison.OrdinalIgnoreCase) ||
                txtProofType.Text.Equals("PAN Card", StringComparison.OrdinalIgnoreCase) ||
                txtProofType.Text.Equals("Driving License", StringComparison.OrdinalIgnoreCase) ||
                txtProofType.Text.Equals("Passport", StringComparison.OrdinalIgnoreCase) ||
                txtProofType.Text.Equals("DL", StringComparison.OrdinalIgnoreCase)
                )
            {

                txtIssueAuthority.Text = "Government of India";
                txtProofNumber.Focus();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            lstGrid.Items.Clear();

            var filtered = _idData
                .Where(x => (x.ProofType != null && x.ProofType.ToLower().Contains(searchText)) ||
                            _guests.FirstOrDefault(g => g.ID == x.GuestID)!.DisplayName.ToLower().Contains(searchText))
                .ToList();

            foreach (var identity in filtered)
            {
                var guest = _guests.FirstOrDefault(x => x.ID == identity.GuestID);
                ListViewItem item = new ListViewItem(identity.ID.ToString());
                item.SubItems.Add(guest!.DisplayName);
                item.SubItems.Add(identity.ProofType);
                item.Tag = guest.ID;
                lstGrid.Items.Add(item);
            }
        }

        private void FrmIDUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }
    }
}
