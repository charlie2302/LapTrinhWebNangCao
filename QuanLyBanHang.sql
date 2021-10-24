CREATE DATABASE QuanLyBanHang;

-- T?O B?NG NHÂN VIÊN
CREATE TABLE NhanVien
(MaNV nvarchar(50) primary key,
HoTen nvarchar(50) not null,
CMND nvarchar(50),
SDT int,
DiaChi nvarchar(50));

-- T?O B?NG KHÁCH HÀNG
CREATE TABLE KhachHang
(MaKH nvarchar(50) primary key,
HoTen nvarchar(50) not null,
SDT int,
DiaChi nvarchar(50),
Gmail nvarchar(50));

-- T?O B?NG LO?I S?N PH?M
CREATE TABLE LoaiSP
(MaLoaiSP nvarchar(50) primary key,
TenLoaiSP nvarchar(50));

-- T?O B?NG S?N PH?M
CREATE TABLE SanPham
(MaSP nvarchar(50) primary key,
TenSP nvarchar(50),
MaLoaiSP nvarchar(50),
SoLuong int,
Gia float);

-- T?O B?NG HOÁ ??N
CREATE TABLE HoaDon
(MaHD nvarchar(50) primary key,
MaNV nvarchar(50),
MaKH nvarchar(50),
NgayMuaHang date,
NgayGiaoHang date,
TongHoaDon float) --T?ng hoá ??n = Thành ti?n - Voucher + Phí v?n chuy?n

-- T?O B?NG CHI TI?T HOÁ ??N
CREATE TABLE CTHoaDon
(MaCTHD nvarchar(50) primary key,
MaHD nvarchar(50),
MaSP nvarchar(50),
Gia float,
SoLuong int,
ThanhTien float, --Thành ti?n = Giá * S? l??ng
Voucher float,
PhiVanChuyen float);

-- T?O B?NG BÁO CÁO TH?NG KÊ 
CREATE TABLE BaoCaoThongKe
(MaBC nvarchar(50) primary key,
MaNV nvarchar(50),
TenNV nvarchar(50),
Thang int);

-- T?O B?NG TH?NG KÊ NH?P XU?T
CREATE TABLE ThongKeNhapXuat
(MaNX nvarchar(50) primary key,
MaBC nvarchar(50),
Thang int,
SoTienChi float, -- S? ti?n chi = S? l??ng nh?p * Giá nh?p + S? l??ng xu?t * Giá nh?p
SoTienThu float, -- S? ti?n thu = S? l??ng xu?t * Giá xu?t
SoTienLai float);

-- T?O B?NG CHI TI?T PHI?U NH?P
CREATE TABLE PhieuNhap
(MaCTPNhap nvarchar(50) primary key,
MaNX nvarchar(50),
Thang int,
MaSP nvarchar(50),
TenSP nvarchar(50),
SLNhap int,
GiaNhap float);

-- T?O B?NG CHI TI?T PHI?U XU?T
CREATE TABLE PhieuXuat
(MaCTPXuat nvarchar(50) primary key,
MaNX nvarchar(50),
Thang int,
MaSP nvarchar(50),
TenSP nvarchar(50),
SLXuat int, -- S? l??ng xu?t = S? l??ng s?n ph?m bán 
GiaXuat float);

-- T?O B?NG Users
CREATE TABLE Users
(Userid int identity primary key,
Username nvarchar(30) not null,
[Password] nvarchar(30) not null,
Email nvarchar(50),
Phone nvarchar(20),
Avatar nvarchar(100),
Allowed int default (0))


ALTER TABLE ThongKeNhapXuat
  DROP COLUMN Thang;

ALTER TABLE ThongKeNhapXuat
  ADD Thang int;

ALTER TABLE CTHoaDon 
  ADD CONSTRAINT XoaHD_CTHD 
  FOREIGN KEY (MaHD) 
  REFERENCES HoaDon(MaHD) 
ON DELETE CASCADE;

ALTER TABLE PhieuXuat 
  ADD CONSTRAINT XoaPX
  FOREIGN KEY (MaNX) 
  REFERENCES ThongKeNhapXuat(MaNX) 
ON DELETE CASCADE;

CREATE TRIGGER TinhST
ON CTHoaDon
FOR INSERT
AS
DECLARE @SoLuong int 
DECLARE @MaSP nvarchar(50) 
SET @SoLuong  = (SELECT SoLuong FROM INSERTED)
SET @MaSP = (SELECT MaSP FROM INSERTED)
UPDATE CTHoaDon 
SET SoLuong =  (SELECT CTHoaDon.SoLuong -  @SoLuong
				FROM SanPham
				WHERE CTHoaDon.MaSP = @MaSP
				GROUP BY MaSP)

USE QuanLyBanHang
GO
DROP TRIGGER TinhST
GO


ALTER TABLE CTHoaDon ADD CONSTRAINT SoLuong CHECK (SoLuong>0)

CREATE TRIGGER SLMua ON CTHoaDon
FOR INSERT
AS
DECLARE @MaSP nvarchar(50) = (SELECT MaSP FROM INSERTED)
DECLARE @SoLuong INT = (SELECT SoLuong FROM CHITIETHOADON WHERE MaSP = @MaSP )
DECLARE @CHECK INT = (SELECT COUNT(SoLuong) FROM inserted WHERE SoLuong > @SoLuong)
IF (@CHECK > 0 )
BEGIN
	RAISERROR ('SO LUONG MUA PHAI NHO HON SO LUONG TON !!',16,1)
	ROLLBACK TRAN
END

DROP TRIGGER TG_03