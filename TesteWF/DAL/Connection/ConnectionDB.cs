using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Connection
{
    public class ConnectionDB
    {
        public static IDataReader Reader(string scriptSQL)
        {
            using(SqlConnection connection = GetConnection())
            {
                IDataReader reader = null;
                try
                {
                    using(SqlCommand command = new SqlCommand(scriptSQL, connection))
                    {
                        reader = command.ExecuteReader();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return reader;
            }
        }

        public static IDataReader Reader(string scriptSQL, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                IDataReader reader = null;
                try
                {
                    using (SqlCommand command = new SqlCommand(scriptSQL, connection))
                    {
                        FillParameters(command, parameters);
                        reader = command.ExecuteReader();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return reader;
            }
        }

        public static DataTable GetDataTable(string scriptSQL)
        {
            using (SqlConnection connection = GetConnection())
            {
                DataTable result = new DataTable();
                try
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(scriptSQL, connection))
                    {
                        dataAdapter.Fill(result);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return result;
            }
        }

        public static DataTable GetDataTable(string scriptSQL, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                DataTable result = new DataTable();
                try
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(scriptSQL, connection))
                    {
                        FillParameters(dataAdapter.SelectCommand, parameters);
                        dataAdapter.Fill(result);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return result;
            }
        }

        public static int NonQuery(string scriptSQL)
        {
            using (SqlConnection connection = GetConnection())
            {
                int result;
                try
                {
                    using (SqlCommand command = new SqlCommand(scriptSQL, connection))
                    {
                        result = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return result;
            }
        }

        public static int NonQuery(string scriptSQL, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                int result;
                try
                {
                    using (SqlCommand command = new SqlCommand(scriptSQL, connection))
                    {
                        FillParameters(command, parameters);
                        result = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return result;
            }
        }

        private static void FillParameters(SqlCommand sqlCommand, Dictionary<string, object> parameters)
        {
            try
            {
                foreach (var parameter in parameters)
                {
                    sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private static SqlConnection GetConnection()
        {
            try
            {
                string stringConn = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stringConn);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
