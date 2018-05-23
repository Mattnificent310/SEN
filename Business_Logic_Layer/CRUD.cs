using Data_Access_;
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
            return new Client(0).Insert(client);
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
            return new Staff().Insert(staff);
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
            return new Product().Insert(prod);
        }
        public static bool UpdateProduct(Product prod)
        {
            return new Product().Update(prod);
        }
        public static bool DeleteProduct(int prodId)
        {
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
            return new Inventory().Delete(invId);
        }
        #endregion

        #region Sale
        public static bool InsertSale(Sale sale)
        {
            return false;
        }
        #endregion
    }
}
