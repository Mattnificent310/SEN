USE [SHSMSDB]
GO

/****** Object:  Table [dbo].[tblJob]    Script Date: 2018/04/30 13:41:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblJob](
	[JobIDPK] [int] IDENTITY(1,1) NOT NULL,
	[JobDescription] [varchar](50) NOT NULL,
	[JobSalary] [money] NOT NULL,
	[HireDate] [date] NOT NULL,
	[JobDetails] [varchar](50) NULL,
 CONSTRAINT [PK_tblJob] PRIMARY KEY CLUSTERED 
(
	[JobIDPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


