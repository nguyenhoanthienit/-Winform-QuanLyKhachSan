USE [DoAnCSDLNC_Index]
GO
/****** Object:  StoredProcedure [dbo].[sp_BaoCaoDoanhThu]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BaoCaoDoanhThu]
AS 
	SELECT MONTH(ngayThanhToan) AS 'Tháng', YEAR(ngayThanhToan) AS 'Năm', SUM(tongTien) AS 'Tổng doanh thu'
	FROM HoaDon
	GROUP BY MONTH(ngayThanhToan), YEAR(ngayThanhToan)
	ORDER BY MONTH(ngayThanhToan)
GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhap]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--5. Đăng nhập - đăng xuất
CREATE PROCEDURE [dbo].[sp_DangNhap] @id VARCHAR(20), @mk VARCHAR(20), @maKH VARCHAR(20) OUT, @hoTen NVARCHAR(30) OUT 
AS
	IF (EXISTS (SELECT * FROM KhachHang WHERE tenDangNhap = @id))
	BEGIN
		IF (EXISTS (SELECT * FROM KhachHang WHERE tenDangNhap = @id AND matKhau = @mk))
		BEGIN
			SET @maKH = (SELECT MAKH FROM KhachHang WHERE tenDangNhap = @id AND matKhau = @mk)
			SET @hoTen = (SELECT HOTEN FROM KhachHang WHERE tenDangNhap = @id AND matKhau = @mk)
		END
		ELSE
			RAISERROR('Sai mật khẩu, vui lòng nhập lại',16,1)
			RETURN -1
	END
	ELSE
		RAISERROR('Tên đăng nhập không tồn tại',16,1)
		RETURN -1


GO
/****** Object:  StoredProcedure [dbo].[sp_DatPhong]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DatPhong] @maDP CHAR(10), @maLoaiPhong CHAR(10), @maKH CHAR(10), @ngbd DATETIME, @ngtrp DATETIME, @ngdat DATETIME, @dongia INT, @mota NVARCHAR(50), @ttrang NVARCHAR(15), @maPhong CHAR(10) 
AS
	IF (EXISTS(SELECT * FROM LoaiPhong WHERE maLoaiPhong = @maLoaiPhong AND slTrong > 0))
	BEGIN
		INSERT INTO DatPhong(maDP,maLoaiPhong,maKH,ngayBatDau,ngayTraPhong,ngayDat,donGia,moTa,tinhTrang)
		VALUES  ( @maDP , -- maDP - char(10)
		          @maLoaiPhong , -- maLoaiPhong - char(10)
		          @maKH , -- maKH - char(10)
		          @ngbd , -- ngayBatDau - datetime
		          @ngtrp , -- ngayTraPhong - datetime
		          @ngdat , -- ngayDat - datetime
		          @dongia , -- donGia - int
		          @mota , -- moTa - nvarchar(50)
		          @ttrang  -- tinhTrang - nvarchar(15)
		        )
		--KH đặt phòng thành công thì số lượng phòng trống của loại phòng đó giảm xuống 1
		UPDATE LoaiPhong
		SET slTrong = slTrong - 1
		WHERE maLoaiPhong = @maLoaiPhong;
		--Chuyển trạng thái phòng KH vừa đặt sang 'đang sử dụng'
		UPDATE TrangThaiPhong
		SET tinhTrang = N'Đang sử dụng'
		WHERE maPhong IN (SELECT P.maPhong FROM Phong P, TrangThaiPhong T
						 WHERE P.maPhong = T.maPhong AND p.maPhong = @maPhong 
						 AND p.loaiPhong = @maLoaiPhong)
		WHILE (@ngbd <= @ngtrp)
		BEGIN
			INSERT INTO TrangThaiPhong
					( maPhong, ngay, tinhTrang )
			VALUES  ( @maPhong, -- maPhong - char(10)
					  @ngbd, -- ngay - datetime
					  N'Đang sử dụng'  -- tinhTrang - nvarchar(15)
					  )
			SET @ngbd = @ngbd + 1
		END
	END
	ELSE
		RAISERROR('Đã hết phòng trống',16,1)
		RETURN -1


GO
/****** Object:  StoredProcedure [dbo].[sp_LapHoaDon]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LapHoaDon] @maDP CHAR(10), @tongTien INT, @ngLap DATETIME
AS
	DECLARE @maHD CHAR(10) = 'HD' + SUBSTRING(@maDP,3,8);
	IF (EXISTS(SELECT dp.tinhTrang FROM dbo.DatPhong dp WHERE  dp.tinhTrang = N'Chưa xác nhận' AND dp.maDP = @maDP))
	BEGIN
		RAISERROR(N'Mã đặt phòng chưa được xác nhận nên không thể lập hoá đơn',16,1)
		RETURN -1
	END
	ELSE
	BEGIN     
		INSERT INTO HoaDon( maHD, ngayThanhToan, tongTien, maDP )
		VALUES  ( @maHD,@ngLap,@tongTien,@maDP)
	
		--Tăng số lượng trống của loại phòng lên 1
		UPDATE LoaiPhong
		SET slTrong = slTrong + 1
		WHERE maLoaiPhong = (SELECT L.maLoaiPhong FROM LoaiPhong L, DatPhong D 
							 WHERE D.maLoaiPhong = L.maLoaiPhong AND D.maDP = @maDP)
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKhachHang]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemKhachHang] @MaKH CHAR(10),@HoTen NVARCHAR(30),@ID VARCHAR(20),@MK VARCHAR(20),@CMND VARCHAR(13),@DC nVARCHAR(50),@SDT VARCHAR(13),@MT nVARCHAR(50),@EM VARCHAR(20)
AS
	IF (EXISTS (SELECT * FROM KhachHang WHERE tenDangNhap = @ID))
	BEGIN
		RAISERROR('Lỗi : Tên đăng nhập đã tồn tại',16,1)
		RETURN -1
	END
	IF (EXISTS (SELECT * FROM KhachHang WHERE soCMND = @CMND))
	BEGIN
		RAISERROR('Lỗi : Số cmnd đã bị trùng',16,1)
		RETURN -1
	END
	ELSE
		INSERT INTO KhachHang VALUES (@MAKH,@HoTen,@ID,@MK,@CMND,@DC,@SDT,@MT,@EM)


GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKePhongTrong]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThongKePhongTrong]
AS 
	SELECT K.maKS AS 'Mã khách sạn', K.tenKS AS 'Tên khách sạn', K.thanhPho AS 'Thành phố', K.soSao AS 'Số sao', L.tenLoaiPhong AS 'Tên loại phòng', SUM(L.slTrong) AS 'Số lượng phòng trống'
	FROM LoaiPhong L, KhachSan K
	WHERE L.maKS = K.maKS
	GROUP BY K.maKS, K.tenKS, L.tenLoaiPhong, K.thanhPho, K.soSao
	ORDER BY K.thanhPho ASC,K.soSao ASC
GO
/****** Object:  StoredProcedure [dbo].[sp_TimHoaDonMaKH]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimHoaDonMaKH] @maKH CHAR(10)
AS
	SELECT H.*, D.maKH 
	FROM HoaDon H, DatPhong D
	WHERE (H.maDP = D.maDP) AND (D.maKH = @maKH)


GO
/****** Object:  StoredProcedure [dbo].[sp_TimHoaDonNgay]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimHoaDonNgay] @Ngay DATETIME
AS
	SELECT *
	FROM HoaDon
	WHERE DAY(ngayThanhToan) = DAY(@Ngay) AND month(ngayThanhToan) = month(@Ngay) AND YEAR(ngayThanhToan) = YEAR(@Ngay)


GO
/****** Object:  StoredProcedure [dbo].[sp_TimHoaDonTien]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimHoaDonTien] @Tien INT
AS
	SELECT *
	FROM HoaDon
	WHERE tongTien = @Tien


GO
/****** Object:  StoredProcedure [dbo].[sp_TimKiemThongTinKhachSan]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimKiemThongTinKhachSan] @giaMin INT, @giaMax INT, @sao INT, @tpho NVARCHAR(20)
AS
	SELECT L.maLoaiPhong AS 'Mã loại phòng',L.tenLoaiPhong AS 'Tên loại phòng',L.donGia AS 'Đơn giá', L.moTa AS 'Mô tả', L.slTrong AS 'Số lượng trống', K.tenKS AS 'Tên khách sạn', K.giaTB AS 'Giá TB khách sạn', K.soSao AS 'Số sao',K.thanhPho AS 'Thành phố'
	FROM LoaiPhong L, KhachSan K
	WHERE L.maKS = K.maKS AND L.slTrong > 0 AND @giaMin <= k.giaTB AND K.giaTB <= @giaMax AND K.soSao = @sao AND K.thanhPho = @tpho

GO
/****** Object:  StoredProcedure [dbo].[sp_TimKiemThongTinKhachSanTheoGiaTP]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimKiemThongTinKhachSanTheoGiaTP] @giaMin INT,@giaMax INT,@tpho NVARCHAR(20)
AS
	SELECT L.maLoaiPhong AS 'Mã loại phòng',L.tenLoaiPhong AS 'Tên loại phòng',L.donGia AS 'Đơn giá', L.moTa AS 'Mô tả', L.slTrong AS 'Số lượng trống', K.tenKS AS 'Tên khách sạn', K.giaTB AS 'Giá TB khách sạn', K.soSao AS 'Số sao',K.thanhPho AS 'Thành phố'
	FROM LoaiPhong L, KhachSan K
	WHERE L.maKS = K.maKS AND L.slTrong > 0 AND @giaMin <= k.giaTB AND K.giaTB <= @giaMax AND K.thanhPho = @tpho


GO
/****** Object:  StoredProcedure [dbo].[sp_TimKiemThongTinKhachSanTheoSaoTP]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimKiemThongTinKhachSanTheoSaoTP] @sao INT, @tpho NVARCHAR(20)
AS
	SELECT L.maLoaiPhong AS 'Mã loại phòng',L.tenLoaiPhong AS 'Tên loại phòng',L.donGia AS 'Đơn giá', L.moTa AS 'Mô tả', L.slTrong AS 'Số lượng trống', K.tenKS AS 'Tên khách sạn', K.giaTB AS 'Giá TB khách sạn', K.soSao AS 'Số sao',K.thanhPho AS 'Thành phố'
	FROM LoaiPhong L, KhachSan K
	WHERE L.maKS = K.maKS AND L.slTrong > 0 AND K.soSao = @sao AND K.thanhPho = @tpho


GO
/****** Object:  StoredProcedure [dbo].[sp_TimKiemThongTinKhachSanTheoTP]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimKiemThongTinKhachSanTheoTP] @tpho NVARCHAR(20)
AS
	SELECT L.maLoaiPhong AS 'Mã loại phòng',L.tenLoaiPhong AS 'Tên loại phòng',L.donGia AS 'Đơn giá', L.moTa AS 'Mô tả', L.slTrong AS 'Số lượng trống', K.tenKS AS 'Tên khách sạn', K.giaTB AS 'Giá TB khách sạn', K.soSao AS 'Số sao',K.thanhPho AS 'Thành phố'
	FROM LoaiPhong L, KhachSan K
	WHERE L.maKS = K.maKS AND L.slTrong > 0 AND K.thanhPho = @tpho


GO
/****** Object:  StoredProcedure [dbo].[sp_XuatThongTinHoaDon]    Script Date: 06-Jun-18 11:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XuatThongTinHoaDon] @maDP CHAR(10), @tongTien INT OUT
AS
	IF (EXISTS(SELECT * FROM DatPhong WHERE maDP = @maDP))
	BEGIN
		SET @tongTien = (SELECT DATEDIFF(day,ngayBatDau,ngayTraPhong)*donGia  FROM DatPhong WHERE maDP = @maDP);
	END 
	ELSE
    BEGIN
		RAISERROR('Lỗi : Mã đặt phòng không tồn tại',16,1)
	END 
GO
