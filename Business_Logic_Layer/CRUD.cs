using Data_Access_;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class CRUD
    {
        #region Client
        public static bool InsertClient(Client client)
        {
            return new Client().Insert(client) != null? true : false;
        }

        public static bool UpdateClient(Client client)
        {
            return new Client().Update(client);
        }

        public static bool DeleteClient(int clientId)
        {
            return new Client().Delete(clientId);
        }
        #endregion

        #region Staff
        public static Staff Login(string username, string password)
        {
            return new Staff().Login(username, password);
        }
        public static bool InsertStaff(Staff staff)
        {
            return new Staff().Insert(staff)!=null ? true : false;
        }
        public static bool UpdateStaff(Staff staff)
        {
            return new Staff().Update(staff);
        }
        public static bool DeleteStaff(int staffId)
        {
            return new Staff().Delete(staffId);
        }
        #endregion

        #region Products
        public static bool InsertProduct(Product prod)
        {
            new Product().Insert(prod);
            var prodId = (int?)new StoredProcedure().SelectProcedure("sp_GetLastInsert").Rows[0][0];
            var inv = new Inventory(0, "1001", prod.InStock, 10, prodId.ToString());
            new Inventory().Insert(inv);
            return prodId != null && inv != null ? true : false;
        }
        public static bool UpdateProduct(Product prod)
        {
            return new Product().Update(prod);
        }
        public static bool DeleteProduct(int prodId)
        {
            var inv = new Inventory()[prodId.ToString()];
            inv.DeleteStock(inv.InventoryID);
            return new Product().Delete(prodId);
        }        
        #endregion

        #region Inventory
        public static bool InsertInventory(Inventory inv)
        {
            return new Inventory().Insert(inv) == null ? false : true;
        }

        public static bool UpdateInventory(Inventory inv)
        {
            return new Inventory().Update(inv);
        }

        public static bool DeleteInventory(int invId)
        {
            return new Inventory().DeleteStock(invId);
        }
        #endregion

        #region Sale
        public static bool InsertSale(Sale sale)
        {
            return false;
        }
        #endregion

        #region CallLog
        public static bool InsertCall(Call call)
        {
            return new Call().InsertCall(call) == null ? false : true;
        }
        #endregion

        #region Contract
        public static bool InsertContract(Contract contract)
        {
            return new Contract().InsertContract(contract) == null ? false : true;
        }
        public static bool UpdateContract(Contract contract)
        {
            return new Contract().UpdateContract(contract);
        }
        public bool DeleteContract(int contractId)
        {
            return new Contract().DeleteContract(contractId);
        }
        #endregion
    }
}
