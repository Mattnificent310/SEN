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
    public class Location
    {
        private int locationId;
        private string country;
        private string city;
        private string street;
        private static Data_Access_Layer.DataHandler dh = new DataHandler(Cons.table4);
        public static List<Location> locs;
        public static  List<Location> countries;
        private static Dictionary<string, object> values;
        private static bool notFound = false;

        public int LocationId { get { return locationId; } set { locationId = value; } }
        public string Country { get { return country; } set { country = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Street { get { return street; } set { street = value; } }

        public Location(string cons)
        { dh = new Data_Access_Layer.DataHandler(cons); }

        public Location()
        {
            locs = new List<Location>();
            DataTable locTbl = DataHandler.GetData(Cons.table4);

            foreach (DataRow item in locTbl.Rows)
            {
                DataRow row = new StoredProcedure().GetProcs("sp_SearchLocationByID", new Dictionary<string, object>
                {
                    {"LocationID",(int)item[Cons.table4IdFk] }
                }).Rows[0];
                locs.Add(new Location(
                  (int)item[Cons.table4Id],
                       item[Cons.table4Col1].ToString().Trim(),
                       row[Cons.table5Col1].ToString(),
                       row[Cons.table6Col1].ToString()

                       //DataHandler.Search(item[Cons.table4IdFk].ToString(), Cons.table5)[Cons.table5Col1].ToString(),
                       //DataHandler.Search(DataHandler.Search(item[Cons.table4IdFk].ToString(),
                       //Cons.table5)[Cons.table5IdFk].ToString(),
                       //Cons.table6)[Cons.table6Col1].ToString()
                  ));
            }
            countries = new List<Location>();
            DataRowCollection rows = new StoredProcedure().ShowAll("sp_GetCountries").Rows;
            foreach (DataRow item in rows)
            {
                countries.Add(new Location(0,"","",item[Cons.table6Col1].ToString()));
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
                return new Location(Insert(new Location(0, street, city, country)),street, city, country);
                throw new KeyNotFoundException();
            }
        }


        #endregion
        public int Insert(Location location)
        {
            values = new Dictionary<string, object>();
            values.Add(Cons.table4Col1, location.Street);
            values.Add(Cons.table4Col2, "N/A");
            values.Add(Cons.table4IdFk, (int)DataHandler.SearchByName(Cons.table5Col1, location.City, Cons.table5)[Cons.table5Id]);                      
            return dh.Insert(values, Cons.table4) != null ? (int)dh.Insert(values, Cons.table4) : -1;

        }
    }
}
