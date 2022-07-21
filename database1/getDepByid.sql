USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetDepartmentByID]    Script Date: 7/21/2022 4:42:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_GetDepartmentByID]
@id int = null
as
begin

select * from dbo.Department where id=@id

end
GO

