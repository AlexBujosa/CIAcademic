using System.Data;
using System.Data.SqlClient;

namespace CIAcademicApp.DatabaseLayer
{
    public class Autenticarse
    {
        public SqlCommand sqlCommand;
        public Conexion con;
        public Autenticarse()
        {
            con = new Conexion();
        }

        public DataSet GetAll(int ID, string Password)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "GetAll";
            sqlCommand.Parameters.AddWithValue("@ID_Person", ID);
            sqlCommand.Parameters.AddWithValue("@Password_Person", Password);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            var da = new SqlDataAdapter(sqlCommand);
            try
            {
                da.Fill(dataSet);
            }
            catch (Exception ex)
            {

            }
            return dataSet;
        }
    }
}
