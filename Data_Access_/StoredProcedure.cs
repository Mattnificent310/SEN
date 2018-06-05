using Data_Access_Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //Dynamic stored procedure struct that takes any stored procedure name 
    //and parameters with values then executes
    struct ParamData
    {
        public string pName;
        public object pValue;
        public ParamData(string pName, object pValue)
        {
            this.pName = pName;

            this.pValue = pValue;

        }

    }
    public class StoredProcedure
    {
        private string sProcName;
        private ArrayList sParams = new ArrayList();
        /// <summary>
        /// set the parameters
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pDataType"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        /// 

        public void SetParam(string pName, object pValue)
        {

            ParamData pData = new ParamData(pName, pValue);
            sParams.Add(pData);
        }

        /// <summary>
        /// get the Parameter list
        /// </summary>
        /// <returns></returns>
        public ArrayList GetParams()
        {
            if (!(sParams == null))
            {
                return sParams;
            }
            else
            {
                return null;

            }

        }

        public string ProcName
        {
            get
            {
                return sProcName;
            }
            set
            {
                sProcName = value;
            }
        }

        #region Show All
        public DataTable ShowAll(string spName)
        {

            return SelectProcedure(spName);
        }
        #endregion

        #region Add 
        public bool AddProcs(string spName, Dictionary<string, object> param)
        {


            StoredProcedureCollection spCol = new StoredProcedureCollection();
            StoredProcedure sp = new StoredProcedure();
            sp.ProcName = spName;
            foreach (var item in param)
            {
                sp.SetParam(item.Key, item.Value);
            }
            spCol.add(sp);
            return ExecuteSps(spCol);

        }
        #endregion

        #region Change
        public bool ChangeProc(string spName, Dictionary<string, object> param)
        {
            StoredProcedureCollection spCol = new StoredProcedureCollection();
            StoredProcedure sp = new StoredProcedure();
            sp.ProcName = spName;
            SqlParameter[] sqlParam = { };
            int i = 0;
            foreach (var item in param)
            {
                sqlParam[i++] =
                        new SqlParameter
                        {
                            ParameterName = item.Key,
                            Value = item.Value
                        };

            }
            spCol.add(sp);
            return InsertProcedure(spName, sqlParam);


        }
        #endregion

        #region Search
        public DataTable GetProcs(string spName, Dictionary<string, object> param)
        {


            StoredProcedureCollection spCol = new StoredProcedureCollection();
            StoredProcedure sp = new StoredProcedure();
            sp.ProcName = spName;
            foreach (var item in param)
            {
                sp.SetParam(item.Key, item.Value);
            }
            spCol.add(sp);
            return SearchProcedure(spCol);



        }
        #endregion

        #region DB Interaction

        #region Connection
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;
        private string conn_string;

        private SqlConnection OpenConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn_string = DBConn.connStr;
            conn = new SqlConnection(conn_string);
            if (conn.State == ConnectionState.Closed || conn.State ==
                        ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }
        #endregion

        #region Stored Procedure Select
        public DataTable SelectProcedure(string _spName)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = _spName;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {

            }
            finally
            {

            }
            return dataTable;
        }

        #endregion

        #region Stored Procedure Search

        public DataTable SearchProcedure(StoredProcedureCollection spCol)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                foreach (StoredProcedure spData in spCol)
                {
                    SqlCommand cmd = new SqlCommand();
                    int i = 0;
                    cmd.Connection = OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spData.ProcName;
                    IEnumerator myEnumerator = spData.GetParams().GetEnumerator();
                    while (myEnumerator.MoveNext())
                    {
                        ParamData pData = (ParamData)myEnumerator.Current;
                        cmd.Parameters.Add(new SqlParameter(pData.pName, pData.pValue));
                        //cmd.Parameters[i].Value = pData.pValue;
                        i++;

                    }
                    cmd.ExecuteNonQuery();

                    myAdapter.SelectCommand = cmd;
                    myAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
            }
            catch (SqlException e)
            {

            }
            finally
            {

            }
            return dataTable;
        }
        #endregion



        #region Stored Procedure Insert
        public bool InsertProcedure(string _spName, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = _spName;
                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand.Parameters.AddRange(sqlParameter);

                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {

                return false;
            }
            finally
            {
            }
            return true;
        }
        #endregion

        #region Stored Procedure Execute

        public bool ExecuteSps(StoredProcedureCollection spCollection)
        {

            try
            {
                foreach (StoredProcedure spData in spCollection)
                {
                    SqlCommand cmd = new SqlCommand();
                    int i = 0;
                    cmd.Connection = OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spData.ProcName;
                    IEnumerator myEnumerator = spData.GetParams().GetEnumerator();
                    while (myEnumerator.MoveNext())
                    {
                        ParamData pData = (ParamData)myEnumerator.Current;
                        cmd.Parameters.Add(new SqlParameter(pData.pName, pData.pValue));
                        //cmd.Parameters[i].Value = pData.pValue;
                        i++;

                    }
                    cmd.ExecuteNonQuery();

                    return true;


                }
            }
            catch (Exception exc)
            {
                return false;
            }
            return false;
        }
        #endregion
        #endregion

    }
}

