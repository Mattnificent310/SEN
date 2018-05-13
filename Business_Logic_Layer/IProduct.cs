using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface IProduct
    {
        bool Insert(Product prod);
        bool Update(Product prod);
        bool Delete(int prodId);
    }
}
