using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface IContract
    {
        int? InsertContract(Contract contract);
        bool UpdateContract(Contract contract);
        bool DeleteContract(int contractId);
    }
}
