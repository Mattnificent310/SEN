using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    class Support
    {
        private int supportIDPK;

        public int SupportIDPK
        {
            get { return supportIDPK; }
            set { supportIDPK = value; }
        }

        private string supportType;

        public string SupportType
        {
            get { return supportType; }
            set { supportType = value; }
        }

        private string supportDetails;

        public string SupportDetails
        {
            get { return supportDetails; }
            set { supportDetails = value; }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public Support()
        {

        }

        public Support(int supportIDPK, string supportType, string supportDetails, DateTime startDate, DateTime endDate, int duration)
        {
            this.supportIDPK = supportIDPK;
            this.supportType = supportType;
            this.supportDetails = supportDetails;
            this.startDate = startDate;
            this.endDate = endDate;
            this.duration = duration;
        }

        #region Methods
        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return null;
        }
        #endregion

    }
}
