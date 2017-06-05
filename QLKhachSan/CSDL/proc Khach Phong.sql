USE [QLKhachSan]
GO

/****** Object:  StoredProcedure [dbo].[suaKhach]    Script Date: 6/5/2017 4:03:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[suaKhach] (@ma varchar(10), @ten nvarchar(50), @gioitinh bit, @cmnd varchar(10), @diachi nvarchar(100), @coquan nvarchar(50), @sdt varchar(11), @email varchar(50))
as
	begin
		update khachhang
		set   tenkhachhang= @ten,
				gioitinh= @gioitinh, 
				cmnd_passport= @cmnd,
				diachi = @diachi,
				coquan = @coquan,
				sodienthoai = @sdt,
				email = @email
		where makhachhang = @ma
	end



GO

USE [QLKhachSan]
GO

/****** Object:  StoredProcedure [dbo].[suaPhong]    Script Date: 6/5/2017 4:03:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[suaPhong] (@maphong varchar(10), @maloai nvarchar(50))
as
	begin
		update phong
		set maphong = @maphong, maloai = @maloai

	end

GO


USE [QLKhachSan]
GO

/****** Object:  StoredProcedure [dbo].[themKhach]    Script Date: 6/5/2017 4:03:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[themKhach](@ma varchar(10), @ten nvarchar(50), @gioitinh bit, @cmnd varchar(10), @diachi nvarchar(100), @coquan nvarchar(50), @sdt varchar(11), @email varchar(50))
as
	begin
		insert into khachhang
		values(@ma, @ten, @gioitinh, @cmnd, @diachi, @coquan, @sdt, @email)
	end
GO

USE [QLKhachSan]
GO

/****** Object:  StoredProcedure [dbo].[themPhong]    Script Date: 6/5/2017 4:03:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[themPhong] (@maphong varchar(10), @maloai nvarchar(50))
as
	begin
		insert into phong(maphong, maloai)
		values (@maphong, @maloai)

	end
GO

USE [QLKhachSan]
GO

/****** Object:  StoredProcedure [dbo].[xoaKhach]    Script Date: 6/5/2017 4:04:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[xoaKhach] (@ma varchar (10))
as
	begin
		delete khachhang
		where makhachhang = @ma
	end
GO

USE [QLKhachSan]
GO

/****** Object:  StoredProcedure [dbo].[xoaPhong]    Script Date: 6/5/2017 4:04:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[xoaPhong] (@maphong varchar(10))
as
	begin
		delete phong
		where maphong = @maphong
	end
GO

