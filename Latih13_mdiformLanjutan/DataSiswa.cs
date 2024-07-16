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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Latih13_mdiformLanjutan
{
    public partial class DataSiswa : Form
    {
        public DataSiswa()
        {
            InitializeComponent();
            ListData();
            this.Load += new EventHandler(DataSiswa_Load);
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
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

            // Load the state of the radio buttons
            if (siswa.Gender == "Laki Laki")
            {
                rb_laki.Checked = true;
            }
            else if (siswa.Gender == "Perempuan")
            {
                rb_perempuan.Checked = true;
            }

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

                // Save the state of the radio buttons
                if (rb_laki.Checked)
                {
                    siswa.Gender = "Option1";
                }
                else if (rb_perempuan.Checked)
                {
                    siswa.Gender = "Option2";
                }

                db.SaveChanges();
            }

            // After saving, switch back to TabPage 1
            tabControl1.SelectedIndex = 1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                int siswaID = GetCurrentSiswaID();
                LoadData(siswaID);
            }
        }

        private void DataSiswa_Load(object sender, EventArgs e)
        {
            int siswaID = GetCurrentSiswaID();
            LoadData(siswaID);
        }

        private int GetCurrentSiswaID()
        {
            // Replace this with the actual logic to get the selected SiswaID
            if (int.TryParse(txt_siswaID.Text, out int siswaID))
            {
                return siswaID;
            }
            return 0; // or any default value
        }

        public void LoadData(int siswaID)
        {
            using (var db = new Dbcon())
            {
                var siswa = db.siswa.Find(siswaID);

                if (siswa != null)
                {
                    txt_name.Text = siswa.SiswaName;
                    txt_NIS.Text = siswa.Nis;
                    txt_tempatlahir.Text = siswa.TempatLahir;
                    dtp_tgl.Value = siswa.TglLahir;
                    txt_alamat.Text = siswa.Alamat;
                    txt_kota.Text = siswa.Kota;

                    // Load the state of the radio buttons
                    if (siswa.Gender == "Laki Laki")
                    {
                        rb_laki.Checked = true;
                    }
                    else if (siswa.Gender == "Perempuan")
                    {
                        rb_perempuan.Checked = true;
                    }
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void rb_perempuan_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
