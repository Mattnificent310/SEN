using Data_Access_;
using System;
using System.Collections.Generic;

namespace Business_Logic_Layer
{
    enum SalesProcess
    {
        Initiated,


    }
    public class Sale :Staff, ISale
    {
        private Guid salesNumber;
        private string salesType;
        private DateTime salesDate;

        public Guid SalesNumber
        {
            get
            {
                return salesNumber;
            }

            set
            {
                salesNumber = value;
            }
        }

        public string SalesType
        {
            get
            {
                return salesType;
            }

            set
            {
                salesType = value;
            }
        }

        public DateTime SalesDate
        {
            get
            {
                return salesDate;
            }

            set
            {
                salesDate = value;
            }
        }
        public Sale()
        {

        }
        public Sale(string _salesType, DateTime _salesDate)
        {
            salesNumber = Guid.NewGuid();
            salesType = _salesType;
            SalesDate = _salesDate;
        }
        public bool ProcessSale()
        {
            throw new System.NotImplementedException();
        }
        protected override bool Equals(object obj)
        {
            return obj == null || !(obj is Sale) ? false : SalesType.Equals(((Sale)obj).SalesType);
        }

        protected override int GetHashCode()
        {
            return SalesType.GetHashCode();
        }

        protected override string ToString()
        {
            return string.Format(SalesNumber.ToString(), SalesType, SalesDate.ToShortDateString());
        }

        #region CRUD
        public bool Insert(Sale sale)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add(Cons.table11Col1, sale.SalesType);
            values.Add(Cons.table11Col2, sale.SalesDate);
            values.Add(Cons.table11IdFk1, Identity);
            values.Add(Cons.table11IDFk2, Contract.ContractID);
            return true;

        }

        public bool Update(Sale sale)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int saleId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}