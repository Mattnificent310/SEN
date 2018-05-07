using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    class Tasks
    {
        private int taskID;

        public int TaskID
        {
            get { return taskID; }
            set { taskID = value; }
        }

        private string taskDescription;

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value; }
        }

        private string taskCriteria;

        public string TaskCriteria
        {
            get { return taskCriteria; }
            set { taskCriteria = value; }
        }

        private string taskType;

        public string TaskType
        {
            get { return taskType; }
            set { taskType = value; }
        }

        public Tasks()
        {
            
        }

        public Tasks(int taskID, string taskDescription, string taskCriteria, string taskType)
        {
            this.taskID = taskID;
            this.taskDescription = taskDescription;
            this.taskCriteria = taskCriteria;
            this.taskType = taskType;
        }

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
    }
}
