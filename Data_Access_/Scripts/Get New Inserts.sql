USE SHSMS
GO
CREATE PROCEDURE sp_GetNewInsert
(@Table VARCHAR(50))
AS
BEGIN
DECLARE @Tbl VARCHAR(50)
SET @Tbl = @Table;
IF @Tbl = 'tblProducts'
BEGIN
SELECT TOP 1 P.ProductSerialNoPK
FROM tblProducts P
ORDER BY ProductSerialNoPK DESC
END 

IF @Tbl = 'tblClients'
BEGIN
SELECT TOP 1 C.ClientIDPK
FROM tblClients C
ORDER BY C.ClientIDPK DESC
END

IF @Tbl = 'TblStaff'
BEGIN
SELECT TOP 1 S.StaffIDPK
FROM tblStaff S
ORDER BY S.StaffIDPK DESC
END

IF @Tbl = 'tblLocations'
BEGIN
SELECT TOP 1 L.LocationIDPK
FROM tblLocations L
ORDER BY L.LocationIDPK DESC
END

IF @Tbl = 'tblCities'
BEGIN
SELECT TOP 1 C.CityIDPK
FROM tblCities C
ORDER BY C.CityIDPK DESC
END

IF @Tbl = 'tblCountries'
BEGIN 
SELECT TOP 1 CR.CountryIDPK
FROM tblCountries CR
ORDER BY CR.CountryIDPK DESC
END

IF @Tbl = 'tblCategories'
BEGIN
SELECT TOP 1 CT.CategoryIDPK
FROM tblCategories CT
ORDER BY CT.CategoryIDPK DESC
END

IF @Tbl = 'tblCalls'
BEGIN 
SELECT TOP 1 CL.CallID
FROM tblCalls CL
ORDER BY CL.CallID DESC
END

IF @Tbl = 'tblInventories'
BEGIN
SELECT TOP 1 I.InventoryIDPK
FROM tblInventories I
ORDER BY I.InventoryIDPK DESC
END

IF @Tbl = 'tblJobs'
BEGIN
SELECT TOP 1 J.JobIDPK
FROM tblJobs J
ORDER BY J.JobIDPK DESC
END

IF @Tbl = 'tblContracts'
BEGIN 
SELECT TOP 1 CN.ContractID
FROM tblContracts CN
ORDER BY CN.ContractID DESC
END

IF @Tbl = 'tblAccounts'
BEGIN 
SELECT TOP 1 A.AccountIDPK
FROM tblAccounts A
ORDER BY A.AccountIDPK DESC
END

IF @Tbl = 'tblOffers'
BEGIN 
SELECT TOP 1 O.OfferIDPK
FROM tblOffers O
ORDER BY O.OfferIDPK DESC
END

IF @Tbl = 'tblSales'
BEGIN 
SELECT TOP 1 SL.SalesIDPK
FROM tblSales SL
ORDER BY SL.SalesIDPK DESC
END
END