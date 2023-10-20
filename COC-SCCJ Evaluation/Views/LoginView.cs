using COC_SCCJ_Evaluation.Models;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace COC_SCCJ_Evaluation.Views
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(1);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(2);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();

            forgetPassword.Dock = DockStyle.Fill;
            this.Controls.Add(forgetPassword);
            forgetPassword.BringToFront();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string faculty_id = txtUsername.Text;
            string password = txtPassword.Text;

            using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tbl_faculty_users WHERE faculty_id = @faculty_id AND password = @password AND isAdmin = 0";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", faculty_id);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string firstname = reader["faculty_firstname"].ToString();
                            string lastname = reader["faculty_lastname"].ToString();
                            SessionData.Firstname = firstname;
                            SessionData.Lastname = lastname;
                            SessionData.Username = txtUsername.Text;

                            // Retrieve the image data from the database
                            byte[] imageBytes = reader["faculty_Profileimage"] as byte[];

                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                try
                                {
                                    // Convert the binary image data to an Image
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        SessionData.ProfileImage = Image.FromStream(ms);
                                    }
                                }
                                catch (ArgumentException ex)
                                {
                                    // Handle the "Parameter is not valid" error
                                    MessageBox.Show("Failed to load the profile image. Login successful, " +
                                        "but the image could not be displayed. \nAdditional Error: " + ex.Message);
                                }
                            }

                            MessageBox.Show("Login successful!");

                           
                            // Close the login form
                            this.Hide();
                            var home = new Views.HomeView();
                            home.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            // Failed login
                            MessageBox.Show("Invalid credentials. Please try again.");
                        }
                    }
                }
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            string faculty_id = txtAdminUname.Text;
            string password = txtAdminPass.Text;

            using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tbl_faculty_users WHERE faculty_id = @faculty_id AND password = @password AND isAdmin = 1";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", faculty_id);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string firstname = reader["faculty_firstname"].ToString();
                            string lastname = reader["faculty_lastname"].ToString();
                            adminSessionData.Firstname = firstname;
                            adminSessionData.Lastname = lastname;
                            adminSessionData.Username = txtAdminUname.Text;

                           
                            byte[] imageBytes = reader["faculty_Profileimage"] as byte[];

                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                try
                                {
                                   
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        adminSessionData.ProfileImage = Image.FromStream(ms);
                                    }
                                }
                                catch (ArgumentException ex)
                                {
                                    
                                    MessageBox.Show("Failed to load the profile image. Login successful, " +
                                        "but the image could not be displayed. \nAdditional Error: " + ex.Message);
                                }
                            }

                            MessageBox.Show("Login successful!");


                           
                            this.Hide();
                            var admin = new Views.AdminView();
                            admin.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                           
                            MessageBox.Show("Invalid credentials. Please try again.");
                        }
                    }
                }
            }
        }
    }
}