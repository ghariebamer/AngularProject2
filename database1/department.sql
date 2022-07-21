USE [EmployeeDB]
GO

/****** Object:  Table [dbo].[Department]    Script Date: 7/21/2022 4:39:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[createddate] [date] NULL,
	[createBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Department] ADD  DEFAULT (getdate()) FOR [createddate]
GO

ALTER TABLE [dbo].[Department] ADD  DEFAULT ((1)) FOR [createBy]
GO

