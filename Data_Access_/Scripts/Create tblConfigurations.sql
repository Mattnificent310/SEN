USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblStaff]    Script Date: 2018/04/30 13:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblConfigurations](
	[ConfigIDPK] [INT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ConfigType] [VARCHAR](50) NOT NULL,
	[ConfigCost] [MONEY] NOT NULL,	
	[ConfigCriteria] [VARCHAR](50) NOT NULL,
	[ConfigDetails] [VARCHAR](50)
	) ON [PRIMARY]

GO


