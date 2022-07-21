USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_deleteDepartment]    Script Date: 7/21/2022 4:41:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_deleteDepartment] 
@ID int = null
as
begin

delete from dbo.Department where id=@ID ;

end
GO

