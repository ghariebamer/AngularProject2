USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateDepartment]    Script Date: 7/21/2022 4:42:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_UpdateDepartment]
@id int = null,
@name nvarchar(500)
as
begin

update [dbo].[Department] 
set [Name]=@name
where id=@id

end
GO

