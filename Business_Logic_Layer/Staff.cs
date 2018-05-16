using Data_Access_;
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
        private int identity;
        private string jobDesc;
        private string department;
        public static List<Staff> staff;
        private static Data_Access_Layer.DataHandler dh;
        private static Dictionary<string, object> items;
        private static Location loc;
        private static Job job;

        #region Properties
        public int Identity { get { return identity; } set { identity = value; } }
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
            dh = new Data_Access_Layer.DataHandler();
            loc = new Location();
            staff = new List<Staff>();
            job = new Job();

            foreach (DataRow item in dh.GetData(Cons.table3).Rows)
            {
                staff.Add(new Staff(
                (int)item[Cons.table3Id],
                item[Cons.table3Col1].ToString(),
                item[Cons.table3Col2].ToString(),
                item[Cons.table3Col3].ToString(),
                (bool)item[Cons.table3Col5] ? "Female" : "Male",
                (DateTime)item[Cons.table3Col4],
                item[Cons.table3Col6].ToString(),
                item[Cons.table3Col7].ToString(),
                job[(int)item[Cons.table3IdFk1]].JobDesc,
                loc[(int)item[Cons.table3IdFk2]].Country,
                loc.City,
                loc.Street
                ));
            }

        }
        public Staff(int staffId, string title, string name, string surname, string gender, DateTime birth, string phone, string email, string jobDesc, string country, string city, string street)
        : base(title, name, surname, gender, birth, phone, email, country, city, street)
        {
            this.Identity = staffId;
            this.JobDesc = jobDesc;
        }

        public Staff(string username, string password)
        {}
        #endregion

        #region Indexer
        public Staff this[int? staffId = null, string department = null, string name = null, string surname = null, string phone = null, string email = null]
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
            dh = new Data_Access_Layer.DataHandler();
            foreach (DataRow item in dh.GetData(Cons.table10).Rows)
            {
                if (username.Equals(item[Cons.table10Col1].ToString()) && password.Equals(item[Cons.table10Col2].ToString()))
                {
                    return new Staff(username,password)[(int?)item[Cons.table10IDFk], item[Cons.table10Col3].ToString()];
                }

            }
            return null;
        }
        public bool Insert(Staff staff)
        {
            int locId = loc[null, staff.City, staff.Country].LocationId;
            items = new Dictionary<string, object>();
            items.Add(Cons.table3Col1, staff.Title);
            items.Add(Cons.table3Col2, staff.Name);
            items.Add(Cons.table3Col3, staff.Surname);
            items.Add(Cons.table3Col4, staff.BirthDate);
            items.Add(Cons.table3Col5, staff.Gender.StartsWith("M") ? false : true);
            items.Add(Cons.table3Col6, staff.ContactNumber);
            items.Add(Cons.table3Col7, staff.EmailAddress);
            items.Add(Cons.table3IdFk2, locId);
            new Staff(Cons.table3);
            return dh.Insert(items) != null ? true : false;
        }

        public bool Update(Staff staff)
        {
            int locId = loc[null, staff.Street, staff.City, staff.Country].LocationId;
            items = new Dictionary<string, object>();
            items.Add(Cons.table3Col1, staff.Title);
            items.Add(Cons.table3Col2, staff.Name);
            items.Add(Cons.table3Col3, staff.Surname);
            items.Add(Cons.table3Col4, staff.BirthDate);
            items.Add(Cons.table3Col5, staff.Gender.StartsWith("M") ? false : true);
            items.Add(Cons.table3Col6, staff.ContactNumber);
            items.Add(Cons.table3Col7, staff.EmailAddress);
            items.Add(Cons.table3IdFk2, locId);
            new Staff(Cons.table3);
            return dh.Update(items, staff.Identity.ToString());
        }

        public bool Delete(int staffId)
        {
            new Client(Cons.table3);
            return dh.Delete(staffId.ToString());
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
