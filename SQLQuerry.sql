CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(20) PRIMARY KEY,
    TenNCC NVARCHAR(100),
    SDT  VARCHAR(20), 
    Email VARCHAR(100)
);

CREATE TABLE SanPham (
    MaSP VARCHAR(20) PRIMARY KEY,
    TenSP NVARCHAR(100),
    Hang NVARCHAR(50),
    TheLoai NVARCHAR(50),
    GiaBan INT,
    SoLuongTon INT
);


CREATE TABLE KhachHang (
    MaKhachHang VARCHAR(20) PRIMARY KEY,
    TenKH NVARCHAR(100),
    SDT VARCHAR(20),
    Email VARCHAR(100),
    TongChiTieu INT,
    ThuHang AS (
        CASE 
            WHEN TongChiTieu >= 10000000 THEN N'Kim Cương'
            WHEN TongChiTieu >= 5000000 THEN N'Vàng'
            WHEN TongChiTieu >= 1000000 THEN N'Bạc'
            ELSE N'Vãng lai'
        END
    ) PERSISTED
);

CREATE TABLE NhanVien (
    MaNV VARCHAR(20) PRIMARY KEY,
    HoTenLot NVARCHAR(100),
    Ten NVARCHAR(50),
    SDT VARCHAR(20),
    Email VARCHAR(100),
    TK VARCHAR(50),
    MK VARCHAR(50),
    Quyen NVARCHAR(50)
);

CREATE TABLE DonHang (
    MaDon VARCHAR(20) PRIMARY KEY,
    MaNV VARCHAR(20),
    MaKhachHang VARCHAR(20),
    SDT VARCHAR(20),
    NgayMua DATE,
    HinhThuc NVARCHAR(50),
    DiaChi NVARCHAR(200),
    TongTien int,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);


CREATE TABLE ChiTietDonHang (
    MaDon VARCHAR(20),
    MaSP VARCHAR(20),
    SoLuong INT,
    GiaBan DECIMAL(18, 2),
    ThanhTien AS (SoLuong * GiaBan) PERSISTED,
    PRIMARY KEY (MaDon, MaSP),
    FOREIGN KEY (MaDon) REFERENCES DonHang(MaDon),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE PhieuNhap (
    MaNhap VARCHAR(20) PRIMARY KEY,
    MaNCC VARCHAR(20),
    NgayNhap DATE,
    TongTien int,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

CREATE TABLE ChiTietNhap (
    MaNhap VARCHAR(20),
    MaSP VARCHAR(20),
    SoLuong INT,
    DonGia money,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaNhap, MaSP),
    FOREIGN KEY (MaNhap) REFERENCES PhieuNhap(MaNhap),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

GO
CREATE TRIGGER trg_CapNhatTongChiTieu
ON DonHang
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE KhachHang
    SET TongChiTieu = (
        SELECT SUM(TongTien)
        FROM DonHang
        WHERE DonHang.MaKhachHang = KhachHang.MaKhachHang
    )
    WHERE MaKhachHang IN (SELECT MaKhachHang FROM inserted);
END;

GO
CREATE TRIGGER trg_CapNhatTongTien_PN
ON ChiTietNhap
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE PhieuNhap
    SET TongTien = (
        SELECT SUM(SoLuong * DonGia)
        FROM ChiTietNhap
        WHERE ChiTietNhap.MaNhap = PhieuNhap.MaNhap
    )
    WHERE MaNhap IN (SELECT MaNhap FROM inserted);
END;

GO
CREATE TRIGGER trg_CapNhatTonKho_Nhap
ON ChiTietNhap
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE SanPham
    SET SoLuongTon = SoLuongTon + (
        SELECT SUM(SoLuong)
        FROM inserted
        WHERE inserted.MaSP = SanPham.MaSP
    )
    WHERE MaSP IN (SELECT MaSP FROM inserted);
END;
INSERT INTO NhanVien (MaNV, HoTenLot, Ten, SDT, Email, TK, MK, Quyen)
VALUES ('AD001', N'Nguyễn Văn', N'Sáng', '0900000000', 'admin@qlbh.vn', 'admin', '123', N'Admin');
