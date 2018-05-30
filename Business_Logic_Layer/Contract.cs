using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Contract : Client
    {
        #region Fields
        private static string contractID;
        private string contractType;
        private string contractLevel;
        private DateTime issueDate;
        private DateTime contractTerm;
        #endregion

        #region Properties

        public static string ContractID
        {
            get
            {
                return contractID;
            }

            set
            {
                contractID = value;
            }
        }

        public string ContractType
        {
            get
            {
                return contractType;
            }

            set
            {
                contractType = value;
            }
        }

        public string ContractLevel
        {
            get
            {
                return contractLevel;
            }

            set
            {
                contractLevel = value;
            }
        }

        public DateTime IssueDate
        {
            get
            {
                return issueDate;
            }

            set
            {
                issueDate = value;
            }
        }

        public DateTime ContractTerm
        {
            get
            {
                return contractTerm;
            }

            set
            {
                contractTerm = value;
            }
        }


        #endregion

        #region Contrutors
        public Contract()
        {

        }
        public Contract(string _cID, string _cLevel, string _cType, DateTime _issueDate, DateTime _expiry)
        {
            this.ContractType = _cType;
            this.ContractLevel = _cLevel;
            this.IssueDate = _issueDate;
            this.ContractTerm = _expiry;
        }
        #endregion
        #region Methods
        protected override bool Equals(object obj)
        {
            return obj == null || !(obj is Contract) ? false : ContractType.Equals(((Contract)obj).ContractType);
        }

        protected override int GetHashCode()
        {
            return ContractType.GetHashCode();
        }

        protected override string ToString()
        {
            return string.Format(ContractID, ContractType, ContractLevel, IssueDate, ContractTerm);
        }
        #endregion
    }
}
