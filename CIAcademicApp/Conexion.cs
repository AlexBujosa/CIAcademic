using System.Data.SqlClient;

namespace CIAcademicApp
{
    public class Conexion
    {
        public string ConnectionString;
        public SqlConnection sqlConnection;


        public string GetConnStr()
        {
            return ConnectionString;
        }
        public void OpenConnection()
        {
            sqlConnection = new SqlConnection("workstation id=CIAcademic.mssql.somee.com;packet size=4096;user id=AlexBujosa_SQLLogin_1;pwd=xpfqvflfr7;data source=CIAcademic.mssql.somee.com;persist security info=False;initial catalog=CIAcademic");
            sqlConnection.Open();
        }
        public void CloseConnection()
        {
            sqlConnection.Close();
        }
    }
}
