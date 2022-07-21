USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[CreateDepartment]    Script Date: 7/21/2022 4:40:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[CreateDepartment] 
@name nvarchar(500),
@createby int =null
as
begin

insert into dbo.Department(Name,createBy) values (@name,@createby);

end
GO

