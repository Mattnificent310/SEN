using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface ICall
    {
        int? InsertCall(Call call);
        bool UpdateCall(Call call);
        bool DeleteCall(int callId);
    }
}
