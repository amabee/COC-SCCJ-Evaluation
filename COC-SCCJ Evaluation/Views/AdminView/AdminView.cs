using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COC_SCCJ_Evaluation.Models;

namespace COC_SCCJ_Evaluation.Views
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();

        }


        public void Alert(string msg, CustomAlertBox.CustomAlert.enmType type, string details)
        {
            CustomAlertBox.CustomAlert frm = new CustomAlertBox.CustomAlert();
            frm.showAlert(msg, type, details);
        }
        private void Faculty_DataGrid() {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
                {
                    connection.Open();

                    string query = "SELECT `id`, `faculty_Id`, `faculty_firstname`, `faculty_lastname` FROM `tbl_faculty_users` WHERE isAdmin = 0";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        facultyDataGrid.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private void Evaluation_DataGrid()
        {

           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(3);
        }

        private void inputValidation()
        {
            if (string.IsNullOrWhiteSpace(txtFacultyID.Text)
                || string.IsNullOrWhiteSpace(txtFacultyFname.Text)
                || string.IsNullOrWhiteSpace(txtFacultyLname.Text)
                || string.IsNullOrWhiteSpace(txtFacultyPassword.Text)
                || string.IsNullOrWhiteSpace(txtReEnterPass.Text))
                btnSaveFaculty.Enabled = false;

        }

        private void UpdateBorderColor()
        {

            if (txtFacultyPassword.Text != txtReEnterPass.Text)
            {
                btnSaveFaculty.Enabled = false;
                txtReEnterPass.FocusedState.BorderColor = Color.Red;
            }
            else
            {

                btnSaveFaculty.Enabled = true;
                txtReEnterPass.FocusedState.BorderColor = Color.Green;
            }
        }

        private void txtReEnterPass_TextChanged(object sender, EventArgs e)
        {
            UpdateBorderColor();
            txtReEnterPass.Invalidate();
        }

        private void txtReEnterPass_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateBorderColor();
            txtReEnterPass.Invalidate();
        }

        private void btnSaveFaculty_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO `tbl_faculty_users`(`faculty_Id`, `faculty_firstname`, `faculty_lastname`, `password`, `faculty_Profileimage`, `isAdmin`) " +
                                    "VALUES (@FacultyID, @FirstName, @LastName, @Password, @ProfileImage, @isAdmin)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FacultyID", txtFacultyID.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFacultyFname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtFacultyLname.Text);
                    cmd.Parameters.AddWithValue("@Password", txtReEnterPass.Text);
                    cmd.Parameters.AddWithValue("@isAdmin", 0);

                    // Load the image directly without conversion
                    using (FileStream fs = new FileStream("E:/FILES/COC-SCCJ-Evaluation/default.png", FileMode.Open, FileAccess.Read))
                    {
                        byte[] imageBytes = new byte[fs.Length];
                        fs.Read(imageBytes, 0, imageBytes.Length);
                        cmd.Parameters.AddWithValue("@ProfileImage", imageBytes);
                    }

                    cmd.ExecuteNonQuery();

                    this.Alert("Success", CustomAlertBox.CustomAlert.enmType.Success, "Faculty User SuccessFully Added");
                }
            }
        }

        private void AdminView_Load(object sender, EventArgs e)
        {
            lblAdminUname.Text = adminSessionData.Firstname + " " + adminSessionData.Lastname;
            ProfilePicture.Image = adminSessionData.ProfileImage;

            Faculty_DataGrid();
            Evaluation_DataGrid();
            inputValidation();
        }
    }
}
