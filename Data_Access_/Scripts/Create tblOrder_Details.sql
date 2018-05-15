USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblStaff]    Script Date: 2018/04/30 13:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblOrder_Details](
	[OrderIDFK] [INT] NOT NULL,
	[ProductIDFK] [INT] NOT NULL,
	[ConfigurationIDFK] [INT] NOT NULL,	
	[OfferIDFK] [INT] NOT NULL,
	[AccumulatedPrice] [MONEY] NOT NULL,
	[Quantity] [INT] NOT NULL,
	[OrderDetails] [VARCHAR](100)
	) ON [PRIMARY]

GO


