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
        private string key;
        public static List<Inventory> stocks;
        private static DataHandler dh = new DataHandler();
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
                warehouse = string.IsNullOrEmpty(value) ? "1001" : value.Trim();
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
                unitsInStock = value < 1 ? 1 : value;
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
                reorderLevel = value < 0 ? 10 : value;
            }
        }

        public Inventory()
        {
            stocks = new List<Inventory>();
            foreach (DataRow item in DataHandler.GetData(Cons.table8).Rows)
            {
                stocks.Add(new Inventory
                ((int)item[Cons.table8Id],
                item[Cons.table8Col1] as string,
                (int)item[Cons.table8Col2],
                (int)item[Cons.table8Col3],
                item[Cons.table8IdFk].ToString()
                ));
            }


        }
        public Inventory(string cons)
        {
            dh = new DataHandler(cons);
        }
        public Inventory(int invId, string _warehouse, int _units, int _reorder, string prodId)
        {
            this.InventoryID = invId;
            this.Warehouse = _warehouse;
            this.UnitsInStock = _units;
            this.ReorderLevel = _reorder;
            this.key = prodId;
        }
        #region Indexer
        public Inventory this[string prodId, int? invId = null, string warehouse = null, int? stock = null, int? reorder = null]
        {
            get
            {
                foreach (var item in stocks)
                {
                    if (item.key == (prodId ?? item.key)
                    && item.Warehouse == (warehouse ?? item.Warehouse)
                    && item.UnitsInStock == (stock ?? item.UnitsInStock)
                    && item.ReorderLevel == (reorder ?? item.ReorderLevel))
                    {
                        this.InventoryID = item.InventoryID;
                        this.UnitsInStock = item.UnitsInStock;
                        this.Warehouse = item.Warehouse;
                        this.ReorderLevel = item.ReorderLevel;
                        this.key = item.key;
                        return (Inventory)item;
                    }
                }
                return new Inventory((int)Insert(new Inventory(0, warehouse, stock ?? 10, reorder ?? 1, key)),warehouse, stock ?? 1,reorder ?? 1, key);
                throw new KeyNotFoundException();
            }
        }


        #endregion

        #region CRUD
        public int? Insert(Inventory inv)
        {
            return (int?)dh.Insert(new Dictionary<string, object>
            {
                { Cons.table8Col1, inv.Warehouse},
                { Cons.table8Col2, inv.UnitsInStock},                
                { Cons.table8Col3, inv.ReorderLevel},
                { Cons.table8IdFk, inv.key }
            },Cons.table8);
        }
        public bool Update(Inventory inv)
        {
            return dh.Update(new Dictionary<string, object>
            {
                { Cons.table8Col1, inv.Warehouse },
                { Cons.table8Col2, inv.UnitsInStock },
                { Cons.table8Col3, inv.ReorderLevel },
                { Cons.table8IdFk, inv.key }
            }, inv.InventoryID.ToString(), Cons.table8);            
        }

        public bool DeleteStock(int invId)
        {
            return dh.Delete(invId.ToString(), Cons.table8);
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
