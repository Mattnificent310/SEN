using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    #region Enums
    enum OrderProcess
    {
        Ordered,
        Pending,
        Terminated
    }
    #endregion 

    
    public class Order : Sale, IOrder
    {
        #region Fields
        private Guid orderNumber;
        private string orderType;
        private DateTime orderDate;
        private string orderDetails;
        #endregion

        #region Properties
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
        #endregion

        #region Constructors
        public Order():base()
        {

        }
        public Order(string _type, DateTime _date, string _details):this()
        {
            
            orderNumber = Guid.NewGuid();
            orderDate = _date;
            OrderType = _type;
            orderDetails = _details;
        }     
        #endregion

        #region Insert
        public bool Insert(Order order)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public bool Delete(int orderId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
