USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblClient]    Script Date: 2018/04/30 13:38:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblClient](
	[ClientIDPK] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ClientTitle] [varchar](50) NOT NULL,
	[ClientName] [varchar](50) NOT NULL,
	[ClientSurname] [varchar](50) NOT NULL,
	[ClientDOB] [date] NOT NULL,
	[ClientGender] [bit] NOT NULL,
	[ClientPhone] [varchar](50) NULL,
	[ClientEmail] [varchar](50) NULL,
	[LocationIDFK] [int] NULL
) ON [PRIMARY]
GO


