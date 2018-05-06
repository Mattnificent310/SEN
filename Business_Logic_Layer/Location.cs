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
            DataRow dtrStreet = dh.Search(key.ToString(), "tblLocation");
            int cityId = (int)dtrStreet["CityIDFK"];
            this.Street = dtrStreet["StreetAddress"].ToString();
            DataRow dtrCity = dh.Search(cityId.ToString(), "tblCity");
            int countryId = (int)dtrCity["CountryIDFK"];
            this.City = dtrCity["CityName"].ToString();
            DataRow dtrCountry = dh.Search(countryId.ToString(), "tblCountry");
            this.Country = dtrCountry["CountryName"].ToString();
           
        }
        public Location(string street, string city, string country)
        {
            dh = new Data_Access_Layer.DataHandler();
            Dictionary<string, object> countries = new Dictionary<string, object>();
            Dictionary<string, object> cities = new Dictionary<string, object>();
            Dictionary<string, object> streets = new Dictionary<string, object>();
            countries.Add("CountryName", country);
            countries.Add("CountryCode", "TBA");
            int countryId = (int)dh.Insert(countries, "tblCountry", "CountryIDPK");
            cities.Add("CityName", city);
            cities.Add("CityCode", "TBA");
            cities.Add("StateCode", "TBA");
            cities.Add("CountryIDFK", countryId);
            int cityId = (int)dh.Insert(cities, "tblCity", "CityIDPK");
            streets.Add("StreetAddress", street);
            streets.Add("Suburb", "TBA");
            streets.Add("CityIDFK", cityId);
            this.LocationId = (int)dh.Insert(streets, "tblLocation", "LocationIDPK");
            
        }
    }
}
