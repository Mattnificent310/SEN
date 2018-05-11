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
        public const string table1 = "tblClient",
                            table1Id = "ClientIDPK",
                            table1Col1 = "ClientTitle",
                            table1Col2 = "ClientName",
                            table1Col3 = "ClientSurname",
                            table1Col4 = "ClientDOB",
                            table1Col5 = "ClientGender",
                            table1Col6 = "ClientPhone",
                            table1Col7 = "ClientEmail",
                            table1IdFk = "LocationIDFK";
        #endregion

        #region Products

        public const string table2 = "tblProducts",
                            table2Id = "ProductNoPK",
                            table2Col1 = "ProductModel",
                            table2Col2 = "ProductDetail",
                            table2Col3 = "UnitPrice",
                            table2Col4 = "Discontinued",
                            table2IdFk1 = "CategoryIDFK",
                            table2IdFk2 = "InventoryIDFK";
        #endregion

        #region Staff
        public const string table3 = "tblStaff",
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
        public const string table4 = "tblLocation",
                            table4Id = "LocationIDPK",
                            table4Col1 = "StreetAddress",
                            table4Col2 = "Suburb",
                            table4IdFk = "CityIDFK";
        #endregion

        #region City
        public const string table5 = "tblCity",
                            table5Id = "CityIDPK",
                            table5Col1 = "CityName",
                            table5Col2 = "CityCode",
                            table5Col3 = "StateCode",
                            table5IdFk = "CountryIDFK";
        #endregion

        #region Country
        public const string table6 = "tblCountry",
                            table6Id = "CountryIDPK",
                            table6Col1 = "CountryName",
                            table6Col2 = "CountryCode";
        #endregion

        #region Category
        public const string table7 = "tblCategory",
                            table7Id = "CategoryIDPK",
                            table7Col1 = "CategoryName",
                            table7Col2 = "CategoryDescription";
        #endregion

        #region Inventory
        public const string table8 = "tblInventory",
                            table8Id = "InventoryIDPK",
                            table8Col1 = "WarehouseNo",
                            table8Col2 = "UnitsInStock",
                            table8Col3 = "ReorderLevel";
        #endregion

        #region Job
        public const string table9 = "tblJob",
                            table9Id = "JobIDPK",
                            table9Col1 = "JobDescription",
                            table9Col2 = "JobSalary",
                            table9Col3 = "HireDate",
                            table9Col4 = "JobDetails";
        #endregion
    }
}
