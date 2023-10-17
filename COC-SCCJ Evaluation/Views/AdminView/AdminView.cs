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

namespace COC_SCCJ_Evaluation.Views
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();

            Faculty_DataGrid();
            Evaluation_DataGrid();
            inputValidation();
        }

        private void Faculty_DataGrid() {

            // Create a DataTable and add columns
            DataTable dt = new DataTable();
            dt.Columns.Add("Faculty ID", typeof(string));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            

            // Add rows to the DataTable
            dt.Rows.Add("02-1920-03954", "John Paul", "Orencio", "Active");
            dt.Rows.Add("02-2021-01611", "Shan", "Gorra", "Active");
            dt.Rows.Add("02-1920-03045", "John Paul", "Orencio", "Active");

            guna2DataGridView1.DataSource = dt;
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

        //private void btnSaveFaculty_Click(object sender, EventArgs e)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
        //    {
        //        connection.Open();

        //        string insertQuery = "INSERT INTO `tbl_faculty_users`(`faculty_Id`, `faculty_firstname`, `faculty_lastname`, `password`, `faculty_Profileimage`, `isAdmin`) " +
        //                            "VALUES (@FacultyID, @FirstName, @LastName, @Password, @ProfileImage, @isAdmin)";
        //        using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@FacultyID", txtFacultyID.Text);
        //            cmd.Parameters.AddWithValue("@FirstName", txtFacultyFname.Text);
        //            cmd.Parameters.AddWithValue("@LastName", txtFacultyLname.Text);
        //            cmd.Parameters.AddWithValue("@Password", txtReEnterPass.Text);
        //            cmd.Parameters.AddWithValue("@isAdmin", 0);

        //            // Convert and insert the image in a supported format (e.g., JPEG)
        //            byte[] imageBytes;
        //            using (Image image = Image.FromFile("path_to_image.jpg")) // Load the original image
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                image.Save(ms, ImageFormat.Jpeg); // Save it as JPEG
        //                imageBytes = ms.ToArray();
        //            }
        //            cmd.Parameters.AddWithValue("@ProfileImage", imageBytes);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }

        //}

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
                }
            }
        }


    }
}
