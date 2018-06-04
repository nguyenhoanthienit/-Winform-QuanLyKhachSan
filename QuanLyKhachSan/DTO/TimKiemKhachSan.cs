using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class TimKiemKhachSan
    {
        public TimKiemKhachSan(string maKhachSan, string tenKhachSan, int soSao, int soNha, string duong, string quan, string tenThanhPho, int giaCa, string moTa)
        {
            this.MaKhachSan = maKhachSan;
            this.TenKhachSan = tenKhachSan;
            this.SoSao = soSao;
            this.SoNha = soNha;
            this.Duong = duong;
            this.Quan = quan;
            this.TenThanhPho = tenThanhPho;
            this.GiaCa = giaCa;
            this.MoTa = moTa;
        }

        public TimKiemKhachSan(DataRow row)
        {
            this.MaKhachSan = row["maKS"].ToString();
            this.TenKhachSan = row["tenKS"].ToString();
            this.SoNha = (int)row["soNha"];
            this.SoSao = (int)row["soSao"];
            this.Duong = row["duong"].ToString();
            this.Quan = row["quan"].ToString();
            this.TenThanhPho = row["thanhPho"].ToString();
            this.GiaCa = (int)row["giaTB"];
            this.MoTa = row["moTa"].ToString();
        }

        private int soSao;
        private string tenThanhPho;
        private int giaCa;
        private string maKhachSan;
        private string tenKhachSan;
        private int soNha;
        private string duong;
        private string quan;
        private string moTa;

        public int SoSao { get => soSao; set => soSao = value; }
        public string TenThanhPho { get => tenThanhPho; set => tenThanhPho = value; }
        public int GiaCa { get => giaCa; set => giaCa = value; }
        public string MaKhachSan { get => maKhachSan; set => maKhachSan = value; }
        public string TenKhachSan { get => tenKhachSan; set => tenKhachSan = value; }
        public int SoNha { get => soNha; set => soNha = value; }
        public string Duong { get => duong; set => duong = value; }
        public string Quan { get => quan; set => quan = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
