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
            //connStr = @"Data Source=TRACKDS1G014723;Initial Catalog=SHSMS;Integrated Security=True";
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
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.Fill(DBConn.ds, _table);
                        DataRow row = new StoredProcedure().GetProcs("sp_GetNewInsert", new Dictionary<string, object>
                    { {"Table",_table} }).Rows[0];
                        ds.Tables[_table].Columns[0].AutoIncrementSeed = (int)row[4] - (int)row[5];

                        //ds.Tables[_table].PrimaryKey = new DataColumn[] { ds.Tables[_table].Columns[0] };
                        //ds.Tables[_table].Columns[0].AutoIncrement = true;



                    }
                }

            }
            return DBConn.ds;
        }
        public bool Write(DataSet updDS, string _table)
        {

            using (conn = new SqlConnection(connStr))
            {
                using (adapter = new SqlDataAdapter("SELECT * FROM " + _table, conn))
                {
                    using (cmd = new SqlCommandBuilder(adapter))
                    {
                        bool sync = adapter.Update(updDS, _table) == 1 ? true : false;
                        DataRow row = new StoredProcedure().GetProcs("sp_GetNewInsert", new Dictionary<string, object>
                    { {"Table",_table} }).Rows[0];
                        ds.Tables[_table].Columns[0].AutoIncrementSeed = (int)row[4] - (int)row[5];
                        return sync;


                    }
                }

            }

        }

    }
}

