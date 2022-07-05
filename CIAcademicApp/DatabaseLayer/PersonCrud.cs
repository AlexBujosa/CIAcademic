using System.Data;
using System.Data.SqlClient;
using log4net;
namespace CIAcademicApp.DatabaseLayer
{
    public class PersonCrud
    {
        public SqlCommand sqlCommand;
        public Conexion con;
        static SqlTransaction transaction = null;
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public PersonCrud()
        {
            con = new Conexion();
        }
        public async Task<int> ppInsertPerson(string Name, string LastName, string Email, string Password, int ID_Rol)
        {
            int Respuesta = 0;
            con.OpenConnection();

            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertPerson";
            sqlCommand.Parameters.AddWithValue("@Name_Person", Name);
            sqlCommand.Parameters.AddWithValue("@LastName_Person", LastName);
            sqlCommand.Parameters.AddWithValue("@Email_Person", Email);
            sqlCommand.Parameters.AddWithValue("@Password_Person", Password);
            sqlCommand.Parameters.AddWithValue("@ID_Rol", ID_Rol);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {

                Task<int> resp = sqlCommand.ExecuteNonQueryAsync();
                Respuesta = await resp;

                if (ID_Rol == 1)
                {
                    logger.Info($"Se ha insertado el estudiante de Nombre " + Name + ", Apellido " + LastName + " y Correo " + Email);
                    
                }else if(ID_Rol == 2)
                {
                    logger.Info($"Se ha insertado el profesor de Nombre " + Name + ", Apellido " + LastName + " y Correo " + Email);
                }
                else if(ID_Rol == 3)
                {
                    logger.Info($"Se ha insertado el administradosr de Nombre " + Name + ", Apellido " + LastName + " y Correo " + Email);
                }

            }
            catch
            {
                string[] type = { "Estudiante", "Profesor", "Administrador" };
                logger.Error($"Oh Oh ha ocurrido un error tratando de registrar un " + type[ID_Rol - 1]);
            }
            con.CloseConnection();
            return Respuesta;
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
                logger.Info($"Se ha insertado un profesor con ID {ID_Person}");
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
                logger.Info($"Se ha insertado un estudiante con ID {ID_Person}");
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
                logger.Info($"Se ha Eliminado un estudiante con ID {ID_Person}");

            }
            catch (Exception er)
            {
                logger.Info($"Oh oh ha ocurrido un error al tratar de eliminar a un estudiante con ID {ID_Person}. Mas Detalle del error: {er}");
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
                logger.Info($"Se ha Actualizado un estudiante con ID {ID_Person}");

            }
            catch (Exception er)
            {
                logger.Info($"Oh oh ha ocurrido un error al tratar de eliminar a un estudiante con ID {ID_Person}. Mas Detalle del error: {er}");
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
                logger.Info($"Se ha Eliminado un profesor con ID {ID_Person}");

            }
            catch (Exception er)
            {
                logger.Info($"Oh oh ha ocurrido un error al tratar de eliminar a un profesor con ID {ID_Person}. Mas Detalle del error: {er}");
            }
            con.CloseConnection();
            return Respuesta;
        }
    }
}
