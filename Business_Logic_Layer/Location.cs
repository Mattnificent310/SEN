using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Location
    {
        private int locationId;
        private string country;
        private string city;
        private string street;
        private static Data_Access_Layer.DataHandler dh;

        public int LocationId { get { return locationId; } set { locationId = value; } }
        public string Country { get { return country; } set { country = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Street { get { return street; } set { street = value; } }

        public Location()
        { }
        public Location(int key)
        {
            dh = new Data_Access_Layer.DataHandler();
            DataRow dtrStreet = dh.Search("tblLocation", key.ToString());
            int cityId = (int)dtrStreet["CityIDFK"];
            this.Street = dtrStreet["StreetAddress"].ToString();
            DataRow dtrCity = dh.Search("tblCity", cityId.ToString());
            int countryId = (int)dtrCity["CountryIDFK"];
            this.City = dtrCity["CityName"].ToString();
            DataRow dtrCountry = dh.Search("tblCountry", countryId.ToString());
            this.Country = dtrCountry["CountryName"].ToString();

        }
        public Location(string street, string city, string country)
        {
            dh = new Data_Access_Layer.DataHandler();
            Dictionary<string, object> streets = new Dictionary<string, object>();
            int countryId = (int)dh.SearchByName("tblCountry", "CountryName", country)[0];
            int cityId = (int)dh.SearchByName("tblCity", "CityName", city)[0];
            streets.Add("StreetAddress", street);
            streets.Add("Suburb", "TBA");
            streets.Add("CityIDFK", cityId);
            if(dh.SearchByName("tblLocation", "StreetAddress", street)==null)
            {
               
                this.LocationId = (int)dh.Insert(streets, "tblLocation");
            }
            else
            {
                this.locationId = (int)dh.SearchByName("tblLocation", "StreetAddress", street)[0];
            }
            

        }
    }
}
