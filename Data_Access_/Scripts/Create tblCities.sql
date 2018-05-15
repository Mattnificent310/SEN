USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblStaff]    Script Date: 2018/04/30 13:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCities](
	[CityIDPK] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[CityCode] [varchar](10) NOT NULL,	
	[StateCode] [varchar](10) NOT NULL,	
	[CountryIDFK] [int] NOT NULL,
 CONSTRAINT [PK_tblCities] PRIMARY KEY CLUSTERED 
(
	[CityIDPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


