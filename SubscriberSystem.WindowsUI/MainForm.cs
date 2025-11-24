using SubscriberSystem.WindowsUI.Models;
using SubscriberSystem.WindowsUI.Services;

namespace SubscriberSystem.WindowsUI
{
    public partial class MainForm : Form
    {
        private readonly ApiSubscriberService _subscriberService;
        private List<SubscriberDto> _subscribers = new();

        public MainForm()
        {
            InitializeComponent();

            _subscriberService = new ApiSubscriberService("https://localhost:7025/");

            // Optional but nice
            dataGridSubscribers.AutoGenerateColumns = true;
            dataGridSubscribers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridSubscribers.MultiSelect = false;
            dataGridSubscribers.ReadOnly = true;

            dataGridSubscribers.SelectionChanged += dataGridSubscribers_SelectionChanged;
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _subscribers = await _subscriberService.GetAllSubscribersAsync();

                dataGridSubscribers.DataSource = null;
                dataGridSubscribers.DataSource = _subscribers;

        
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load subscribers.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newSubscriber = new SubscriberDto
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DeliveryAddress = txtDeliveryAddress.Text,
                ZipCode = txtZipCode.Text,
                City = txtCity.Text,
                Phone = txtPhone.Text,
                SocialSecurity = txtSocialSecurity.Text
            };

            try
            {
                var created = await _subscriberService.CreateSubscriberAsync(newSubscriber);
                if (created == null)
                {
                    MessageBox.Show("Subscriber created but no data was returned.", "Warning");
                }

                await ReloadSubscribersAsync();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create subscriber.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridSubscribers.CurrentRow?.DataBoundItem is not SubscriberDto selected)
            {
                MessageBox.Show("Select a subscriber to update.", "Info");
                return;
            }

            // Update from textboxes
            selected.FirstName = txtFirstName.Text;
            selected.LastName = txtLastName.Text;
            selected.DeliveryAddress = txtDeliveryAddress.Text;
            selected.ZipCode = txtZipCode.Text;
            selected.City = txtCity.Text;
            selected.Phone = txtPhone.Text;
            selected.SocialSecurity = txtSocialSecurity.Text;

            try
            {
                await _subscriberService.UpdateSubscriberAsync(selected);
                await ReloadSubscribersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update subscriber.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridSubscribers.CurrentRow?.DataBoundItem is not SubscriberDto selected)
            {
                MessageBox.Show("Select a subscriber to delete.", "Info");
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete {selected.FirstName} {selected.LastName}?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                await _subscriberService.DeleteSubscriberAsync(selected.SubscriberId);
                await ReloadSubscribersAsync();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete subscriber.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // search by id
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearchId.Text, out int searchId))
            {
                MessageBox.Show("Enter a valid Subscriber ID to search.", "Info");
                return;
            }
            try
            {
                var subscriber = await _subscriberService.GetSubscriberByIdAsync(searchId);
                dataGridSubscribers.DataSource = null;
                dataGridSubscribers.DataSource = new List<SubscriberDto> { subscriber };
                if (subscriber == null)
                {
                    MessageBox.Show("Subscriber not found.", "Info");
                    return;
                }
                // Display found subscriber
                txtFirstName.Text = subscriber.FirstName;
                txtLastName.Text = subscriber.LastName;
                txtDeliveryAddress.Text = subscriber.DeliveryAddress;
                txtZipCode.Text = subscriber.ZipCode;
                txtCity.Text = subscriber.City;
                txtPhone.Text = subscriber.Phone;
                txtSocialSecurity.Text = subscriber.SocialSecurity;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to search subscriber.\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ReloadSubscribersAsync()
        {
            _subscribers = await _subscriberService.GetAllSubscribersAsync();
            dataGridSubscribers.DataSource = null;
            dataGridSubscribers.DataSource = _subscribers;

            var idCol = dataGridSubscribers.Columns[nameof(SubscriberDto.SubscriberId)];
            if (idCol != null)
            {
                idCol.HeaderText = "Subscription Number";
                idCol.ReadOnly = true;
            }
        }

        private void ClearInputFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtDeliveryAddress.Clear();
            txtZipCode.Clear();
            txtCity.Clear();
            txtPhone.Clear();
            txtSocialSecurity.Clear();
        }

        private void dataGridSubscribers_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridSubscribers.CurrentRow?.DataBoundItem is not SubscriberDto selected)
                return;

            txtFirstName.Text = selected.FirstName;
            txtLastName.Text = selected.LastName;
            txtDeliveryAddress.Text = selected.DeliveryAddress;
            txtZipCode.Text = selected.ZipCode;
            txtCity.Text = selected.City;
            txtPhone.Text = selected.Phone;
            txtSocialSecurity.Text = selected.SocialSecurity;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
