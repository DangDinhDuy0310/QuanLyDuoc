using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanAn
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadCTHD();
            TongDoanhThuHDA();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-9DJVGKJ;Initial Catalog=HeThongDuocPham;Integrated Security=True");
    
     
        private void LoadCTHD()
        {
            Con.Open();
            string Query = "select s.NgayBan,x.TenDaiLy,Sum(s.TongTien) as 'Tổng Tiền Của Đại Lý' from ChiTietHoaDon as s,DaiLy as x, HoaDon as hd where s.MaHoaDon = hd.MaHoaDon and x.MaDaiLy = hd.MaDaiLy group by x.TenDaiLy,s.NgayBan";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BangCTHD.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        
        private void BangTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BangTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }

        private void Them_Click(object sender, EventArgs e)
        {
            
        }
        int Key = 0;
        private void Xoa_Click(object sender, EventArgs e)
        {
            
        }

        private void DoiMatKhau_Click(object sender, EventArgs e)
        {
           

        }

        private void VaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BangCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void TongDoanhThuHDA()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(TongTien) from ChiTietHoaDon  ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TongDoanhThu.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        void TongDoanhThuHD()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(TongTien) from ChiTietHoaDon where NgayBan >= '" + NgayBD.Text + "' and NgayBan <= '" + NgayKT.Text + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TongDoanhThu.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
         
          
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Con.Open();
            string Query = "select s.NgayBan,x.TenDaiLy,Sum(s.TongTien) as 'Tổng Tiền Của Đại Lý' from ChiTietHoaDon as s,DaiLy as x, HoaDon as hd where s.MaHoaDon = hd.MaHoaDon and x.MaDaiLy = hd.MaDaiLy and s.NgayBan >= '" + NgayBD.Text + "' and s.NgayBan <= '" + NgayKT.Text + "' group by x.TenDaiLy,s.NgayBan";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BangCTHD.DataSource = ds.Tables[0];
            Con.Close();
            TongDoanhThuHD();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Con.Open();
            string Query = "select s.NgayBan,x.TenDaiLy,Sum(s.TongTien) as 'Tổng Tiền Của Đại Lý' from ChiTietHoaDon as s,DaiLy as x, HoaDon as hd where s.MaHoaDon = hd.MaHoaDon and x.MaDaiLy = hd.MaDaiLy group by x.TenDaiLy,s.NgayBan";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BangCTHD.DataSource = ds.Tables[0];
            Con.Close();
            TongDoanhThuHDA();
        }
    }
}
