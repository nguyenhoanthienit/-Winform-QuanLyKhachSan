using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fBatDau : Form
    {
        public fBatDau()
        {
            InitializeComponent();
        }

        public string currentUser = fDangNhap.UserInformation.CurrentLoggedInUser;
        private void btnDki_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangKi f = new fDangKi();
            f.ShowDialog();
        }

        private void btnDnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
        }

        private void fBatDau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thật sự thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fBatDau_Load(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                Label l = new Label();
                l.Text = "Xin chào " + currentUser + " !";
                l.AutoSize = true;
                l.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                l.Font = new System.Drawing.Font("Segoe UI", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                l.ForeColor = System.Drawing.Color.DeepSkyBlue;
                l.Location = new System.Drawing.Point(48, 0);
                l.Name = "labeldemo";
                l.Size = new System.Drawing.Size(148, 30);
                l.TabIndex = 15;
                panelDV.Controls.Remove(btnDVDnhap);
                panelDV.Controls.Remove(btnDVDki);
                panelDV.Controls.Add(l);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            fDatPhong f = new fDatPhong();
            f.Show();
        }

        private void fBatDau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
