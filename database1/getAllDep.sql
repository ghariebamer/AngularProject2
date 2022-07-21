USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetDepartments]    Script Date: 7/21/2022 4:42:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_GetDepartments]
as
begin

select * from dbo.Department

end
GO

