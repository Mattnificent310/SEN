USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblStaff]    Script Date: 2018/04/30 13:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblOffers](
	[OfferIDPK] [INT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[OfferType] [VARCHAR](50) NOT NULL,
	[OfferDiscount] [DECIMAL] NOT NULL,	
	[OfferCriteria] [VARCHAR](50) NOT NULL,
	[OfferDetails] [VARCHAR](50)
	) ON [PRIMARY]

GO


