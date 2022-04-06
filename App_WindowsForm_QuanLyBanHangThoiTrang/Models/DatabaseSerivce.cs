using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.ReportingServices.Diagnostics.Internal;

namespace Models
{
    public class DatabaseSerivce
    {
        public const string connectionString = @"Data Source=(local);Initial Catalog=ProjectTeamBDKT;User ID=sa;Password=123456";
        public SqlConnection connection;
        public SqlCommand command;
        public DatabaseSerivce()
        {
            connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlDataReader ReadData(string sql)
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public SqlDataAdapter Adapter(string sql)
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            return Adapter;
        }
        public SqlDataAdapter AdapterMore(string sql, SqlParameter[] pars)
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            SqlDataAdapter Adapter = new SqlDataAdapter();
            return Adapter;
        }
        public SqlDataReader ReadDataPars(string sql, SqlParameter[] pars )
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            SqlDataReader reader = command.ExecuteReader();
            return reader;

        }
        public bool Excute(string sql, SqlParameter[] pars)
        {
            bool success = false;
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            success = command.ExecuteNonQuery() > 0;
            return success;
        }

    }
}