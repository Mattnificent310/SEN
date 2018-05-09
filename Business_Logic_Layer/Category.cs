using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Category
    {
        private int categoryId;
        private string categoryName;
        private string categoryDesc;
        DataHandler dh;
        public static List<Category> cats;

        public int CategoryId { get { return categoryId; } set { categoryId = value; } }
        public string CategoryName { get { return categoryName; } set { categoryName = value; } }
        public string CategoryDesc { get { return categoryDesc; } set { categoryDesc = value; } }

        public Category()
        {
            dh = new DataHandler();
            cats = new List<Category>();
            foreach (DataRow item in dh.GetData("tblCategory").Rows)
            {
                cats.Add(new Category
                (
                    (int)item["CategoryIDPK"],
                    item["CategoryName"].ToString(),
                    item["CategoryDescription"].ToString()
                )
                );
            }
        }
        public Category(int catId, string catName, string catDesc)
        {
            this.CategoryId = catId;
            this.CategoryName = catName;
            this.CategoryDesc = catDesc;
        }
        public Category(string catName)
        {
            dh = new DataHandler();
            this.categoryId = (int)dh.SearchByName("tblCategory", "CategoryName", catName)[0];
            this.categoryName = catName;
            this.CategoryDesc = dh.SearchByName("tblCategory", "CategoryName", catName)["categoryDescription"] as string;
        }
    }
}
