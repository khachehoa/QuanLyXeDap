create database WebDB;
go

create table NguoiDung
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	TenNguoiDung nvarchar(100),
	TaiKhoan varchar(50),
	MatKhau varchar(50),
	NgayTao date default getdate(),
	SoDienThoai varchar(20),
	Gmail varchar(50),
	VaiTro int default 1
);
go

truncate table NguoiDung;
go

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail, VaiTro)
output inserted.ID
values (N'Trần Thanh Phong', 'phongle', '123456', '0333568910', 'tranphong123@gmail.com', 2);

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail, VaiTro)
output inserted.ID
values (N'Nguyễn Thị Xuan Linh', 'linhxinhdep', '123456', '0333748913', 'xuanlinh@gmail.com', 2);

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail, VaiTro)
output inserted.ID
values (N'Nguyễn Đình Sang', 'sangdeptrai', '123456', '0345225651', 'nguyendinhsang9199@gmail.com', 2);

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail)
output inserted.ID
values (N'Trần Minh Nhật', 'nhattran', '123456', '0333568100', 'trannhat24@gmail.com');

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail)
output inserted.ID
values (N'Huỳnh Khương Ninh', 'hkn', '123456', '0345678900', 'ninh@gmail.com');

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail)
output inserted.ID
values (N'Trần Minh Hiếu', 'tranminhhieu', '123456', '0345678932', 'hieutran@gmail.com');

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail)
output inserted.ID
values (N'Phạm Phương Thanh', 'thanhthanh', '123456', '0339999999', 'chethichhoa@gmail.com');

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail)
output inserted.ID
values (N'Trần Thị Thúy An', 'thuyan', '123456', '0985632547', 'an123@gmail.com');

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail)
output inserted.ID
values (N'Thái Minh Quân', 'vodoi', '123456', '0333568910', 'batcandoi@gmail.com');

insert into NguoiDung(TenNguoiDung, TaiKhoan, MatKhau, SoDienThoai, Gmail)
output inserted.ID
values (N'Phạm Tấn Phát', 'phamtanphat', '123456', '0987654321', 'phatpham@gmail.com');
go


create table NhaCungCap
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	ten nvarchar(100),
	sdt nvarchar(100),
	diachi nvarchar(100),
)
go
create table Xe
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	ten nvarchar(100),
	loai nvarchar(100),
	IDNCC int,
	CONSTRAINT Xe_NhaCungCap
	FOREIGN KEY (IDNCC)
	REFERENCES dbo.NhaCungCap(ID) 
	ON DELETE CASCADE,
	soluong int,
	gia int,
)
go
create table NguoiDung
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	TenNguoiDung nvarchar(100),
	TaiKhoan nvarchar(100),
	matkhau nvarchar(10),
	NgayTao nvarchar(10),
	SoDienThoai nvarchar(10),
	gmail nvarchar(100),
	vaitro int,
)
go
create table KhachHang
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	ten nvarchar(100),
	ngaysinh nvarchar(10),
	sdt nvarchar(10),
	diachi nvarchar(100),
)
go
create table HoaDon
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	IDNguoiDung int,
	CONSTRAINT HoaDon_NguoiDung
	FOREIGN KEY (IDNguoiDung)
	REFERENCES dbo.NguoiDung(ID) 
	ON DELETE CASCADE,
	IDKhachHang int,
	CONSTRAINT HoaDon_KhachHang
	FOREIGN KEY (IDKhachHang)
	REFERENCES dbo.KhachHang(ID) 
	ON DELETE CASCADE,
	ngaymua nvarchar(10),
	gia int,
)
go
create table CTHoaDon
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	IDHoaDon int,
	CONSTRAINT CTHoaDon_HoaDon
	FOREIGN KEY (IDHoaDon)
	REFERENCES dbo.HoaDon(ID) 
	ON DELETE CASCADE,
	IDXe int,
	CONSTRAINT CTHoaDon_Xe
	FOREIGN KEY (IDXe)
	REFERENCES dbo.Xe(ID) 
	ON DELETE CASCADE,
	soluong int,
)
go
create table NhapHang
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	IDNguoiDung int,
	CONSTRAINT NhapHang_NguoiDung
	FOREIGN KEY (IDNguoiDung)
	REFERENCES dbo.NguoiDung(ID) 
	ON DELETE CASCADE,
	ngaymua nvarchar(10),
	gia int,
)
go
create table CTNhapHang
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	IDNhapHang int,
	CONSTRAINT CTNhapHang_NhapHang
	FOREIGN KEY (IDNhapHang)
	REFERENCES dbo.NhapHang(ID) 
	ON DELETE CASCADE,
	IDXe int,
	CONSTRAINT CTNhapHang_Xe
	FOREIGN KEY (IDXe)
	REFERENCES dbo.Xe(ID) 
	ON DELETE CASCADE,
	soluong int,
)
go