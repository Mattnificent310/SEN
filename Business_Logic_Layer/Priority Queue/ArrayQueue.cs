using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ArrayQueue<T> : Queue<T>
    {
        private int front, rear;
        private T[] queue;

        public ArrayQueue() : this(10) { }

        public ArrayQueue(int initialCapacity) : base()
        {
            queue = new T[initialCapacity <= 0 ? 10 : initialCapacity];
            front = rear = -1;
        }

        public override int Count
        {
            get
            {
                lock (queue)
                {
                    return Empty ? 0 : front <= rear ? rear - front + 1 : queue.Length + rear - front + 1;
                }
            }
        }

        public override bool Empty
        {
            get { lock (queue) { return front == -1; } }
        }

        public override T this[int index]
        {
            get
            {
                lock (queue)
                {
                    if (index < 0 || index >= Count) throw new QueueElementNotFoundException(index);
                    return front <= rear ? queue[front + index] : queue[queue.Length - front + index + 1];
                }
            }
        }

        public override T Dequeue()
        {
            lock (queue)
            {
                if (Empty) throw new QueueUnderflowException();
                T element = queue[front];
                if (front == rear)
                    front = rear = -1;
                else
                    front++;
                return element;
            }
        }

        public override void Enqueue(T element)
        {
            lock (queue)
            {
                if (Count == queue.Length)
                {
                    T[] newQueue = new T[queue.Length * 2];
                    if (front <= rear)
                        for (int index = front; index <= rear; index++)
                            newQueue[index - front] = queue[index];
                    else
                    {
                        for (int index = front; index <= queue.Length - 1; index++)
                            newQueue[index - front] = queue[index];
                        for (int index = 0; index <= rear; index++)
                            newQueue[queue.Length - front + index + 1] = queue[index];
                    }
                    front = 0;
                    rear = queue.Length - 1;
                    queue = newQueue;
                }
                queue[++rear] = element;
                if (front == -1) front = 0;
            }
        }

        public override System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            if (Empty) yield break;
            for (int index = 0; index < Count; index++)
                yield return this[index];
        }
    }
}
