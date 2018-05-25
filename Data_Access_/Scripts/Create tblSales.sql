USE [SHSMS]
GO

/****** Object:  Table [dbo].[tblSales]    Script Date: 2018/05/24 19:44:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSales](
	[SalesIDPK] [int] IDENTITY(1,1) NOT NULL,
	[SalesType] [varchar](50) NOT NULL,
	[SalesDate] [varchar](50) NOT NULL,
	[StaffIDFK] [int] NOT NULL,
	[ContractIDFK] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblSales] PRIMARY KEY CLUSTERED 
(
	[SalesIDPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblSales]  WITH CHECK ADD  CONSTRAINT [FK_tblSales_tblCompContract] FOREIGN KEY([ContractIDFK])
REFERENCES [dbo].[tblCompContracts] ([ContractIDPK])
GO

ALTER TABLE [dbo].[tblSales] CHECK CONSTRAINT [FK_tblSales_tblCompContract]
GO

ALTER TABLE [dbo].[tblSales]  WITH CHECK ADD  CONSTRAINT [FK_tblSales_tblContract] FOREIGN KEY([ContractIDFK])
REFERENCES [dbo].[tblContracts] ([ContractID])
GO

ALTER TABLE [dbo].[tblSales] CHECK CONSTRAINT [FK_tblSales_tblContract]
GO

ALTER TABLE [dbo].[tblSales]  WITH CHECK ADD  CONSTRAINT [FK_tblSales_tblStaff] FOREIGN KEY([StaffIDFK])
REFERENCES [dbo].[tblStaffs] ([StaffIDPK])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblSales] CHECK CONSTRAINT [FK_tblSales_tblStaff]
GO


