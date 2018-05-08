using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;

namespace Data_Access_Layer
{
    public class DataHandler
    {
        #region Fields
        private static DBConn db;
        private static DBConn dbc;
        private static DataSet ds;
        private List<object> sender;
        private static string[] index;
        private static SqlParameter[] param;
        #endregion
        #region Constructor
        public DataHandler()
        {
            db = new DBConn();
            dbc = new DBConn();
            sender = new List<object>();
            ds = new DataSet();


        }
        #endregion

        #region Method
        public DataTable GetData(string table, string[] columns = null)
        {
            int i = 0;
            string _query = "SELECT ";
            
                if (columns != null)
                {
                    while (i < columns.Length)
                    {
                        if (i > 0) _query += ", ";
                        _query += columns[i++];
                    }
                    _query += " FROM " + table;
                    //ds = db.ReadOnly(_query);
                }
               ds = db.Read(table);
                return ds.Tables[table];
           
          
        }

        public static bool CreateEntity(Dictionary<string, object> create, string[] columns, string table)
        {
            bool inserted = false;
            try
            {
                string _query = "INSERT INTO " + table + " (";
                string _query2 = " VALUES(";
                param = new SqlParameter[create.Count];
                int i = 0;
                foreach (string item in index)
                {
                    if (i > 1 && i < columns.Length) { _query += ", "; _query2 += ", "; }
                    if (i < columns.Length)
                    {
                        _query += columns[i]; _query2 += "@" + columns[i];

                        param[i] = new SqlParameter("@" + index[i], create[index[i++]]);
                    }
                    _query += ")" + _query2 + ")";

                    //if (db.Create(_query, param))
                    //{
                    //    inserted = true;
                    //}

                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return inserted;
        }
        public static bool ChangeEntity(Dictionary<string, object> values, string[] columns, string table)
        {
            bool updated = false;

            try

            {
                int i = 0, j = 1;
                string _query = "UPDATE " + table + " SET ";

                param = new SqlParameter[values.Count];
                foreach (var item in values)
                {
                    if (j > 1 && j < columns.Length) _query += ", ";
                    if (j < columns.Length) _query += columns[j] + " = @" + columns[j++];

                    param[i] = new SqlParameter("@" + columns[i], values[columns[i++]]);
                }
                _query += " WHERE " + columns[0] + " = @" + columns[0];

                //if (db.Change(_query, param))
                //{
                //    updated = true;
                //}

            }
            catch (SqlException e) { throw new Exception(e.Message); }
            return updated;
        }

        public object Insert(Dictionary<string, object> values, string table)
        {
            try
            {
                DataRow dr = ds.Tables[table].NewRow();
                foreach (var item in values)
                {
                    dr[item.Key] = item.Value;
                }
                ds.Tables[table].Rows.Add(dr);
              if(dbc.Write(ds, table))
              {
                    int count = ds.Tables[table].Rows.Count - 1;
                    return ds.Tables[table].Rows[count][0];
              }
                return null;
               
            }
            catch (SqlException e) { throw new Exception(e.Message); }
           
        }
        public int GetRow(DataSet ds, string table, string identifier)
        {
            ds.Tables[table].PrimaryKey = new DataColumn[] { ds.Tables[table].Columns[0] };
            int index = 0;
            foreach (DataRow dr in ds.Tables[table].Rows)
            {
                if (dr == ds.Tables[table].Rows.Find(identifier))
                {
                    index = (int)ds.Tables[table].Rows.IndexOf(dr);
                }
            }
            return index;
        }
        public bool Update(Dictionary<string, object> values, string table, string identifier)
        {

           
            try
            {
                foreach (var item in values)
                {
                    ds.Tables[table].Rows[GetRow(ds, table, identifier)][item.Key] = item.Value;

                }
               return dbc.Write(ds, table);
                
            }
            catch (SqlException e) { throw new Exception(e.Message); }
           
        }
        public bool Delete(string table, string identifier)
        {
           
            try
            {
                ds.Tables[table].Rows[GetRow(ds, table, identifier)].Delete();
               return dbc.Write(ds, table);
              
            }
            catch (SqlException e) { throw new Exception(e.Message); }
           
        }

        public DataRow Search(string table, string identifier)
        {
            GetData(table);
            int index = 0;
            ds.Tables[table].PrimaryKey = new DataColumn[] { ds.Tables[table].Columns[0] };
            foreach (DataRow dr in ds.Tables[table].Rows)
            {
                if (dr == ds.Tables[table].Rows.Find(identifier))
                {
                    index = (int)ds.Tables[table].Rows.IndexOf(dr);
                }
            }
            return ds.Tables[table].Rows[index];
        }
        public DataRow SearchByName(string table, string column,string value)
        {
            GetData(table);
            int index = 0;
            foreach (DataRow dr in ds.Tables[table].Rows)
            {
               
                    if (dr.Equals(ds.Tables[table].Select(column + " = '" + value + "'")))
                    {
                        index = (int)ds.Tables[table].Rows.IndexOf(dr);
                    }
                
               
            }
            return ds.Tables[table].Rows[index];
        }
        #endregion

    }
}

