CREATE PROCEDURE sp_GetStockByProduct
(@ProductId INT)
AS
BEGIN
SELECT UnitsInStock 
FROM tblInventories 
WHERE ProductIDFK = @ProductId
END