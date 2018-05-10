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
    public class Inventory
    {
        private int inventoryID;
        private string warehouse;
        private int unitsInStock;
        private int reorderLevel;
        public static List<Inventory> stocks;
        private DataHandler dh;
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
            new Inventory(Cons.table8);
            stocks = new List<Inventory>();
            foreach (DataRow item in dh.GetData().Rows)
            {
                stocks.Add(new Inventory
                ((int)item[Cons.table8Id],
                item[Cons.table8Col1] as string,
                (int)item[Cons.table8Col2],
                (int)item[Cons.table8Col3]
                ));
            }
            Inventory inv = new Inventory();

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
        public Inventory this[int invId = 0, string warehouse = null, int stock = 0, int reorder = 0]
        {
            get
            {
                new Inventory();
                foreach (var item in stocks)
                {
                    if (item.Warehouse == (warehouse != null ? warehouse : item.Warehouse)
                    && item.UnitsInStock == (stock != 0 ? stock : item.UnitsInStock)
                    && item.ReorderLevel == (reorder != 0 ? reorder : item.ReorderLevel))
                    {
                        return (Inventory)item;
                    }
                    else
                    {
                         values = new Dictionary<string, object>();
                        values.Add(Cons.table8Col1, warehouse);
                        values.Add(Cons.table8Col2, stock);
                        values.Add(Cons.table8Col3, reorder);
                        this.InventoryID = (int)dh.Insert(values);
                    }
                }
                throw new KeyNotFoundException();
            }
        }


        #endregion


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
