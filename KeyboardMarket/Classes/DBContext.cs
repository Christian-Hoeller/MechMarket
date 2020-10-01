using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace KeyboardMarket.Classes
{
    public class DBContext
    {
        protected string ConnectionString { get; set; }


        public DBContext()
        {
            string password = "";
            this.ConnectionString = "Server=tcp:mysqlserver-keyboardmarket.database.windows.net,1433;" +
                "Initial Catalog=keyboardmarket-database;Persist Security Info=False;" +
                "User ID=ch.hoeller14@gmail.com@mysqlserver-keyboardmarket;" +
                $"Password={password};" +
                "MultipleActiveResultSets=False;Encrypt=True;" +
                "TrustServerCertificate=False;Connection Timeout=30;";
        }

        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }

        public int ExecuteNonQuery(SqlCommand cmd)
        {
            int returnValue = -1;

            try
            {
                using (SqlConnection connection = this.GetConnection())
                {
                    cmd.Connection = connection;
                    returnValue = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //LogException("Failed to ExecuteNonQuery for " + procedureName, ex, parameters);
                throw;
            }

            return returnValue;
        }

        public DataTable GetDataReader(SqlCommand cmd)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = this.GetConnection())
                {
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                //LogException("Failed to GetDataReader for " + procedureName, ex, parameters);
                throw;
            }

            return dt;
        }
    }
}
