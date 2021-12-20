using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanAn
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            open(new BanHang());
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            open(new Admin());
        }
        private Form currentFormChild;
        private void open(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            guna2Panel2.Controls.Add(childForm);
            guna2Panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            open(new Thuoc());
        }

        private void guna2Button3_Click_2(object sender, EventArgs e)
        {
            open(new nvVSkh());
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
