using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CIAcademic.DatabaseLayer
{
    public class Conexion
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString;
        public SqlConnection sqlConnection;
       


        public Conexion(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("CIAcademic");

        }
        public string GetConnStr()
        {
            return ConnectionString;
        }
        public void OpenConnection()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
        }
        public void CloseConnection()
        {
            sqlConnection.Close();
        }
    }
}
