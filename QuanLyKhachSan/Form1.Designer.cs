using System.Collections;
using System.Windows.Forms;
namespace QuanLyKhachSan
{
    partial class fBatDau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBatDau));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDVTimKiem = new System.Windows.Forms.Button();
            this.cbxDVGia = new System.Windows.Forms.ComboBox();
            this.cbxDVSao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDVTp = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel301 = new System.Windows.Forms.Panel();
            this.label201 = new System.Windows.Forms.Label();
            this.pictureBox101 = new System.Windows.Forms.PictureBox();
            this.btnDVDnhap = new System.Windows.Forms.Button();
            this.btnDVDki = new System.Windows.Forms.Button();
            this.panelDV = new System.Windows.Forms.Panel();
            this.btnDVDxuat = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelChuY = new System.Windows.Forms.Label();
            this.labelTenKH = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel301.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox101)).BeginInit();
            this.panelDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(235, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dịch vụ Ivivu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Giá cả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(182, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hạng sao";
            // 
            // btnDVTimKiem
            // 
            this.btnDVTimKiem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDVTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDVTimKiem.FlatAppearance.BorderSize = 0;
            this.btnDVTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDVTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnDVTimKiem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDVTimKiem.Location = new System.Drawing.Point(542, 23);
            this.btnDVTimKiem.Name = "btnDVTimKiem";
            this.btnDVTimKiem.Size = new System.Drawing.Size(99, 47);
            this.btnDVTimKiem.TabIndex = 5;
            this.btnDVTimKiem.Text = "TÌM KIẾM";
            this.btnDVTimKiem.UseVisualStyleBackColor = false;
            this.btnDVTimKiem.Click += new System.EventHandler(this.btnDVTimKiem_Click);
            // 
            // cbxDVGia
            // 
            this.cbxDVGia.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cbxDVGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDVGia.FormattingEnabled = true;
            this.cbxDVGia.Items.AddRange(new object[] {
            "1000000",
            "1500000",
            "2000000",
            "5000000"});
            this.cbxDVGia.Location = new System.Drawing.Point(14, 49);
            this.cbxDVGia.Name = "cbxDVGia";
            this.cbxDVGia.Size = new System.Drawing.Size(107, 21);
            this.cbxDVGia.TabIndex = 1;
            this.cbxDVGia.Text = "1000000";
            // 
            // cbxDVSao
            // 
            this.cbxDVSao.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cbxDVSao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDVSao.FormattingEnabled = true;
            this.cbxDVSao.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbxDVSao.Location = new System.Drawing.Point(187, 49);
            this.cbxDVSao.Name = "cbxDVSao";
            this.cbxDVSao.Size = new System.Drawing.Size(107, 21);
            this.cbxDVSao.TabIndex = 2;
            this.cbxDVSao.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(355, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thành phố";
            // 
            // cbxDVTp
            // 
            this.cbxDVTp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cbxDVTp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDVTp.FormattingEnabled = true;
            this.cbxDVTp.Items.AddRange(new object[] {
            "TPHCM",
            "Đà Nẵng",
            "Hà Nội"});
            this.cbxDVTp.Location = new System.Drawing.Point(361, 49);
            this.cbxDVTp.Name = "cbxDVTp";
            this.cbxDVTp.Size = new System.Drawing.Size(107, 21);
            this.cbxDVTp.TabIndex = 3;
            this.cbxDVTp.Text = "TPHCM";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnDVTimKiem);
            this.panel1.Controls.Add(this.cbxDVTp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbxDVGia);
            this.panel1.Controls.Add(this.cbxDVSao);
            this.panel1.Location = new System.Drawing.Point(58, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 84);
            this.panel1.TabIndex = 10;
            // 
            // panel301
            // 
            this.panel301.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel301.Controls.Add(this.label201);
            this.panel301.Controls.Add(this.pictureBox101);
            this.panel301.Location = new System.Drawing.Point(64, 0);
            this.panel301.Name = "panel301";
            this.panel301.Size = new System.Drawing.Size(102, 137);
            this.panel301.TabIndex = 11;
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label201.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label201.Location = new System.Drawing.Point(24, 94);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(59, 23);
            this.label201.TabIndex = 3;
            this.label201.Text = "IVIVU";
            // 
            // pictureBox101
            // 
            this.pictureBox101.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox101.Image")));
            this.pictureBox101.Location = new System.Drawing.Point(18, 16);
            this.pictureBox101.Name = "pictureBox101";
            this.pictureBox101.Size = new System.Drawing.Size(67, 63);
            this.pictureBox101.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox101.TabIndex = 4;
            this.pictureBox101.TabStop = false;
            // 
            // btnDVDnhap
            // 
            this.btnDVDnhap.BackColor = System.Drawing.Color.DarkRed;
            this.btnDVDnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDVDnhap.FlatAppearance.BorderSize = 0;
            this.btnDVDnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDVDnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDVDnhap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDVDnhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDVDnhap.Location = new System.Drawing.Point(179, 8);
            this.btnDVDnhap.Name = "btnDVDnhap";
            this.btnDVDnhap.Size = new System.Drawing.Size(90, 23);
            this.btnDVDnhap.TabIndex = 10;
            this.btnDVDnhap.Tag = "";
            this.btnDVDnhap.Text = "ĐĂNG NHẬP";
            this.btnDVDnhap.UseVisualStyleBackColor = false;
            this.btnDVDnhap.Click += new System.EventHandler(this.btnDnhap_Click);
            // 
            // btnDVDki
            // 
            this.btnDVDki.BackColor = System.Drawing.Color.DarkRed;
            this.btnDVDki.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDVDki.FlatAppearance.BorderSize = 0;
            this.btnDVDki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDVDki.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDVDki.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDVDki.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDVDki.Location = new System.Drawing.Point(271, 8);
            this.btnDVDki.Name = "btnDVDki";
            this.btnDVDki.Size = new System.Drawing.Size(90, 23);
            this.btnDVDki.TabIndex = 12;
            this.btnDVDki.Tag = "";
            this.btnDVDki.Text = "ĐĂNG KÍ";
            this.btnDVDki.UseVisualStyleBackColor = false;
            this.btnDVDki.Click += new System.EventHandler(this.btnDki_Click);
            // 
            // panelDV
            // 
            this.panelDV.Controls.Add(this.labelTenKH);
            this.panelDV.Controls.Add(this.btnDVDxuat);
            this.panelDV.Controls.Add(this.btnDVDnhap);
            this.panelDV.Controls.Add(this.btnDVDki);
            this.panelDV.Location = new System.Drawing.Point(336, 5);
            this.panelDV.Name = "panelDV";
            this.panelDV.Size = new System.Drawing.Size(367, 62);
            this.panelDV.TabIndex = 13;
            // 
            // btnDVDxuat
            // 
            this.btnDVDxuat.BackColor = System.Drawing.Color.DarkRed;
            this.btnDVDxuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDVDxuat.FlatAppearance.BorderSize = 0;
            this.btnDVDxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDVDxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDVDxuat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDVDxuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDVDxuat.Location = new System.Drawing.Point(271, 36);
            this.btnDVDxuat.Name = "btnDVDxuat";
            this.btnDVDxuat.Size = new System.Drawing.Size(90, 23);
            this.btnDVDxuat.TabIndex = 13;
            this.btnDVDxuat.Tag = "";
            this.btnDVDxuat.Text = "ĐĂNG XUẤT";
            this.btnDVDxuat.UseVisualStyleBackColor = false;
            this.btnDVDxuat.Click += new System.EventHandler(this.btnDVDxuat_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(50, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(641, 150);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // labelChuY
            // 
            this.labelChuY.AutoSize = true;
            this.labelChuY.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChuY.ForeColor = System.Drawing.Color.DarkRed;
            this.labelChuY.Location = new System.Drawing.Point(68, 246);
            this.labelChuY.Name = "labelChuY";
            this.labelChuY.Size = new System.Drawing.Size(336, 20);
            this.labelChuY.TabIndex = 15;
            this.labelChuY.Text = "*Click vào dòng có phòng cần đặt để đặt phòng";
            // 
            // labelTenKH
            // 
            this.labelTenKH.AutoSize = true;
            this.labelTenKH.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTenKH.Font = new System.Drawing.Font("Segoe UI", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenKH.ForeColor = System.Drawing.Color.Indigo;
            this.labelTenKH.Location = new System.Drawing.Point(146, 3);
            this.labelTenKH.Name = "labelTenKH";
            this.labelTenKH.Size = new System.Drawing.Size(175, 30);
            this.labelTenKH.TabIndex = 16;
            this.labelTenKH.Text = "Tên khách hàng";
            // 
            // fBatDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(707, 447);
            this.Controls.Add(this.labelChuY);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelDV);
            this.Controls.Add(this.panel301);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fBatDau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ivivu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fBatDau_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fBatDau_FormClosed);
            this.Load += new System.EventHandler(this.fBatDau_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel301.ResumeLayout(false);
            this.panel301.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox101)).EndInit();
            this.panelDV.ResumeLayout(false);
            this.panelDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDVTimKiem;
        private System.Windows.Forms.ComboBox cbxDVGia;
        private System.Windows.Forms.ComboBox cbxDVSao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDVTp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel301;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.PictureBox pictureBox101;
        private System.Windows.Forms.Button btnDVDnhap;
        private System.Windows.Forms.Button btnDVDki;
        private System.Windows.Forms.Panel panelDV;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Label labelChuY;
        private Button btnDVDxuat;
        private Label labelTenKH;

    }
}

