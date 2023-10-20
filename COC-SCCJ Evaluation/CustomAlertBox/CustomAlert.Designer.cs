
namespace COC_SCCJ_Evaluation.CustomAlertBox
{
    partial class CustomAlert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.borderPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.alertBoxPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblPrimary = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.alertBoxPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // borderPanel
            // 
            this.borderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(211)))), ((int)(((byte)(125)))));
            this.borderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.borderPanel.Location = new System.Drawing.Point(0, 0);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(21, 108);
            this.borderPanel.TabIndex = 0;
            // 
            // alertBoxPicture
            // 
            this.alertBoxPicture.Image = global::COC_SCCJ_Evaluation.Properties.Resources.icons8_check;
            this.alertBoxPicture.ImageRotate = 0F;
            this.alertBoxPicture.Location = new System.Drawing.Point(44, 32);
            this.alertBoxPicture.Name = "alertBoxPicture";
            this.alertBoxPicture.Size = new System.Drawing.Size(55, 49);
            this.alertBoxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alertBoxPicture.TabIndex = 1;
            this.alertBoxPicture.TabStop = false;
            // 
            // lblPrimary
            // 
            this.lblPrimary.AutoSize = true;
            this.lblPrimary.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimary.Location = new System.Drawing.Point(105, 22);
            this.lblPrimary.Name = "lblPrimary";
            this.lblPrimary.Size = new System.Drawing.Size(129, 33);
            this.lblPrimary.TabIndex = 2;
            this.lblPrimary.Text = "Success";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(107, 58);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(91, 23);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Message";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 10;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(460, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(53, 53);
            this.guna2ControlBox1.TabIndex = 4;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CustomAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 108);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblPrimary);
            this.Controls.Add(this.alertBoxPicture);
            this.Controls.Add(this.borderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomAlert";
            this.Text = "CustomAlert";
            ((System.ComponentModel.ISupportInitialize)(this.alertBoxPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel borderPanel;
        private Guna.UI2.WinForms.Guna2PictureBox alertBoxPicture;
        private System.Windows.Forms.Label lblPrimary;
        private System.Windows.Forms.Label lblMessage;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Timer timer1;
    }
}