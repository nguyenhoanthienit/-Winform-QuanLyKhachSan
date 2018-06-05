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
            
        }
    }
}
