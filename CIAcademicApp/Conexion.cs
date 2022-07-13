using System.Data.SqlClient;

namespace CIAcademicApp
{
    public class Conexion
    {
        public string ConnectionString = "workstation id=CIAcademic.mssql.somee.com;packet size=4096;user id=AlexBujosa_SQLLogin_1;pwd=xpfqvflfr7;data source=CIAcademic.mssql.somee.com;persist security info=False;initial catalog=CIAcademic";
        public SqlConnection sqlConnection;

        public Conexion()
        {
            sqlConnection = new SqlConnection(ConnectionString);
        }
        public string GetConnStr()
        {
            return ConnectionString;
        }
        public void OpenConnection()
        {
            sqlConnection.Open();
        }
        public void CloseConnection()
        {
            sqlConnection.Close();
        }
    }
}
