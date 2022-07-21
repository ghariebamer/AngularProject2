USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_CreateEmployee]    Script Date: 7/21/2022 4:40:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[sp_CreateEmployee]

@name nvarchar(500),
@department nvarchar(500),
@dataofjoining date,
@phatoName nvarchar(500)
as
begin
insert into dbo.Employee(Name,Department,dateofjoining,PhotoName) values(@name,@department,@dataofjoining,@phatoName)
end
GO

