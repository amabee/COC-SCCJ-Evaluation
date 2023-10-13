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
    }
}
