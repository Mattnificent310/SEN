using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer
{
    public class Product
    {
        private int productID;
        private string productModel;
        private string productDetail;
        private decimal unitPrice;
        private bool discontinued;
        private static DataHandler dh;
        public static List<Product> prods;

        public int ProductID { get { return productID; } set { productID = value; } }
        public string ProductModel { get { return productModel; } set { productModel = value; } }
        public string ProductDetail { get { return productDetail; } set { productDetail = value; } }
        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
        public bool Discontinued { get { return discontinued; } set { discontinued = value; } }

        public Product()
        {
            dh = new DataHandler();
            prods = new List<Product>();
            foreach (DataRow item in dh.GetData("tblProducts").Rows)
            {
                prods.Add(new Product(
                (int)item["ProductNoPK"],
                item["ProductModel"].ToString(),
                item["ProductDetail"].ToString(),
                (decimal)item["UnitPrice"],
                (bool)item["Discontinued"]));
            }

        }
        public Product(int id, string model, string detail, decimal price, bool discontinued)
        {
            this.ProductID = id;
            this.ProductModel = model;
            this.ProductDetail = detail;
            this.UnitPrice = price;
            this.Discontinued = discontinued;
        }

        public static bool Insert(Product prod)
        {
            Dictionary<string, object> items = new Dictionary<string, object>();
            items.Add("ProductModel", prod.ProductModel);
            items.Add("ProductDetail", prod.ProductDetail);
            items.Add("UnitPrice", prod.UnitPrice);
            items.Add("Discontinued", prod.Discontinued);
            items.Add("InventoryIDFK", 1);
            items.Add("CategoryIDFK", 1);
            return dh.Insert(items, "tblProducts") != null ? true : false;
        }

        public static bool Update(Product prod)
        {
            Dictionary<string, object> items = new Dictionary<string, object>();
            items.Add("ProductModel", prod.ProductModel);
            items.Add("ProductDetail", prod.ProductDetail);
            items.Add("UnitPrice", prod.UnitPrice);
            items.Add("Discontinued", prod.Discontinued);
            return dh.Update(items, "tblProducts", prod.ProductID.ToString());
        }

        public static bool Delete(string prodId)
        {
            return dh.Delete("tblProducts", prodId);
        }
    }

}
