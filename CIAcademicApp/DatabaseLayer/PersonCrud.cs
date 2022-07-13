using System.Data;
using System.Data.SqlClient;
using log4net;
namespace CIAcademicApp.DatabaseLayer
{
    public class PersonCrud
    {
        public SqlCommand sqlCommand;
        public Conexion con;
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
            sqlCommand.Parameters.AddWithValue("@Active", 1);
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
        public Task<int> ppDeletePerson(int ID_Person)
        {
            return Task.Run(() =>
            {
                con.OpenConnection();
                int Respuesta = 0;
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "ppDeletePerson";
                sqlCommand.Parameters.AddWithValue("@ID_Person", ID_Person);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = con.sqlConnection;
                try
                {
                    Respuesta = sqlCommand.ExecuteNonQuery();
                    logger.Info($"Se ha Eliminado el usuario con ID {ID_Person}");

                }
                catch (Exception er)
                {
                    logger.Info($"Oh oh ha ocurrido un error al tratar de eliminar el usuario con ID {ID_Person}. Mas Detalle del error: {er}");
                }
                con.CloseConnection();
                return Respuesta;
            });
           
        }
        public int ppUpdatePerson(int ID_Person, string Name, string LastName, string Email, string Password)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppUpdatePerson";
            sqlCommand.Parameters.AddWithValue("@ID_Person", ID_Person);
            sqlCommand.Parameters.AddWithValue("@Name_Person", Name);
            sqlCommand.Parameters.AddWithValue("@LastName_Person", LastName);
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
            con.CloseConnection();
            return Respuesta;
           
        }
        public DataSet ppGetOnePerson(int ID)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetOnePerson";
            sqlCommand.Parameters.AddWithValue("@ID_Person", ID);
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
