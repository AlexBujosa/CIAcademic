using System.Data;
using System.Data.SqlClient;

namespace CIAcademicApp.DatabaseLayer
{
    public class PersonCrud
    {
        public SqlCommand sqlCommand;
        private IConfiguration configuration;
        public Conexion con;
        static SqlTransaction transaction = null;
        static filestream filestream;
        public PersonCrud()
        {
            con = new Conexion(configuration);
            filestream = new filestream();
        }
        public int ppInsertPerson(string Name, string LastName, string Email, string Password, int ID_Rol)
        {
            int ID_Person = 0;
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            transaction = con.sqlConnection.BeginTransaction();
            sqlCommand.CommandText = "ppInsertPerson";
            sqlCommand.Parameters.AddWithValue("@Name_Person", Name);
            sqlCommand.Parameters.AddWithValue("@LastName_Person", LastName);
            sqlCommand.Parameters.AddWithValue("@Email_Person", Email);
            sqlCommand.Parameters.AddWithValue("@Password_Person", Password);
            sqlCommand.Parameters.AddWithValue("@ID_Rol", ID_Rol);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            sqlCommand.Transaction = transaction;
            var da = new SqlDataAdapter(sqlCommand);
            try
            {
                da.Fill(dataSet);

                ID_Person = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                transaction.Rollback();
            }

            return ID_Person;
        }
        public int ppInsertTeacher(int ID_Person)
        {
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertTeacher";
            sqlCommand.Parameters.AddWithValue("@ID_Teacher", ID_Person);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            sqlCommand.Transaction = transaction;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Se ha insertado un profesor con ID {ID_Person}");
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            con.CloseConnection();
            return Respuesta;
        }
        public int ppInsertStudent(int ID_Person)
        {
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertStudent";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Person);
            sqlCommand.Parameters.AddWithValue("@General_Index", 4.0);
            sqlCommand.Parameters.AddWithValue("@Accumulated_Credit", 0);
            sqlCommand.Parameters.AddWithValue("@Accumulated_Point", 0);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            sqlCommand.Transaction = transaction;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Se ha insertado un estudiante con ID {ID_Person}");
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            con.CloseConnection();
            return Respuesta;
        }
        public int ppDeleteStudent(int ID_Person)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppDeleteStudent";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Person);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Se ha Eliminado un estudiante con ID {ID_Person}");

            }
            catch (Exception er)
            {
                filestream.Error($"Oh oh ha ocurrido un error al tratar de eliminar a un estudiante con ID {ID_Person}. Mas Detalle del error: {er}");
            }
            con.CloseConnection();
            return Respuesta;
        }
        public int ppUpdatePerson(int ID_Person, string Name, string LastName, string Email, string Password)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppUpdatePerson";
            sqlCommand.Parameters.AddWithValue("@ID_Person", ID_Person);
            sqlCommand.Parameters.AddWithValue("@Name_Person", Name);
            sqlCommand.Parameters.AddWithValue("@Last_Person", LastName);
            sqlCommand.Parameters.AddWithValue("@Email_Person", Email);
            sqlCommand.Parameters.AddWithValue("@Password_Person", Password);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Se ha Actualizado un estudiante con ID {ID_Person}");

            }
            catch (Exception er)
            {
                filestream.Error($"Oh oh ha ocurrido un error al tratar de eliminar a un estudiante con ID {ID_Person}. Mas Detalle del error: {er}");
            }
            return Respuesta;
            con.CloseConnection();
        }
        public int ppDeleteTeacher(int ID_Person)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppDeleteTeacher";
            sqlCommand.Parameters.AddWithValue("@ID_Teacher", ID_Person);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Se ha Eliminado un profesor con ID {ID_Person}");

            }
            catch (Exception er)
            {
                filestream.Error($"Oh oh ha ocurrido un error al tratar de eliminar a un profesor con ID {ID_Person}. Mas Detalle del error: {er}");
            }
            con.CloseConnection();
            return Respuesta;
        }
    }
}
