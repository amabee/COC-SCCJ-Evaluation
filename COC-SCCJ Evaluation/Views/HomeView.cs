using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



            // Create a DataTable and add columns
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("Criminal Law and Jurisprudence", typeof(int));
            dt.Columns.Add("Law Enforcement Administration", typeof(int));
            dt.Columns.Add("Forensics/Criminalistics", typeof(int));
            dt.Columns.Add("Crime Detection and Investigation", typeof(int));
            dt.Columns.Add("Sociology of Crimes and Ethics", typeof(int));
            dt.Columns.Add("Correctional Administration", typeof(int));

            // Add rows to the DataTable
            dt.Rows.Add(1, "John", "Doe", 90, 85, 92, 88, 78, 87);
            dt.Rows.Add(2, "Alice", "Smith", 88, 90, 85, 89, 82, 91);
            dt.Rows.Add(3, "Bob", "Johnson", 92, 87, 89, 91, 80, 88);


            guna2DataGridView1.DataSource = dt;

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
        private string isSuccessful;
        private bool isEditable;
        private string imageUri;
        private bool hasImage;
        private string categoryId;

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        // PROPS
        public string CategoryId { get => categoryId; set => categoryId = value; }
        public bool HasImage { get => hasImage; set => hasImage = value; }
        public string ImageUri { get => imageUri; set => imageUri = value; }
        public string Question { get => txtQuestion.Text; set => txtQuestion.Text = value; }
        public string Answer { get => txtAnswer.Text; set => txtAnswer.Text = value; }
        public string Option1 { get => txtOption1.Text; set => txtOption1.Text = value; }
        public string Option2 { get => txtOption2.Text; set => txtOption2.Text = value; }
        public string Option3 { get => txtOption3.Text; set => txtOption3.Text = value; }
        public string Option4 { get => txtOption4.Text; set => txtOption4.Text = value; }
        public string SearchValue { get => txtBox_Search.Text; set => txtBox_Search.Text = value; }
        public bool IsEditable { get => isEditable; set => isEditable = value; }
        public string IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }

        public void SetQuestionBindingSource(BindingSource questionList)
        {
            guna2DataGridView2.DataSource = questionList; 
        }

        private void answer1_CheckedChanged(object sender, EventArgs e)
        {
            if (answer1.Checked) {                
                txtAnswer.Text = txtOption1.Text;
            }
        }

        private void answer2_CheckedChanged(object sender, EventArgs e)
        {
            if (answer2.Checked)
            {
                txtAnswer.Text = txtOption2.Text;
            }
        }

        private void answer3_CheckedChanged(object sender, EventArgs e)
        {
            if (answer2.Checked)
            {
                txtAnswer.Text = txtOption2.Text;
            }
        }

        private void answer4_CheckedChanged(object sender, EventArgs e)
        {
            if (answer4.Checked)
            {
                txtAnswer.Text = txtOption4.Text;
            }
        }
    }
}
