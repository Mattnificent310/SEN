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
        private string connStr;

        public DBConn()
        {
            connStr = @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=SHSMSDB;Integrated Security=True";
            ds = new DataSet();

           // adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        }
        public DataSet Read(string _table, string _query = null) //Select the required table from the database
        {
            using (conn = new SqlConnection(connStr))
            {
                using (adapter = new SqlDataAdapter(_query ?? "SELECT * FROM " + _table, conn))
                {
                    using (cmd = new SqlCommandBuilder(adapter))
                    {
                        adapter.Fill(ds, _table);                       

                    }
                }

            }
            return ds;
        }
        public bool Write(DataSet updDS, string _table) //Insert or update changes made to tables 
        {
            bool saved = false;
            using (conn = new SqlConnection(connStr))
            {
                using (adapter = new SqlDataAdapter("SELECT * FROM " + _table, conn))
                {
                    using (cmd = new SqlCommandBuilder(adapter))
                    {
                    using (var cm = new SqlCommand()){  }
                    
                        adapter.Update(updDS, _table);
                        ds.Merge(updDS);
                        ds.AcceptChanges();
                        saved = true;
                    }
                }

            }
            return saved;
        }

    }
}

