using KiemTra.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTra
{
    public partial class Form1 : Form
    {
        string pathDataNhom;
        string pathDataChitiet;
        private List<ChiTietDanhBa> chitietdanhba;
        private List<NhómDanhBa> nhomdanhba;
        public Form1()
        {
            InitializeComponent();
            pathDataNhom = Application.StartupPath + @"\Data\NhomDanhBa.data";
            pathDataChitiet= Application.StartupPath + @"\Data\ChiTietDanhBa.data";
            gridNhom.AutoGenerateColumns = false;
            
            nhomdanhba = NhómDanhBa.GetListFromFile(pathDataNhom);
            bds1.DataSource = nhomdanhba;
            gridNhom.DataSource = bds1;
        }
         

       

        private void Dvg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var nhomdanhba = (NhómDanhBa)bds1.Current;
            chitietdanhba = ChiTietDanhBa.GetListFromFile(pathDataChitiet, nhomdanhba.TenNhom);
            gridLienLac.AutoGenerateColumns = false;
            bds2.DataSource = chitietdanhba;
            gridLienLac.DataSource = bds2;
        }
        private void GridLienLac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var chitietdanhba = (ChiTietDanhBa)bds2.Current;
            lblTen.Text = chitietdanhba.Tengoi.ToString();
            lblDiaChi.Text = chitietdanhba.Diachi.ToString();
            lblEmail.Text = chitietdanhba.Email.ToString();
            lblSdt.Text = chitietdanhba.SDT.ToString();
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            var themNhom = new ThemNhom();
            themNhom.Show();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            var themLienLac = new ThemLienLac();
            themLienLac.Show();
        }

        private void BtnXoaNhom_Click(object sender, EventArgs e)
        {
            gridNhom.Rows.Remove(gridNhom.CurrentRow);
        }

        private void BtnXoaLienLac_Click(object sender, EventArgs e)
        {
            gridLienLac.Rows.Remove(gridLienLac.CurrentRow);
        }

       
    }
}
