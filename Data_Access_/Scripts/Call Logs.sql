
USE SHSMS
GO
ALTER TABLE tblCalls
ALTER COLUMN CallDate varchar(50) NULL
GO
ALTER TABLE tblCalls
ALTER COLUMN CallTime varchar(50) NULL
GO
ALTER TABLE tblCalls
ALTER COLUMN CallDuration varchar(50) NULL
GO
ALTER TABLE tblCalls
ALTER COLUMN CallHoldDuration varchar(50) NULL
GO
ALTER TABLE tblCalls
ALTER COLUMN StaffIDFK int NULL
GO
ALTER TABLE tblCalls
ALTER COLUMN ClientIDFK int NULL
GO
ALTER TABLE tblCalls
ALTER COLUMN CompanyIDFK int NULL
GO
ALTER TABLE tblCalls
ADD CallType varchar(50) NULL
GO