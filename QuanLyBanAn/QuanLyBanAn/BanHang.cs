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
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
            LoadbangThuoc();
            LoadHoaDon();
            hienthimanDL();
            hienthimanNV();
           
            numberHD();
            sum();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-9DJVGKJ;Initial Catalog=HeThongDuocPham;Integrated Security=True");

       
        private void LoadbangThuoc()
        {
            
                Con.Open();
                string Query = "Select  *from Thuoc";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                BangThuoc.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in BangThuoc.Rows)
            {
                if (row.Cells[1].Value != null | Convert.ToString(row.Cells[1].Value) == string.Empty)
                {
                    BangThuoc.Columns[0].Visible = false;
                    BangThuoc.Columns[1].Visible = false;
                    break;
                }
                else
                {
                    BangThuoc.Columns[0].Visible = true;
                    BangThuoc.Columns[1].Visible = true;
                    break;
                }
            }

            Con.Close();
            
        }
      

        private void LoadHoaDon()
        {
            
            Con.Open();
            string Query = "Select * from HoaDon";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DatHang.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in DatHang.Rows)
            {
                if (row.Cells[1].Value != null | Convert.ToString(row.Cells[1].Value) == string.Empty)
                {
                    DatHang.Columns[0].Visible = false;
                    DatHang.Columns[1].Visible = false;
                    DatHang.Columns[2].Visible = false;
                   
                    break;
                }
                else
                {
                    DatHang.Columns[0].Visible = true;
                    DatHang.Columns[1].Visible = true;
                    DatHang.Columns[2].Visible = true;
                 
                    break;
                }
            }
            Con.Close();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        int Key = 0;
        
        
       

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        void reset()
        {
            TenThuoc.Text = "";
            SoLuongThuoc.Text = "";
           
            GiaBan.Text = "";
       
            
        }
        void resetDonHang()
        {
            guna2TextBox1.Text = "";
            TenThuoc.Text = "";
            SoLuongThuoc.Text = "";

            GiaBan.Text = "";
           
            

        }

        /* TenThuoc.Text = BangThuoc.Rows[i].Cells[1].Value.ToString();
            SoLuongThuoc.Text = BangThuoc.Rows[i].Cells[4].Value.ToString();
            GiaBan.Text = BangThuoc.Rows[i].Cells[3].Value.ToString();
            LoaiThuoc.Text = BangThuoc.Rows[i].Cells[0].Value.ToString();
            NguoiSuDung.Text = BangThuoc.Rows[i].Cells[2].Value.ToString();*/


        private void BangThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.BangThuoc.Rows[e.RowIndex];
                TenThuoc.Text = BangThuoc.Rows[e.RowIndex].Cells[2].Value.ToString();
               
                GiaBan.Text = BangThuoc.Rows[e.RowIndex].Cells[4].Value.ToString();
                MaThuoc.Text = BangThuoc.Rows[e.RowIndex].Cells[0].Value.ToString();
                soluongdau = Convert.ToInt32(BangThuoc.Rows[e.RowIndex].Cells[3].Value.ToString());
               
            }
            if (TenThuoc.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BangThuoc.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
          
        }
        int SoLuongDathang=0;
    
        private void DatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DatHang.Rows[e.RowIndex];
               guna2TextBox1.Text = DatHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                TenThuoc.Text = DatHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                GiaBan.Text = DatHang.Rows[e.RowIndex].Cells[5].Value.ToString();
             
                ThanhTien.Text = DatHang.Rows[e.RowIndex].Cells[6].Value.ToString();
                
              
                SoLuongDathang =Convert.ToInt32(DatHang.Rows[e.RowIndex].Cells[4].Value.ToString());
               

            }
            if (TenThuoc.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DatHang.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
       

        void  sum()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(ThanhTien) from HoaDon ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            HienThiThanhTien.Text =  dt.Rows[0][0].ToString();
            Con.Close();
        }
        int soluongdau  ;

        int newsoluong;
       
        void giam()
        {
           
            try
            {
               
              newsoluong = soluongdau - Convert.ToInt32(SoLuongThuoc.Text) ;
                Con.Open();
                
                SqlCommand cmd = new SqlCommand("sp_CapNhatThuoc N'" + TenThuoc.Text + "','" + newsoluong + "'", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                
                LoadbangThuoc();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        int number = 0;
        int sp;
        void tang()
        {
        
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select SoLuong from Thuoc where TenThuoc=N'" + TenThuoc.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SoLuongThuoc.Text = dt.Rows[0][0].ToString();
            sp = Convert.ToInt32(SoLuongThuoc.Text);
            number = SoLuongDathang + sp;
              
                SqlCommand cmd = new SqlCommand("sp_CapNhatThuoc N'" + TenThuoc.Text + "','" + number + "'", Con);
              
                cmd.ExecuteNonQuery();
                Con.Close();
               
                LoadbangThuoc();


        }
       
        
       
       void  CTHD()
        {
           
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into ChiTietHoaDon (MaHoaDon,MaThuoc,TenThuoc,NgayBan,TongTien,TenDaiLy) values (@MY,@MN,@RR,@MK,@MC,@MA)", Con);
            cmd.Parameters.AddWithValue("@MY", MaHoaDon.Text);
            cmd.Parameters.AddWithValue("@MN", MaThuoc.Text);
            cmd.Parameters.AddWithValue("@RR", TenThuoc.Text);
            cmd.Parameters.AddWithValue("@MK",guna2DateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@MC", ThanhTien.Text);
            cmd.Parameters.AddWithValue("@MA", TenDaiLy.Text);
            cmd.ExecuteNonQuery();
            Con.Close();
        }
         string S= "Chưa Thanh Toán";
        
        private void MuaThuoc_Click(object sender, EventArgs e)
        {
            if (TenThuoc.Text == "" || SoLuongThuoc.Text == ""|| GiaBan.Text == "" || TenDaiLy.Text == "" || TenNhanVien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into HoaDon (MaHoaDon,TenThuoc,SoLuong,ThanhTien,GiaBan,MaNhanVien,MaDaiLy,TrangThai,TenDaiLy) values (@MY,@MN,@MK,@MC,@GB,@AA,@BB,@CC,@DC)", Con);
                    cmd.Parameters.AddWithValue("@MY", MaHoaDon.Text);
                    cmd.Parameters.AddWithValue("@MN", TenThuoc.Text);
                    cmd.Parameters.AddWithValue("@MK", SoLuongThuoc.Text);
                    cmd.Parameters.AddWithValue("@MC", ThanhTien.Text);
                    cmd.Parameters.AddWithValue("@GB", GiaBan.Text);
                   
                    cmd.Parameters.AddWithValue("@AA", MaNhanVien.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BB", MaDaiLy.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DC", TenDaiLy.Text);
                    cmd.Parameters.AddWithValue("@CC", S.ToString());
                    cmd.ExecuteNonQuery();
                 
                    MessageBox.Show("Đã lưu");
                    Con.Close();
                    giam();
                    LoadHoaDon();
                    sum();
                    CTHD();

                    numberHD();

                    reset();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void numberHD()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select MAX(MaHoaDon)+1 from HoaDon", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MaHoaDon.Text =  dt.Rows[0][0].ToString();
            Con.Close();
        }
        void CTHDXoa()
        {

            Con.Open();
            SqlCommand cmd = new SqlCommand("Delete from ChiTietHoaDon where MaHoaDon = @MKey", Con);
            cmd.Parameters.AddWithValue("@MKey", Key);
            cmd.ExecuteNonQuery();
            
            Con.Close();
        }
        private void XoaThuoc_Click(object sender, EventArgs e)
        {
            CTHDXoa();
            if (Key == 0)
            {
                MessageBox.Show("Chọn một dòng để xóa !");
            }
            else
            {
                try
                {
                 
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from HoaDon where MaHoaDon = @MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa");
                    Con.Close();
                    tang();
                    
                    LoadHoaDon();
                    resetDonHang();
                   
                    sum();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
              
        }

        private void HienThiThanhTien_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SoLuongThuoc_TextChanged(object sender, EventArgs e)
        {
            if (SoLuongThuoc.Text != "")
            {
                int Price = Convert.ToInt32(GiaBan.Text);
                int Quantity = Convert.ToInt32(SoLuongThuoc.Text);
                int Total = Price * Quantity;
                ThanhTien.Text = Total.ToString();
            }
            else
            {
                ThanhTien.Clear();
            }
        }

        private void GiaBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DanhSachNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            Con.Open();
            string Query = "Select  *from Thuoc where DoiTuongSD=N'"+DanhSachNguoiDung.SelectedItem+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BangThuoc.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in BangThuoc.Rows)
            {
                if (row.Cells[1].Value != null | Convert.ToString(row.Cells[1].Value) == string.Empty)
                {
                    BangThuoc.Columns[0].Visible = false;
                    BangThuoc.Columns[1].Visible = false;
                    break;
                }
                else
                {
                    BangThuoc.Columns[0].Visible = true;
                    BangThuoc.Columns[1].Visible = true;
                    break;
                }
            }

            Con.Close();

        }
        void update()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("update HoaDon set ThanhTien= 0,TrangThai=N'Đã Thanh Toán' where MaDaiLy = @MKey", Con);
            cmd.Parameters.AddWithValue("@MKey", MaDaiLy.SelectedValue.ToString());
            cmd.ExecuteNonQuery();

            Con.Close();
        }
        private void ThanhToan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tổng Tiền Bạn Đã Thanh Toán  " + HienThiThanhTien.Text);
            update();
            LoadHoaDon();
            sum();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void hienthimanNV()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MaNhanVien from NhanVien", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNhanVien", typeof(int));
            dt.Load(Rdr);
            MaNhanVien.ValueMember = "MaNhanVien";
            MaNhanVien.DataSource = dt;
            Con.Close();
        }
        void GetNhanVien()
        {
            Con.Open();
            string Query = "Select * from NhanVien where MaNhanVien= '" + MaNhanVien.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TenNhanVien.Text = dr["HoTen"].ToString();
            }
            Con.Close();
        }
        private void hienthimanDL()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MaDaiLy from DaiLy", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaDaiLy", typeof(int));
            dt.Load(Rdr);
            MaDaiLy.ValueMember = "MaDaiLy";
            MaDaiLy.DataSource = dt;
            Con.Close();
        }
        void GetDaiLy()
        {
            Con.Open();
            string Query = "Select * from DaiLy where MaDaiLy= '" + MaDaiLy.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TenDaiLy.Text = dr["TenDaiLy"].ToString();
            }
            Con.Close();
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MaDaiLy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDaiLy();
        }

        private void MaNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetNhanVien();
        }

        private void lammoi_Click(object sender, EventArgs e)
        {

            Con.Open();
            string Query = "Select  *from Thuoc";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BangThuoc.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in BangThuoc.Rows)
            {
                if (row.Cells[1].Value != null | Convert.ToString(row.Cells[1].Value) == string.Empty)
                {
                    BangThuoc.Columns[0].Visible = false;
                    BangThuoc.Columns[1].Visible = false;
                    break;
                }
                else
                {
                    BangThuoc.Columns[0].Visible = true;
                    BangThuoc.Columns[1].Visible = true;
                    break;
                }
            }

            Con.Close();
        }
    }
}
