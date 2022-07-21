USE [EmployeeDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_deleteEmployee]    Script Date: 7/21/2022 4:41:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_deleteEmployee]
@ID int = null
as
begin

delete from dbo.Employee where id=@ID ;

end
GO

