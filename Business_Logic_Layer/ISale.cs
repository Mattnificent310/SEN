using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface ISale
    {
        int Insert(Sale sale);
        bool Update(Sale sale);
        bool Delete(int saleId);
    }
}
