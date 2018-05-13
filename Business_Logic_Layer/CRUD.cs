﻿using System;
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
            return new Client().Insert(client);
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
    }
}