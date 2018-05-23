using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface ISale
    {
        bool Insert(Sale sale);
        bool Update(Sale sale);
        bool Delete(int saleId);
    }
}
