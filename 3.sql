--==============================TẠO DB Quản Lý Khách Sạn==============================
CREATE DATABASE QLKhachSan
GO

USE QLKhachSan
GO

--=======================================================================================
--=======================================================================================
--==============================TẠO BẢNG==============================
CREATE TABLE KhachHang
(
	maKH CHAR(10),
	hoTen NVARCHAR(30),
	tenDangNhap VARCHAR(20) NOT NULL,
	matKhau VARCHAR(20) NOT NULL,
	soCMND VARCHAR(13) NOT NULL,
	diaChi NVARCHAR(50),
	soDienThoai VARCHAR(13),
	moTa NVARCHAR(50),
	email VARCHAR(20) NOT NULL,
	PRIMARY KEY (maKH)
)
GO
CREATE TABLE KhachSan
(
	maKS CHAR(5),
	tenKS NVARCHAR(15) NOT NULL,
	soSao INT NOT NULL,
	soNha INT,
	duong NVARCHAR(20),
	quan NVARCHAR(15),
	thanhPho NVARCHAR(20) NOT NULL,
	giaTB INT NOT NULL,
	moTa NVARCHAR(50),
	PRIMARY KEY (maKS)
)
GO

CREATE TABLE LoaiPhong
(
	maLoaiPhong CHAR(10),
	tenLoaiPhong NVARCHAR(10) NOT NULL,
	maKS CHAR(5) NOT NULL,
	donGia INT NOT NULL,
	moTa NVARCHAR(50),
	slTrong INT NOT NULL,
	PRIMARY KEY (maLoaiPhong)
)
GO
CREATE TABLE Phong
(
	maPhong CHAR(10),
	loaiPhong CHAR(10) NOT NULL,
	soPhong INT NOT NULL,
	PRIMARY KEY (maPhong)
)
GO
CREATE TABLE TrangThaiPhong
(
	maPhong CHAR(10),
	ngay DATETIME,
	tinhTrang NVARCHAR(15) NOT NULL,
	PRIMARY KEY (maPhong, ngay)
)
GO
CREATE TABLE DatPhong
(
	maDP CHAR(10),
	maLoaiPhong CHAR(10) NOT NULL,
	maKH CHAR(10) NOT NULL,
	ngayBatDau DATETIME NOT NULL,
	ngayTraPhong DATETIME NOT NULL,
	ngayDat DATETIME NOT NULL,
	donGia INT NOT NULL,
	moTa NVARCHAR(50),
	tinhTrang NVARCHAR(15) NOT NULL,
	PRIMARY KEY (maDP)
)
GO
CREATE TABLE HoaDon 
(
	maHD CHAR(10),
	ngayThanhToan DATETIME NOT NULL,
	tongTien INT NOT NULL,
	maDP CHAR(10) NOT NULL,
	PRIMARY KEY (maHD)
)
GO


--=======================================================================================
--=======================================================================================
--==============================TẠO KHÓA NGOẠI==============================
--LoaiPhong_KhachSan
ALTER TABLE LoaiPhong
ADD CONSTRAINT FK_LoaiPhong_KhachSan
FOREIGN KEY (maKS) REFERENCES KhachSan(maKS)

--Phong_LoaiPhong
ALTER TABLE Phong
ADD CONSTRAINT FK_Phong_LoaiPhong
FOREIGN KEY (loaiPhong) REFERENCES LoaiPhong(maLoaiPhong)

--TrangThaiPhong_Phong
ALTER TABLE TrangThaiPhong
ADD CONSTRAINT FK_TrangThaiPhong_Phong
FOREIGN KEY (maPhong) REFERENCES Phong(maPhong)

--DatPhong_LoaiPhong
ALTER TABLE DatPhong
ADD CONSTRAINT FK_DatPhong_LoaiPhong
FOREIGN KEY (maLoaiPhong) REFERENCES LoaiPhong(maLoaiPhong)

--DatPhong_KhachHang
ALTER TABLE DatPhong
ADD CONSTRAINT FK_DatPhong_KhachHang
FOREIGN KEY (maKH) REFERENCES KhachHang(maKH)

--HoaDon_DatPhong
ALTER TABLE HoaDon
ADD CONSTRAINT FK_HoaDon_DatPhong
FOREIGN KEY (maDP) REFERENCES DatPhong(maDP)


--=======================================================================================
--=======================================================================================
--==============================TẠO INDEX==============================
--KhachHang 
CREATE INDEX IDX_DangNhap ON KhachHang(tenDangNhap, matKhau)
CREATE UNIQUE INDEX IDX_CMND ON KhachHang(soCMND)

--KhachSan
CREATE INDEX IDX_SoSaoThanhPho ON KhachSan(soSao, thanhPho)
CREATE INDEX IDX_GiaTBThanhPho ON KhachSan(giaTB, thanhPho)
CREATE INDEX IDX_ThanhPho ON KhachSan(thanhPho)

--LoaiPhong
CREATE INDEX IDX_MaKS ON LoaiPhong(maKS)
CREATE INDEX IDX_MaKSDonGia ON LoaiPhong(maKS, donGia)

--Phong
CREATE INDEX IDX_LoaiPhong ON Phong(loaiPhong)

--TrangThaiPhong
CREATE INDEX IDX_MaPhong ON TrangThaiPhong(maPhong)

--DatPhong
CREATE INDEX IDX_MaLoaiPhong ON DatPhong(maLoaiPhong)
CREATE INDEX IDX_MaKH ON DatPhong(maKH)

--HoaDon
CREATE INDEX IDX_NgayThanhToanTongTien ON HoaDon(ngayThanhToan, tongTien)
GO

--=======================================================================================
--=======================================================================================
--==============================STORE PROCEDURE==============================
