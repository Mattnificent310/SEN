using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Schedule : Support
    {
        private DateTime schedStartDate;
        private DateTime schedEndDate;
        private int schedDuration;

        public int SchedDuration
        {
            get
            {
                return schedDuration;
            }

            set
            {
                schedDuration = value;
            }
        }

        public DateTime SchedStartDate
        {
            get
            {
                return schedStartDate;
            }

            set
            {
                schedStartDate = value;
            }
        }

        public DateTime SchedEndDate
        {
            get
            {
                return schedEndDate;
            }

            set
            {
                schedEndDate = value;
            }
        }

        public Schedule()
        {

        }
        public Schedule(DateTime _startDate, DateTime _endDate, int _duration)
        {
            SchedStartDate = _startDate;
            SchedEndDate = _endDate;
            schedDuration = _duration;
        }


        public override bool Equals(object obj)
        {
            return obj == null || !(obj is Schedule) ? false : SchedEndDate.Equals(((Schedule)obj).SchedEndDate);
        }

        public override int GetHashCode()
        {
            return SchedEndDate.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(SchedStartDate.ToShortDateString(), SchedDuration.ToString(), SchedEndDate.ToShortDateString());
        }

    }
}
