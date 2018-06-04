using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fDatPhong : Form
    {
        public fDatPhong()
        {
            InitializeComponent();
        }
        public string currentUser = fDangNhap.UserInformation.CurrentLoggedInUser;

        private void btnTTDatPhong_Click(object sender, EventArgs e)
        {
            
            if (currentUser == null)
            {
                MessageBox.Show("Bạn cần đăng nhập để thực hiện chức năng này !");
                this.Hide();
                fDangNhap f = new fDangNhap();
                f.Show();
            }
            else
            {
                MessageBox.Show("Đặt phòng thành công !");
                this.Hide();
                fBatDau f = new fBatDau();
                f.Show();
            }
            
        }

        private void fDatPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            fBatDau f = new fBatDau();
            f.Show();
        }

    }
}
