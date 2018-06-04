using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IQueue<T>
    {
        int Count { get; }
        bool Empty { get; }

        T this[int index] { get; }

        T Dequeue();
        void Enqueue(T element);
        void Merge(IQueue<T> queue);
    }

    
}
