using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface IClient
    {
        int? Insert(Client client);
        bool Update(Client client);
        bool Delete(int clientId);
    }
}
