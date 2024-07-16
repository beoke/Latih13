using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latih13_mdiformLanjutan
{
    public partial class DataSiswa : Form
    {
        public DataSiswa()
        {
            InitializeComponent();
            ListData();
        }
        private void ListData()
        {
            using var db = new Dbcon();
            var listSiswa = db.siswa.ToList();
            dataGridView1.DataSource = listSiswa;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            NewSiswa();
        }
        public void NewSiswa()
        {
            var newSiswa = new SiswaModel();
            using (var db = new Dbcon())
            {
                db.siswa.Add(newSiswa);
                db.SaveChanges();
            }

            ShowInput(newSiswa);
        }
        public void ShowInput(SiswaModel siswa)
        {
            txt_siswaID.Text = siswa.SiswaId.ToString();
            txt_name.Text = siswa.SiswaName;
            txt_NIS.Text = siswa.Nis;
            txt_tempatlahir.Text = siswa.TempatLahir;
            dtp_tgl.Value = siswa.TglLahir;
            txt_alamat.Text = siswa.Alamat;
            txt_kota.Text = siswa.Kota;
            tabControl1.SelectedIndex = 1;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveData();
            ListData();
        }
        public void SaveData()
        {
            using (var db = new Dbcon())
            {
                var siswa = db.siswa.Find(int.Parse(txt_siswaID.Text));

                siswa.SiswaName = txt_name.Text;
                siswa.Nis = txt_NIS.Text;
                siswa.TempatLahir = txt_tempatlahir.Text;
                siswa.TglLahir = dtp_tgl.Value;
                siswa.Alamat = txt_alamat.Text;
                siswa.Kota = txt_kota.Text;

                db.SaveChanges();
            }

            // Setelah menyimpan, kembali ke TabPage 1
            tabControl1.SelectedIndex = 1;
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void DataSiswa_Load(object sender, EventArgs e)
        {

        }

    }
}
