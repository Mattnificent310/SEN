using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StoredProcedureCollection : System.Collections.CollectionBase
    {

        public void add(StoredProcedure value)
        {
            List.Add(value);
        }
        public void Remove(int index)
        {

            if (index > Count - 1 || index < 0)

            {

            }
            else
            {
                List.RemoveAt(index);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public StoredProcedure Item(int Index)
        {
            return (StoredProcedure)List[Index];
        }


    }
}

