
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2018 13:22:54
-- Generated from EDMX file: C:\Users\matt.maree\Desktop\SEN 321\Assignments\Project\SHS Management System\DataAccessLayer\SHSDBEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SHSMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblAccessOrder_tblAccessories]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblAccessOrder] DROP CONSTRAINT [FK_tblAccessOrder_tblAccessories];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblAccessOrder_tblOrder_Details]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblAccessOrder] DROP CONSTRAINT [FK_tblAccessOrder_tblOrder_Details];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccount_tblStaff]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccount] DROP CONSTRAINT [FK_tblAccount_tblStaff];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBilling_tblOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBilling] DROP CONSTRAINT [FK_tblBilling_tblOrders];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCalls_tblClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCalls] DROP CONSTRAINT [FK_tblCalls_tblClient];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCalls_tblCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCalls] DROP CONSTRAINT [FK_tblCalls_tblCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCalls_tblStaff]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCalls] DROP CONSTRAINT [FK_tblCalls_tblStaff];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCIty_tblCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCIty] DROP CONSTRAINT [FK_tblCIty_tblCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_tblClient_tblLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblClient] DROP CONSTRAINT [FK_tblClient_tblLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCompany_tblLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCompany] DROP CONSTRAINT [FK_tblCompany_tblLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCompContract_tblCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCompContract] DROP CONSTRAINT [FK_tblCompContract_tblCompany];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblCompOffContract_tblBenifits]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblCompOffContract] DROP CONSTRAINT [FK_tblCompOffContract_tblBenifits];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblCompOffContract_tblCompContract]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblCompOffContract] DROP CONSTRAINT [FK_tblCompOffContract_tblCompContract];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblCompOffContract_tblOffers]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblCompOffContract] DROP CONSTRAINT [FK_tblCompOffContract_tblOffers];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblComponentSupplier_tblComponents]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblComponentSupplier] DROP CONSTRAINT [FK_tblComponentSupplier_tblComponents];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblComponentSupplier_tblManufacturer]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblComponentSupplier] DROP CONSTRAINT [FK_tblComponentSupplier_tblManufacturer];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblConSupProd_tblCompContract]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblConSupProd] DROP CONSTRAINT [FK_tblConSupProd_tblCompContract];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblConSupProd_tblComponents]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblConSupProd] DROP CONSTRAINT [FK_tblConSupProd_tblComponents];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblConSupProd_tblContract]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblConSupProd] DROP CONSTRAINT [FK_tblConSupProd_tblContract];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblConSupProd_tblSupport]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblConSupProd] DROP CONSTRAINT [FK_tblConSupProd_tblSupport];
GO
IF OBJECT_ID(N'[dbo].[FK_tblContract_tblClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblContract] DROP CONSTRAINT [FK_tblContract_tblClient];
GO
IF OBJECT_ID(N'[dbo].[FK_tblLocation_tblCIty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblLocation] DROP CONSTRAINT [FK_tblLocation_tblCIty];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblOfferContract_tblBenifits]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblOfferContract] DROP CONSTRAINT [FK_tblOfferContract_tblBenifits];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblOfferContract_tblContract]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblOfferContract] DROP CONSTRAINT [FK_tblOfferContract_tblContract];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblOfferContract_tblOffers]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblOfferContract] DROP CONSTRAINT [FK_tblOfferContract_tblOffers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrder_Details_tblConfiguration]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrder_Details] DROP CONSTRAINT [FK_tblOrder_Details_tblConfiguration];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrder_Details_tblOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrder_Details] DROP CONSTRAINT [FK_tblOrder_Details_tblOrders];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrder_Details_tblProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrder_Details] DROP CONSTRAINT [FK_tblOrder_Details_tblProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrders_tblSales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrders] DROP CONSTRAINT [FK_tblOrders_tblSales];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrders_tblShipping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrders] DROP CONSTRAINT [FK_tblOrders_tblShipping];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblProdAccessories_tblAccessories]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblProdAccessories] DROP CONSTRAINT [FK_tblProdAccessories_tblAccessories];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblProdAccessories_tblProducts]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblProdAccessories] DROP CONSTRAINT [FK_tblProdAccessories_tblProducts];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblProductComponents_tblComponents]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblProductComponents] DROP CONSTRAINT [FK_tblProductComponents_tblComponents];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblProductComponents_tblProducts]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblProductComponents] DROP CONSTRAINT [FK_tblProductComponents_tblProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProducts_tblCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProducts] DROP CONSTRAINT [FK_tblProducts_tblCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProducts_tblInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProducts] DROP CONSTRAINT [FK_tblProducts_tblInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSales_tblCompContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSales] DROP CONSTRAINT [FK_tblSales_tblCompContract];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSales_tblContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSales] DROP CONSTRAINT [FK_tblSales_tblContract];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSales_tblStaff]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSales] DROP CONSTRAINT [FK_tblSales_tblStaff];
GO
IF OBJECT_ID(N'[dbo].[FK_tblShipping_tblLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblShipping] DROP CONSTRAINT [FK_tblShipping_tblLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStaff_tblJob]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStaff] DROP CONSTRAINT [FK_tblStaff_tblJob];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStaff_tblLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStaff] DROP CONSTRAINT [FK_tblStaff_tblLocation];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblStaffTeam_tblStaff]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblStaffTeam] DROP CONSTRAINT [FK_tblStaffTeam_tblStaff];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblStaffTeam_Team]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblStaffTeam] DROP CONSTRAINT [FK_tblStaffTeam_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSupport_tblMaintenanceTasks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSupport] DROP CONSTRAINT [FK_tblSupport_tblMaintenanceTasks];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblSupportTeam_tblSupport]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblSupportTeam] DROP CONSTRAINT [FK_tblSupportTeam_tblSupport];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[FK_tblSupportTeam_Team]', 'F') IS NOT NULL
    ALTER TABLE [SHSDBModelStoreContainer].[tblSupportTeam] DROP CONSTRAINT [FK_tblSupportTeam_Team];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tblAccessories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccessories];
GO
IF OBJECT_ID(N'[dbo].[tblAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccount];
GO
IF OBJECT_ID(N'[dbo].[tblBenifits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBenifits];
GO
IF OBJECT_ID(N'[dbo].[tblBilling]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBilling];
GO
IF OBJECT_ID(N'[dbo].[tblCalls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCalls];
GO
IF OBJECT_ID(N'[dbo].[tblCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCategory];
GO
IF OBJECT_ID(N'[dbo].[tblCIty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCIty];
GO
IF OBJECT_ID(N'[dbo].[tblClient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblClient];
GO
IF OBJECT_ID(N'[dbo].[tblCompany]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCompany];
GO
IF OBJECT_ID(N'[dbo].[tblCompContract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCompContract];
GO
IF OBJECT_ID(N'[dbo].[tblComponents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblComponents];
GO
IF OBJECT_ID(N'[dbo].[tblConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblConfiguration];
GO
IF OBJECT_ID(N'[dbo].[tblContract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblContract];
GO
IF OBJECT_ID(N'[dbo].[tblCountry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCountry];
GO
IF OBJECT_ID(N'[dbo].[tblInventory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblInventory];
GO
IF OBJECT_ID(N'[dbo].[tblJob]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblJob];
GO
IF OBJECT_ID(N'[dbo].[tblLocation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLocation];
GO
IF OBJECT_ID(N'[dbo].[tblManufacturer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblManufacturer];
GO
IF OBJECT_ID(N'[dbo].[tblOffers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOffers];
GO
IF OBJECT_ID(N'[dbo].[tblOrder_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrder_Details];
GO
IF OBJECT_ID(N'[dbo].[tblOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrders];
GO
IF OBJECT_ID(N'[dbo].[tblProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProducts];
GO
IF OBJECT_ID(N'[dbo].[tblSales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSales];
GO
IF OBJECT_ID(N'[dbo].[tblShipping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblShipping];
GO
IF OBJECT_ID(N'[dbo].[tblStaff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStaff];
GO
IF OBJECT_ID(N'[dbo].[tblSupport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSupport];
GO
IF OBJECT_ID(N'[dbo].[tblSupportTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSupportTasks];
GO
IF OBJECT_ID(N'[dbo].[tblTeam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTeam];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblAccessOrder]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblAccessOrder];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblCompOffContract]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblCompOffContract];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblComponentSupplier]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblComponentSupplier];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblConSupProd]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblConSupProd];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblOfferContract]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblOfferContract];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblProdAccessories]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblProdAccessories];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblProductComponents]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblProductComponents];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblStaffTeam]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblStaffTeam];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[tblSupportTeam]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[tblSupportTeam];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[v_SearchJobDesc]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[v_SearchJobDesc];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[v_SearchLocation]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[v_SearchLocation];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[v_SearchMaintenance]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[v_SearchMaintenance];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[v_SearchStaff]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[v_SearchStaff];
GO
IF OBJECT_ID(N'[SHSDBModelStoreContainer].[v_SearchStaffMaintenance]', 'U') IS NOT NULL
    DROP TABLE [SHSDBModelStoreContainer].[v_SearchStaffMaintenance];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tblAccessories'
CREATE TABLE [dbo].[tblAccessories] (
    [AccessoryIDPK] int IDENTITY(1,1) NOT NULL,
    [AccessoryName] varchar(50)  NOT NULL,
    [AccessoryType] varchar(50)  NOT NULL,
    [AccessoryPrice] decimal(19,4)  NOT NULL,
    [AccessoryDetails] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblAccounts'
CREATE TABLE [dbo].[tblAccounts] (
    [AccountIDPK] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(50)  NOT NULL,
    [AdminType] varchar(50)  NOT NULL,
    [Passcode] varchar(50)  NOT NULL,
    [StaffIDFK] int  NOT NULL,
    [Department] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblBenifits'
CREATE TABLE [dbo].[tblBenifits] (
    [BenifitIDPK] int IDENTITY(1,1) NOT NULL,
    [BenifitName] varchar(50)  NOT NULL,
    [BenifitTerm] int  NOT NULL,
    [BenifitType] varchar(50)  NOT NULL,
    [BenifitProvision] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblBillings'
CREATE TABLE [dbo].[tblBillings] (
    [BillingIDPK] int IDENTITY(1,1) NOT NULL,
    [BillingMethod] varchar(50)  NOT NULL,
    [BillingDate] datetime  NOT NULL,
    [BillingDetails] varchar(50)  NOT NULL,
    [BillingAddress] varchar(50)  NOT NULL,
    [BillingAmount] decimal(19,4)  NOT NULL,
    [OrderIDFK] int  NOT NULL
);
GO

-- Creating table 'tblCalls'
CREATE TABLE [dbo].[tblCalls] (
    [CallID] char(10)  NOT NULL,
    [CallDate] datetime  NOT NULL,
    [CallTime] time  NOT NULL,
    [CallDuration] time  NOT NULL,
    [CallHoldDuration] time  NOT NULL,
    [StaffIDFK] int  NOT NULL,
    [ClientIDFK] varchar(50)  NULL,
    [CompanyIDFK] varchar(50)  NULL
);
GO

-- Creating table 'tblCategories'
CREATE TABLE [dbo].[tblCategories] (
    [CategoryIDPK] int IDENTITY(1,1) NOT NULL,
    [CategoryName] varchar(50)  NOT NULL,
    [CategoryDescription] varchar(100)  NOT NULL
);
GO

-- Creating table 'tblCIties'
CREATE TABLE [dbo].[tblCIties] (
    [CityIDPK] int  NOT NULL,
    [CityName] varchar(50)  NULL,
    [CountryIDFK] char(10)  NULL
);
GO

-- Creating table 'tblClients'
CREATE TABLE [dbo].[tblClients] (
    [ClientIDPK] varchar(50)  NOT NULL,
    [ClientTitle] varchar(50)  NOT NULL,
    [ClientName] varchar(50)  NOT NULL,
    [ClientSurname] varchar(50)  NOT NULL,
    [ClientEmail] varchar(50)  NOT NULL,
    [ContactMethod] varchar(50)  NULL,
    [ClientGender] varchar(50)  NOT NULL,
    [ClientPhone] varchar(15)  NOT NULL,
    [ClientDOB] datetime  NOT NULL,
    [ClientStatus] varchar(50)  NULL,
    [CreditStatus] varchar(50)  NULL,
    [LocationIDFK] int  NULL
);
GO

-- Creating table 'tblCompanies'
CREATE TABLE [dbo].[tblCompanies] (
    [CompanyID] varchar(50)  NOT NULL,
    [CompanyName] varchar(50)  NOT NULL,
    [CompanyType] varchar(50)  NOT NULL,
    [CompanyPhone] char(10)  NOT NULL,
    [CompanyEmail] varchar(50)  NOT NULL,
    [CompanyStatus] char(10)  NOT NULL,
    [LocationIDFK] int  NOT NULL
);
GO

-- Creating table 'tblCompContracts'
CREATE TABLE [dbo].[tblCompContracts] (
    [ContractIDPK] varchar(50)  NOT NULL,
    [ContractLevel] char(10)  NOT NULL,
    [ContractType] varchar(50)  NOT NULL,
    [ContractIssueDate] datetime  NOT NULL,
    [ContractTerm] int  NOT NULL,
    [CompanyIDFK] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblComponents'
CREATE TABLE [dbo].[tblComponents] (
    [ComponentID] varchar(50)  NOT NULL,
    [ComponentName] varchar(50)  NOT NULL,
    [ComponentType] varchar(50)  NOT NULL,
    [ComponetnDetails] varchar(50)  NOT NULL,
    [ComponentPrice] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'tblConfigurations'
CREATE TABLE [dbo].[tblConfigurations] (
    [ConfigIDPK] int IDENTITY(1,1) NOT NULL,
    [ConfigCriteria] varchar(50)  NOT NULL,
    [ConfigType] varchar(50)  NOT NULL,
    [ConfigDetails] varchar(100)  NOT NULL
);
GO

-- Creating table 'tblContracts'
CREATE TABLE [dbo].[tblContracts] (
    [ContractID] varchar(50)  NOT NULL,
    [ContractLevel] varchar(50)  NOT NULL,
    [ContractType] varchar(50)  NOT NULL,
    [ContractDateIssued] datetime  NOT NULL,
    [ContractTerm] int  NOT NULL,
    [ClientIDFK] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblCountries'
CREATE TABLE [dbo].[tblCountries] (
    [CountryIDPK] char(10)  NOT NULL,
    [CountryName] varchar(50)  NULL
);
GO

-- Creating table 'tblInventories'
CREATE TABLE [dbo].[tblInventories] (
    [InventoryIDPK] int IDENTITY(1,1) NOT NULL,
    [WarehouseNo] varchar(10)  NOT NULL,
    [UnitsInStock] int  NOT NULL,
    [UnitsOnOrder] int  NOT NULL,
    [ReorderLevel] int  NOT NULL
);
GO

-- Creating table 'tblJobs'
CREATE TABLE [dbo].[tblJobs] (
    [JobIDPK] int IDENTITY(1,1) NOT NULL,
    [JobDescription] varchar(50)  NOT NULL,
    [JobSalary] decimal(19,4)  NOT NULL,
    [HireDate] datetime  NULL,
    [JobDetails] varchar(100)  NOT NULL,
    [Department] varchar(50)  NULL
);
GO

-- Creating table 'tblLocations'
CREATE TABLE [dbo].[tblLocations] (
    [LocationIDPK] int IDENTITY(1,1) NOT NULL,
    [StreetAddress] varchar(50)  NOT NULL,
    [SuburbAddress] varchar(50)  NULL,
    [CityIDFK] int  NULL
);
GO

-- Creating table 'tblManufacturers'
CREATE TABLE [dbo].[tblManufacturers] (
    [ManufacturerIDPK] int IDENTITY(1,1) NOT NULL,
    [ManufacturerName] varchar(50)  NOT NULL,
    [ManufacturerType] varchar(50)  NOT NULL,
    [ManufacturerPhone] char(10)  NOT NULL,
    [ManufacturerEmail] varchar(50)  NOT NULL,
    [ManufacturerStatus] char(10)  NOT NULL,
    [LocationIDFK] int  NOT NULL
);
GO

-- Creating table 'tblOffers'
CREATE TABLE [dbo].[tblOffers] (
    [OfferIDPK] int IDENTITY(1,1) NOT NULL,
    [OfferType] varchar(50)  NOT NULL,
    [OfferOption] varchar(50)  NOT NULL,
    [OfferDetails] varchar(50)  NOT NULL,
    [OfferCriteria] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblOrder_Details'
CREATE TABLE [dbo].[tblOrder_Details] (
    [OrderDetIDPK] int IDENTITY(1,1) NOT NULL,
    [OrderID] int  NOT NULL,
    [ProductID] varchar(50)  NOT NULL,
    [ConfigID] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [Total] decimal(19,4)  NOT NULL,
    [Discount] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'tblOrders'
CREATE TABLE [dbo].[tblOrders] (
    [OrderNoPK] int IDENTITY(1,1) NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [OrderDetails] varchar(50)  NOT NULL,
    [RequiredDate] datetime  NOT NULL,
    [SalesIDFK] int  NOT NULL,
    [ShippingNoFK] int  NOT NULL
);
GO

-- Creating table 'tblProducts'
CREATE TABLE [dbo].[tblProducts] (
    [ProductSerialNoPK] varchar(50)  NOT NULL,
    [ProductModel] varchar(50)  NOT NULL,
    [ProductDetails] varchar(100)  NOT NULL,
    [UnitPrice] decimal(19,4)  NOT NULL,
    [Discontinued] bit  NOT NULL,
    [CategoryIDFK] int  NOT NULL,
    [InventoryIDFK] int  NOT NULL
);
GO

-- Creating table 'tblSales'
CREATE TABLE [dbo].[tblSales] (
    [SalesIDPK] int IDENTITY(1,1) NOT NULL,
    [SalesType] varchar(50)  NOT NULL,
    [SalesDate] varchar(50)  NOT NULL,
    [StaffIDFK] int  NOT NULL,
    [ContractIDFK] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblShippings'
CREATE TABLE [dbo].[tblShippings] (
    [ShippingINoPK] int IDENTITY(1,1) NOT NULL,
    [Freight] varchar(50)  NOT NULL,
    [ShippingDate] datetime  NOT NULL,
    [ShipVia] varchar(50)  NOT NULL,
    [LocationIDFK] int  NOT NULL
);
GO

-- Creating table 'tblStaffs'
CREATE TABLE [dbo].[tblStaffs] (
    [StaffIDPK] int IDENTITY(1,1) NOT NULL,
    [StaffTitle] varchar(10)  NOT NULL,
    [StaffName] varchar(50)  NOT NULL,
    [StaffSurname] varchar(50)  NOT NULL,
    [StaffDOB] datetime  NOT NULL,
    [StaffGender] char(10)  NOT NULL,
    [StaffPhone] varchar(10)  NOT NULL,
    [StaffEmail] varchar(50)  NOT NULL,
    [JobDescIDFK] int  NOT NULL,
    [LocationIDFK] int  NOT NULL
);
GO

-- Creating table 'tblSupports'
CREATE TABLE [dbo].[tblSupports] (
    [SupportIDPK] int  NOT NULL,
    [SupportDetails] varchar(50)  NOT NULL,
    [SupportStartDate] datetime  NOT NULL,
    [SupportDuration] int  NOT NULL,
    [SupportEndDate] datetime  NOT NULL,
    [TeamIDFK] int  NOT NULL,
    [TaskIDFK] int  NOT NULL
);
GO

-- Creating table 'tblSupportTasks'
CREATE TABLE [dbo].[tblSupportTasks] (
    [TaskIDPK] int  NOT NULL,
    [TaskType] varchar(50)  NOT NULL,
    [TaskDescription] varchar(50)  NOT NULL,
    [TaskCriteria] varchar(50)  NOT NULL,
    [TaskCost] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'tblTeams'
CREATE TABLE [dbo].[tblTeams] (
    [TeamIDPK] int  NOT NULL,
    [TeamName] varchar(50)  NOT NULL,
    [TeamCapacity] int  NOT NULL,
    [TeamSpeciality] varchar(50)  NULL
);
GO

-- Creating table 'tblAccessOrders'
CREATE TABLE [dbo].[tblAccessOrders] (
    [AccessoryIDq] int  NOT NULL,
    [OrderID] int  NULL
);
GO

-- Creating table 'tblCompOffContracts'
CREATE TABLE [dbo].[tblCompOffContracts] (
    [OfferID] int  NOT NULL,
    [ContractID] varchar(50)  NOT NULL,
    [BenifitID] int  NOT NULL
);
GO

-- Creating table 'tblConSupProds'
CREATE TABLE [dbo].[tblConSupProds] (
    [ContractID] varchar(50)  NOT NULL,
    [ComponentD] varchar(50)  NOT NULL,
    [SupportID] int  NOT NULL
);
GO

-- Creating table 'tblOfferContracts'
CREATE TABLE [dbo].[tblOfferContracts] (
    [OfferID] int  NOT NULL,
    [ContractID] varchar(50)  NOT NULL,
    [BenifitID] int  NOT NULL
);
GO

-- Creating table 'v_SearchJobDesc'
CREATE TABLE [dbo].[v_SearchJobDesc] (
    [Job_Description] varchar(50)  NOT NULL,
    [Job_Salary] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'v_SearchLocation'
CREATE TABLE [dbo].[v_SearchLocation] (
    [Country] varchar(50)  NOT NULL,
    [City] varchar(50)  NOT NULL,
    [Street] varchar(50)  NOT NULL
);
GO

-- Creating table 'v_SearchMaintenance'
CREATE TABLE [dbo].[v_SearchMaintenance] (
    [Task_Criteria] varchar(50)  NOT NULL,
    [Task_Description] varchar(50)  NOT NULL,
    [Task_Tye] varchar(50)  NOT NULL,
    [Task_Cost] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'v_SearchStaff'
CREATE TABLE [dbo].[v_SearchStaff] (
    [Title] varchar(10)  NULL,
    [First_Name] varchar(50)  NOT NULL,
    [Last_Name] varchar(50)  NOT NULL,
    [Contact_Number] varchar(10)  NOT NULL,
    [Email_Address] varchar(50)  NOT NULL,
    [Gender] bit  NULL,
    [Date_of_Birth] datetime  NOT NULL,
    [Job_Description] varchar(50)  NOT NULL,
    [Job_Salary] decimal(19,4)  NOT NULL,
    [Date_Hired] datetime  NULL,
    [Street] varchar(50)  NOT NULL,
    [City] varchar(50)  NOT NULL,
    [Country] varchar(50)  NOT NULL
);
GO

-- Creating table 'v_SearchStaffMaintenance'
CREATE TABLE [dbo].[v_SearchStaffMaintenance] (
    [Staff_Full_Name] varchar(101)  NOT NULL,
    [Staff_DOB] datetime  NOT NULL,
    [Staff_Contact] varchar(10)  NOT NULL,
    [Maintenance_Task] varchar(50)  NOT NULL,
    [Task_Description] varchar(50)  NOT NULL,
    [Start_Date] datetime  NOT NULL,
    [End_Date] datetime  NOT NULL,
    [Details] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblComponentSupplier'
CREATE TABLE [dbo].[tblComponentSupplier] (
    [tblComponents_ComponentID] varchar(50)  NOT NULL,
    [tblManufacturers_ManufacturerIDPK] int  NOT NULL
);
GO

-- Creating table 'tblProdAccessories'
CREATE TABLE [dbo].[tblProdAccessories] (
    [tblAccessories_AccessoryIDPK] int  NOT NULL,
    [tblProducts_ProductSerialNoPK] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblProductComponents'
CREATE TABLE [dbo].[tblProductComponents] (
    [tblComponents_ComponentID] varchar(50)  NOT NULL,
    [tblProducts_ProductSerialNoPK] varchar(50)  NOT NULL
);
GO

-- Creating table 'tblStaffTeam'
CREATE TABLE [dbo].[tblStaffTeam] (
    [tblStaffs_StaffIDPK] int  NOT NULL,
    [tblTeams_TeamIDPK] int  NOT NULL
);
GO

-- Creating table 'tblSupportTeam'
CREATE TABLE [dbo].[tblSupportTeam] (
    [tblSupports_SupportIDPK] int  NOT NULL,
    [tblTeams_TeamIDPK] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [AccessoryIDPK] in table 'tblAccessories'
ALTER TABLE [dbo].[tblAccessories]
ADD CONSTRAINT [PK_tblAccessories]
    PRIMARY KEY CLUSTERED ([AccessoryIDPK] ASC);
GO

-- Creating primary key on [AccountIDPK] in table 'tblAccounts'
ALTER TABLE [dbo].[tblAccounts]
ADD CONSTRAINT [PK_tblAccounts]
    PRIMARY KEY CLUSTERED ([AccountIDPK] ASC);
GO

-- Creating primary key on [BenifitIDPK] in table 'tblBenifits'
ALTER TABLE [dbo].[tblBenifits]
ADD CONSTRAINT [PK_tblBenifits]
    PRIMARY KEY CLUSTERED ([BenifitIDPK] ASC);
GO

-- Creating primary key on [BillingIDPK] in table 'tblBillings'
ALTER TABLE [dbo].[tblBillings]
ADD CONSTRAINT [PK_tblBillings]
    PRIMARY KEY CLUSTERED ([BillingIDPK] ASC);
GO

-- Creating primary key on [CallID] in table 'tblCalls'
ALTER TABLE [dbo].[tblCalls]
ADD CONSTRAINT [PK_tblCalls]
    PRIMARY KEY CLUSTERED ([CallID] ASC);
GO

-- Creating primary key on [CategoryIDPK] in table 'tblCategories'
ALTER TABLE [dbo].[tblCategories]
ADD CONSTRAINT [PK_tblCategories]
    PRIMARY KEY CLUSTERED ([CategoryIDPK] ASC);
GO

-- Creating primary key on [CityIDPK] in table 'tblCIties'
ALTER TABLE [dbo].[tblCIties]
ADD CONSTRAINT [PK_tblCIties]
    PRIMARY KEY CLUSTERED ([CityIDPK] ASC);
GO

-- Creating primary key on [ClientIDPK] in table 'tblClients'
ALTER TABLE [dbo].[tblClients]
ADD CONSTRAINT [PK_tblClients]
    PRIMARY KEY CLUSTERED ([ClientIDPK] ASC);
GO

-- Creating primary key on [CompanyID] in table 'tblCompanies'
ALTER TABLE [dbo].[tblCompanies]
ADD CONSTRAINT [PK_tblCompanies]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [ContractIDPK] in table 'tblCompContracts'
ALTER TABLE [dbo].[tblCompContracts]
ADD CONSTRAINT [PK_tblCompContracts]
    PRIMARY KEY CLUSTERED ([ContractIDPK] ASC);
GO

-- Creating primary key on [ComponentID] in table 'tblComponents'
ALTER TABLE [dbo].[tblComponents]
ADD CONSTRAINT [PK_tblComponents]
    PRIMARY KEY CLUSTERED ([ComponentID] ASC);
GO

-- Creating primary key on [ConfigIDPK] in table 'tblConfigurations'
ALTER TABLE [dbo].[tblConfigurations]
ADD CONSTRAINT [PK_tblConfigurations]
    PRIMARY KEY CLUSTERED ([ConfigIDPK] ASC);
GO

-- Creating primary key on [ContractID] in table 'tblContracts'
ALTER TABLE [dbo].[tblContracts]
ADD CONSTRAINT [PK_tblContracts]
    PRIMARY KEY CLUSTERED ([ContractID] ASC);
GO

-- Creating primary key on [CountryIDPK] in table 'tblCountries'
ALTER TABLE [dbo].[tblCountries]
ADD CONSTRAINT [PK_tblCountries]
    PRIMARY KEY CLUSTERED ([CountryIDPK] ASC);
GO

-- Creating primary key on [InventoryIDPK] in table 'tblInventories'
ALTER TABLE [dbo].[tblInventories]
ADD CONSTRAINT [PK_tblInventories]
    PRIMARY KEY CLUSTERED ([InventoryIDPK] ASC);
GO

-- Creating primary key on [JobIDPK] in table 'tblJobs'
ALTER TABLE [dbo].[tblJobs]
ADD CONSTRAINT [PK_tblJobs]
    PRIMARY KEY CLUSTERED ([JobIDPK] ASC);
GO

-- Creating primary key on [LocationIDPK] in table 'tblLocations'
ALTER TABLE [dbo].[tblLocations]
ADD CONSTRAINT [PK_tblLocations]
    PRIMARY KEY CLUSTERED ([LocationIDPK] ASC);
GO

-- Creating primary key on [ManufacturerIDPK] in table 'tblManufacturers'
ALTER TABLE [dbo].[tblManufacturers]
ADD CONSTRAINT [PK_tblManufacturers]
    PRIMARY KEY CLUSTERED ([ManufacturerIDPK] ASC);
GO

-- Creating primary key on [OfferIDPK] in table 'tblOffers'
ALTER TABLE [dbo].[tblOffers]
ADD CONSTRAINT [PK_tblOffers]
    PRIMARY KEY CLUSTERED ([OfferIDPK] ASC);
GO

-- Creating primary key on [OrderDetIDPK] in table 'tblOrder_Details'
ALTER TABLE [dbo].[tblOrder_Details]
ADD CONSTRAINT [PK_tblOrder_Details]
    PRIMARY KEY CLUSTERED ([OrderDetIDPK] ASC);
GO

-- Creating primary key on [OrderNoPK] in table 'tblOrders'
ALTER TABLE [dbo].[tblOrders]
ADD CONSTRAINT [PK_tblOrders]
    PRIMARY KEY CLUSTERED ([OrderNoPK] ASC);
GO

-- Creating primary key on [ProductSerialNoPK] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [PK_tblProducts]
    PRIMARY KEY CLUSTERED ([ProductSerialNoPK] ASC);
GO

-- Creating primary key on [SalesIDPK] in table 'tblSales'
ALTER TABLE [dbo].[tblSales]
ADD CONSTRAINT [PK_tblSales]
    PRIMARY KEY CLUSTERED ([SalesIDPK] ASC);
GO

-- Creating primary key on [ShippingINoPK] in table 'tblShippings'
ALTER TABLE [dbo].[tblShippings]
ADD CONSTRAINT [PK_tblShippings]
    PRIMARY KEY CLUSTERED ([ShippingINoPK] ASC);
GO

-- Creating primary key on [StaffIDPK] in table 'tblStaffs'
ALTER TABLE [dbo].[tblStaffs]
ADD CONSTRAINT [PK_tblStaffs]
    PRIMARY KEY CLUSTERED ([StaffIDPK] ASC);
GO

-- Creating primary key on [SupportIDPK] in table 'tblSupports'
ALTER TABLE [dbo].[tblSupports]
ADD CONSTRAINT [PK_tblSupports]
    PRIMARY KEY CLUSTERED ([SupportIDPK] ASC);
GO

-- Creating primary key on [TaskIDPK] in table 'tblSupportTasks'
ALTER TABLE [dbo].[tblSupportTasks]
ADD CONSTRAINT [PK_tblSupportTasks]
    PRIMARY KEY CLUSTERED ([TaskIDPK] ASC);
GO

-- Creating primary key on [TeamIDPK] in table 'tblTeams'
ALTER TABLE [dbo].[tblTeams]
ADD CONSTRAINT [PK_tblTeams]
    PRIMARY KEY CLUSTERED ([TeamIDPK] ASC);
GO

-- Creating primary key on [AccessoryIDq] in table 'tblAccessOrders'
ALTER TABLE [dbo].[tblAccessOrders]
ADD CONSTRAINT [PK_tblAccessOrders]
    PRIMARY KEY CLUSTERED ([AccessoryIDq] ASC);
GO

-- Creating primary key on [OfferID], [ContractID], [BenifitID] in table 'tblCompOffContracts'
ALTER TABLE [dbo].[tblCompOffContracts]
ADD CONSTRAINT [PK_tblCompOffContracts]
    PRIMARY KEY CLUSTERED ([OfferID], [ContractID], [BenifitID] ASC);
GO

-- Creating primary key on [ContractID], [ComponentD], [SupportID] in table 'tblConSupProds'
ALTER TABLE [dbo].[tblConSupProds]
ADD CONSTRAINT [PK_tblConSupProds]
    PRIMARY KEY CLUSTERED ([ContractID], [ComponentD], [SupportID] ASC);
GO

-- Creating primary key on [OfferID], [ContractID], [BenifitID] in table 'tblOfferContracts'
ALTER TABLE [dbo].[tblOfferContracts]
ADD CONSTRAINT [PK_tblOfferContracts]
    PRIMARY KEY CLUSTERED ([OfferID], [ContractID], [BenifitID] ASC);
GO

-- Creating primary key on [Job_Description], [Job_Salary] in table 'v_SearchJobDesc'
ALTER TABLE [dbo].[v_SearchJobDesc]
ADD CONSTRAINT [PK_v_SearchJobDesc]
    PRIMARY KEY CLUSTERED ([Job_Description], [Job_Salary] ASC);
GO

-- Creating primary key on [Country], [City], [Street] in table 'v_SearchLocation'
ALTER TABLE [dbo].[v_SearchLocation]
ADD CONSTRAINT [PK_v_SearchLocation]
    PRIMARY KEY CLUSTERED ([Country], [City], [Street] ASC);
GO

-- Creating primary key on [Task_Criteria], [Task_Description], [Task_Tye], [Task_Cost] in table 'v_SearchMaintenance'
ALTER TABLE [dbo].[v_SearchMaintenance]
ADD CONSTRAINT [PK_v_SearchMaintenance]
    PRIMARY KEY CLUSTERED ([Task_Criteria], [Task_Description], [Task_Tye], [Task_Cost] ASC);
GO

-- Creating primary key on [First_Name], [Last_Name], [Contact_Number], [Email_Address], [Date_of_Birth], [Job_Description], [Job_Salary], [Street], [City], [Country] in table 'v_SearchStaff'
ALTER TABLE [dbo].[v_SearchStaff]
ADD CONSTRAINT [PK_v_SearchStaff]
    PRIMARY KEY CLUSTERED ([First_Name], [Last_Name], [Contact_Number], [Email_Address], [Date_of_Birth], [Job_Description], [Job_Salary], [Street], [City], [Country] ASC);
GO

-- Creating primary key on [Staff_Full_Name], [Staff_DOB], [Staff_Contact], [Maintenance_Task], [Task_Description], [Start_Date], [End_Date], [Details] in table 'v_SearchStaffMaintenance'
ALTER TABLE [dbo].[v_SearchStaffMaintenance]
ADD CONSTRAINT [PK_v_SearchStaffMaintenance]
    PRIMARY KEY CLUSTERED ([Staff_Full_Name], [Staff_DOB], [Staff_Contact], [Maintenance_Task], [Task_Description], [Start_Date], [End_Date], [Details] ASC);
GO

-- Creating primary key on [tblComponents_ComponentID], [tblManufacturers_ManufacturerIDPK] in table 'tblComponentSupplier'
ALTER TABLE [dbo].[tblComponentSupplier]
ADD CONSTRAINT [PK_tblComponentSupplier]
    PRIMARY KEY CLUSTERED ([tblComponents_ComponentID], [tblManufacturers_ManufacturerIDPK] ASC);
GO

-- Creating primary key on [tblAccessories_AccessoryIDPK], [tblProducts_ProductSerialNoPK] in table 'tblProdAccessories'
ALTER TABLE [dbo].[tblProdAccessories]
ADD CONSTRAINT [PK_tblProdAccessories]
    PRIMARY KEY CLUSTERED ([tblAccessories_AccessoryIDPK], [tblProducts_ProductSerialNoPK] ASC);
GO

-- Creating primary key on [tblComponents_ComponentID], [tblProducts_ProductSerialNoPK] in table 'tblProductComponents'
ALTER TABLE [dbo].[tblProductComponents]
ADD CONSTRAINT [PK_tblProductComponents]
    PRIMARY KEY CLUSTERED ([tblComponents_ComponentID], [tblProducts_ProductSerialNoPK] ASC);
GO

-- Creating primary key on [tblStaffs_StaffIDPK], [tblTeams_TeamIDPK] in table 'tblStaffTeam'
ALTER TABLE [dbo].[tblStaffTeam]
ADD CONSTRAINT [PK_tblStaffTeam]
    PRIMARY KEY CLUSTERED ([tblStaffs_StaffIDPK], [tblTeams_TeamIDPK] ASC);
GO

-- Creating primary key on [tblSupports_SupportIDPK], [tblTeams_TeamIDPK] in table 'tblSupportTeam'
ALTER TABLE [dbo].[tblSupportTeam]
ADD CONSTRAINT [PK_tblSupportTeam]
    PRIMARY KEY CLUSTERED ([tblSupports_SupportIDPK], [tblTeams_TeamIDPK] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccessoryIDq] in table 'tblAccessOrders'
ALTER TABLE [dbo].[tblAccessOrders]
ADD CONSTRAINT [FK_tblAccessOrder_tblAccessories]
    FOREIGN KEY ([AccessoryIDq])
    REFERENCES [dbo].[tblAccessories]
        ([AccessoryIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StaffIDFK] in table 'tblAccounts'
ALTER TABLE [dbo].[tblAccounts]
ADD CONSTRAINT [FK_tblAccount_tblStaff]
    FOREIGN KEY ([StaffIDFK])
    REFERENCES [dbo].[tblStaffs]
        ([StaffIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccount_tblStaff'
CREATE INDEX [IX_FK_tblAccount_tblStaff]
ON [dbo].[tblAccounts]
    ([StaffIDFK]);
GO

-- Creating foreign key on [BenifitID] in table 'tblCompOffContracts'
ALTER TABLE [dbo].[tblCompOffContracts]
ADD CONSTRAINT [FK_tblCompOffContract_tblBenifits]
    FOREIGN KEY ([BenifitID])
    REFERENCES [dbo].[tblBenifits]
        ([BenifitIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCompOffContract_tblBenifits'
CREATE INDEX [IX_FK_tblCompOffContract_tblBenifits]
ON [dbo].[tblCompOffContracts]
    ([BenifitID]);
GO

-- Creating foreign key on [BenifitID] in table 'tblOfferContracts'
ALTER TABLE [dbo].[tblOfferContracts]
ADD CONSTRAINT [FK_tblOfferContract_tblBenifits]
    FOREIGN KEY ([BenifitID])
    REFERENCES [dbo].[tblBenifits]
        ([BenifitIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOfferContract_tblBenifits'
CREATE INDEX [IX_FK_tblOfferContract_tblBenifits]
ON [dbo].[tblOfferContracts]
    ([BenifitID]);
GO

-- Creating foreign key on [OrderIDFK] in table 'tblBillings'
ALTER TABLE [dbo].[tblBillings]
ADD CONSTRAINT [FK_tblBilling_tblOrders]
    FOREIGN KEY ([OrderIDFK])
    REFERENCES [dbo].[tblOrders]
        ([OrderNoPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBilling_tblOrders'
CREATE INDEX [IX_FK_tblBilling_tblOrders]
ON [dbo].[tblBillings]
    ([OrderIDFK]);
GO

-- Creating foreign key on [ClientIDFK] in table 'tblCalls'
ALTER TABLE [dbo].[tblCalls]
ADD CONSTRAINT [FK_tblCalls_tblClient]
    FOREIGN KEY ([ClientIDFK])
    REFERENCES [dbo].[tblClients]
        ([ClientIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCalls_tblClient'
CREATE INDEX [IX_FK_tblCalls_tblClient]
ON [dbo].[tblCalls]
    ([ClientIDFK]);
GO

-- Creating foreign key on [CompanyIDFK] in table 'tblCalls'
ALTER TABLE [dbo].[tblCalls]
ADD CONSTRAINT [FK_tblCalls_tblCompany]
    FOREIGN KEY ([CompanyIDFK])
    REFERENCES [dbo].[tblCompanies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCalls_tblCompany'
CREATE INDEX [IX_FK_tblCalls_tblCompany]
ON [dbo].[tblCalls]
    ([CompanyIDFK]);
GO

-- Creating foreign key on [StaffIDFK] in table 'tblCalls'
ALTER TABLE [dbo].[tblCalls]
ADD CONSTRAINT [FK_tblCalls_tblStaff]
    FOREIGN KEY ([StaffIDFK])
    REFERENCES [dbo].[tblStaffs]
        ([StaffIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCalls_tblStaff'
CREATE INDEX [IX_FK_tblCalls_tblStaff]
ON [dbo].[tblCalls]
    ([StaffIDFK]);
GO

-- Creating foreign key on [CategoryIDFK] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProducts_tblCategory]
    FOREIGN KEY ([CategoryIDFK])
    REFERENCES [dbo].[tblCategories]
        ([CategoryIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProducts_tblCategory'
CREATE INDEX [IX_FK_tblProducts_tblCategory]
ON [dbo].[tblProducts]
    ([CategoryIDFK]);
GO

-- Creating foreign key on [CountryIDFK] in table 'tblCIties'
ALTER TABLE [dbo].[tblCIties]
ADD CONSTRAINT [FK_tblCIty_tblCountry]
    FOREIGN KEY ([CountryIDFK])
    REFERENCES [dbo].[tblCountries]
        ([CountryIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCIty_tblCountry'
CREATE INDEX [IX_FK_tblCIty_tblCountry]
ON [dbo].[tblCIties]
    ([CountryIDFK]);
GO

-- Creating foreign key on [CityIDFK] in table 'tblLocations'
ALTER TABLE [dbo].[tblLocations]
ADD CONSTRAINT [FK_tblLocation_tblCIty]
    FOREIGN KEY ([CityIDFK])
    REFERENCES [dbo].[tblCIties]
        ([CityIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblLocation_tblCIty'
CREATE INDEX [IX_FK_tblLocation_tblCIty]
ON [dbo].[tblLocations]
    ([CityIDFK]);
GO

-- Creating foreign key on [LocationIDFK] in table 'tblClients'
ALTER TABLE [dbo].[tblClients]
ADD CONSTRAINT [FK_tblClient_tblLocation]
    FOREIGN KEY ([LocationIDFK])
    REFERENCES [dbo].[tblLocations]
        ([LocationIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblClient_tblLocation'
CREATE INDEX [IX_FK_tblClient_tblLocation]
ON [dbo].[tblClients]
    ([LocationIDFK]);
GO

-- Creating foreign key on [ClientIDFK] in table 'tblContracts'
ALTER TABLE [dbo].[tblContracts]
ADD CONSTRAINT [FK_tblContract_tblClient]
    FOREIGN KEY ([ClientIDFK])
    REFERENCES [dbo].[tblClients]
        ([ClientIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblContract_tblClient'
CREATE INDEX [IX_FK_tblContract_tblClient]
ON [dbo].[tblContracts]
    ([ClientIDFK]);
GO

-- Creating foreign key on [LocationIDFK] in table 'tblCompanies'
ALTER TABLE [dbo].[tblCompanies]
ADD CONSTRAINT [FK_tblCompany_tblLocation]
    FOREIGN KEY ([LocationIDFK])
    REFERENCES [dbo].[tblLocations]
        ([LocationIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCompany_tblLocation'
CREATE INDEX [IX_FK_tblCompany_tblLocation]
ON [dbo].[tblCompanies]
    ([LocationIDFK]);
GO

-- Creating foreign key on [CompanyIDFK] in table 'tblCompContracts'
ALTER TABLE [dbo].[tblCompContracts]
ADD CONSTRAINT [FK_tblCompContract_tblCompany]
    FOREIGN KEY ([CompanyIDFK])
    REFERENCES [dbo].[tblCompanies]
        ([CompanyID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCompContract_tblCompany'
CREATE INDEX [IX_FK_tblCompContract_tblCompany]
ON [dbo].[tblCompContracts]
    ([CompanyIDFK]);
GO

-- Creating foreign key on [ContractID] in table 'tblCompOffContracts'
ALTER TABLE [dbo].[tblCompOffContracts]
ADD CONSTRAINT [FK_tblCompOffContract_tblCompContract]
    FOREIGN KEY ([ContractID])
    REFERENCES [dbo].[tblCompContracts]
        ([ContractIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCompOffContract_tblCompContract'
CREATE INDEX [IX_FK_tblCompOffContract_tblCompContract]
ON [dbo].[tblCompOffContracts]
    ([ContractID]);
GO

-- Creating foreign key on [ContractID] in table 'tblConSupProds'
ALTER TABLE [dbo].[tblConSupProds]
ADD CONSTRAINT [FK_tblConSupProd_tblCompContract]
    FOREIGN KEY ([ContractID])
    REFERENCES [dbo].[tblCompContracts]
        ([ContractIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ContractIDFK] in table 'tblSales'
ALTER TABLE [dbo].[tblSales]
ADD CONSTRAINT [FK_tblSales_tblCompContract]
    FOREIGN KEY ([ContractIDFK])
    REFERENCES [dbo].[tblCompContracts]
        ([ContractIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSales_tblCompContract'
CREATE INDEX [IX_FK_tblSales_tblCompContract]
ON [dbo].[tblSales]
    ([ContractIDFK]);
GO

-- Creating foreign key on [ComponentD] in table 'tblConSupProds'
ALTER TABLE [dbo].[tblConSupProds]
ADD CONSTRAINT [FK_tblConSupProd_tblComponents]
    FOREIGN KEY ([ComponentD])
    REFERENCES [dbo].[tblComponents]
        ([ComponentID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblConSupProd_tblComponents'
CREATE INDEX [IX_FK_tblConSupProd_tblComponents]
ON [dbo].[tblConSupProds]
    ([ComponentD]);
GO

-- Creating foreign key on [ConfigID] in table 'tblOrder_Details'
ALTER TABLE [dbo].[tblOrder_Details]
ADD CONSTRAINT [FK_tblOrder_Details_tblConfiguration]
    FOREIGN KEY ([ConfigID])
    REFERENCES [dbo].[tblConfigurations]
        ([ConfigIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrder_Details_tblConfiguration'
CREATE INDEX [IX_FK_tblOrder_Details_tblConfiguration]
ON [dbo].[tblOrder_Details]
    ([ConfigID]);
GO

-- Creating foreign key on [ContractID] in table 'tblConSupProds'
ALTER TABLE [dbo].[tblConSupProds]
ADD CONSTRAINT [FK_tblConSupProd_tblContract]
    FOREIGN KEY ([ContractID])
    REFERENCES [dbo].[tblContracts]
        ([ContractID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ContractID] in table 'tblOfferContracts'
ALTER TABLE [dbo].[tblOfferContracts]
ADD CONSTRAINT [FK_tblOfferContract_tblContract]
    FOREIGN KEY ([ContractID])
    REFERENCES [dbo].[tblContracts]
        ([ContractID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOfferContract_tblContract'
CREATE INDEX [IX_FK_tblOfferContract_tblContract]
ON [dbo].[tblOfferContracts]
    ([ContractID]);
GO

-- Creating foreign key on [ContractIDFK] in table 'tblSales'
ALTER TABLE [dbo].[tblSales]
ADD CONSTRAINT [FK_tblSales_tblContract]
    FOREIGN KEY ([ContractIDFK])
    REFERENCES [dbo].[tblContracts]
        ([ContractID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSales_tblContract'
CREATE INDEX [IX_FK_tblSales_tblContract]
ON [dbo].[tblSales]
    ([ContractIDFK]);
GO

-- Creating foreign key on [InventoryIDFK] in table 'tblProducts'
ALTER TABLE [dbo].[tblProducts]
ADD CONSTRAINT [FK_tblProducts_tblInventory]
    FOREIGN KEY ([InventoryIDFK])
    REFERENCES [dbo].[tblInventories]
        ([InventoryIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProducts_tblInventory'
CREATE INDEX [IX_FK_tblProducts_tblInventory]
ON [dbo].[tblProducts]
    ([InventoryIDFK]);
GO

-- Creating foreign key on [JobDescIDFK] in table 'tblStaffs'
ALTER TABLE [dbo].[tblStaffs]
ADD CONSTRAINT [FK_tblStaff_tblJob]
    FOREIGN KEY ([JobDescIDFK])
    REFERENCES [dbo].[tblJobs]
        ([JobIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStaff_tblJob'
CREATE INDEX [IX_FK_tblStaff_tblJob]
ON [dbo].[tblStaffs]
    ([JobDescIDFK]);
GO

-- Creating foreign key on [LocationIDFK] in table 'tblShippings'
ALTER TABLE [dbo].[tblShippings]
ADD CONSTRAINT [FK_tblShipping_tblLocation]
    FOREIGN KEY ([LocationIDFK])
    REFERENCES [dbo].[tblLocations]
        ([LocationIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblShipping_tblLocation'
CREATE INDEX [IX_FK_tblShipping_tblLocation]
ON [dbo].[tblShippings]
    ([LocationIDFK]);
GO

-- Creating foreign key on [LocationIDFK] in table 'tblStaffs'
ALTER TABLE [dbo].[tblStaffs]
ADD CONSTRAINT [FK_tblStaff_tblLocation]
    FOREIGN KEY ([LocationIDFK])
    REFERENCES [dbo].[tblLocations]
        ([LocationIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStaff_tblLocation'
CREATE INDEX [IX_FK_tblStaff_tblLocation]
ON [dbo].[tblStaffs]
    ([LocationIDFK]);
GO

-- Creating foreign key on [OfferID] in table 'tblCompOffContracts'
ALTER TABLE [dbo].[tblCompOffContracts]
ADD CONSTRAINT [FK_tblCompOffContract_tblOffers]
    FOREIGN KEY ([OfferID])
    REFERENCES [dbo].[tblOffers]
        ([OfferIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OfferID] in table 'tblOfferContracts'
ALTER TABLE [dbo].[tblOfferContracts]
ADD CONSTRAINT [FK_tblOfferContract_tblOffers]
    FOREIGN KEY ([OfferID])
    REFERENCES [dbo].[tblOffers]
        ([OfferIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OrderID] in table 'tblAccessOrders'
ALTER TABLE [dbo].[tblAccessOrders]
ADD CONSTRAINT [FK_tblAccessOrder_tblOrder_Details]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[tblOrder_Details]
        ([OrderDetIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccessOrder_tblOrder_Details'
CREATE INDEX [IX_FK_tblAccessOrder_tblOrder_Details]
ON [dbo].[tblAccessOrders]
    ([OrderID]);
GO

-- Creating foreign key on [OrderID] in table 'tblOrder_Details'
ALTER TABLE [dbo].[tblOrder_Details]
ADD CONSTRAINT [FK_tblOrder_Details_tblOrders]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[tblOrders]
        ([OrderNoPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrder_Details_tblOrders'
CREATE INDEX [IX_FK_tblOrder_Details_tblOrders]
ON [dbo].[tblOrder_Details]
    ([OrderID]);
GO

-- Creating foreign key on [ProductID] in table 'tblOrder_Details'
ALTER TABLE [dbo].[tblOrder_Details]
ADD CONSTRAINT [FK_tblOrder_Details_tblProducts]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[tblProducts]
        ([ProductSerialNoPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrder_Details_tblProducts'
CREATE INDEX [IX_FK_tblOrder_Details_tblProducts]
ON [dbo].[tblOrder_Details]
    ([ProductID]);
GO

-- Creating foreign key on [SalesIDFK] in table 'tblOrders'
ALTER TABLE [dbo].[tblOrders]
ADD CONSTRAINT [FK_tblOrders_tblSales]
    FOREIGN KEY ([SalesIDFK])
    REFERENCES [dbo].[tblSales]
        ([SalesIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrders_tblSales'
CREATE INDEX [IX_FK_tblOrders_tblSales]
ON [dbo].[tblOrders]
    ([SalesIDFK]);
GO

-- Creating foreign key on [ShippingNoFK] in table 'tblOrders'
ALTER TABLE [dbo].[tblOrders]
ADD CONSTRAINT [FK_tblOrders_tblShipping]
    FOREIGN KEY ([ShippingNoFK])
    REFERENCES [dbo].[tblShippings]
        ([ShippingINoPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrders_tblShipping'
CREATE INDEX [IX_FK_tblOrders_tblShipping]
ON [dbo].[tblOrders]
    ([ShippingNoFK]);
GO

-- Creating foreign key on [StaffIDFK] in table 'tblSales'
ALTER TABLE [dbo].[tblSales]
ADD CONSTRAINT [FK_tblSales_tblStaff]
    FOREIGN KEY ([StaffIDFK])
    REFERENCES [dbo].[tblStaffs]
        ([StaffIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSales_tblStaff'
CREATE INDEX [IX_FK_tblSales_tblStaff]
ON [dbo].[tblSales]
    ([StaffIDFK]);
GO

-- Creating foreign key on [SupportID] in table 'tblConSupProds'
ALTER TABLE [dbo].[tblConSupProds]
ADD CONSTRAINT [FK_tblConSupProd_tblSupport]
    FOREIGN KEY ([SupportID])
    REFERENCES [dbo].[tblSupports]
        ([SupportIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblConSupProd_tblSupport'
CREATE INDEX [IX_FK_tblConSupProd_tblSupport]
ON [dbo].[tblConSupProds]
    ([SupportID]);
GO

-- Creating foreign key on [TaskIDFK] in table 'tblSupports'
ALTER TABLE [dbo].[tblSupports]
ADD CONSTRAINT [FK_tblSupport_tblMaintenanceTasks]
    FOREIGN KEY ([TaskIDFK])
    REFERENCES [dbo].[tblSupportTasks]
        ([TaskIDPK])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSupport_tblMaintenanceTasks'
CREATE INDEX [IX_FK_tblSupport_tblMaintenanceTasks]
ON [dbo].[tblSupports]
    ([TaskIDFK]);
GO

-- Creating foreign key on [tblComponents_ComponentID] in table 'tblComponentSupplier'
ALTER TABLE [dbo].[tblComponentSupplier]
ADD CONSTRAINT [FK_tblComponentSupplier_tblComponents]
    FOREIGN KEY ([tblComponents_ComponentID])
    REFERENCES [dbo].[tblComponents]
        ([ComponentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tblManufacturers_ManufacturerIDPK] in table 'tblComponentSupplier'
ALTER TABLE [dbo].[tblComponentSupplier]
ADD CONSTRAINT [FK_tblComponentSupplier_tblManufacturer]
    FOREIGN KEY ([tblManufacturers_ManufacturerIDPK])
    REFERENCES [dbo].[tblManufacturers]
        ([ManufacturerIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblComponentSupplier_tblManufacturer'
CREATE INDEX [IX_FK_tblComponentSupplier_tblManufacturer]
ON [dbo].[tblComponentSupplier]
    ([tblManufacturers_ManufacturerIDPK]);
GO

-- Creating foreign key on [tblAccessories_AccessoryIDPK] in table 'tblProdAccessories'
ALTER TABLE [dbo].[tblProdAccessories]
ADD CONSTRAINT [FK_tblProdAccessories_tblAccessories]
    FOREIGN KEY ([tblAccessories_AccessoryIDPK])
    REFERENCES [dbo].[tblAccessories]
        ([AccessoryIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tblProducts_ProductSerialNoPK] in table 'tblProdAccessories'
ALTER TABLE [dbo].[tblProdAccessories]
ADD CONSTRAINT [FK_tblProdAccessories_tblProducts]
    FOREIGN KEY ([tblProducts_ProductSerialNoPK])
    REFERENCES [dbo].[tblProducts]
        ([ProductSerialNoPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProdAccessories_tblProducts'
CREATE INDEX [IX_FK_tblProdAccessories_tblProducts]
ON [dbo].[tblProdAccessories]
    ([tblProducts_ProductSerialNoPK]);
GO

-- Creating foreign key on [tblComponents_ComponentID] in table 'tblProductComponents'
ALTER TABLE [dbo].[tblProductComponents]
ADD CONSTRAINT [FK_tblProductComponents_tblComponents]
    FOREIGN KEY ([tblComponents_ComponentID])
    REFERENCES [dbo].[tblComponents]
        ([ComponentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tblProducts_ProductSerialNoPK] in table 'tblProductComponents'
ALTER TABLE [dbo].[tblProductComponents]
ADD CONSTRAINT [FK_tblProductComponents_tblProducts]
    FOREIGN KEY ([tblProducts_ProductSerialNoPK])
    REFERENCES [dbo].[tblProducts]
        ([ProductSerialNoPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductComponents_tblProducts'
CREATE INDEX [IX_FK_tblProductComponents_tblProducts]
ON [dbo].[tblProductComponents]
    ([tblProducts_ProductSerialNoPK]);
GO

-- Creating foreign key on [tblStaffs_StaffIDPK] in table 'tblStaffTeam'
ALTER TABLE [dbo].[tblStaffTeam]
ADD CONSTRAINT [FK_tblStaffTeam_tblStaff]
    FOREIGN KEY ([tblStaffs_StaffIDPK])
    REFERENCES [dbo].[tblStaffs]
        ([StaffIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tblTeams_TeamIDPK] in table 'tblStaffTeam'
ALTER TABLE [dbo].[tblStaffTeam]
ADD CONSTRAINT [FK_tblStaffTeam_tblTeam]
    FOREIGN KEY ([tblTeams_TeamIDPK])
    REFERENCES [dbo].[tblTeams]
        ([TeamIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStaffTeam_tblTeam'
CREATE INDEX [IX_FK_tblStaffTeam_tblTeam]
ON [dbo].[tblStaffTeam]
    ([tblTeams_TeamIDPK]);
GO

-- Creating foreign key on [tblSupports_SupportIDPK] in table 'tblSupportTeam'
ALTER TABLE [dbo].[tblSupportTeam]
ADD CONSTRAINT [FK_tblSupportTeam_tblSupport]
    FOREIGN KEY ([tblSupports_SupportIDPK])
    REFERENCES [dbo].[tblSupports]
        ([SupportIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tblTeams_TeamIDPK] in table 'tblSupportTeam'
ALTER TABLE [dbo].[tblSupportTeam]
ADD CONSTRAINT [FK_tblSupportTeam_tblTeam]
    FOREIGN KEY ([tblTeams_TeamIDPK])
    REFERENCES [dbo].[tblTeams]
        ([TeamIDPK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSupportTeam_tblTeam'
CREATE INDEX [IX_FK_tblSupportTeam_tblTeam]
ON [dbo].[tblSupportTeam]
    ([tblTeams_TeamIDPK]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------