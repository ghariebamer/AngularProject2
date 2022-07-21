USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_getEmployee]    Script Date: 7/21/2022 4:42:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_getEmployee]
@id int =null
as
begin

select * from dbo.Employee where id= @id
end
GO

