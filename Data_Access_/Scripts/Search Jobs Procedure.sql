--USE [SHSMS]
--GO
CREATE OR ALTER PROCEDURE [dbo].[sp_SearchJobs] 
	-- Add the parameters for the stored procedure here
	(@JobDesc VARCHAR(50) = '',
	@JobSalary MONEY = 0,
	@HireDate DATETIME = '2018-01-01')AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT J.JobIDPK
  FROM tblJobs J 
  WHERE JobDescription = @JobDesc 
  OR J.JobSalary = @JobSalary
  OR J.HireDate = @HireDate
  END
