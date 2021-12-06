using QuanLyBanAn.Dao;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadLoaiThuoc();
            LoadNhaCungCap();
            Thuoc();
            hienthimansx();
            hienThiMaLoaiThuoc();
        }


        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-9DJVGKJ;Initial Catalog=HeThongDuocPham;Integrated Security=True");
        private void LoadLoaiThuoc()
        {
            Con.Open();
            string Query = "Select * from LoaiThuoc";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LoaiThuoc.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Thuoc()
        {
            Con.Open();
            string Query = "Select * from Thuoc";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ThuocKS.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            guna2TextBox7.Text = "";
            guna2TextBox13.Text = "";
        }
        private void ResetNCC()
        {
            TenNCC.Text = "";
            DiaChi.Text = "";
            SDT.Text = "";
        }
        private void ResetThuoc()
        {
            TenThuoc.Text = "";
            SoLuongThuoc.Text = "";
            GiaBan.Text = "";
        }
        private void LoadNhaCungCap()
        {
            Con.Open();
            string Query = "Select * from NhaSanXuat";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
           NhaCungCap.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.LoaiThuoc.Rows[e.RowIndex];
                guna2TextBox13.Text = LoaiThuoc.Rows[e.RowIndex].Cells[1].Value.ToString();
                guna2TextBox7.Text = LoaiThuoc.Rows[e.RowIndex].Cells[2].Value.ToString();
               
            }
            if (guna2TextBox13.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LoaiThuoc.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (guna2TextBox7.Text == "" || guna2TextBox13.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into LoaiThuoc(NguoiSD,LoaiThuoc)values(@MN,@MK)", Con);
                    cmd.Parameters.AddWithValue("@MN", guna2TextBox13.Text);
                    cmd.Parameters.AddWithValue("@MK", guna2TextBox7.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu");
                    Con.Close();
                    LoadLoaiThuoc();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        private void guna2Button9_Click(object sender, EventArgs e)
        {

            if (guna2TextBox7.Text == "" || guna2TextBox13.Text == "")
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update LoaiThuoc set LoaiThuoc=@MK,NguoiSD=@MN where MaLoaiThuoc=@Mkey", Con);
                    cmd.Parameters.AddWithValue("@MN", guna2TextBox13.Text);
                    cmd.Parameters.AddWithValue("@MK", guna2TextBox7.Text);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu");
                    Con.Close();
                    LoadLoaiThuoc();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("Chọn một dòng để xóa !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from LoaiThuoc where MaLoaiThuoc = @MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa");
                    Con.Close();
                    LoadLoaiThuoc();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.NhaCungCap.Rows[e.RowIndex];
                TenNCC.Text = NhaCungCap.Rows[e.RowIndex].Cells[1].Value.ToString();
                DiaChi.Text = NhaCungCap.Rows[e.RowIndex].Cells[2].Value.ToString();
                SDT.Text = NhaCungCap.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            if (TenNCC.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(NhaCungCap.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            if (DiaChi.Text == "" || TenNCC.Text == "" || SDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into NhaSanXuat(TenNSX,DiaChi,SDT)values(@MN,@MK,@AK)", Con);
                    cmd.Parameters.AddWithValue("@MN", TenNCC.Text);
                    cmd.Parameters.AddWithValue("@MK", DiaChi.Text);
                    cmd.Parameters.AddWithValue("@AK", SDT.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu");
                    Con.Close();
                   LoadNhaCungCap();
                    ResetNCC();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("Chọn một dòng để xóa !");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from NhaSanXuat where MaNSX = @MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa");
                    Con.Close();
                    LoadNhaCungCap();
                    ResetNCC();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            if (DiaChi.Text == "" || TenNCC.Text == "" || SDT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update NhaSanXuat set TenNSX=@MN,DiaChi=@Mk,SDT=@AK where MaNSX=@Mkey", Con);
                    cmd.Parameters.AddWithValue("@MN", TenNCC.Text);
                    cmd.Parameters.AddWithValue("@MK", DiaChi.Text);
                    cmd.Parameters.AddWithValue("@AK", SDT.Text);

                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu");
                    Con.Close();
                    LoadNhaCungCap();
                    ResetNCC();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        

        private void hienthimansx()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MaNSX from NhaSanXuat", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNSX", typeof(int));
            dt.Load(Rdr);
            guna2ComboBox2.ValueMember = "MaNSX";
            guna2ComboBox2.DataSource = dt;
            Con.Close();
        }
        private void hienThiMaLoaiThuoc()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MaLoaiThuoc from LoaiThuoc", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLoaiThuoc", typeof(int));
            dt.Load(Rdr);
            guna2ComboBox1.ValueMember = "MaLoaiThuoc";
            guna2ComboBox1.DataSource = dt;
            Con.Close();
        }
        private void MedManCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            
        }

        private void ThuocKS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ThuocKS.Rows[e.RowIndex];
                TenThuoc.Text = ThuocKS.Rows[e.RowIndex].Cells[0].Value.ToString();
                SoLuongThuoc.Text = ThuocKS.Rows[e.RowIndex].Cells[1].Value.ToString();
                GiaBan.Text = ThuocKS.Rows[e.RowIndex].Cells[2].Value.ToString();
                guna2ComboBox1.SelectedItem = ThuocKS.Rows[e.RowIndex].Cells[3].Value.ToString();
                guna2ComboBox2.SelectedItem = ThuocKS.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            if (TenThuoc.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ThuocKS.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (TenThuoc.Text == "" || SoLuongThuoc.Text == "" || GiaBan.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Thuoc(TenThuoc,[SoLuong],GiaBan,MaNSX,MaLoaiThuoc)values(@MN,@MK,@GB,@HD,@UI)", Con);
                    cmd.Parameters.AddWithValue("@MN", TenThuoc.Text);
                    cmd.Parameters.AddWithValue("@MK", SoLuongThuoc.Text);
                    cmd.Parameters.AddWithValue("@GB", GiaBan.Text);
                    cmd.Parameters.AddWithValue("@HD", guna2ComboBox1.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@UI", guna2ComboBox2.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu");
                    Con.Close();
                    LoadLoaiThuoc();
                    ResetThuoc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
