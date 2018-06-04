using Data_Access_;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Call : ICall
    {
        private int callId;
        private string callType;
        private string callDate;
        private string callTime;
        private string duration;
        private int staffId;
        private int clientId;
        private int companyId;
        public static List<Call> calls;

        public int CallId { get => callId; set => callId = value; }
        public string CallDate { get => callDate; set => callDate = value; }
        public string CallTime { get => callTime; set => callTime = value; }
        public string Duration { get => duration; set => duration = value; }
        public int StaffId { get => staffId; set => staffId = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public int CompanyId { get => companyId; set => companyId = value; }
        public string CallType { get => callType; set => callType = value; }

        #region Constructor
        public Call(int callId, string callType, string callDate, string callTime, string duration, int staffId, int? clientId = null, int? companyId = null)
        {
            this.CallId = callId;
            this.CallType = callType;
            this.CallDate = callDate;
            this.CallTime = callTime;
            this.Duration = duration;
            this.StaffId = staffId;
            this.ClientId = clientId != null ? (int)clientId : 1;
        }

        public Call()
        {
            calls = new List<Call>();
            foreach (DataRow item in DataHandler.GetData(Cons.table17).Rows)
            {
                calls.Add(new Call(
                (int)item[Cons.table17Id],
                item[Cons.table17Col5].ToString(),
                item[Cons.table17Col1].ToString(),
                item[Cons.table17Col2].ToString(),
                item[Cons.table17Col3].ToString(),
                (int)item[Cons.table17IDFK1],
                (int?)item[Cons.table17IDFK2]));   
            }
        }
        #endregion


        #region CRUD


        public int? InsertCall(Call call)
        {
            return (int?)new DataHandler().Insert(new Dictionary<string, object>()
        {
            {Cons.table17Col5,call.callType },
            {Cons.table17Col1, call.CallDate },
            {Cons.table17Col2, call.CallTime },
            {Cons.table17Col3, call.Duration },
            {Cons.table17IDFK1, call.StaffId },
            {Cons.table17IDFK2, call.ClientId }
        }, Cons.table17);

        }

        public bool UpdateCall(Call call)
        {
            return new DataHandler().Update(new Dictionary<string, object>()
        {
            {Cons.table17Col5,call.callType },
            {Cons.table17Col1, call.CallDate },
            {Cons.table17Col2, call.CallTime },
            {Cons.table17Col3, call.Duration },
            {Cons.table17IDFK1, call.StaffId },
            {Cons.table17IDFK2, call.ClientId }
        }, call.CallId.ToString(), Cons.table17);

        }
        public bool DeleteCall(int callId)
        {
            return new DataHandler().Delete(callId.ToString());
        }
    }
    #endregion
}
