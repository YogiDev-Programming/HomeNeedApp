using DataAccess.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Factories
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(IConnectionStringSettings settings)
        {
            this.connectionString = settings.ConnectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                var conn = new System.Data.SqlClient.SqlConnection();
                if(conn==null)
                {
                    return null;
                }
                conn.ConnectionString = this.connectionString;
                conn.Open();
                return conn;
            }
        }
    }
}
