namespace BusinessLogicLayer
{
    public class PriorityQueue<T> : IPriorityQueue<T>, System.Collections.Generic.IEnumerable<T>
    {
        private bool ascending;
        private int defaultPriority;
        private System.Collections.Generic.SortedDictionary<int, Queue<T>> queues;

        public PriorityQueue() : base()
        {
            queues = new System.Collections.Generic.SortedDictionary<int, Queue<T>>();
        }

        public PriorityQueue(int defaultPriority) : this()
        {
            DefaultPriority = defaultPriority;
        }

        public PriorityQueue(int defaultPriority, bool ascending) : this(defaultPriority)
        {
            Ascending = ascending;
        }

        public bool Ascending
        {
            get { lock (queues) { return ascending; } }
            private set { ascending = value; }
        }

        public virtual int Count
        {
            get
            {
                lock (queues)
                {
                    int count = 0;
                    foreach (Queue<T> queue in queues.Values)
                        count += queue.Count;
                    return count;
                }
            }
        }

        public int DefaultPriority
        {
            get { lock (queues) { return defaultPriority; } }
            set { lock (queues) { defaultPriority = value; } }
        }

        public virtual bool Empty
        {
            get
            {
                lock (queues)
                {
                    foreach (Queue<T> queue in queues.Values)
                        if (!queue.Empty) return false;
                    return true;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                lock (queues)
                {
                    if (index < 0) throw new QueueElementNotFoundException(index);
                    foreach (Queue<T> queue in queues.Values)
                        if (index < queue.Count)
                            return queue[index];
                        else
                            index -= queue.Count;
                    throw new QueueElementNotFoundException(index);
                }
            }
        }

        public virtual T Dequeue()
        {
            lock (queues)
            {
                foreach (Queue<T> queue in queues.Values)
                    if (!queue.Empty) return queue.Dequeue();
                throw new QueueUnderflowException();
            }
        }

        public void Enqueue(T element)
        {
            lock (queues)
            {
                Enqueue(DefaultPriority, element);
            }
        }

        public virtual void Enqueue(int priority, T element)
        {
            lock (queues)
            {
                if (!Ascending) priority = -priority;
                Queue<T> queue;
                if (!queues.TryGetValue(priority, out queue))
                    queues[priority] = queue = new LinkedQueue<T>();
                queue.Enqueue(element);
            }
        }

        public void Merge(IQueue<T> queue)
        {
            if (queue == null) return;
            lock (queues)
            {
                lock (queue)
                {
                    Merge(DefaultPriority, queue);
                }
            }
        }

        public virtual void Merge(int priority, IQueue<T> queue)
        {
            if (queue == null) return;
            lock (queues)
            {
                lock (queue)
                {
                    while (!queue.Empty)
                        Enqueue(priority, queue.Dequeue());
                }
            }
        }

        public virtual System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            lock (queues)
            {
                foreach (Queue<T> queue in queues.Values)
                    foreach (T element in queue)
                        yield return element;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
