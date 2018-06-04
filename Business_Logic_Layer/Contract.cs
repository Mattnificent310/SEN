﻿using Data_Access_;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Contract : IContract
    {
        #region Fields
        private string contractID;
        private string clientId;
        private string contractType;
        private string contractLevel;
        private DateTime issueDate;
        private int contractTerm;
        public static List<Contract> contracts;
        private static DataHandler dh = new DataHandler();
        #endregion

        #region Properties

        public string ContractID
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

        public int ContractTerm
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
            contracts = new List<Contract>();
            foreach (DataRow item in DataHandler.GetData(Cons.table12).Rows)
            {
                contracts.Add(new Contract(
                string.Format("{0}{1}{2}{3}",DateTime.Parse(item[Cons.table12Col3].ToString()).Year,
                item[Cons.table12Col2].ToString()[0], item[Cons.table12Col1].ToString(),
                    item[Cons.table12Id].ToString().PadLeft(6,'0')),
                    item[Cons.table12Col1].ToString(),
                    item[Cons.table12Col2].ToString(),
                    (DateTime)item[Cons.table12Col3],
                    (int)item[Cons.table12Col4],
                    item[Cons.table12IdFk].ToString()
                ));
            }
        }
        public Contract(string _cID, string _cLevel, string _cType, DateTime _issueDate, int _term, string key)
        {
            this.ContractID = _cID;
            this.ContractType = _cType;
            this.ContractLevel = _cLevel;
            this.IssueDate = _issueDate;
            this.ContractTerm = _term;
            this.clientId = key;
        }
        #endregion

        #region CRUD
        public int? InsertContract(Contract contract)
        {
            return (int?)new DataHandler().Insert(new Dictionary<string, object>
            {
                {Cons.table12Col1, contract.ContractLevel },
                {Cons.table12Col2, contract.ContractType },
                {Cons.table12Col3, contract.IssueDate },
                {Cons.table12Col4, contract.ContractTerm },
                {Cons.table12IdFk, contract.clientId }
            }, Cons.table12);
        }

        public bool UpdateContract(Contract contract)
        {
            return new DataHandler().Update(new Dictionary<string, object>
            {
                {Cons.table12Col1, contract.ContractLevel },
                {Cons.table12Col2, contract.ContractType },
                {Cons.table12Col3, contract.IssueDate },
                {Cons.table12Col4, contract.ContractTerm },
                {Cons.table12IdFk, contract.clientId }
            }, contract.ContractID, Cons.table12);
        }

        public bool DeleteContract(int contractId)
        {
            return new DataHandler().Delete(contractId.ToString(), Cons.table12);
        }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return obj == null || !(obj is Contract) ? false : ContractType.Equals(((Contract)obj).ContractType);
        }

        public override int GetHashCode()
        {
            return ContractType.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(ContractID, ContractType, ContractLevel, IssueDate, ContractTerm);
        }


        #endregion
    }
}
