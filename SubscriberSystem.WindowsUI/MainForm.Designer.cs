namespace SubscriberSystem.WindowsUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            txtFirstName = new TextBox();
            txtDeliveryAddress = new TextBox();
            txtSocialSecurity = new TextBox();
            txtLastName = new TextBox();
            txtZipCode = new TextBox();
            txtPhone = new TextBox();
            txtCity = new TextBox();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblZipCode = new Label();
            lblDeliveryAddress = new Label();
            lblPhone = new Label();
            lblSocialSecurity = new Label();
            lblCity = new Label();
            dataGridSubscribers = new DataGridView();
            txtSearchId = new TextBox();
            btnSearch = new Button();
            lblSearchId = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridSubscribers).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1000, 106);
            button1.Name = "button1";
            button1.Size = new Size(116, 57);
            button1.TabIndex = 0;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnLoad_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1000, 188);
            button2.Name = "button2";
            button2.Size = new Size(116, 57);
            button2.TabIndex = 1;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnAdd_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1000, 261);
            button3.Name = "button3";
            button3.Size = new Size(116, 57);
            button3.TabIndex = 2;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnUpdate_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1000, 342);
            button4.Name = "button4";
            button4.Size = new Size(116, 57);
            button4.TabIndex = 3;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnDelete_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(109, 494);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(156, 23);
            txtFirstName.TabIndex = 5;
            // 
            // txtDeliveryAddress
            // 
            txtDeliveryAddress.Location = new Point(109, 571);
            txtDeliveryAddress.Name = "txtDeliveryAddress";
            txtDeliveryAddress.Size = new Size(156, 23);
            txtDeliveryAddress.TabIndex = 6;
            // 
            // txtSocialSecurity
            // 
            txtSocialSecurity.Location = new Point(495, 494);
            txtSocialSecurity.Name = "txtSocialSecurity";
            txtSocialSecurity.Size = new Size(156, 23);
            txtSocialSecurity.TabIndex = 7;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(304, 494);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(156, 23);
            txtLastName.TabIndex = 8;
            // 
            // txtZipCode
            // 
            txtZipCode.Location = new Point(304, 571);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(156, 23);
            txtZipCode.TabIndex = 9;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(688, 494);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(156, 23);
            txtPhone.TabIndex = 10;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(495, 571);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(156, 23);
            txtCity.TabIndex = 11;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(109, 466);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(62, 15);
            lblFirstName.TabIndex = 12;
            lblFirstName.Text = "First name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(304, 466);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(61, 15);
            lblLastName.TabIndex = 13;
            lblLastName.Text = "Last name";
            // 
            // lblZipCode
            // 
            lblZipCode.AutoSize = true;
            lblZipCode.Location = new Point(304, 544);
            lblZipCode.Name = "lblZipCode";
            lblZipCode.Size = new Size(53, 15);
            lblZipCode.TabIndex = 14;
            lblZipCode.Text = "Zip code";
            // 
            // lblDeliveryAddress
            // 
            lblDeliveryAddress.AutoSize = true;
            lblDeliveryAddress.Location = new Point(109, 544);
            lblDeliveryAddress.Name = "lblDeliveryAddress";
            lblDeliveryAddress.Size = new Size(49, 15);
            lblDeliveryAddress.TabIndex = 15;
            lblDeliveryAddress.Text = "Address";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(688, 466);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(41, 15);
            lblPhone.TabIndex = 16;
            lblPhone.Text = "Phone";
            // 
            // lblSocialSecurity
            // 
            lblSocialSecurity.AutoSize = true;
            lblSocialSecurity.Location = new Point(495, 466);
            lblSocialSecurity.Name = "lblSocialSecurity";
            lblSocialSecurity.Size = new Size(127, 15);
            lblSocialSecurity.TabIndex = 17;
            lblSocialSecurity.Text = "Social security number";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(495, 544);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(28, 15);
            lblCity.TabIndex = 18;
            lblCity.Text = "City";
            // 
            // dataGridSubscribers
            // 
            dataGridSubscribers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSubscribers.Location = new Point(81, 76);
            dataGridSubscribers.Name = "dataGridSubscribers";
            dataGridSubscribers.Size = new Size(895, 351);
            dataGridSubscribers.TabIndex = 4;
            // 
            // txtSearchId
            // 
            txtSearchId.Location = new Point(552, 40);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new Size(328, 23);
            txtSearchId.TabIndex = 19;
            txtSearchId.TextChanged += textBox1_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(886, 30);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 40);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblSearchId
            // 
            lblSearchId.AutoSize = true;
            lblSearchId.Location = new Point(552, 22);
            lblSearchId.Name = "lblSearchId";
            lblSearchId.Size = new Size(56, 15);
            lblSearchId.TabIndex = 21;
            lblSearchId.Text = "Search ID";
            lblSearchId.Click += label1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 612);
            Controls.Add(lblSearchId);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchId);
            Controls.Add(lblCity);
            Controls.Add(lblSocialSecurity);
            Controls.Add(lblPhone);
            Controls.Add(lblDeliveryAddress);
            Controls.Add(lblZipCode);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(txtCity);
            Controls.Add(txtPhone);
            Controls.Add(txtZipCode);
            Controls.Add(txtLastName);
            Controls.Add(txtSocialSecurity);
            Controls.Add(txtDeliveryAddress);
            Controls.Add(txtFirstName);
            Controls.Add(dataGridSubscribers);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "Subscriber Manager";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridSubscribers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;

        private TextBox txtFirstName;
        private TextBox txtDeliveryAddress;
        private TextBox txtSocialSecurity;
        private TextBox txtLastName;
        private TextBox txtZipCode;
        private TextBox txtPhone;
        private TextBox txtCity;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblZipCode;
        private Label lblDeliveryAddress;
        private Label lblPhone;
        private Label lblSocialSecurity;
        private Label lblCity;
        private DataGridView dataGridSubscribers;

        // Add this method to handle the Load event in your MainForm class
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialization code here if needed
        }

        private TextBox txtSearchId;
        private Button btnSearch;
        private Label lblSearchId;
    }
}