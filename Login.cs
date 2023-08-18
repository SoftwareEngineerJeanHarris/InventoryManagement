using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InventoryManagement
{
    public partial class Login : Form
    {
        // Connection string (replace with your actual connection string)
        private string connectionString = "Server=89.117.139.52;Port=3306;Database=u428290900_Jean;Uid=u428290900_Jean;Pwd=Jmjmjm_1993;";

        TextBox txtUsernameCreate;
        TextBox txtPasswordCreate;
        TextBox txtFirstName;
        TextBox txtLastName;
        TextBox txtEmail;

        public Login()
        {
            InitializeComponent();
            CreateLoginSection();
            CreateWindow();
            CreateCreateAccountSection();
        }

        private void CreateWindow()
        {
            Text = "Login Screen";
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(330, 350);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        }

        private void CreateLoginSection()
        {
            Label lblLoginAccount = new Label { Text = "Login", Width = 150, Location = new System.Drawing.Point(10, 10), Font = new System.Drawing.Font(Font.FontFamily, Font.Size + 2) };

            Label lblUsernameLogin = new Label { Text = "Username:",  Width = 150, Location = new System.Drawing.Point(10, 45) };
            TextBox txtUsernameLogin = new TextBox { Location = new System.Drawing.Point(10, 65),  Width = 150 };

            Label lblPasswordLogin = new Label { Text = "Password:",  Width = 150, Location = new System.Drawing.Point(10, 95) };
            TextBox txtPasswordLogin = new TextBox { Location = new System.Drawing.Point(10, 115), PasswordChar = '*',  Width = 150 };

            Button btnLogin = new Button { Text = "Login",  Width = 150, Height = 40, Location = new System.Drawing.Point(10, 155) };
            btnLogin.Click += BtnLogin_Click; // Event handler for login button click

            Controls.AddRange(new Control[] {lblLoginAccount, lblUsernameLogin, txtUsernameLogin, lblPasswordLogin, txtPasswordLogin, btnLogin });
        }

        private void CreateCreateAccountSection()
        {
            Label lblCreateAccount = new Label { Text = "Create Account", Width = 150, Location = new System.Drawing.Point(160, 10), Font = new System.Drawing.Font(Font.FontFamily, Font.Size + 2) };

            Label lblUsernameCreate = new Label { Text = "Username:",  Width = 150, Location = new System.Drawing.Point(160, 40) };
            txtUsernameCreate = new TextBox { Location = new System.Drawing.Point(160, 60),  Width = 150 };

            Label lblPasswordCreate = new Label { Text = "Password:",  Width = 150, Location = new System.Drawing.Point(160, 90) };
            txtPasswordCreate = new TextBox { Location = new System.Drawing.Point(160, 110), PasswordChar = '*',  Width = 150 };

            Label lblFirstName = new Label { Text = "First Name:",  Width = 150, Location = new System.Drawing.Point(160, 140) };
            txtFirstName = new TextBox { Location = new System.Drawing.Point(160, 160),  Width = 150 };

            Label lblLastName = new Label { Text = "Last Name:",  Width = 150, Location = new System.Drawing.Point(160, 190) };
            txtLastName = new TextBox { Location = new System.Drawing.Point(160, 210),  Width = 150 };

            Label lblEmail = new Label { Text = "Email Address:",  Width = 150, Location = new System.Drawing.Point(160, 240) };
            txtEmail = new TextBox { Location = new System.Drawing.Point(160, 260),  Width = 150 };

            Button btnCreateAccount = new Button { Text = "Create Account",  Width = 150, Height = 40, Location = new System.Drawing.Point(160, 290) };
            btnCreateAccount.Click += BtnCreateAccount_Click; // Event handler for create account button click

            Controls.AddRange(new Control[] { lblCreateAccount, lblUsernameCreate, txtUsernameCreate, lblPasswordCreate, txtPasswordCreate, lblFirstName, txtFirstName, lblLastName, txtLastName, lblEmail, txtEmail, btnCreateAccount });
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Login logic goes here
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsernameCreate.Text;
            string password = txtPasswordCreate.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Check if email already exists
                string queryEmail = "SELECT * FROM inventoryManagementUsers WHERE EmailAddress = @email";
                using (MySqlCommand cmdEmail = new MySqlCommand(queryEmail, conn))
                {
                    cmdEmail.Parameters.AddWithValue("@email", email);
                    MySqlDataReader readerEmail = cmdEmail.ExecuteReader();
                    if (readerEmail.Read())
                    {
                        MessageBox.Show("An account with this email address already exists!");
                        return;
                    }
                    readerEmail.Close();
                }

                // Check if username already exists
                string queryUsername = "SELECT * FROM inventoryManagementUsers WHERE Username = @username";
                using (MySqlCommand cmdUsername = new MySqlCommand(queryUsername, conn))
                {
                    cmdUsername.Parameters.AddWithValue("@username", username);
                    MySqlDataReader readerUsername = cmdUsername.ExecuteReader();
                    if (readerUsername.Read())
                    {
                        MessageBox.Show("An account with this username already exists!");
                        return;
                    }
                    readerUsername.Close();
                }

                // Create the account
                string queryInsert = "INSERT INTO inventoryManagementUsers (Username, Password, FirstName, LastName, EmailAddress) VALUES (@username, @password, @firstName, @lastName, @email)";
                using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@username", username);
                    cmdInsert.Parameters.AddWithValue("@password", password);
                    cmdInsert.Parameters.AddWithValue("@firstName", firstName);
                    cmdInsert.Parameters.AddWithValue("@lastName", lastName);
                    cmdInsert.Parameters.AddWithValue("@email", email);
                    cmdInsert.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully!");
                }
            }
        }
    }
}
