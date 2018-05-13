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
    public class Product
    {
        private int productID;
        private string productType;
        private string productModel;
        private string productDetail;
        private decimal unitPrice;
        private int inStock;
        private bool discontinued;
        private static DataHandler dh;
        public static List<Product> prods;
        private static Inventory inv;
        private static Category cat;


        public int ProductID { get { return productID; } set { productID = value; } }
        public string ProductType { get { return productType; } set { productType = value; } }
        public string ProductDetail { get { return productDetail; } set { productDetail = value; } }
        public string ProductModel { get { return productModel; } set { productModel = value; } }
        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
        public int InStock { get { return inStock; } set { inStock = value; } }
        public bool Discontinued { get { return discontinued; } set { discontinued = value; } }



        public Product()
        {
            cat = new Category();
            inv = new Inventory();
            dh = new DataHandler();
            prods = new List<Product>();
            foreach (DataRow item in dh.GetData(Cons.table2).Rows)
            {
                prods.Add(new Product(
                (int)item[Cons.table2Id],
                 cat[(int)item[Cons.table2IdFk2]].CategoryName,
                item[Cons.table2Col1].ToString(),
                item[Cons.table2Col2].ToString(),
                (decimal)item[Cons.table2Col3],
                 inv[(int)item[Cons.table2IdFk1]].UnitsInStock,
                 (bool)item[Cons.table2Col4]));
            }
        }
        public Product(string cons)
        {
            dh = new DataHandler(cons);
        }
        public Product(int id, string type, string model, string detail, decimal price, int inStock, bool discontinued)
        {
            this.ProductID = id;
            this.ProductType = type;
            this.ProductModel = model;
            this.ProductDetail = detail;
            this.UnitPrice = price;
            this.InStock = inStock;
            this.Discontinued = discontinued;
        }
        #region Indexer
        public Product this[int? prodId = null, string model = null, string desc = null, decimal? price = null, bool? discon = null]
        {
            get
            {
                new Inventory();
                foreach (var item in prods)
                {
                    if (item.ProductID == (prodId ?? item.ProductID)
                    && item.ProductModel == (model ?? item.ProductModel)
                    && item.ProductDetail == (desc ?? item.ProductDetail)
                    && item.UnitPrice == (price ?? item.UnitPrice)
                    && item.Discontinued == (discon ?? item.Discontinued))
                    {
                        this.ProductID = item.ProductID;
                        this.ProductModel = item.ProductModel;
                        this.ProductDetail = item.ProductDetail;
                        this.UnitPrice = item.UnitPrice;
                        this.Discontinued = item.Discontinued;
                        return (Product)item;
                    }
                }
                throw new KeyNotFoundException();
            }
        }


        #endregion

        public static bool Insert(Product prod, Category cat, Inventory inv)
        {
            new Product(Cons.table2);
            Dictionary<string, object> items = new Dictionary<string, object>();
            items.Add(Cons.table2Col1, prod.ProductModel);
            items.Add(Cons.table2Col2, prod.ProductDetail);
            items.Add(Cons.table2Col3, prod.UnitPrice);
            items.Add(Cons.table2Col4, prod.Discontinued);
            items.Add(Cons.table2IdFk1, inv.InventoryID);
            items.Add(Cons.table2IdFk2, cat.CategoryId);
            return dh.Insert(items) != null ? true : false;
        }

        public static bool Update(Product prod)
        {
            new Product(Cons.table2);
            Dictionary<string, object> items = new Dictionary<string, object>();
            items.Add(Cons.table2Col1, prod.ProductModel);
            items.Add(Cons.table2Col2, prod.ProductDetail);
            items.Add(Cons.table2Col3, prod.UnitPrice);
            items.Add(Cons.table2Col4, prod.Discontinued);
            return dh.Update(items, prod.ProductID.ToString());
        }

        public static bool Delete(string prodId)
        {
            new Product(Cons.table2);
            return dh.Delete(prodId);
        }
    }

}
