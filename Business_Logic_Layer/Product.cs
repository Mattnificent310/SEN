using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_;
using Data_Access_Layer;

namespace Business_Logic_Layer
{
    public class Product : IProduct
    {
        private int productID;
        private string productType;
        private string productModel;
        private string productName;
        private decimal unitPrice;
        private int inStock;
        private bool discontinued;
        private static DataHandler dh = new DataHandler(Cons.table2);
        public static List<Product> prods;
        private static Inventory inv;
        private static Category cat;
        private int p1;
        private string p2;
        private string p3;
        private decimal p4;
        private int p5;
        private bool p6;


        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string ProductModel
        {
            get { return productModel; }
            set { productModel = value; }
        }
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public int InStock
        {
            get { return inStock; }
            set { inStock = value; }
        }
        public bool Discontinued
        {
            get { return discontinued; }
            set { discontinued = value; }
        }


        public Product()
        {
            cat = new Category();
            inv = new Inventory();
            prods = new List<Product>();
            foreach (DataRow item in DataHandler.GetData(Cons.table2).Rows)
            {
                prods.Add(new Product(
                (int)item[Cons.table2Id],
                 cat[(int)item[Cons.table2IdFk1]].CategoryName,
                item[Cons.table2Col1].ToString(),
                item[Cons.table2Col2].ToString(),
                (decimal)item[Cons.table2Col3],
                 inv[(int)item[Cons.table2IdFk2]].UnitsInStock,
                 (bool)item[Cons.table2Col4]));
            }
        }
        public Product(string cons)
        {
            dh = new DataHandler(cons);
        }
        public Product(int id, string type, string model, string name, decimal price, int inStock, bool discontinued)
        {
            this.ProductID = id;
            this.ProductType = type;
            this.ProductModel = model;
            this.ProductName = name;
            this.UnitPrice = price;
            this.InStock = inStock;
            this.Discontinued = discontinued;
        }

        //private Product(int p1, string p2, string p3, decimal p4, int p5, bool p6)
        //{
        //    // TODO: Complete member initialization
        //    this.p1 = p1;
        //    this.p2 = p2;
        //    this.p3 = p3;
        //    this.p4 = p4;
        //    this.p5 = p5;
        //    this.p6 = p6;
        //}
        #region Indexer
        public Product this[int? prodId = null, string prodType = null, string model = null, string name = null, decimal? price = null, bool? discon = null]
        {
            get
            {
                new Inventory();
                foreach (var item in prods)
                {
                    if ((item.ProductID == (prodId ?? item.ProductID))
                    && (item.ProductType == (prodType ?? item.ProductType))
                    && (item.ProductModel == (model ?? item.ProductModel))
                    && (item.ProductName == (name ?? item.ProductName))
                    && (item.UnitPrice == (price ?? item.UnitPrice))
                    && (item.Discontinued == (discon ?? item.Discontinued)))
                    {
                        return (Product)item;
                    }
                }
                throw new KeyNotFoundException();
            }
        }


        #endregion

        public int? Insert(Product prod)
        {
            inv = new Inventory();
            cat = new Category();
            return (int?)dh.Insert(new Dictionary<string, object>
            {
                { Cons.table2Col1, prod.ProductModel },
                { Cons.table2Col2, prod.ProductName },
                { Cons.table2Col3, prod.UnitPrice },
                { Cons.table2Col4, prod.Discontinued },
                { Cons.table2IdFk1, cat[null, prod.ProductType].CategoryId },
                { Cons.table2IdFk2, inv[null, null, prod.InStock].InventoryID }
            },Cons.table2);
            
        }

        public bool Update(Product prod)
        {
            inv = new Inventory();
            cat = new Category();
            int catId = cat[null, prod.ProductType].CategoryId;
            int invId = inv[null, null, prod.inStock].InventoryID;
            Dictionary<string, object> items = new Dictionary<string, object>();
            items.Add(Cons.table2Col1, prod.ProductModel);
            items.Add(Cons.table2Col2, prod.ProductName);
            items.Add(Cons.table2Col3, prod.UnitPrice);
            items.Add(Cons.table2Col4, prod.Discontinued);
            items.Add(Cons.table2IdFk1, catId);
            items.Add(Cons.table2IdFk2, invId);
            new Product(Cons.table2);
            return dh.Update(items, prod.ProductID.ToString());
        }

        public bool Delete(int prodId)
        {
            new Product(Cons.table2);
            return dh.Delete(prodId.ToString());
        }
    }

}
