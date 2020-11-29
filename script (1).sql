

ALTER DATABASE [QL_BANHANG] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_BANHANG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_BANHANG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_BANHANG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_BANHANG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_BANHANG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_BANHANG] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_BANHANG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_BANHANG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_BANHANG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_BANHANG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_BANHANG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_BANHANG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_BANHANG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_BANHANG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_BANHANG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_BANHANG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QL_BANHANG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_BANHANG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_BANHANG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_BANHANG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_BANHANG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_BANHANG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_BANHANG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_BANHANG] SET RECOVERY FULL 
GO
ALTER DATABASE [QL_BANHANG] SET  MULTI_USER 
GO
ALTER DATABASE [QL_BANHANG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_BANHANG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_BANHANG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_BANHANG] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_BANHANG]
GO
/****** Object:  Table [dbo].[Table_BANSANPHAM]    Script Date: 11/28/2020 9:29:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_BANSANPHAM](
	[ID_BANSANPHAM] [int] IDENTITY(1,1) NOT NULL,
	[ID_DONHANG] [int] NOT NULL,
	[ThanhToanTienCK] [float] NULL,
	[TinhTrangThanhToan] [float] NULL,
 CONSTRAINT [PK_Table_BANSANPHAM] PRIMARY KEY CLUSTERED 
(
	[ID_BANSANPHAM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_DONHANG]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_DONHANG](
	[ID_DONHANG] [int] IDENTITY(1,1) NOT NULL,
	[ID_NGUOIBAN] [int] NULL,
	[ID_NGUOIGIAO] [int] NULL,
	[ID_NGUOICHOT] [int] NULL,
	[ID_KHACHHANG] [int] NULL,
	[TONGTIEN] [float] NULL,
	[NgayGiaoDich] [date] NULL,
	[Damua] [bit] NULL,
	[NgayGiaoHang] [date] NULL,
	[GhiChu] [nvarchar](500) NULL,
	[TinhTrang] [bit] NULL,
	[PhanHoi] [nvarchar](500) NULL,
 CONSTRAINT [PK_Table_DONHANG] PRIMARY KEY CLUSTERED 
(
	[ID_DONHANG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_DONHANG_DM]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_DONHANG_DM](
	[ID_DONHANG_DM] [int] IDENTITY(1,1) NOT NULL,
	[ID_DONHANG] [int] NOT NULL,
	[ID_SANPHAM] [int] NOT NULL,
	[TuyChon] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[Giatien] [float] NULL,
	[TinhTrang] [bit] NULL,
	[GHICHU] [ntext] NULL,
 CONSTRAINT [PK_Table_DONHANG_DM] PRIMARY KEY CLUSTERED 
(
	[ID_DONHANG_DM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_KHACHHANG]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_KHACHHANG](
	[ID_KHACHHANG] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](500) NOT NULL,
	[SDT] [varchar](10) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Facebook] [varchar](100) NULL,
	[Skype] [varchar](100) NULL,
	[Whatapp] [varchar](100) NULL,
	[Telegram] [varchar](100) NULL,
	[ID_GIOITHIEU] [int] NULL,
	[NgayGioiThieu] [datetime] NULL,
 CONSTRAINT [PK_Table_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[ID_KHACHHANG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_LOAINHANVIEN]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_LOAINHANVIEN](
	[ID_LOAINHANVIEN] [int] IDENTITY(1,1) NOT NULL,
	[Tenloainhanvien] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Table_LOAINHANVIEN] PRIMARY KEY CLUSTERED 
(
	[ID_LOAINHANVIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_LOAISANPHAM]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_LOAISANPHAM](
	[ID_LOAISANPHAM] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSanPham] [nvarchar](500) NOT NULL,
	[Root] [int] NOT NULL,
	[TenThuMuc] [varchar](100) NULL,
 CONSTRAINT [PK_Table_LOAISANPHAN] PRIMARY KEY CLUSTERED 
(
	[ID_LOAISANPHAM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_MUCHINHANH]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_MUCHINHANH](
	[ID_HINHANH] [int] IDENTITY(1,1) NOT NULL,
	[ID_SANPHAM] [int] NOT NULL,
	[HINHANH_N] [varchar](200) NULL,
 CONSTRAINT [PK_Table_MUCHINHANH] PRIMARY KEY CLUSTERED 
(
	[ID_HINHANH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_NHANVIEN]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_NHANVIEN](
	[ID_NHANVIEN] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](500) NOT NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[GioiTinh] [bit] NULL,
	[SDT] [varchar](10) NULL,
	[TKBank] [varchar](100) NULL,
	[Diachi] [nvarchar](500) NULL,
	[Email] [varchar](100) NULL,
	[Skype] [varchar](100) NULL,
	[ANHDAIDIEN] [varchar](100) NULL,
	[ID_LOAINHANVIEN] [int] NULL,
	[Code] [nvarchar](100) NULL,
	[ActiveCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_Table_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[ID_NHANVIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_NHAPKHO]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_NHAPKHO](
	[ID_NHAPKHO] [int] IDENTITY(1,1) NOT NULL,
	[ID_SANPHAM] [int] NOT NULL,
	[ID_NHANVIEN] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[NgayNhap] [date] NULL,
 CONSTRAINT [PK_Table_NHAPKHO] PRIMARY KEY CLUSTERED 
(
	[ID_NHAPKHO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_NhaSX]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_NhaSX](
	[ID_NSX] [int] IDENTITY(1,1) NOT NULL,
	[NhaSX] [nvarchar](50) NOT NULL,
	[NoiSX] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Table_NhaSX] PRIMARY KEY CLUSTERED 
(
	[ID_NSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_SANPHAM]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_SANPHAM](
	[ID_SANPHAM] [int] IDENTITY(1,1) NOT NULL,
	[ID_LOAISANPHAM] [int] NOT NULL,
	[TenSanPham] [nvarchar](500) NOT NULL,
	[ChiTiet] [nvarchar](500) NULL,
	[MAUSAC] [nvarchar](100) NULL,
	[SIZE] [nvarchar](100) NULL,
	[CHATLIEU] [nvarchar](100) NULL,
	[DonGia] [float] NOT NULL,
	[ChietKhau] [float] NULL,
	[ID_NSX] [int] NULL,
	[Ngung] [bit] NULL,
	[SoLuong] [int] NULL,
	[HINHANH] [varchar](50) NULL,
	[VIEWER] [int] NULL,
	[UuTien] [bit] NULL,
 CONSTRAINT [PK_Table_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[ID_SANPHAM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_TUYCHON]    Script Date: 11/28/2020 9:29:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_TUYCHON](
	[ID_TUYCHON] [int] IDENTITY(1,1) NOT NULL,
	[ID_SANPHAM] [int] NOT NULL,
	[TuyChon] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_Table_TUYCHON] PRIMARY KEY CLUSTERED 
(
	[ID_TUYCHON] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Table_DONHANG] ON 

INSERT [dbo].[Table_DONHANG] ([ID_DONHANG], [ID_NGUOIBAN], [ID_NGUOIGIAO], [ID_NGUOICHOT], [ID_KHACHHANG], [TONGTIEN], [NgayGiaoDich], [Damua], [NgayGiaoHang], [GhiChu], [TinhTrang], [PhanHoi]) VALUES (1, 13, 12, 15, 101, 900000, CAST(N'2020-10-27' AS Date), 1, NULL, NULL, 1, N'Giao từ 9h - 12h')
INSERT [dbo].[Table_DONHANG] ([ID_DONHANG], [ID_NGUOIBAN], [ID_NGUOIGIAO], [ID_NGUOICHOT], [ID_KHACHHANG], [TONGTIEN], [NgayGiaoDich], [Damua], [NgayGiaoHang], [GhiChu], [TinhTrang], [PhanHoi]) VALUES (2, 13, 12, 15, 101, 450000, CAST(N'2020-10-28' AS Date), 0, NULL, N'Khách hàng không đủ tiền', 0, NULL)
SET IDENTITY_INSERT [dbo].[Table_DONHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_DONHANG_DM] ON 

INSERT [dbo].[Table_DONHANG_DM] ([ID_DONHANG_DM], [ID_DONHANG], [ID_SANPHAM], [TuyChon], [SoLuong], [Giatien], [TinhTrang], [GHICHU]) VALUES (2, 1, 1034, N'S', 1, 450000, 1, N'abc')
INSERT [dbo].[Table_DONHANG_DM] ([ID_DONHANG_DM], [ID_DONHANG], [ID_SANPHAM], [TuyChon], [SoLuong], [Giatien], [TinhTrang], [GHICHU]) VALUES (3, 1, 1035, N'L', 1, 450000, 1, N'bc')
INSERT [dbo].[Table_DONHANG_DM] ([ID_DONHANG_DM], [ID_DONHANG], [ID_SANPHAM], [TuyChon], [SoLuong], [Giatien], [TinhTrang], [GHICHU]) VALUES (5, 2, 1035, N'S', 1, 450000, 1, N'aa')
SET IDENTITY_INSERT [dbo].[Table_DONHANG_DM] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_KHACHHANG] ON 

INSERT [dbo].[Table_KHACHHANG] ([ID_KHACHHANG], [HoTen], [SDT], [DiaChi], [Email], [Facebook], [Skype], [Whatapp], [Telegram], [ID_GIOITHIEU], [NgayGioiThieu]) VALUES (101, N'Trần Văn C', N'0918239812', N'ABC', NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2020-10-27T02:31:41.880' AS DateTime))
INSERT [dbo].[Table_KHACHHANG] ([ID_KHACHHANG], [HoTen], [SDT], [DiaChi], [Email], [Facebook], [Skype], [Whatapp], [Telegram], [ID_GIOITHIEU], [NgayGioiThieu]) VALUES (102, N'Trần Văn A', N'0358985655', N'ABC', NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2020-10-25T02:28:42.827' AS DateTime))
INSERT [dbo].[Table_KHACHHANG] ([ID_KHACHHANG], [HoTen], [SDT], [DiaChi], [Email], [Facebook], [Skype], [Whatapp], [Telegram], [ID_GIOITHIEU], [NgayGioiThieu]) VALUES (103, N'Trần Văn D', N'0358983456', N'asdasd', NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2020-10-25T02:20:42.827' AS DateTime))
INSERT [dbo].[Table_KHACHHANG] ([ID_KHACHHANG], [HoTen], [SDT], [DiaChi], [Email], [Facebook], [Skype], [Whatapp], [Telegram], [ID_GIOITHIEU], [NgayGioiThieu]) VALUES (104, N'Trần Văn E', N'0358983457', N'asdasd', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-24T02:20:42.827' AS DateTime))
SET IDENTITY_INSERT [dbo].[Table_KHACHHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_LOAINHANVIEN] ON 

INSERT [dbo].[Table_LOAINHANVIEN] ([ID_LOAINHANVIEN], [Tenloainhanvien]) VALUES (0, N'Quản lý')
INSERT [dbo].[Table_LOAINHANVIEN] ([ID_LOAINHANVIEN], [Tenloainhanvien]) VALUES (1, N'Cộng tác viên')
INSERT [dbo].[Table_LOAINHANVIEN] ([ID_LOAINHANVIEN], [Tenloainhanvien]) VALUES (2, N'Nhân viên giao hàng')
INSERT [dbo].[Table_LOAINHANVIEN] ([ID_LOAINHANVIEN], [Tenloainhanvien]) VALUES (3, N'Nhân viên chốt hàng')
INSERT [dbo].[Table_LOAINHANVIEN] ([ID_LOAINHANVIEN], [Tenloainhanvien]) VALUES (4, N'ABC')
INSERT [dbo].[Table_LOAINHANVIEN] ([ID_LOAINHANVIEN], [Tenloainhanvien]) VALUES (5, N'BOSS')
SET IDENTITY_INSERT [dbo].[Table_LOAINHANVIEN] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_LOAISANPHAM] ON 

INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (1, N'Thời trang', 0, N'THOITRANG')
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (2, N'Mỹ phẩm', 0, N'MYPHAM')
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (3, N'Linh kiện điện thoại', 0, N'LINHKIEN')
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (4, N'Đồ gia dụng', 0, N'GIAY')
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (5, N'Thời trang nam', 1, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (6, N'Thời trang nữ', 1, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (7, N'Thời Trang Trẻ Em', 1, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (8, N'Dưỡng da', 2, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (9, N'Nước hoa', 2, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (10, N'Trang điểm', 2, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (11, N'Sạc dự phòng', 3, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (12, N'Tai nghe', 3, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (14, N'Giày nữ', 4, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (15, N'Kính cường lực', 3, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (1022, N'Sản phẩm khác', 0, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (1023, N'Giày Nam', 1, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (1024, N'Nhà bếp', 4, NULL)
INSERT [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM], [TenLoaiSanPham], [Root], [TenThuMuc]) VALUES (1025, N'Nhà tắm', 4, NULL)
SET IDENTITY_INSERT [dbo].[Table_LOAISANPHAM] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_MUCHINHANH] ON 

INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (7, 1034, N'/Content/image/nam2.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (8, 1034, N'/Content/image/nam3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (9, 1034, N'/Content/image/nam4.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (10, 1034, N'/Content/image/nam5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (11, 1034, N'/Content/image/nam6.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (12, 1035, N'/Content/image/somi2.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (13, 1035, N'/Content/image/somi3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (14, 1035, N'/Content/image/somi4.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (15, 1035, N'/Content/image/somi5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (16, 1035, N'/Content/image/somi6.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (17, 1036, N'/Content/image/tay1.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (18, 1036, N'/Content/image/tay2.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (19, 1036, N'/Content/image/tay3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (20, 1036, N'/Content/image/tay4.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (21, 1036, N'/Content/image/tay5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (22, 1037, N'/Content/image/jean1.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (23, 1037, N'/Content/image/jean3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (24, 1037, N'/Content/image/jean5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (25, 1037, N'/Content/image/jean6.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (26, 1038, N'/Content/image/nu1.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (27, 1038, N'/Content/image/nu2.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (28, 1038, N'/Content/image/nu3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (29, 1038, N'/Content/image/nu5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (30, 1039, N'/Content/image/vay2.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (31, 1039, N'/Content/image/vay3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (32, 1039, N'/Content/image/vay4.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (33, 1039, N'/Content/image/vay5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (34, 1040, N'/Content/image/tre2.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (35, 1040, N'/Content/image/tre3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (36, 1040, N'/Content/image/tre4.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (37, 1040, N'/Content/image/tre5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (38, 1041, N'/Content/image/gai2.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (39, 1041, N'/Content/image/gai3.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (40, 1041, N'/Content/image/gai4.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (41, 1041, N'/Content/image/gai5.jpg')
INSERT [dbo].[Table_MUCHINHANH] ([ID_HINHANH], [ID_SANPHAM], [HINHANH_N]) VALUES (42, 1041, N'/Content/image/gai6.jpg')
SET IDENTITY_INSERT [dbo].[Table_MUCHINHANH] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_NHANVIEN] ON 

INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (11, N'Nguyễn Thị Trần Dần', N'trandan123456', N'0D-53-99-50-84-27-CE-79-55-6C-DA-71-91-80-20-C1-E8-D1-5B-53', 1, N'0385912323', N'2255665522', NULL, N'trandan@gmail.com', N'', N'/Content/image/hinha.jpg', 0, NULL, NULL)
INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (12, N'BEST', N'best', N'0D-53-99-50-84-27-CE-79-55-6C-DA-71-91-80-20-C1-E8-D1-5B-53', 1, N'0258963254', NULL, N'a123', N'vonghuy27598@gmail.com', NULL, NULL, 2, N'', NULL)
INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (13, N'asd', N'ctv123', N'0D-53-99-50-84-27-CE-79-55-6C-DA-71-91-80-20-C1-E8-D1-5B-53', 1, N'0386339819', NULL, N'123123', N'123@gmail.com', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (14, N'Hoàng Thanh Quang', N'1711545248', N'53-6D-25-23-0E-8E-31-DB-D4-0D-1A-9B-FD-8D-80-B0-59-F9-C4-81', 1, N'0349834528', N'1242515461', N'zxczxvzx', N'quang7190@gmail.com', N'zxvxv', N'/Content/image/Meo-anh-long-ngan-thumb.jpg', 0, NULL, NULL)
INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (15, N'Nhân viên chốt đơn', N'chotdon123', N'0D-53-99-50-84-27-CE-79-55-6C-DA-71-91-80-20-C1-E8-D1-5B-53', 1, N'0123456789', N'012235544456', N'asdasd', N'asd@gmail.com', NULL, N'/Content/image/hinhz.jpg', 3, NULL, NULL)
INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (16, N'Nhân viên chốt đơn 2', N'chotdon2', N'0D-53-99-50-84-27-CE-79-55-6C-DA-71-91-80-20-C1-E8-D1-5B-53', 1, N'0123456789', NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (17, N'Boss', N'boss', N'0D-53-99-50-84-27-CE-79-55-6C-DA-71-91-80-20-C1-E8-D1-5B-53', 1, N'0123456789', NULL, N'zxc', N'boss123@gmail.com', NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[Table_NHANVIEN] ([ID_NHANVIEN], [HoTen], [Username], [Password], [GioiTinh], [SDT], [TKBank], [Diachi], [Email], [Skype], [ANHDAIDIEN], [ID_LOAINHANVIEN], [Code], [ActiveCode]) VALUES (18, N'abc', N'abc', N'0D-53-99-50-84-27-CE-79-55-6C-DA-71-91-80-20-C1-E8-D1-5B-53', 1, N'0349845628', NULL, N'klcmxvkmcxk', N'boss123@gmail.com', NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Table_NHANVIEN] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_NhaSX] ON 

INSERT [dbo].[Table_NhaSX] ([ID_NSX], [NhaSX], [NoiSX]) VALUES (1, N'Sản xuất Áo', N'TP HCM')
INSERT [dbo].[Table_NhaSX] ([ID_NSX], [NhaSX], [NoiSX]) VALUES (2, N'Sản xuất linh kiện', N'TP HCM')
SET IDENTITY_INSERT [dbo].[Table_NhaSX] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_SANPHAM] ON 

INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1034, 5, N'Áo thun nam', N'Chi tiết sản phẩm', N'Tự chọn', N'M,L,XL', N'Vải', 450000, 50000, 1, 0, 100, N'/Content/image/nam1.jpg', NULL, NULL)
INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1035, 5, N'Áo somi nam', N'Chi tiết sản phẩm', N'Tự chọn', N'M,L,XL', N'Vải', 450000, 50000, 1, 0, 100, N'/Content/image/somi1.jpg', NULL, NULL)
INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1036, 5, N'Quần tây nam', N'Chi tiết sản phẩm', N'Tự chọn', N'M,L,XL', N'Vải', 450000, 50000, 1, 0, 100, N'/Content/image/taynam.jpg', NULL, NULL)
INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1037, 6, N'Quần Jean nữ', N'Chi tiết sản phẩm', N'Tự chọn', N'S,M,L', N'Jean', 450000, 50000, 1, 0, 100, N'/Content/image/jean2.jpg', NULL, NULL)
INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1038, 6, N'Áo thun nữ', N'Chi tiết sản phẩm', N'Tự chọn', N'S,M,L', N'Vải', 450000, 50000, 1, 0, 100, N'/Content/image/nu4.jpg', NULL, NULL)
INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1039, 6, N'Chân váy ', N'Chi tiết sản phẩm', N'Đen', N'S,M,L', N'Vải', 450000, 50000, 1, 0, 100, N'/Content/image/vay1.jpg', NULL, NULL)
INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1040, 7, N'Đồ bộ bé trai', N'Chi tiết sản phẩm', N'Tự chọn', N'Trẻ em', N'Vải', 450000, 50000, 1, 0, 100, N'/Content/image/tre1.jpg', NULL, NULL)
INSERT [dbo].[Table_SANPHAM] ([ID_SANPHAM], [ID_LOAISANPHAM], [TenSanPham], [ChiTiet], [MAUSAC], [SIZE], [CHATLIEU], [DonGia], [ChietKhau], [ID_NSX], [Ngung], [SoLuong], [HINHANH], [VIEWER], [UuTien]) VALUES (1041, 7, N'Đồ bộ bé gái', N'Chi tiết sản phẩm', N'Tự chọn', N'Trẻ em', N'Vải', 450000, 50000, 1, 0, 100, N'/Content/image/gai1.jpg', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Table_SANPHAM] OFF
GO
SET IDENTITY_INSERT [dbo].[Table_TUYCHON] ON 

INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (1, 1034, N'S', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (2, 1034, N'M', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (3, 1034, N'L', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (4, 1035, N'S', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (5, 1035, N'M', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (6, 1035, N'L', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (7, 1036, N'S', 400000, 8)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (8, 1036, N'M', 400000, 9)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (9, 1036, N'L', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (10, 1037, N'S', 400000, 0)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (11, 1037, N'M', 400000, 0)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (12, 1037, N'L', 400000, 0)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (13, 1038, N'S', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (14, 1038, N'M', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (15, 1038, N'L', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (16, 1039, N'S', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (17, 1039, N'M', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (19, 1039, N'L', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (20, 1040, N'S', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (21, 1040, N'M', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (22, 1040, N'L', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (23, 1041, N'S', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (24, 1041, N'M', 400000, 10)
INSERT [dbo].[Table_TUYCHON] ([ID_TUYCHON], [ID_SANPHAM], [TuyChon], [DonGia], [SoLuong]) VALUES (25, 1041, N'L', 400000, 10)
SET IDENTITY_INSERT [dbo].[Table_TUYCHON] OFF
GO
ALTER TABLE [dbo].[Table_BANSANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_Table_BANSANPHAM_Table_DONHANG] FOREIGN KEY([ID_DONHANG])
REFERENCES [dbo].[Table_DONHANG] ([ID_DONHANG])
GO
ALTER TABLE [dbo].[Table_BANSANPHAM] CHECK CONSTRAINT [FK_Table_BANSANPHAM_Table_DONHANG]
GO
ALTER TABLE [dbo].[Table_DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_Table_DONHANG_Table_KHACHHANG] FOREIGN KEY([ID_KHACHHANG])
REFERENCES [dbo].[Table_KHACHHANG] ([ID_KHACHHANG])
GO
ALTER TABLE [dbo].[Table_DONHANG] CHECK CONSTRAINT [FK_Table_DONHANG_Table_KHACHHANG]
GO
ALTER TABLE [dbo].[Table_DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_Table_DONHANG_Table_NHANVIEN] FOREIGN KEY([ID_NGUOIBAN])
REFERENCES [dbo].[Table_NHANVIEN] ([ID_NHANVIEN])
GO
ALTER TABLE [dbo].[Table_DONHANG] CHECK CONSTRAINT [FK_Table_DONHANG_Table_NHANVIEN]
GO
ALTER TABLE [dbo].[Table_DONHANG_DM]  WITH CHECK ADD  CONSTRAINT [FK_Table_DONHANG_DM_Table_DONHANG] FOREIGN KEY([ID_DONHANG])
REFERENCES [dbo].[Table_DONHANG] ([ID_DONHANG])
GO
ALTER TABLE [dbo].[Table_DONHANG_DM] CHECK CONSTRAINT [FK_Table_DONHANG_DM_Table_DONHANG]
GO
ALTER TABLE [dbo].[Table_DONHANG_DM]  WITH CHECK ADD  CONSTRAINT [FK_Table_DONHANG_DM_Table_SANPHAM] FOREIGN KEY([ID_SANPHAM])
REFERENCES [dbo].[Table_SANPHAM] ([ID_SANPHAM])
GO
ALTER TABLE [dbo].[Table_DONHANG_DM] CHECK CONSTRAINT [FK_Table_DONHANG_DM_Table_SANPHAM]
GO
ALTER TABLE [dbo].[Table_MUCHINHANH]  WITH CHECK ADD  CONSTRAINT [FK_Table_MUCHINHANH_Table_SANPHAM] FOREIGN KEY([ID_SANPHAM])
REFERENCES [dbo].[Table_SANPHAM] ([ID_SANPHAM])
GO
ALTER TABLE [dbo].[Table_MUCHINHANH] CHECK CONSTRAINT [FK_Table_MUCHINHANH_Table_SANPHAM]
GO
ALTER TABLE [dbo].[Table_NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_Table_NHANVIEN_Table_LOAINHANVIEN] FOREIGN KEY([ID_LOAINHANVIEN])
REFERENCES [dbo].[Table_LOAINHANVIEN] ([ID_LOAINHANVIEN])
GO
ALTER TABLE [dbo].[Table_NHANVIEN] CHECK CONSTRAINT [FK_Table_NHANVIEN_Table_LOAINHANVIEN]
GO
ALTER TABLE [dbo].[Table_NHAPKHO]  WITH CHECK ADD  CONSTRAINT [FK_Table_NHAPKHO_Table_NHANVIEN] FOREIGN KEY([ID_NHANVIEN])
REFERENCES [dbo].[Table_NHANVIEN] ([ID_NHANVIEN])
GO
ALTER TABLE [dbo].[Table_NHAPKHO] CHECK CONSTRAINT [FK_Table_NHAPKHO_Table_NHANVIEN]
GO
ALTER TABLE [dbo].[Table_NHAPKHO]  WITH CHECK ADD  CONSTRAINT [FK_Table_NHAPKHO_Table_SANPHAM] FOREIGN KEY([ID_SANPHAM])
REFERENCES [dbo].[Table_SANPHAM] ([ID_SANPHAM])
GO
ALTER TABLE [dbo].[Table_NHAPKHO] CHECK CONSTRAINT [FK_Table_NHAPKHO_Table_SANPHAM]
GO
ALTER TABLE [dbo].[Table_SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_Table_SANPHAM_Table_LOAISANPHAN] FOREIGN KEY([ID_LOAISANPHAM])
REFERENCES [dbo].[Table_LOAISANPHAM] ([ID_LOAISANPHAM])
GO
ALTER TABLE [dbo].[Table_SANPHAM] CHECK CONSTRAINT [FK_Table_SANPHAM_Table_LOAISANPHAN]
GO
ALTER TABLE [dbo].[Table_SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_Table_SANPHAM_Table_NhaSX] FOREIGN KEY([ID_NSX])
REFERENCES [dbo].[Table_NhaSX] ([ID_NSX])
GO
ALTER TABLE [dbo].[Table_SANPHAM] CHECK CONSTRAINT [FK_Table_SANPHAM_Table_NhaSX]
GO
ALTER TABLE [dbo].[Table_TUYCHON]  WITH CHECK ADD  CONSTRAINT [FK_Table_TUYCHON_Table_SANPHAM] FOREIGN KEY([ID_SANPHAM])
REFERENCES [dbo].[Table_SANPHAM] ([ID_SANPHAM])
GO
ALTER TABLE [dbo].[Table_TUYCHON] CHECK CONSTRAINT [FK_Table_TUYCHON_Table_SANPHAM]
GO
USE [master]
GO
ALTER DATABASE [QL_BANHANG] SET  READ_WRITE 
GO
