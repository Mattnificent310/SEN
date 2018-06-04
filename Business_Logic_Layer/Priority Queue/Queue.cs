using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public abstract class Queue<T> : IQueue<T>, System.Collections.Generic.IEnumerable<T>
    {
        public Queue() : base() { }

        public abstract int Count { get; }

        public virtual bool Empty
        {
            get { return Count == 0; }
        }

        public abstract T this[int index] { get; }

        public abstract T Dequeue();

        public abstract void Enqueue(T element);

        public virtual void Merge(IQueue<T> queue)
        {
            if (queue == null) return;
            while (!queue.Empty)
                Enqueue(queue.Dequeue());
        }

        public virtual System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index <= Count; index++)
                yield return this[index];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
