USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_getallEmployees]    Script Date: 7/21/2022 4:41:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_getallEmployees]
as
begin

select * from dbo.Employee
end
GO

