--USE SHSMS 
--GO
CREATE OR ALTER PROCEDURE sp_Login 
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
  INNER JOIN tblStaffs S ON S.StaffIDPK = A.StaffIDFK
  WHERE A.Username = @Username AND A.Passcode = @Password
  END
GO
