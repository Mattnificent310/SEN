USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblOrders]    Script Date: 2018/04/30 13:43:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblInventory](
	[InventoryIDPK] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[WarehouseNo] [int] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	
 ) ON [PRIMARY]
GO


