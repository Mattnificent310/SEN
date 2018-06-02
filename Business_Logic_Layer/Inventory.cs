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
    public class Inventory : Product, IStock
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
                (int)item[Cons.table8IdFk]
                ));
            }


        }
        public Inventory(string cons)
        {
            dh = new DataHandler(cons);
        }
        public Inventory(int invId, string _warehouse, int _units, int _reorder, int prodId)
        {
            this.InventoryID = invId;
            this.Warehouse = _warehouse;
            this.UnitsInStock = _units;
            this.ReorderLevel = _reorder;
            SerialNo = prodId.ToString();
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
                //return new Inventory(Insert(new Inventory(0, warehouse, stock ?? 10, reorder ?? 1, int.Parse(SerialNo.Substring(SerialNo.Length - 3)))),warehouse, stock,reorder, int.Parse(SerialNo.Substring(SerialNo.Length - 3)));
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
                { Cons.table8IdFk, SerialNo }
            },Cons.table8);
        }
        public bool Update(Inventory inv)
        {
            return dh.Update(new Dictionary<string, object>
            {
                { Cons.table8Col1, inv.Warehouse },
                { Cons.table8Col2, inv.UnitsInStock },
                { Cons.table8Col3, inv.ReorderLevel },
                { Cons.table8IdFk, SerialNo }
            }, inv.InventoryID.ToString(), Cons.table8);            
        }

        public bool DeleteStock(int invId)
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
