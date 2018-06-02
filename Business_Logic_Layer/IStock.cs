using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface IStock
    {
        int? Insert(Inventory inv);
        bool Update(Inventory inv);
        bool DeleteStock(int invId);
    }
}
