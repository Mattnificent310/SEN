using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_;
using Data_Access_Layer;
using DataAccessLayer;

namespace Business_Logic_Layer
{
    public class Product : IProduct
    {
        private string serialNo;
        private string productType;
        private string productModel;
        private string productName;
        private decimal unitPrice;
        private int inStock;
        private bool discontinued;
        private static DataHandler dh = new DataHandler(Cons.table2);
        public static List<Product> prods;
        private int p1;
        private string p2;
        private string p3;
        private decimal p4;
        private int p5;
        private bool p6;


        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
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

         
            prods = new List<Product>();
            foreach (DataRow item in DataHandler.GetData(Cons.table2).Rows)
            { 
                DataRow row = new StoredProcedure().GetProcs("sp_GetStockByProduct", new Dictionary<string, object>
            {
               { "ProductId", item[Cons.table2Id] }
            }).Rows[0];
                prods.Add(new Product(
                string.Format("{0}{1}{2}{3}", "SHS", item[Cons.table2Col2].ToString().Split(' ')[0], item[Cons.table2Id].ToString().PadLeft(2, '0'), item[Cons.table2Id].ToString().PadLeft(3, '0')),
                 new Category()[(int)item[Cons.table2IdFk1]].CategoryName,
                item[Cons.table2Col1].ToString(),
                item[Cons.table2Col2].ToString(),
                (decimal)item[Cons.table2Col3],
                 (int)row[0],
                 (bool)item[Cons.table2Col4]));
            }
        }
        public Product(string cons)
        {
            dh = new DataHandler(cons);
        }
        public Product(string serial, string type, string model, string name, decimal price, int inStock, bool discontinued)
        {
            this.SerialNo = serial;
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
        public Product this[string prodId = null, string prodType = null, string model = null, string name = null, decimal? price = null, bool? discon = null]
        {
            get
            {
                new Inventory();
                foreach (var item in prods)
                {
                    if ((item.SerialNo == (prodId ?? item.SerialNo))
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
            return (int?)dh.Insert(new Dictionary<string, object>
            {
                { Cons.table2Col1, prod.ProductModel },
                { Cons.table2Col2, prod.ProductName },
                { Cons.table2Col3, prod.UnitPrice },
                { Cons.table2Col4, prod.Discontinued },
                { Cons.table2IdFk1, new Category()[null, prod.ProductType].CategoryId 
                }
            }, Cons.table2);

        }

        public bool Update(Product prod)
        {
            int catId = new Category()[null, prod.ProductType].CategoryId;
            
            return dh.Update(new Dictionary<string, object>
            {
                { Cons.table2Col1, prod.ProductModel },
                { Cons.table2Col2, prod.ProductName },
                { Cons.table2Col3, prod.UnitPrice },
                { Cons.table2Col4, prod.Discontinued },
                { Cons.table2IdFk1, catId }
            }, int.Parse(prod.SerialNo.Substring(prod.SerialNo.Length - 3)).ToString(), Cons.table2);

        }

        public bool Delete(int prodId)
        {
            new Product(Cons.table2);
            return dh.Delete(prodId.ToString(), Cons.table2);
        }
    }

}
