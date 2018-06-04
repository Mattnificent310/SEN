using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    interface IPriorityQueue<T> : IQueue<T>
    {
        int DefaultPriority { get; set; }
        void Enqueue(int Priority, T Element);
        bool Ascending { get; }
    }
}
