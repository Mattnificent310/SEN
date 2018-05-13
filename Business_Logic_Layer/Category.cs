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
    public class Category
    {
        private int categoryId;
        private string categoryName;
        private string categoryDesc;
        private DataHandler dh;
        public static List<Category> cats;
        private Dictionary<string, object> values;

        public int CategoryId { get { return categoryId; } set { categoryId = value; } }
        public string CategoryName { get { return categoryName; } set { categoryName = value; } }
        public string CategoryDesc { get { return categoryDesc; } set { categoryDesc = value; } }

        public Category()
        {
            dh = new DataHandler();
            cats = new List<Category>();
            foreach (DataRow item in dh.GetData(Cons.table7).Rows)
            {
                cats.Add(new Category
                (
                    (int)item[Cons.table7Id],
                    item[Cons.table7Col1].ToString(),
                    item[Cons.table7Col2].ToString()
                )
                );
            }
        }
        public Category(string cons)
        {
            dh = new DataHandler(cons);
        }
        public Category(int catId, string catName, string catDesc)
        {
            this.CategoryId = catId;
            this.CategoryName = catName;
            this.CategoryDesc = catDesc;
        }
        #region Indexer
        public Category this[int? catId = null, string catName = null, string catDesc = null]
        {
            get
            {
                if(!cats.Any())new Category();

                foreach (var item in cats)
                {
                    if (item.CategoryId == (catId ?? item.CategoryId)
                    && item.CategoryName == (catName ?? item.CategoryName)
                    && item.CategoryDesc == (catDesc ?? item.CategoryDesc))
                    {
                        this.CategoryId = item.CategoryId;
                        this.CategoryName = item.CategoryName;
                        this.CategoryDesc = item.CategoryDesc;
                        return (Category)item;
                    }
                    
                }
                throw new KeyNotFoundException();
            }
        }


        #endregion
    }
}
