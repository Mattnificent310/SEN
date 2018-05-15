USE SHSMSDB
CREATE TABLE tblAccounts(
AccountIDPK INT PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(50) NOT NULL UNIQUE,
Password VARCHAR(50),
Department VARCHAR(50) NOT NULL,
StaffIDFK INT NOT NULL UNIQUE REFERENCES dbo.tblStaff (StaffIDPK) )