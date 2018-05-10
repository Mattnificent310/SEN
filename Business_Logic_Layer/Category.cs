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
            new Category(Cons.table7);
            cats = new List<Category>();
            foreach (DataRow item in dh.GetData().Rows)
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
        public Category this[int catId = 0, string catName = null, string catDesc = null]
        {
            get
            {
                new Category();
                foreach (var item in cats)
                {
                    if (item.CategoryId == (catId != 0 ? catId : item.CategoryId)
                    && item.CategoryName == (catName != null ? catName : item.CategoryName)
                    && item.CategoryDesc == (catDesc != null ? catDesc : item.CategoryDesc))
                    {
                        return (Category)item;
                    }
                    
                }
                throw new KeyNotFoundException();
            }
        }


        #endregion
    }
}
