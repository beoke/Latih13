namespace Latih13_mdiformLanjutan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            masterToolStripMenuItem = new ToolStripMenuItem();
            siswaToolStripMenuItem = new ToolStripMenuItem();
            mahasiswaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { masterToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(902, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            masterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { siswaToolStripMenuItem, mahasiswaToolStripMenuItem });
            masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            masterToolStripMenuItem.Size = new Size(104, 24);
            masterToolStripMenuItem.Text = "Master Data";
            // 
            // siswaToolStripMenuItem
            // 
            siswaToolStripMenuItem.Name = "siswaToolStripMenuItem";
            siswaToolStripMenuItem.Size = new Size(224, 26);
            siswaToolStripMenuItem.Text = "Siswa";
            siswaToolStripMenuItem.Click += siswaToolStripMenuItem_Click;
            // 
            // mahasiswaToolStripMenuItem
            // 
            mahasiswaToolStripMenuItem.Name = "mahasiswaToolStripMenuItem";
            mahasiswaToolStripMenuItem.Size = new Size(224, 26);
            mahasiswaToolStripMenuItem.Text = "Mahasiswa";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 563);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem masterToolStripMenuItem;
        private ToolStripMenuItem siswaToolStripMenuItem;
        private ToolStripMenuItem mahasiswaToolStripMenuItem;
    }
}
