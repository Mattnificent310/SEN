using Data_Access_;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Inventory : IStock
    {
        private int inventoryID;
        private string warehouse;
        private int unitsInStock;
        private int reorderLevel;
        public static List<Inventory> stocks;
        private static DataHandler dh;
        private Dictionary<string, object> values;

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

        public string Warehouse
        {
            get
            {
                return warehouse;
            }

            set
            {
                warehouse = value;
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
            dh = new DataHandler();
            stocks = new List<Inventory>();
            foreach (DataRow item in dh.GetData(Cons.table8).Rows)
            {
                stocks.Add(new Inventory
                ((int)item[Cons.table8Id],
                item[Cons.table8Col1] as string,
                (int)item[Cons.table8Col2],
                (int)item[Cons.table8Col3]
                ));
            }
           

        }
        public Inventory(string cons)
        {
            dh = new DataHandler(cons);
        }
        public Inventory(int invId, string _warehouse, int _units, int _reorder)
        {
            this.InventoryID = invId;
            this.Warehouse = _warehouse;
            this.UnitsInStock = _units;
            this.ReorderLevel = _reorder;
        }
        #region Indexer
        public Inventory this[int? invId = null, string warehouse = null, int? stock = null, int? reorder = null]
        {
            get
            {
                new Inventory();
                foreach (var item in stocks)
                {
                    if (item.Warehouse == (warehouse ?? item.Warehouse)
                    && item.UnitsInStock == (stock ?? item.UnitsInStock)
                    && item.ReorderLevel == (reorder ?? item.ReorderLevel))
                    {
                        this.InventoryID = item.InventoryID;
                        this.UnitsInStock = item.UnitsInStock;
                        this.Warehouse = item.Warehouse;
                        this.ReorderLevel = item.ReorderLevel;
                        return (Inventory)item;
                    }                    
                }
                throw new KeyNotFoundException();
            }
        }


        #endregion

        #region CRUD
        public int? Insert(Inventory inv)
        {
            new Inventory(Cons.table8);
            values = new Dictionary<string, object>();
            values.Add(Cons.table8Col1, inv.Warehouse);
            values.Add(Cons.table8Col2, inv.UnitsInStock);
            values.Add(Cons.table8Col3, inv.ReorderLevel);
            return (int?)dh.Insert(values);
        }
        public bool Update(Inventory inv)
        {
            new Inventory(Cons.table8);
            values = new Dictionary<string, object>();
            values.Add(Cons.table8Col1, inv.Warehouse);
            values.Add(Cons.table8Col2, inv.UnitsInStock);
            values.Add(Cons.table8Col3, inv.ReorderLevel);
            return dh.Update(values, inv.InventoryID.ToString());
        }

        public bool Delete(int invId)
        {
            return dh.Delete(invId.ToString());
        }
        #endregion

        #region Poly Methods
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
