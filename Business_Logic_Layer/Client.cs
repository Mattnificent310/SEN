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
    public class Client : Person
    {
        #region Fields

        private string identity;
        private string status;
        private string contactMethod;
        private string creditRating;
        public static List<Client> clients;
        private static Data_Access_Layer.DataHandler dh;
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
            clients = new List<Client>();
            foreach (DataRow item in dh.GetData("tblClient").Rows)
            {
                Location loc = new Location((int)item["LocationIDFK"]);
                clients.Add(new Client(
                item["ClientIDPK"].ToString(),
                item["ClientTitle"].ToString(),
                item["ClientName"].ToString(),
                item["ClientSurname"].ToString(),
                (bool)item["ClientGender"] ? "Female" : "Male",
                (DateTime)item["ClientDOB"],
                item["ClientPhone"].ToString(),
                item["ClientEmail"].ToString(),
                string.Empty,
                string.Empty,
                string.Empty,
                loc.Country,
                loc.City,
                loc.Street
                ));

            }

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
                    if ((item.Name == name && item.Surname == surname) || item.EmailAddress == email)
                    {
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

        public static bool Insert(Client client)
        {
            Location loc = new Location(client.Street, client.City, client.Country);
            int locId = loc.LocationId;
            Dictionary<string, object> items = new Dictionary<string, object>();
            items.Add("ClientTitle", client.Title);
            items.Add("ClientName", client.Name);
            items.Add("ClientSurname", client.Surname);
            items.Add("ClientDOB", client.BirthDate);
            items.Add("ClientGender", client.Gender.StartsWith("M") ? false : true);
            items.Add("ClientPhone", client.ContactNumber);
            items.Add("ClientEmail", client.EmailAddress);
            items.Add("LocationIDFK", locId);
            return dh.Insert(items, "tblClient") != null ? true : false;
        }

        public static bool Update(Client client)
        {
            Location loc = new Location(client.Street, client.City, client.Country);
            int locId = loc.LocationId;
            Dictionary<string, object> items = new Dictionary<string, object>();
            items.Add("ClientTitle", client.Title);
            items.Add("ClientName", client.Name);
            items.Add("ClientSurname", client.Surname);
            items.Add("ClientDOB", client.BirthDate);
            items.Add("ClientGender", client.Gender.StartsWith("M") ? false : true);
            items.Add("ClientPhone", client.ContactNumber);
            items.Add("ClientEmail", client.EmailAddress);
            items.Add("LocationIDFK", locId);
            return dh.Update(items, "tblClient", client.Identity);
        }

        public static bool Delete(string clientId)
        {
            return dh.Delete("tblClient", clientId);
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
        #endregion

    }


}
