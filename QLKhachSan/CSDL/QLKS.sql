USE [master]
GO
/****** Object:  Database [QLKhachSan]    Script Date: 5/31/2017 10:21:23 PM ******/
CREATE DATABASE [QLKhachSan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NguyenDucTung_QLKhachSan_BData', FILENAME = N'E:\Thực tập\QLKS\trunk\QLKhachSan\CSDL\QLKhachSan.mdf' , SIZE = 4096KB , MAXSIZE = 20480KB , FILEGROWTH = 10240KB )
 LOG ON 
( NAME = N'NguyenDucTung_QLKhachSan_BLog', FILENAME = N'E:\Thực tập\QLKS\trunk\QLKhachSan\CSDL\QLKhachSan_Log.ldf' , SIZE = 1024KB , MAXSIZE = 20480KB , FILEGROWTH = 10240KB )
GO
ALTER DATABASE [QLKhachSan] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKhachSan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKhachSan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKhachSan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLKhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [QLKhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKhachSan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLKhachSan]
GO
/****** Object:  StoredProcedure [dbo].[DanhsachNV]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DanhsachNV] 
	-- Add the parameters for the stored procedure here
	@chucvu nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @chucvu=N'Tất cả'
SELECT * FROM NHANVIEN order by chucvu
else
SELECT * FROM NHANVIEN WHERE chucvu=@CHUCVU order by chucvu
END

GO
/****** Object:  StoredProcedure [dbo].[InhoadonDichVu]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InhoadonDichVu] 
	-- Add the parameters for the stored procedure here
	@mahoadon varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.chitietthuephong.maphieuthue, dbo.dichvu.tendichvu, dbo.dichvu.gia, dbo.dichvu.donvitinh, dbo.chitietthuephong.soluong, dbo.chitietthuephong.maphong, 
                      dbo.hoadon.mahoadon, dbo.chitietthuephong.ngay
FROM         dbo.hoadon INNER JOIN
                      dbo.phieuthuephong ON dbo.hoadon.maphieuthue = dbo.phieuthuephong.maphieuthue INNER JOIN
                      dbo.chitietthuephong ON dbo.phieuthuephong.maphieuthue = dbo.chitietthuephong.maphieuthue INNER JOIN
                      dbo.dichvu ON dbo.chitietthuephong.madichvu = dbo.dichvu.madichvu
WHERE     (dbo.hoadon.mahoadon = @mahoadon)
END

GO
/****** Object:  StoredProcedure [dbo].[InhoadonPhong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE  [dbo].[InhoadonPhong]
	-- Add the parameters for the stored procedure here
	@mahoadon varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.hoadon.mahoadon, dbo.khachhang.tenkhachhang, DATEDIFF(dd, dbo.phieudatphong.ngayden, dbo.phieudatphong.ngaydi)+1 AS ngayo, 
                      dbo.khachhang.cmnd_passport, dbo.khachhang.diachi, dbo.khachhang.coquan, dbo.khachhang.sodienthoai, dbo.khachhang.email, dbo.phieudatphong.ngayden, 
                      dbo.phieudatphong.ngaydi, dbo.phieudatphong.sotiendatcoc, dbo.loaiphong.gia, dbo.phong.maphong, dbo.nhanvien.tennhanvien, dbo.hoadon.tongtien
FROM         dbo.hoadon INNER JOIN
                      dbo.khachhang ON dbo.hoadon.makhachhang = dbo.khachhang.makhachhang INNER JOIN
                      dbo.phieuthuephong ON dbo.hoadon.maphieuthue = dbo.phieuthuephong.maphieuthue INNER JOIN
                      dbo.phieudatphong ON dbo.phieuthuephong.maphieudat = dbo.phieudatphong.maphieudat INNER JOIN
                      dbo.chitietdatphong ON dbo.phieudatphong.maphieudat = dbo.chitietdatphong.maphieudat INNER JOIN
                      dbo.phong ON dbo.chitietdatphong.maphong = dbo.phong.maphong INNER JOIN
                      dbo.loaiphong ON dbo.phong.maloai = dbo.loaiphong.maloai INNER JOIN
                      dbo.hethong ON dbo.hoadon.username = dbo.hethong.username AND dbo.phieuthuephong.username = dbo.hethong.username INNER JOIN
                      dbo.nhanvien ON dbo.hethong.manhanvien = dbo.nhanvien.manhanvien
WHERE     (dbo.hoadon.mahoadon = @mahoadon)
END

GO
/****** Object:  StoredProcedure [dbo].[kiemtraphong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[kiemtraphong] 
	-- Add the parameters for the stored procedure here
	@ngayden datetime, 
	@ngaydi datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     dbo.chitietdatphong.maphieudat, dbo.chitietdatphong.maphong, dbo.phieudatphong.ngayden,dbo.phieudatphong.ngaydi,dbo.phieudatphong.tinhtrang
FROM         dbo.phieudatphong INNER JOIN
                      dbo.chitietdatphong ON dbo.phieudatphong.maphieudat = dbo.chitietdatphong.maphieudat INNER JOIN
                      dbo.phong ON dbo.chitietdatphong.maphong = dbo.phong.maphong
where  
(	
					(@ngayden<dbo.phieudatphong.ngayden and dbo.phieudatphong.ngayden<@ngaydi)
				or	(@ngayden<dbo.phieudatphong.ngaydi and dbo.phieudatphong.ngaydi<@ngaydi)
				or	(
						(dbo.phieudatphong.ngayden<@ngayden)
						and (@ngaydi<dbo.phieudatphong.ngaydi)
					)
		)
	and (dbo.phieudatphong.tinhtrang='busy' or dbo.phieudatphong.tinhtrang='waitting')
END

GO
/****** Object:  StoredProcedure [dbo].[thongkedatphong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[thongkedatphong]
	-- Add the parameters for the stored procedure here
	@thang int,@nam int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     derivedtbl_1.Solan, dbo.phong.maphong
FROM         dbo.phong LEFT OUTER JOIN
                          (SELECT     COUNT(phong_1.maphong) AS Solan, phong_1.maphong
                            FROM          dbo.chitietdatphong INNER JOIN
                                                   dbo.phieudatphong ON dbo.chitietdatphong.maphieudat = dbo.phieudatphong.maphieudat RIGHT OUTER JOIN
                                                   dbo.phong AS phong_1 ON dbo.chitietdatphong.maphong = phong_1.maphong
                            WHERE      (MONTH(dbo.phieudatphong.ngayden) = @thang) AND (YEAR(dbo.phieudatphong.ngayden) = @nam)
                            GROUP BY phong_1.maphong) AS derivedtbl_1 ON dbo.phong.maphong = derivedtbl_1.maphong
END

GO
/****** Object:  Table [dbo].[account]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[SEQ] [nchar](10) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nchar](10) NULL,
	[urlImage] [nvarchar](100) NULL,
	[IdEmp] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chitietdatphong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chitietdatphong](
	[maphieudat] [varchar](10) NOT NULL,
	[maphong] [varchar](10) NOT NULL,
 CONSTRAINT [PK_chitietdondatphong] PRIMARY KEY CLUSTERED 
(
	[maphieudat] ASC,
	[maphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chitietthuephong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chitietthuephong](
	[maphieuthue] [varchar](10) NOT NULL,
	[maphong] [varchar](10) NOT NULL,
	[ngay] [datetime] NOT NULL,
	[madichvu] [varchar](10) NOT NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_chitietthuephong_1] PRIMARY KEY CLUSTERED 
(
	[maphieuthue] ASC,
	[maphong] ASC,
	[ngay] ASC,
	[madichvu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chitietvattu]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chitietvattu](
	[mavattu] [varchar](10) NOT NULL,
	[maloaiphong] [nvarchar](50) NOT NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_chitietvattu] PRIMARY KEY CLUSTERED 
(
	[mavattu] ASC,
	[maloaiphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dichvu]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dichvu](
	[madichvu] [varchar](10) NOT NULL,
	[tendichvu] [nvarchar](50) NULL,
	[gia] [money] NULL,
	[donvitinh] [nchar](10) NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[madichvu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hoadon](
	[mahoadon] [varchar](10) NOT NULL,
	[ngaythanhtoan] [datetime] NOT NULL,
	[tongtien] [money] NULL,
	[maphieuthue] [varchar](10) NULL,
	[makhachhang] [varchar](10) NULL,
	[username] [varchar](10) NULL,
 CONSTRAINT [PK_hoadon] PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[khachhang](
	[makhachhang] [varchar](10) NOT NULL,
	[tenkhachhang] [nvarchar](50) NULL,
	[gioitinh] [bit] NULL,
	[cmnd_passport] [varchar](10) NULL,
	[diachi] [nvarchar](100) NULL,
	[coquan] [nvarchar](50) NULL,
	[sodienthoai] [varchar](11) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Custumer] PRIMARY KEY CLUSTERED 
(
	[makhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[loaiphong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaiphong](
	[maloai] [nvarchar](50) NOT NULL,
	[gia] [money] NULL,
	[songuoi] [int] NULL,
 CONSTRAINT [PK_loaiphong] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nhanvien](
	[manhanvien] [varchar](10) NOT NULL,
	[tennhanvien] [nvarchar](50) NULL,
	[ngaysinh] [datetime] NULL,
	[phai] [bit] NULL,
	[diachi] [nvarchar](100) NULL,
	[phone] [varchar](11) NULL,
	[chucvu] [nvarchar](50) NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[phieudatphong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[phieudatphong](
	[maphieudat] [varchar](10) NOT NULL,
	[makhachhang] [varchar](10) NOT NULL,
	[ngayden] [datetime] NULL,
	[ngaydi] [datetime] NULL,
	[sotiendatcoc] [money] NULL,
	[username] [varchar](10) NULL,
	[tinhtrang] [varchar](10) NULL,
	[songuoi] [int] NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[maphieudat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[phieuthuephong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[phieuthuephong](
	[maphieuthue] [varchar](10) NOT NULL,
	[maphieudat] [varchar](10) NULL,
	[username] [varchar](10) NULL,
 CONSTRAINT [PK_phieuthuephong] PRIMARY KEY CLUSTERED 
(
	[maphieuthue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[phong]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[phong](
	[maphong] [varchar](10) NOT NULL,
	[maloai] [nvarchar](50) NOT NULL,
	[dadat] [bit] NULL,
	[danhan] [bit] NULL,
 CONSTRAINT [PK_phong] PRIMARY KEY CLUSTERED 
(
	[maphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vattu]    Script Date: 5/31/2017 10:21:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vattu](
	[mavattu] [varchar](10) NOT NULL,
	[tenvattu] [nvarchar](50) NULL,
 CONSTRAINT [PK_thietbi] PRIMARY KEY CLUSTERED 
(
	[mavattu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_dichvu]    Script Date: 5/31/2017 10:21:23 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_dichvu] ON [dbo].[dichvu]
(
	[tendichvu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_vattu]    Script Date: 5/31/2017 10:21:23 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_vattu] ON [dbo].[vattu]
(
	[tenvattu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[chitietdatphong]  WITH CHECK ADD  CONSTRAINT [FK_chitietdatphong_phieudatphong] FOREIGN KEY([maphieudat])
REFERENCES [dbo].[phieudatphong] ([maphieudat])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietdatphong] CHECK CONSTRAINT [FK_chitietdatphong_phieudatphong]
GO
ALTER TABLE [dbo].[chitietdatphong]  WITH CHECK ADD  CONSTRAINT [FK_chitietdatphong_phong] FOREIGN KEY([maphong])
REFERENCES [dbo].[phong] ([maphong])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietdatphong] CHECK CONSTRAINT [FK_chitietdatphong_phong]
GO
ALTER TABLE [dbo].[chitietthuephong]  WITH CHECK ADD  CONSTRAINT [FK_chitietthuephong_dichvu] FOREIGN KEY([madichvu])
REFERENCES [dbo].[dichvu] ([madichvu])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietthuephong] CHECK CONSTRAINT [FK_chitietthuephong_dichvu]
GO
ALTER TABLE [dbo].[chitietthuephong]  WITH CHECK ADD  CONSTRAINT [FK_chitietthuephong_phieuthuephong] FOREIGN KEY([maphieuthue])
REFERENCES [dbo].[phieuthuephong] ([maphieuthue])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietthuephong] CHECK CONSTRAINT [FK_chitietthuephong_phieuthuephong]
GO
ALTER TABLE [dbo].[chitietthuephong]  WITH CHECK ADD  CONSTRAINT [FK_chitietthuephong_phong] FOREIGN KEY([maphong])
REFERENCES [dbo].[phong] ([maphong])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietthuephong] CHECK CONSTRAINT [FK_chitietthuephong_phong]
GO
ALTER TABLE [dbo].[chitietvattu]  WITH CHECK ADD  CONSTRAINT [FK_chitietvattu_loaiphong] FOREIGN KEY([maloaiphong])
REFERENCES [dbo].[loaiphong] ([maloai])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietvattu] CHECK CONSTRAINT [FK_chitietvattu_loaiphong]
GO
ALTER TABLE [dbo].[chitietvattu]  WITH CHECK ADD  CONSTRAINT [FK_chitietvattu_vattu] FOREIGN KEY([mavattu])
REFERENCES [dbo].[vattu] ([mavattu])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietvattu] CHECK CONSTRAINT [FK_chitietvattu_vattu]
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_khachhang] FOREIGN KEY([makhachhang])
REFERENCES [dbo].[khachhang] ([makhachhang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_khachhang]
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_phieuthuephong] FOREIGN KEY([maphieuthue])
REFERENCES [dbo].[phieuthuephong] ([maphieuthue])
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_phieuthuephong]
GO
ALTER TABLE [dbo].[phieudatphong]  WITH CHECK ADD  CONSTRAINT [FK_phieudatphong_khachhang1] FOREIGN KEY([makhachhang])
REFERENCES [dbo].[khachhang] ([makhachhang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[phieudatphong] CHECK CONSTRAINT [FK_phieudatphong_khachhang1]
GO
ALTER TABLE [dbo].[phieuthuephong]  WITH CHECK ADD  CONSTRAINT [FK_phieuthuephong_phieudatphong] FOREIGN KEY([maphieudat])
REFERENCES [dbo].[phieudatphong] ([maphieudat])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[phieuthuephong] CHECK CONSTRAINT [FK_phieuthuephong_phieudatphong]
GO
ALTER TABLE [dbo].[phong]  WITH CHECK ADD  CONSTRAINT [FK_phong_loaiphong] FOREIGN KEY([maloai])
REFERENCES [dbo].[loaiphong] ([maloai])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[phong] CHECK CONSTRAINT [FK_phong_loaiphong]
GO
USE [master]
GO
ALTER DATABASE [QLKhachSan] SET  READ_WRITE 
GO
