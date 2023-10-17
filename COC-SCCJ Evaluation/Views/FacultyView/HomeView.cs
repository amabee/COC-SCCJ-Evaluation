using COC_SCCJ_Evaluation.Models;
using COC_SCCJ_Evaluation.Presenter.FacultyPresenter;
using COC_SCCJ_Evaluation.Repositories;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace COC_SCCJ_Evaluation.Views
{
    public partial class HomeView : Form, IQuestionView
    {
        

        public HomeView()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            Resize += HomeView_Resize_1;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

            AssociateAndRaiseViewEvents();
            GetAllCategories();

            
            lblName.Text = SessionData.Firstname + " " +SessionData.Lastname;
            lblUsername.Text = SessionData.Username;
            ProfilePicture.Image = SessionData.ProfileImage;


        }



        private void AssociateAndRaiseViewEvents()
        {
            btnTestSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtTestSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };
            
        }



        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool isNormal = true;


        private void minimizedButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(0);
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(1);
        }
        private void HomeView_Resize_1(object sender, EventArgs e)
        {


            if (this.Width < minimumWidth)
            {
                this.Width = minimumWidth;
                this.Update();
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(2);
        }
        private void guna2TileButton6_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(3);
        }


        private void maximizedButton_Click_1(object sender, EventArgs e)
        {

            if (isNormal)
            {
                // Get the working area of the primary screen
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

                // Set the size and location of the form to match the working area
                this.Size = new Size(workingArea.Width, workingArea.Height);
                this.Location = new Point(workingArea.Left, workingArea.Top);

                guna2BorderlessForm1.BorderRadius = 0;
            }
            else
            {
                this.Size = new Size(1080, 720);
                this.StartPosition = FormStartPosition.CenterScreen;
                guna2BorderlessForm1.BorderRadius = 20;
            }

            isNormal = !isNormal;
        }

        private int minimumWidth = 1000;
        private string message;
        private bool isSuccessful;
        private bool isEditable;
        private string imageUri;
        private bool hasImage;
        private string categoryId;
        private int questionId;

        private void answer1_CheckedChanged(object sender, EventArgs e)
        {
            if (answer1.Checked) {                
                txtAnswers.Text = txtOption1.Text;
            }
        }

        private void answer2_CheckedChanged(object sender, EventArgs e)
        {
            if (answer2.Checked)
            {
                txtAnswers.Text = txtOption2.Text;
            }
        }

        private void answer3_CheckedChanged(object sender, EventArgs e)
        {
            if (answer3.Checked)
            {
                txtAnswers.Text = txtOption2.Text;
            }
        }

        private void answer4_CheckedChanged(object sender, EventArgs e)
        {
            if (answer4.Checked)
            {
                txtAnswers.Text = txtOption4.Text;
            }
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectTab(4);
        }

        private string selectedFilePath;

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select a File to Open";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName; // Store the selected file path
                var text = System.IO.File.ReadAllText(selectedFilePath);
                MessageBox.Show(text);
            }
        }


        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        #region PROPS
        // PROPS

        public int QuestionId { get => questionId; set => questionId = value; }
        public string CategoryId { get => categoryId; set => categoryId = value; }
        public bool HasImage { get => hasImage; set => hasImage = value; }
        public string ImageUri { get => imageUri; set => imageUri = value; }
        public string Question { get => txtQuestion.Text; set => txtQuestion.Text = value; }
        public string Answer { get => txtAnswers.Text; set => txtAnswers.Text = value; }
        public string Option1 { get => txtOption1.Text; set => txtOption1.Text = value; }
        public string Option2 { get => txtOption2.Text; set => txtOption2.Text = value; }
        public string Option3 { get => txtOption3.Text; set => txtOption3.Text = value; }
        public string Option4 { get => txtOption4.Text; set => txtOption4.Text = value; }
        public string SearchValue { get => txtTestSearch.Text; set => txtTestSearch.Text = value; }
        public bool IsEditable { get => isEditable; set => isEditable = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }

        public void SetQuestionBindingSource(BindingSource questionList)
        {
            guna2DataGridView2.DataSource = questionList;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text;
            string answer = txtAnswers.Text;
            string op1 = txtOption1.Text;
            string op2 = txtOption2.Text;
            string op3 = txtOption3.Text;
            string op4 = txtOption4.Text;
            int categoryID = (int)categorySelect.SelectedValue;

            using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO `tbl_questions`(`categoryId`,`question`, `answer`, `option1`, `option2`, `option3`, `option4`) " +
                                   "VALUES (@category, @question, @answer, @op1, @op2, @op3, @op4)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters for each input value
                        cmd.Parameters.AddWithValue("@question", question);
                        cmd.Parameters.AddWithValue("@answer", answer);
                        cmd.Parameters.AddWithValue("@op1", op1);
                        cmd.Parameters.AddWithValue("@op2", op2);
                        cmd.Parameters.AddWithValue("@op3", op3);
                        cmd.Parameters.AddWithValue("@op4", op4);
                        cmd.Parameters.AddWithValue("@category", categoryID);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data inserted into the database.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void GetAllCategories()
        {
            Dictionary<int, string> categoryDictionary = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
            {
                try
                {
                    connection.Open();

                    
                    string query = "SELECT id, name FROM tbl_categories";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add the ID and name to the dictionary
                                categoryDictionary.Add(Convert.ToInt32(reader["id"]), reader["name"].ToString());

                            }
                        }
                    }

                    
                    categorySelect.DataSource = new BindingSource(categoryDictionary, null);
                    categorySelect.DisplayMember = "Value"; 
                    categorySelect.ValueMember = "Key";

                    readingMaterialCategory.DataSource = new BindingSource(categoryDictionary, null);
                    readingMaterialCategory.DisplayMember = "Value";
                    readingMaterialCategory.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void guna2TileButton5_Click(object sender, EventArgs e)
        {
            LoginView _login = new LoginView();
            this.Hide();
            SessionData.Username = null;
            SessionData.Firstname = null;
            SessionData.Lastname = null;
            SessionData.ProfileImage = null;
            _login.ShowDialog();
            this.Close();
        }

        private void btnSubmitRM_Click(object sender, EventArgs e)
        {
            string materialTitle = txtMaterialTitle.Text;
            int categoryID = Convert.ToInt32(readingMaterialCategory.SelectedValue);

            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                byte[] fileData = File.ReadAllBytes(selectedFilePath);

                using (MySqlConnection connection = new MySqlConnection(Properties.Resources.connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO `tbl_readingmaterials`(`categoryId`, `material_title`, `file`) " +
                                   "VALUES (@CategoryID, @MaterialTitle, @MaterialFile)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaterialTitle", materialTitle);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@MaterialFile", fileData);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Material uploaded successfully!");
                }
            }
            else
            {
                MessageBox.Show("No file selected.");
            }
        }



    }
}
