USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblStaff]    Script Date: 2018/04/30 13:57:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblStaff](
	[StaffIDPK] [int] NOT NULL,
	[StaffTitle] [varchar](50) NOT NULL,
	[StaffName] [varchar](50) NOT NULL,
	[StaffSurname] [varchar](50) NOT NULL,
	[StaffDOB] [date] NOT NULL,
	[StaffGender] [bit] NOT NULL,
	[StaffPhone] [varchar](50) NULL,
	[StaffEmail] [varchar](50) NULL,
	[JobDescIDFK] [int] NULL,
	[LocationIDFK] [int] NULL,
 CONSTRAINT [PK_tblStaff] PRIMARY KEY CLUSTERED 
(
	[StaffIDPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


