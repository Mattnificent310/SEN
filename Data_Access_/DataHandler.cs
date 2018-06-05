﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using DataAccessLayer;

namespace Data_Access_Layer
{
    public class DataHandler
    {
        #region Fields
        private static DataSet ds = new DataSet();
        private List<object> sender;
        private static string[] index;
        private static SqlParameter[] param;
        private static DBConn db = new DBConn();
        private static string table;
        #endregion

        #region Constructor
        public DataHandler(string _table = null)
        {
            sender = new List<object>();
            table = _table;
            if (!string.IsNullOrEmpty(_table)) { GetData(); }
        }
        #endregion

        #region Method
        //Builds a dataset of all entities that calls this method
        public static DataTable GetData(string _table = null, string[] columns = null)
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
            if (!ds.Tables.Contains(_table ?? table)) ds.Merge(db.Read(_table ?? table).Tables[_table ?? table]);
            return ds.Tables[_table ?? table];


        }
        //Builds an insert query for any entity during runtime
        public static bool CreateEntity(Dictionary<string, object> create, string[] columns)
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

        //Builds an update query for any entity during runtime
        public static bool ChangeEntity(Dictionary<string, object> values, string[] columns)
        {
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
            return false;
        }

        //Dynamically allows the Insert of any entity that calls this method
        public object Insert(Dictionary<string, object> values, string _table = null)
        {
            try
            {
                DataRow dr = ds.Tables[_table ?? table].NewRow();
                DataRow row = new StoredProcedure().GetProcs("sp_GetAutoIncrement", new Dictionary<string, object>
                    { {"Table",_table} }).Rows[0];
                foreach (var item in values)
                {
                    dr[item.Key] = item.Value;
                }
                ds.Tables[_table ?? table].Rows.Add(dr);
                if (db.Write(ds, _table ?? table))
                {
                    //ds = db.Read(_table ?? table);
                    int count = ds.Tables[_table ?? table].Rows.Count - 1;
                     return ds.Tables[_table ?? table].Rows[count][0];


                }
                return null;

            }
            catch (SqlException e) { throw new Exception(e.Message); }

        }
        //Searches for the particular row equal to the entities identifier
        public int GetRow(DataSet getDS, string getTable, string identifier)
        {
            getDS.Tables[getTable].PrimaryKey = new DataColumn[] { getDS.Tables[getTable].Columns[0] };
            int index = 0;
            foreach (DataRow dr in getDS.Tables[getTable].Rows)
            {
                if (dr == getDS.Tables[getTable].Rows.Find(identifier))
                {
                    index = getDS.Tables[getTable].Rows.IndexOf(dr);
                }
            }
            return index;
        }

        //Dynamically Updates any entity values that calls this method
        public bool Update(Dictionary<string, object> values, string identifier, string _table = null)
        {
            try
            {
                foreach (var item in values)
                {
                    ds.Tables[_table ?? table].Rows[GetRow(ds, _table ?? table, identifier)][item.Key] = item.Value;

                }
                return db.Write(ds, _table ?? table);

            }
            catch (SqlException e) { throw new Exception(e.Message); }

        }
        //Dynamically deletes any entity row that calls this method
        public bool Delete(string identifier, string _table = null)
        {

            try
            {
                ds.Tables[_table ?? table].Rows[GetRow(ds, _table ?? table, identifier)].Delete();
                return db.Write(ds, _table ?? table);

            }
            catch (SqlException e) { throw new Exception(e.Message); }

        }

        public static DataRow Search(string identifier, string _table)
        {

            GetData(_table);

            int index = -1;
            ds.Tables[_table].PrimaryKey = new DataColumn[] { ds.Tables[_table].Columns[0] };
            foreach (DataRow dr in ds.Tables[_table].Rows)
            {
                if (dr == ds.Tables[_table].Rows.Find(identifier))
                {
                    index = (int)ds.Tables[_table].Rows.IndexOf(dr);
                }
            }
            return ds.Tables[_table].Rows[index];
        }
        public static DataRow SearchByName(string column, string value, string _table)
        {
            int index = -1;
            foreach (DataRow dr in ds.Tables[_table].Rows)
            {
                //Check for matching row and column then returns the first value
                if (dr == ds.Tables[_table].Select(column + " = '" + value + "'").FirstOrDefault())
                {
                    return ds.Tables[_table].Rows[ds.Tables[_table].Rows.IndexOf(dr)];
                }
            }
            return null;
        }
        #endregion

    }
}

