using Data_Access_;
using Data_Access_Layer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Staff : Person, IStaff
    {
        private string identity;
        private string jobDesc;
        private string department;
        public static List<Staff> staff;
        private static Data_Access_Layer.DataHandler dh = new DataHandler(Cons.table3);
        private static string[] unique = { "A", "B", "C", "D", "E" };
        private static Location loc;
        private static Job job;

        #region Properties
        public string Identity { get { return identity; } set { identity = value; } }
        public string JobDesc { get { return jobDesc; } set { jobDesc = string.IsNullOrEmpty(value.Trim()) ? "Pending" : value.Trim(); } }
        public string Department { get { return department; } set { department = value; } }
        #endregion

        #region Constructors
        public Staff(string cons)
        {
            dh = new Data_Access_Layer.DataHandler(cons);
        }
        public Staff()
        {
            loc = new Location();
            staff = new List<Staff>();
            job = new Job();

            foreach (DataRow item in DataHandler.GetData(Cons.table3).Rows)
            {
                DataRow row = new StoredProcedure().GetProcs("sp_SearchLocationByID", new Dictionary<string, object> { { "LocationID", item[Cons.table1IdFk] } }).Rows[0];

                staff.Add(new Staff(
                item[Cons.table3Id].ToString(),
                item[Cons.table3Col1].ToString(),
                item[Cons.table3Col2].ToString(),
                item[Cons.table3Col3].ToString(),
                item[Cons.table3Col5].ToString(),
                (DateTime)item[Cons.table3Col4],
                item[Cons.table3Col6].ToString(),
                item[Cons.table3Col7].ToString(),
                job[(int)item[Cons.table3IdFk1]].JobDesc,
                row[Cons.table6Col1].ToString(),
                row[Cons.table5Col1].ToString(),
                row[Cons.table4Col1].ToString()
                ));
            }

        }
        public Staff(string staffId, string title, string name, string surname, string gender, DateTime birth, string phone, string email, string jobDesc, string country, string city, string street)
            : base(title, name, surname, gender, birth, phone, email, country, city, street)
        {
            this.Identity = staffId;
            this.JobDesc = jobDesc;
        }

        public Staff(string username, string password)
        { }
        #endregion

        #region Indexer
        public Staff this[string staffId = null, string department = null, string name = null, string surname = null, string phone = null, string email = null]
        {
            get
            {
                foreach (var item in staff)
                {
                    if (item.Identity == (staffId ?? item.Identity)
                    && item.Name == (name ?? item.Name)
                    && item.Surname == (surname ?? item.Surname)
                    && item.ContactNumber == (phone ?? item.ContactNumber)
                    && item.EmailAddress == (email ?? item.EmailAddress))
                    {
                        item.Department = department == null ? string.Empty : department;
                        return (Staff)item;
                    }
                }
                throw new KeyNotFoundException();
            }
        }
        #endregion

        #region CRUD

        public Staff Login(string username, string password)
        {
            foreach (DataRow item in DataHandler.GetData(Cons.table10).Rows)
            {
                if (username.Equals(item[Cons.table10Col1].ToString()) && password.Equals(item[Cons.table10Col2].ToString()))
                {
                    return new Staff(username, password)[item[Cons.table10IDFk].ToString(), item[Cons.table10Col3].ToString()];
                }

            }
            return null;
        }
        public int? Insert(Staff staff)
        {
            int locId = (int)new StoredProcedure().GetProcs("sp_SearchLocation", new Dictionary<string, object>
            { { "Country", staff.Country }, { "City", staff.City }, {"Street", staff.Street } }).Rows[0][0];
            //loc[null, staff.Street, staff.City, staff.Country].LocationId;

            return (int?)dh.Insert(new Dictionary<string, object>
            {
                { Cons.table3Col1, staff.Title },
                { Cons.table3Col2, staff.Name },
                { Cons.table3Col3, staff.Surname },
                { Cons.table3Col4, staff.BirthDate },
                { Cons.table3Col5, staff.Gender },
                { Cons.table3Col6, staff.ContactNumber },
                { Cons.table3Col7, staff.EmailAddress },
                { Cons.table3IdFk1, (int)new StoredProcedure().GetProcs("sp_SearchJobs",
                new Dictionary<string,object>{ { "JobDesc", staff.JobDesc } }).Rows[0][0] },
                { Cons.table3IdFk2, locId }
            }, Cons.table3);

        }

        public bool Update(Staff staff)
        {
            int locId = (int)new StoredProcedure().GetProcs("sp_SearchLocation", new Dictionary<string, object> 
            { { "Country", staff.Country }, { "City", staff.City }, {"Street", staff.Street } }).Rows[0][0];
            //loc[null, staff.Street, staff.City, staff.Country].LocationId;

            return dh.Update(new Dictionary<string, object>
            {
                { Cons.table3Col1, staff.Title },
                { Cons.table3Col2, staff.Name },
                { Cons.table3Col3, staff.Surname },
                { Cons.table3Col4, staff.BirthDate },
                { Cons.table3Col5, staff.Gender },
                { Cons.table3Col6, staff.ContactNumber },
                { Cons.table3Col7, staff.EmailAddress },
                { Cons.table3IdFk2, locId }
            }, staff.Identity, Cons.table3 );
        }

        public bool Delete(int staffId)
        {
            new Staff(Cons.table3);
            return dh.Delete(staffId.ToString(), Cons.table3);
        }
        #endregion

        #region Poly
        protected override bool Equals(object obj)
        {
            return obj == null || !(obj is Staff) ? false : Name.Equals(((Staff)obj).Name);
        }

        protected override int GetHashCode()
        {
            int i = 0;
            try
            {
                i = Name.GetHashCode();
            }
            catch (Exception e) { return 0; }
            return i;
        }

        protected override string ToString()
        {
            return string.Format(Identity.ToString(), Title, Name, Surname, Gender, BirthDate.ToShortDateString(), ContactNumber, EmailAddress, JobDesc, Country, City, Street);

        }

        protected override List<Person> Search(string name = "empty", string surname = "empty", string email = "example@example.com")
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
