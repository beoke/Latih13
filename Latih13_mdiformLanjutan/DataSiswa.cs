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
        private int selectedSiswaID;
        public DataSiswa()
        {
            InitializeComponent();
            ListData();
            this.Load += new EventHandler(DataSiswa_Load);
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            
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
            tx_kota.Text = siswa.Kota;


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
            ClearForm();
            tabControl1.SelectedIndex = 0;
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
                siswa.Kota = tx_kota.Text;


                if (rb_laki.Checked)
                {
                    siswa.Gender = "Laki laki";
                }
                else if (rb_perempuan.Checked)
                {
                    siswa.Gender = "Perempuan";
                }

                db.SaveChanges();
            }

            tabControl1.SelectedIndex = 1;
        }
        private void ClearForm()
        {
            txt_siswaID.Clear();
            txt_name.Clear();
            txt_NIS.Clear();
            txt_tempatlahir.Clear();
            dtp_tgl.Value = DateTime.Now;
            txt_alamat.Clear();
            tx_kota.Clear();
            rb_laki.Checked = false;
            rb_perempuan.Checked = false;
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
            if (int.TryParse(txt_siswaID.Text, out int siswaID))
            {
                return siswaID;
            }
            return 0;
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
                    tx_kota.Text = siswa.Kota;

                    // load radio button
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedSiswaID = Convert.ToInt32(row.Cells["SiswaId"].Value);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedSiswaID > 0)
            {
                var result = MessageBox.Show("Apa anda yakin ingin menghapus data di atas?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    DeleteData(selectedSiswaID);
                    ListData();
                }
            }
            else
            {
                MessageBox.Show("Mohon pilih data yang mau di hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DeleteData(int siswaID)
        {
            using (var db = new Dbcon())
            {
                var siswa = db.siswa.Find(siswaID);
                if (siswa != null)
                {
                    db.siswa.Remove(siswa);
                    db.SaveChanges();
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void rb_perempuan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedSiswaID = Convert.ToInt32(row.Cells["SiswaId"].Value);
                tabControl1.SelectedIndex = 1;
                LoadData(selectedSiswaID);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}
