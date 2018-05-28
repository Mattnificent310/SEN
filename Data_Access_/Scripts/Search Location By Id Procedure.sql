USE [SHSMS]
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchJobs]    Script Date: 2018/05/28 19:37:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER   PROCEDURE sp_SearchLocationByID
	-- Add the parameters for the stored procedure here
	(@LocationID INT)
	
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT L.StreetAddress, C.CityName, CR.CountryName
  FROM tblLocations L 
  INNER JOIN tblCities C ON C.CityIDPK = L.CityIDFK
  INNER JOIN tblCountries CR ON CR.CountryIDPK = C.CityIDPK
  WHERE L.LocationIDPK = @LocationID
  END
