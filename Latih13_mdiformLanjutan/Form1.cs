namespace Latih13_mdiformLanjutan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void siswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formdata = new DataSiswa();
            formdata.MdiParent = this;
            formdata.Show();
        }
    }
}
