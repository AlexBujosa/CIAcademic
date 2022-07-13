using System.Data;
using System.Data.SqlClient;

namespace CIAcademicApp.DatabaseLayer
{
    public class Course
    {
        public SqlCommand sqlCommand;
        public Conexion con;
        public Course()
        {
            con = new Conexion();
        }
        public DataSet PPGetCourse()
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetCourse";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            var adapter = new SqlDataAdapter(sqlCommand);
            try
            {
                adapter.Fill(dataSet);
            }
            catch(Exception ex)
            {

            }
            con.CloseConnection();
            return dataSet;
        }
        public Task<DataSet> PPGet1Course(int ID)
        {
            return Task.Run(() =>
            {
                DataSet dataSet = new DataSet();
                con.OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "ppGet1Course";
                sqlCommand.Parameters.AddWithValue("@ID_Course", ID);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = con.sqlConnection;
                var adapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {

                }
                return dataSet;
            });
            
        }
        public async Task<int> ppInsertCourse(string Key_Course, string Name_Course, int Credit_Course)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertCourse";
            sqlCommand.Parameters.AddWithValue("@Key_Course", Key_Course);
            sqlCommand.Parameters.AddWithValue("@Name_Course", Name_Course);
            sqlCommand.Parameters.AddWithValue("@Credit_Course", Credit_Course);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {
                Task<int> resp = sqlCommand.ExecuteNonQueryAsync();
                Respuesta = await resp;
               // filestream.Info($"Hora:  {DateTime.Now}. Se ha agregado una nueva Asignatura. Codigo de asignatura {Key_Course}");
            }
            catch (Exception ex)
            {
               // filestream.Error($"Hora {DateTime.Now}. Error algo ha ocurrido, tratando de agregar asignatura con codigo {Key_Course}  Mas detalle del error: {ex}");
            }
            con.CloseConnection();
            return Respuesta;
        }
        public Task<int> ppUpdateCourse(int ID_Course, string Key_Course, string Name_Course, int Credit_Course)
        {
            return Task.Run(() =>
            {
                con.OpenConnection();
                int Respuesta = 0;
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "ppUpdateCourse";
                sqlCommand.Parameters.AddWithValue("@ID_Course", ID_Course);
                sqlCommand.Parameters.AddWithValue("@Key_Course", Key_Course);
                sqlCommand.Parameters.AddWithValue("@Name_Course", Name_Course);
                sqlCommand.Parameters.AddWithValue("@Credit_Course", Credit_Course);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = con.sqlConnection;
                try
                {
                    Respuesta = sqlCommand.ExecuteNonQuery();
                    // filestream.Info($"Hora:  {DateTime.Now}. Se ha actualizado la Asignatura con ID: {ID_Course}, nueva Clave: {Key_Course}, nuevo nombre: {Name_Course}, credito: {Credit_Course}.");
                }
                catch (Exception ex)
                {
                    //filestream.Error($"Hora {DateTime.Now}. Error algo ha ocurrido, tratando de actualizar asignatura ID: {ID_Course}.  Mas detalle del error: {ex}");
                }
                con.CloseConnection();
                return Respuesta;
            });
           
        }
        public Task<int> ppDeleteCourse(int ID_Course)
        {
            return Task.Run(() =>
            {
                con.OpenConnection();
                int Respuesta = 0;
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "ppDeleteCourse";
                sqlCommand.Parameters.AddWithValue("@ID_Course", ID_Course);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = con.sqlConnection;
                try
                {
                    Respuesta = sqlCommand.ExecuteNonQuery();
                    //  filestream.Info($"Hora:  {DateTime.Now}. Se ha eliminado la Asignatura con ID: {ID_Course}.");
                }
                catch (Exception ex)
                {
                    //  filestream.Error($"Hora: {DateTime.Now}. Error algo ha ocurrido, tratando de actualizar asignatura ID: {ID_Course}.  Mas detalle del error: {ex}");
                }
                con.CloseConnection();
                return Respuesta;
            });
           
        }
    }
}
