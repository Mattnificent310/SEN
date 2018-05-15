USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblOrders]    Script Date: 2018/04/30 13:43:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblOrders](
	[OrderNoPK] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderDetails] [varchar](50) NULL,
	[RequiredDate] [datetime] NOT NULL,
	[SalesIDFK] [int] NULL,
	[BillingIDFK] [int] NULL,
	[ShippingNoFK] [int] NULL,
 CONSTRAINT [PK_tblOrders] PRIMARY KEY CLUSTERED 
(
	[OrderNoPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


