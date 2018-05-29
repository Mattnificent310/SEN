USE SHSMS
GO
CREATE OR ALTER   PROC [dbo].[sp_SearchLocation] 
	-- Add the parameters for the stored procedure here
	(@Country VARCHAR(50),
	@City VARCHAR(50),
	@Street VARCHAR(50))
	AS
	DECLARE @LocId INT
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
 SET @LocId = (SELECT L.LocationIDPK 
	FROM tblLocations L 
	INNER JOIN tblCities C ON C.CityIDPK = L.CityIDFK
	INNER JOIN tblCountries CR ON CR.CountryIDPK = C.CountryIDFK
	WHERE C.CityName = @City AND CR.CountryName = @Country AND L.StreetAddress = @Street)

	IF (@LocId IS NULL) 
	BEGIN
	BEGIN TRANSACTION
	INSERT INTO tblLocations(StreetAddress, CityIDFK) 
	VALUES(@Street,(SELECT C.CityIDPK FROM tblCities C WHERE C.CityName = @City))
	COMMIT
	END 
	SELECT L.LocationIDPK 
	FROM tblLocations L 
	INNER JOIN tblCities C ON C.CityIDPK = L.CityIDFK
	INNER JOIN tblCountries CR ON CR.CountryIDPK = C.CountryIDFK
	WHERE C.CityName = @City AND CR.CountryName = @Country AND L.StreetAddress = @Street
	
END
