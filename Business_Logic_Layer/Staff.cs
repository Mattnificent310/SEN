using Data_Access_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Staff : Person
    {
        private int identity;
        private string jobDesc;
        public static List<Staff> staff;
        private static Data_Access_Layer.DataHandler dh;
        private static Dictionary<string, object> items;
        private static Location loc;
        private static Job job;

        public int Identity { get { return identity; } set { identity = value; } }
        public string JobDesc { get { return jobDesc; } set { jobDesc = value; } }

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

        #region Indexer
        public Staff this[string name, string surname, string email]
        {
            get
            {
                foreach (Person item in staff)
                {
                    if (item.Name == (name ?? item.Name) 
                    && item.Surname == (surname ?? item.Surname) 
                    && item.EmailAddress == (email ?? item.EmailAddress))
                    {
                        this.Name = item.Name;
                        this.Surname = item.Surname;
                        this.EmailAddress = item.EmailAddress;
                        return (Staff)item;
                    }
                }
                throw new KeyNotFoundException();
            }
        }
        #endregion

        #region CRUD
        public static bool Insert(Staff staff)
        {
            int locId = loc[null, staff.City, staff.Country].LocationId;
            new Client(Cons.table3);
            items = new Dictionary<string, object>();
            items.Add(Cons.table3Col1, staff.Title);
            items.Add(Cons.table3Col2, staff.Name);
            items.Add(Cons.table3Col3, staff.Surname);
            items.Add(Cons.table3Col4, staff.BirthDate);
            items.Add(Cons.table3Col5, staff.Gender.StartsWith("M") ? false : true);
            items.Add(Cons.table3Col6, staff.ContactNumber);
            items.Add(Cons.table3Col7, staff.EmailAddress);
            items.Add(Cons.table3IdFk2, locId);
            return dh.Insert(items) != null ? true : false;
        }

        public static bool Update(Staff staff)
        {
            int locId = loc[null, staff.Street, staff.City, staff.Country].LocationId;
            items = new Dictionary<string, object>();
            new Client(Cons.table3);
            items.Add(Cons.table3Col1, staff.Title);
            items.Add(Cons.table3Col2, staff.Name);
            items.Add(Cons.table3Col3, staff.Surname);
            items.Add(Cons.table3Col4, staff.BirthDate);
            items.Add(Cons.table3Col5, staff.Gender.StartsWith("M") ? false : true);
            items.Add(Cons.table3Col6, staff.ContactNumber);
            items.Add(Cons.table3Col7, staff.EmailAddress);
            items.Add(Cons.table3IdFk2, locId);
            return dh.Update(items, staff.Identity.ToString());
        }

        public static bool Delete(string clientId)
        {
            new Client(Cons.table3);
            return dh.Delete(clientId);
        }
        #endregion

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

        protected override List<Person> Search(string name = "empty", string surname = "empty", string email = "example@example.com")
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
