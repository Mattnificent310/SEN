CREATE PROCEDURE sp_GetAutoIncrement
(@Table VARCHAR(50))
AS
BEGIN
SELECT IDENT_SEED(TABLE_SCHEMA + '.' + TABLE_NAME) AS Seed ,
IDENT_INCR(TABLE_SCHEMA + '.' + TABLE_NAME) AS Increment ,
IDENT_CURRENT(TABLE_SCHEMA + '.' + TABLE_NAME) AS CurrentIdentity ,
TABLE_NAME AS Tables,
UPPER(c.DATA_TYPE) AS DataType ,
t.MaxPosValue,
t.MaxPosValue -IDENT_CURRENT(TABLE_SCHEMA + '.' + TABLE_NAME) AS Remaining,
((t.MaxPosValue -IDENT_CURRENT(TABLE_SCHEMA + '.' + TABLE_NAME))/t.MaxPosValue) *100 AS PercentUnAllocated

FROM INFORMATION_SCHEMA.COLUMNS AS c
INNER JOIN ( SELECT name AS Data_Type ,
POWER(CAST(2 AS VARCHAR), ( max_length * 8 ) - 1) AS MaxPosValue
FROM sys.types
WHERE name LIKE '%Int'
) t ON c.DATA_TYPE = t.Data_Type
WHERE TABLE_NAME = @Table AND COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME,
'IsIdentity') = 1 
ORDER BY PercentUnAllocated asc
END

--EXEC sp_GetAutoIncrement 'tblClients'