using System;

namespace Business_Logic_Layer
{
    enum SalesProcess
    {
        Initiated,


    }
    public class Sale
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
        public override bool Equals(object obj)
        {
            return obj == null || !(obj is Sale) ? false : SalesType.Equals(((Sale)obj).SalesType);
        }

        public override int GetHashCode()
        {
            return SalesType.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(SalesNumber.ToString(), SalesType, SalesDate.ToShortDateString());
        }

    }
}