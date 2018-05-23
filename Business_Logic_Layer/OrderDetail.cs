using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class OrderDetail : Order
    {
        #region Fields
        private int orderDetailId;
        private int productId;
        private int configId;
        private int quantity;
        private decimal total;
        private double discount;
        #endregion

        #region Properties
        public int OrderDetailId { get { return orderDetailId; } set { orderDetailId = value; } }
        public int ProductId { get { return productId; } set { productId = value; } }
        public int ConfigId { get { return configId; } set { configId = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public decimal Total { get { return total; } set { total = value; } }
        public double Discount { get { return discount; } set { discount = value; } }
        #endregion

        #region Constructor
        public OrderDetail(int id, int prodId, int configId, int quantity, decimal total, double discount)
        {
            this.OrderDetailId = id;
            this.ProductId = prodId;
            this.ConfigId = configId;
            this.Quantity = quantity;
            this.Total = total;
            this.Discount = discount;
        }
        #endregion
    }
}
