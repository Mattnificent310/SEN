using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface IStaff
    {
        int? Insert(Staff staff);
        bool Update(Staff staff);
        bool Delete(int staffId);
    }
}
