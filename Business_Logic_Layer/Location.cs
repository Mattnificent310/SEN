using Data_Access_;
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
        private static List<Location> locs;
        private static Dictionary<string, object> values;

        public int LocationId { get { return locationId; } set { locationId = value; } }
        public string Country { get { return country; } set { country = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Street { get { return street; } set { street = value; } }

        public Location(string cons)
        { dh = new Data_Access_Layer.DataHandler(cons); }

        public Location()
        {
            dh = new Data_Access_Layer.DataHandler();
            locs = new List<Location>();
            foreach (DataRow item in dh.GetData(Cons.table4).Rows)
            {
                locs.Add(new Location(
                  (int)item[Cons.table4Id],
                       item[Cons.table4Col1].ToString().Trim(),
                       dh.Search(item[Cons.table4IdFk].ToString(), Cons.table5)[Cons.table5Col1].ToString(),
                       dh.Search(dh.Search(item[Cons.table4IdFk].ToString(),
                       Cons.table5)[Cons.table5IdFk].ToString(),
                       Cons.table6)[Cons.table6Col1].ToString()

                  ));
            }
        }

        public Location(int locId, string street, string city, string country)
        {
            this.LocationId = locId;
            this.Street = street;
            this.City = city;
            this.Country = country;
        }
        #region Indexer
        public Location this[int? locId, string street = null, string city = null, string country = null]
        {
            get
            {
                if (!locs.Any()) { new Location(); }
                foreach (var item in locs)
                {
                    
                    if (item.LocationId == (locId ?? item.LocationId)
                    && item.Street == (street ?? item.Street)
                    && item.City == (city ?? item.City)
                    && item.Country == (country ?? item.Country))
                    {
                        this.LocationId = item.LocationId;
                        this.Street = item.Street;
                        this.City = item.City;
                        this.Country = item.Country;
                        return (Location)item;
                    }                    
                }
                throw new KeyNotFoundException();
            }
        }


        #endregion
        public int Insert(Location location)
        {
            values = new Dictionary<string, object>();
            values.Add(Cons.table4Col1, street);
            values.Add(Cons.table4Col2, city);
            values.Add(Cons.table4IdFk, country);
            return (int)dh.Insert(values);

        }
    }
}
