using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public abstract class Person
    {
        #region Fields
        private string title;
        private string name;
        private string surname;
        private string gender;
        private DateTime birthDate;
        private string contactNumber;
        private string emailAddress;
        private string country;
        private string city;
        private string street;
        #endregion

        #region Properties
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value == null ? string.Empty : value.Trim();
            }
        }


        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value == null ? string.Empty : value.Trim();
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value == null ? string.Empty : value.Trim();
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value == null ? string.Empty : value.Trim();
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
            }
        }

        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }

            set
            {
                contactNumber = value == null ? string.Empty : value.Trim();
            }
        }

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }

            set
            {
                emailAddress = value == null ? string.Empty : value.Trim();
            }
        }



        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value == null ? string.Empty : value.Trim();
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value == null ? string.Empty : value.Trim();
            }
        }

        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                street = value == null ? string.Empty : value.Trim();
            }
        }


        #endregion

        #region Constructor
        protected Person()
        {

        }
        protected Person(string _title, string _name, string _surname, string _gender, DateTime _birthDate, string _contactNumber,
            string _emailAddress, string _country, string _city, string _street)
        {
            this.Title = _title;
            this.Name = _name;
            this.Surname = _surname;
            this.Gender = _gender;
            this.BirthDate = _birthDate;
            this.ContactNumber = _contactNumber;
            this.EmailAddress = _emailAddress;
            this.Country = _country;
            this.City = _city;
            this.Street = _street;
        }
        #endregion
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="email"></param>
        /// <returns>Returns a list of Person members as search results</returns>
        protected abstract List<Person> Search(string name = "empty", string surname = "empty", string email = "example@example.com");
        #endregion
    }
}
