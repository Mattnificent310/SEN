USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblProducts]    Script Date: 2018/04/30 13:44:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblProducts](
	[ProductNoPK] [int] NOT NULL,
	[ProductModel] [varchar](50) NOT NULL,
	[ProductDetail] [varchar](50) NULL,
	[UnitPrice] [money] NOT NULL,
	[Discontinued] [bit] NOT NULL,
	[CategoryIDFK] [int] NOT NULL,
CONSTRAINT [PK_tblProducts] PRIMARY KEY CLUSTERED 
(
	[ProductNoPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


