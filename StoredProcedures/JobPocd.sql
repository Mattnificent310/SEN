USE [SHSMS]
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 2018/05/30 22:02:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Login] 
	-- Add the parameters for the stored procedure here
	(@Username VARCHAR(50),
	@Password VARCHAR(50))
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT A.Department
  FROM tblAccounts A
  INNER JOIN tblStaff S ON S.StaffIDPK = A.StaffIDFK
  WHERE A.Username = @Username AND A.Passcode = @Password
  END
