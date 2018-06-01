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
        private static Data_Access_Layer.DataHandler dh = new DataHandler(Cons.table1);
        private static string[] unique = { "A", "B", "C", "D", "E" };
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
                identity = string.IsNullOrEmpty(value) ? "" : string.Format("{0}{1}", unique[new Random().Next(0, 4)],value.PadLeft(8, '0'));
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
            loc = new Location();
            clients = new List<Client>();

            DataTable clientTbl = DataHandler.GetData(Cons.table1);
            foreach (DataRow item in clientTbl.Rows)
            {
                DataRow row = new StoredProcedure().GetProcs("sp_SearchLocationByID", new Dictionary<string, object> 
                { { "LocationID", item[Cons.table1IdFk] } }).Rows[0];
                
                clients.Add(new Client(
                
                item[Cons.table1Id].ToString(),
                item[Cons.table1Col1].ToString(),
                item[Cons.table1Col2].ToString(),
                item[Cons.table1Col3].ToString(),
                item[Cons.table1Col5].ToString(),
                (DateTime)item[Cons.table1Col4],
                item[Cons.table1Col6].ToString(),
                item[Cons.table1Col7].ToString(),
                item[Cons.table1Col8].ToString(),
                item[Cons.table1Col9].ToString(),
                item[Cons.table1Col10].ToString(),
                row[Cons.table6Col1].ToString(),
                row[Cons.table5Col1].ToString(),
                row[Cons.table4Col1].ToString()
                //loc[(int)item[Cons.table1IdFk]].Country,
                //loc.City,
                //loc.Street
                ));
            }
        }
        public Client(int identity) { }
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
        public Client this[string name = null, string surname = null, string email = null]
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
        protected override bool Equals(object obj)
        {
            return obj == null || !(obj is Client) ? false : Name.Equals(((Client)obj).Name);
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
            return string.Format(Identity, Title, Name, Surname, Gender, BirthDate.ToShortDateString(), ContactNumber, EmailAddress, ContactMethod, Status, creditRating, Country, City, Street);
        }
        #endregion

        #region CRUD
        public int? Insert(Client client)
        {
            int locId = (int)new StoredProcedure().GetProcs("sp_SearchLocation", new Dictionary<string, object>
            { {"Country",client.Country }, {"City",client.City }, {"Street", client.Street} }).Rows[0][0];
            //loc[null, client.Street, client.City, client.Country].LocationId;
            
            return (int?)dh.Insert(new Dictionary<string, object>
            {
            { Cons.table1Col1, client.Title },
            { Cons.table1Col2, client.Name },
            { Cons.table1Col3, client.Surname},
            { Cons.table1Col4, client.BirthDate },
            { Cons.table1Col5, client.Gender},
            { Cons.table1Col6, client.ContactNumber },
            { Cons.table1Col7, client.EmailAddress },
            { Cons.table1IdFk, locId }
            }, Cons.table1);
        }

        public bool Update(Client client)
        {            
            int locId = (int)new StoredProcedure().GetProcs("sp_SearchLocation", new Dictionary<string, object>
            { {"Country",client.Country }, {"City",client.City }, {"Street", client.Street} }).Rows[0][0];
            //loc[null, client.Street, client.City, client.Country].LocationId;
            
            return dh.Update(new Dictionary<string, object>
            {
                { Cons.table1Col1, client.Title },
                { Cons.table1Col2, client.Name },
                { Cons.table1Col3, client.Surname },
                { Cons.table1Col5, client.Gender},
                { Cons.table1Col6, client.ContactNumber },
                { Cons.table1Col7, client.EmailAddress },
                { Cons.table1IdFk, locId }
            }, int.Parse(client.Identity.Substring(1)).ToString(), Cons.table1);

        }

        public bool Delete(int clientId)
        {            
            return dh.Delete(clientId.ToString(), Cons.table1);
        }

        #endregion

        #endregion

    }


}
