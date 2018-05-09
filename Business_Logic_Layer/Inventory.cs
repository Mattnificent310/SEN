﻿using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    class Inventory
    {
        private int inventoryID;
        private string warhouse;
        private int unitsInStock;
        private int reorderLevel;
        public static List<Inventory> stocks;
        DataHandler dh;

        public int InventoryID
        {
            get
            {
                return inventoryID;
            }
            set
            {
                inventoryID = value;
            }
        }

        public string Warhouse
        {
            get
            {
                return warhouse;
            }

            set
            {
                warhouse = value;
            }
        }

        public int UnitsInStock
        {
            get
            {
                return unitsInStock;
            }

            set
            {
                unitsInStock = value;
            }
        }

        public int ReorderLevel
        {
            get
            {
                return reorderLevel;
            }

            set
            {
                reorderLevel = value;
            }
        }

        public Inventory()
        {
            stocks = new List<Inventory>();
            dh = new DataHandler();
            foreach (DataRow item in dh.GetData("tblInventory").Rows)
            {
                stocks.Add(new Inventory
                ((int)item["InventoryIDPK"],
                item["WarehouseNo"] as string,
                (int)item["UnitsInStock"],
                (int)item["ReorderLevel"]
                ));
            }
        }
        
        public Inventory(int invId, string _warehouse, int _units, int _reorder)
        {
            this.InventoryID = invId;
            this.Warhouse = _warehouse;
            this.UnitsInStock = _units;
            this.ReorderLevel = _reorder;
        }

        #region Methods
        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}
