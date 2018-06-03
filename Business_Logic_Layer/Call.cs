using Data_Access_;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Call
    {
        private int callId;
        private string callDate;
        private string callTime;
        private string duration;
        private int staffId;
        private int clientId;
        private int companyId;

        public int CallId { get => callId; set => callId = value; }
        public string CallDate { get => callDate; set => callDate = value; }
        public string CallTime { get => callTime; set => callTime = value; }
        public string Duration { get => duration; set => duration = value; }
        public int StaffId { get => staffId; set => staffId = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public int CompanyId { get => companyId; set => companyId = value; }


        #region CRUD
        public int Insert(Call call)
        {
            return (int)new DataHandler().Insert(new Dictionary<string, object>()
        {
            {Cons.table17Col1, call.CallDate },
            {Cons.table17Col2, call.CallTime },
            {Cons.table17Col3, call.Duration },
            {Cons.table17IDFK1, call.StaffId },
            {Cons.table17IDFK2, call.ClientId },
            {Cons.table17IDFK3, call.CompanyId }
        }, Cons.table17);

        }
    }
    #endregion
}
