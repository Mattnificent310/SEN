using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_
{
    public class Cons
    {
        #region Clients
        public const string table1 = "tblClients",
                            table1Id = "ClientIDPK",
                            table1Col1 = "ClientTitle",
                            table1Col2 = "ClientName",
                            table1Col3 = "ClientSurname",
                            table1Col4 = "ClientDOB",
                            table1Col5 = "ClientGender",
                            table1Col6 = "ClientPhone",
                            table1Col7 = "ClientEmail",
                            table1Col8 = "ContactMethod",
                            table1Col9 = "ClientStatus",
                            table1Col10 = "CreditStatus",
                            table1IdFk = "LocationIDFK";
        #endregion

        #region Products

        public const string table2 = "tblProducts",
                            table2Id = "ProductSerialPK",
                            table2Col1 = "ProductModel",
                            table2Col2 = "ProductDetail",
                            table2Col3 = "UnitPrice",
                            table2Col4 = "Discontinued",
                            table2IdFk1 = "CategoryIDFK",
                            table2IdFk2 = "InventoryIDFK";
        #endregion

        #region Staff
        public const string table3 = "tblStaffs",
                            table3Id = "StaffIDPK",
                            table3Col1 = "StaffTitle",
                            table3Col2 = "StaffName",
                            table3Col3 = "StaffSurname",
                            table3Col4 = "StaffDOB",
                            table3Col5 = "StaffGender",
                            table3Col6 = "StaffPhone",
                            table3Col7 = "StaffEmail",
                            table3IdFk1 = "JobDescIDFK",
                            table3IdFk2 = "LocationIDFK";
        #endregion

        #region Location
        public const string table4 = "tblLocations",
                            table4Id = "LocationIDPK",
                            table4Col1 = "StreetAddress",
                            table4Col2 = "SuburbAddress",
                            table4IdFk = "CityIDFK";
        #endregion

        #region City
        public const string table5 = "tblCities",
                            table5Id = "CityIDPK",
                            table5Col1 = "CityName",
                            table5Col2 = "CityCode",
                            table5Col3 = "StateCode",
                            table5IdFk = "CountryIDFK";
        #endregion

        #region Country
        public const string table6 = "tblCountries",
                            table6Id = "CountryIDPK",
                            table6Col1 = "CountryName",
                            table6Col2 = "CountryCode";
        #endregion

        #region Category
        public const string table7 = "tblCategories",
                            table7Id = "CategoryIDPK",
                            table7Col1 = "CategoryName",
                            table7Col2 = "CategoryDescription";
        #endregion

        #region Inventory
        public const string table8 = "tblInventories",
                            table8Id = "InventoryIDPK",
                            table8Col1 = "WarehouseNo",
                            table8Col2 = "UnitsInStock",
                            table8Col3 = "ReorderLevel";
        #endregion

        #region Job
        public const string table9 = "tblJobs",
                            table9Id = "JobIDPK",
                            table9Col1 = "JobDescription",
                            table9Col2 = "JobSalary",
                            table9Col3 = "HireDate",
                            table9Col4 = "JobDetails";
        #endregion
        #region Accounts
        public const string table10 = "tblAccounts",
                            table10Id = "AccountIDPK",
                            table10Col1 = "Username",
                            table10Col2 = "Password",
                            table10Col3 = "Department",
                            table10IDFk = "StaffIDFK";
        #endregion

        #region Sales
        public const string table11 = "tblSales",
                            table11Id = "SalesIDPK",
                            table11Col1 = "SalesType",
                            table11Col2 = "SalesDate",
                            table11IDFK1 = "StaffIDFK",
                            table11IDFk2 = "ContractIDFK";


        #endregion

        #region Contracts
        public const string table12 = "tblContracts",
                            table12Id = "ContractID",
                            table12Col1 = "ContractLevel",
                            table12Col2 = "ContracType",
                            table12Col3 = "ContractDateIssued",
                            table12Col4 = "ContractTerm",
                            table12IdFk = "ClientIDFK";
        #endregion

        #region Orders
        public const string table13 = "tblOrders",
                           table13Id = "OrderIDPK",
                           table13Col1 = "OrderDate",
                           table13Col2 = "OrderDetails",
                           table13Col3 = "RequiredDate",
                           table13IDFk1 = "SalesIDFK";
        #endregion

        #region Order_Details
        public const string table14 = "tblOrderDetails",
                            table14Id = "OrderDetIDPK",
                            table14IdFk1 = "OrderID",
                            table14IdFk2 = "ProductID",
                            table14IdFk3 = "CofigID",
                            table14Col1 = "Quantity",
                            table14Col2 = "Total",
                            table14Col3 = "Discount";
        #endregion

        #region Offers
        public const string table15 = "tblOffers",
                            table15Id = "OfferIDPK",
                            table15Col1 = "OfferDate",
                            table15Col2 = "OrderDetails",
                            table15Col3 = "RequiredDate",
                            table15IDFk1 = "SalesIDFK";
        #endregion

        #region Configurations

        public const string table16 = "tblConfigurations",
                            table16Id = "ConfigIDPK",
                            table16Col1 = "ConfigCriteria",
                            table16Col2 = "ConfigType",
                            table16Col3 = "ConfigDetails";
        #endregion

      
    }
}
