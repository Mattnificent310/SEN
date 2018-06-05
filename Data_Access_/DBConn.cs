using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    //Handles the connections to and interactions with the connected databases
    class DBConn
    {
        private static SqlDataAdapter adapter;
        private static SqlConnection conn;
        private static SqlCommandBuilder cmd;
        public static DataSet ds;
        public static string connStr;

        public DBConn()
        {
            connStr = @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHSMS;Integrated Security=True";
            ds = new DataSet();



        }
        public DataSet Read(string _table)
        {
            using (conn = new SqlConnection(connStr))
            {
                using (adapter = new SqlDataAdapter("SELECT * FROM " + _table, conn))
                {
                    using (cmd = new SqlCommandBuilder(adapter))
                    {
                        DBConn.ds = new DataSet();
                        //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.Fill(DBConn.ds, _table);
                        
                        DataRow row = new StoredProcedure().GetProcs("sp_GetAutoIncrement", new Dictionary<string, object>
                        { {"Table",_table} }).Rows[0];
                        ds.Tables[_table].PrimaryKey = new DataColumn[] { ds.Tables[_table].Columns[0] };
                        ds.Tables[_table].Columns[0].AutoIncrement = true;

                        //Sets the auto increment seed to the next available identiy value
                        ds.Tables[_table].Columns[0].AutoIncrementSeed = (long.Parse(row[5].ToString()) - long.Parse(row[6].ToString())+1);
                        //ds.Tables[_table].Columns[0].AutoIncrementStep = (long.Parse(row[5].ToString()) - long.Parse(row[6].ToString())) - long.Parse(row[2].ToString() + 1);
                        
                        


                     }
                }

            }
            return DBConn.ds;
        }
        //Updates the database with all changes made to the local dataset 
        public bool Write(DataSet updDS, string _table)
        {

            using (conn = new SqlConnection(connStr))
            {
                using (adapter = new SqlDataAdapter("SELECT * FROM " + _table, conn))
                {
                    using (cmd = new SqlCommandBuilder(adapter))
                    {
                        return adapter.Update(updDS, _table) == 1 ? true : false;
                    //    DataRow row = new StoredProcedure().GetProcs("sp_GetAutoIncrement", new Dictionary<string, object>
                    //{ {"Table",_table} }).Rows[0];
                    //    ds.Tables[_table].Columns[0].AutoIncrementSeed = long.Parse(row[5].ToString()) - long.Parse(row[6].ToString());
                    //    return sync;

                   
                    }
                }

            }

        }

    }
}

