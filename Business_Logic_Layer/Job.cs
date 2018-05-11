using Data_Access_;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business_Logic_Layer
{
    public class Job
    {
        private int? jobId;
        private string jobDesc;
        private decimal? salary;
        private System.DateTime? hireDate;
        private string jobDetails;
        public static List<Job> jobs;
        private static Data_Access_Layer.DataHandler dh;
        private static Dictionary<string, object> items;

        public int? JobId
        {
            get { return jobId; }
            set { jobId = value; }
        }
        public string JobDesc
        {
            get { return jobDesc; }
            set { jobDesc = value; }
        }
        public decimal? Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public DateTime? HireDate { get { return hireDate; } set { hireDate = value; } }
        public string JobDetails { get { return jobDetails; } set { jobDetails = value; } }

        public Job()
        {
            dh = new Data_Access_Layer.DataHandler();
            jobs = new List<Job>();

            foreach (DataRow item in dh.GetData(Cons.table9).Rows)
            {
                jobs.Add(new Job(
                (int)item[Cons.table9Id],
                item[Cons.table9Col1].ToString(),
                (decimal)item[Cons.table9Col2],
                (DateTime)item[Cons.table9Col3],
                item[Cons.table9Col4].ToString()));
            }
        }

        public Job(int? jobId = null, string jobDesc = null, decimal? salary = null, DateTime? hireDate = null, string jobDetail = null)
        {
            this.JobId = jobId;
            this.JobDesc = jobDesc;
            this.Salary = salary;
            this.HireDate = hireDate;
            this.JobDetails = jobDetail;
        }
        #region Indexer
        public Job this[int? jobId = null, string jobDesc = null, decimal? salary = null, DateTime? hireDate = null]
        {
            get
            {
                foreach (Job item in jobs)
                {
                    if (item.JobId == (jobId ?? item.JobId)
                    && item.JobDesc == (jobDesc ?? item.JobDesc)
                    && item.Salary == (salary ?? item.Salary))
                    {
                        this.JobId = item.JobId;
                        this.JobDesc = item.JobDesc;
                        this.Salary = item.Salary;
                        this.HireDate = item.HireDate;
                        return (Job)item;
                    }
                }
                throw new KeyNotFoundException();
            }
        }
        #endregion
    }
}