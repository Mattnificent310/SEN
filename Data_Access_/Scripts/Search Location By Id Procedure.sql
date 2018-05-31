USE SHSMS
GO
ALTER PROCEDURE sp_SearchLocationByID
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
  INNER JOIN tblCountries CR ON CR.CountryIDPK = C.CountryIDFK
  WHERE L.LocationIDPK = @LocationID
  END
