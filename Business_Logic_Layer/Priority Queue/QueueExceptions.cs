using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class QueueException : System.Exception
    {
        public QueueException(string message) : base(message) { }
    }

    public class QueueUnderflowException : QueueException
    {
        public QueueUnderflowException() : base("Queue is empty. Cannot dequeue elements.") { }
    }

    public class QueueElementNotFoundException : QueueException
    {
        public QueueElementNotFoundException() : base("No element at requested position in queue.") { }
        public QueueElementNotFoundException(int position) : base("No element at position " + position + " in queue.") { }
    }
}
