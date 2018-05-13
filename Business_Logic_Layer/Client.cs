using Data_Access_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    enum Status
    {
        Regular,
        Exists,
        NewClient,
        Removed
    }
    public class Client : Person, IClient
    {
        #region Fields

        private string identity;
        private string status;
        private string contactMethod;
        private string creditRating;
        public static List<Client> clients;
        private static Data_Access_Layer.DataHandler dh;
        private static Dictionary<string, object> items;
        private static Location loc;


        #endregion
        #region Properties


        public string Identity
        {
            get
            {
                return identity;
            }

            set
            {
                identity = value == null ? string.Empty : value.Trim();
            }
        }
        public static List<Client> Clients
        {
            get
            {
                return clients;
            }

            set
            {
                clients = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value == null ? string.Empty : value.Trim();
            }
        }

        public string ContactMethod
        {
            get
            {
                return contactMethod;
            }

            set
            {
                contactMethod = value == null ? string.Empty : value.Trim();
            }
        }

        public string CreditRating
        {
            get
            {
                return creditRating;
            }

            set
            {
                creditRating = value == null ? string.Empty : value.Trim();
            }
        }


        #endregion
        #region Constructor
        public Client()
        {
            dh = new Data_Access_Layer.DataHandler();
            loc = new Location();
            clients = new List<Client>();

            foreach (DataRow item in dh.GetData(Cons.table1).Rows)
            {
                clients.Add(new Client(
                item[Cons.table1Id].ToString(),
                item[Cons.table1Col1].ToString(),
                item[Cons.table1Col2].ToString(),
                item[Cons.table1Col3].ToString(),
                (bool)item[Cons.table1Col5] ? "Female" : "Male",
                (DateTime)item[Cons.table1Col4],
                item[Cons.table1Col6].ToString(),
                item[Cons.table1Col7].ToString(),
                string.Empty,
                string.Empty,
                string.Empty,
                loc[(int)item[Cons.table1IdFk]].Country,
                loc.City,
                loc.Street
                ));
            }
        }
        public Client(string cons)
        {
            dh = new Data_Access_Layer.DataHandler(cons);
        }
        public Client(string _identity, string _title, string _name, string _surname, string _gender,
            DateTime _birthDate, string _contact, string _email, string _contactMethod, string _status
            , string _credit, string _country, string _city, string _street) :
            base(_title, _name, _surname, _gender, _birthDate, _contact, _email, _country, _city, _street)
        {

            this.Identity = _identity;
            this.Status = _status;
            this.ContactMethod = _contactMethod;
            this.CreditRating = _credit;
        }
        #endregion
        #region Indexer
        public Client this[string name, string surname, string email]
        {
            get
            {
                foreach (Person item in clients)
                {
                    if (item.Name == (name ?? item.Name)
                    && item.Surname == (surname ?? item.Surname)
                    && item.EmailAddress == (email ?? item.EmailAddress))
                    {
                        this.Name = item.Name;
                        this.Surname = item.Surname;
                        this.EmailAddress = item.EmailAddress;
                        return (Client)item;
                    }
                }
                throw new KeyNotFoundException();
            }
        }
        #endregion
        #region Methods
        protected override List<Person> Search(string name = "empty", string surname = "empty", string email = "example@example.com")
        {
            List<Person> client = new List<Person>();
            return client;

        }

        #region Poly Methods
        public override bool Equals(object obj)
        {
            return obj == null || !(obj is Client) ? false : Name.Equals(((Client)obj).Name);
        }

        public override int GetHashCode()
        {
            int i = 0;
            try
            {
                i = Name.GetHashCode();
            }
            catch (Exception e) { return 0; }
            return i;
        }

        public override string ToString()
        {
            return string.Format(Identity, Title, Name, Surname, Gender, BirthDate.ToShortDateString(), ContactNumber, EmailAddress, ContactMethod, Status, creditRating, Country, City, Street);
        }
        #endregion

        #region SOLID Methods
        public bool Insert(Client client)
        {
            int locId = loc[null, client.City, client.Country].LocationId;
            new Client(Cons.table1);
            items = new Dictionary<string, object>();
            items.Add(Cons.table1Col1, client.Title);
            items.Add(Cons.table1Col2, client.Name);
            items.Add(Cons.table1Col3, client.Surname);
            items.Add(Cons.table1Col4, client.BirthDate);
            items.Add(Cons.table1Col5, client.Gender.StartsWith("M") ? false : true);
            items.Add(Cons.table1Col6, client.ContactNumber);
            items.Add(Cons.table1Col7, client.EmailAddress);
            items.Add(Cons.table1IdFk, locId);
            return dh.Insert(items) != null ? true : false;
        }

        public bool Update(Client client)
        {
            int locId = loc[null, client.Street, client.City, client.Country].LocationId;
            items = new Dictionary<string, object>();
            new Client(Cons.table1);
            items.Add(Cons.table1Col1, client.Title);
            items.Add(Cons.table1Col2, client.Name);
            items.Add(Cons.table1Col3, client.Surname);
            items.Add(Cons.table1Col4, client.BirthDate);
            items.Add(Cons.table1Col5, client.Gender.StartsWith("M") ? false : true);
            items.Add(Cons.table1Col6, client.ContactNumber);
            items.Add(Cons.table1Col7, client.EmailAddress);
            items.Add(Cons.table1IdFk, locId);
            return dh.Update(items, client.Identity);
        }

        public bool Delete(int clientId)
        {
            new Client(Cons.table1);
            return dh.Delete(clientId.ToString());
        }






        #endregion
        #endregion

    }


}
