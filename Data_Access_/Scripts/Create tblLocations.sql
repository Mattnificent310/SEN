USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblStaff]    Script Date: 2018/04/30 13:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLocations](
	[LocationIDPK] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[Suburb] [varchar](50) NOT NULL,	
	[CityIDFK] [int] NOT NULL,
 CONSTRAINT [PK_tblLocations] PRIMARY KEY CLUSTERED 
(
	[LocationIDPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


