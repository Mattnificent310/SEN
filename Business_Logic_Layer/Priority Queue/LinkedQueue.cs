using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class LinkedQueue<T> : Queue<T>
    {
        private Node front, rear;
        private object sentinel = new object();

        public LinkedQueue() : base() { }

        public override int Count
        {
            get
            {
                lock (sentinel)
                {
                    int count = 0;
                    Node node = front;
                    while (node != null)
                    {
                        count++;
                        node = node.Successor;
                    }
                    return count;
                }
            }
        }

        public override bool Empty
        {
            get { lock (sentinel) { return front == null; } }
        }

        public override T this[int index]
        {
            get
            {
                lock (sentinel)
                {
                    if (index < 0 || index >= Count) throw new QueueElementNotFoundException(index);
                    Node node = front;
                    while (index > 0)
                    {
                        node = node.Successor;
                        index--;
                    }
                    return node.Element;
                }
            }
        }

        public override T Dequeue()
        {
            lock (sentinel)
            {
                if (Empty) throw new QueueUnderflowException();
                Node first = front;
                front = first.Successor;
                if (front == null) rear = null;
                return first.Element;
            }
        }

        public override void Enqueue(T element)
        {
            lock (sentinel)
            {
                Node last = new Node(element);
                if (Empty)
                    front = rear = last;
                else
                    rear = rear.Successor = last;
            }
        }

        public override System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            lock (sentinel)
            {
                if (Empty) yield break;
                Node node = front;
                while (node != null)
                {
                    yield return node.Element;
                    node = node.Successor;
                }
            }
        }

        private class Node
        {
            public T Element;
            public Node Successor;

            public Node(T element)
            {
                Element = element;
            }
        }
    }
}
