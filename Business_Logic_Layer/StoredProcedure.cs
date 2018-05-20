using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    struct ParamData
    {
        public string pName;
        public object pValue;
        public ParamData(string pName, object pValue)
        {
            this.pName = pName;

            this.pValue = pValue;

        }

    }
    public class StoredProcedure
    {
        private string sProcName;
        private ArrayList sParams = new ArrayList();
        /// <summary>
        /// set the parameters
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDataType"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        /// 

        public void SetParam(string pName, object pValue)
        {

            ParamData pData = new ParamData(pName, pValue);
            sParams.Add(pData);
        }

        /// <summary>
        /// get the Parameter list
        /// </summary>
        /// <returns></returns>
        public ArrayList GetParams()
        {
            if (!(sParams == null))
            {
                return sParams;
            }
            else
            {
                return null;

            }

        }

        public string ProcName
        {
            get
            {
                return sProcName;
            }
            set
            {
                sProcName = value;
            }
        }

    }
}

