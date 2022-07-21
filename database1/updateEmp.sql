USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 7/21/2022 4:43:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_UpdateEmployee]
@ID int = null,
@name nvarchar(500),
@department nvarchar(500),
@dateofjoining date

as
begin

update dbo.Employee
set [Name]=@name,[Department]=@department,[dateofjoining]=@dateofjoining
where id=@ID


end
GO

