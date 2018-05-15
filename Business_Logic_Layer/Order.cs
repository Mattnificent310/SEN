using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    enum OrderProcess
    {
        Ordered,
        Pending,
        Terminated
    }
    public class Order : Sale
    {
        private Guid orderNumber;
        private string orderType;
        private DateTime orderDate;
        private string orderDetails;

        public Guid OrderNumber
        {
            get
            {
                return orderNumber;
            }

            set
            {
                orderNumber = value;
            }
        }

        public string OrderType
        {
            get
            {
                return orderType;
            }

            set
            {
                orderType = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
            }
        }

        public string OrderDetails
        {
            get
            {
                return orderDetails;
            }

            set
            {
                orderDetails = value;
            }
        }
        public Order()
        {

        }
        public Order(string _type, DateTime _date, string _details)
        {
            orderNumber = Guid.NewGuid();
            orderDate = _date;
            OrderType = _type;
            orderDetails = _details;
        }
    }
}
