using System.Data;
using System.Data.SqlClient;

namespace CIAcademicApp.DatabaseLayer
{
    public class Seccion
    {
        public SqlCommand sqlCommand;
        public Conexion con;
        public Seccion()
        {
            con = new Conexion();
        }
        public DataSet PPGetSection()
        {
           
                DataSet dataSet = new DataSet();
                con.OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "ppOnSection";
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
                con.CloseConnection();
                return dataSet;
           
        }
        public async Task<int> PPInsertSection(int ID_Course, int ID_Teacher)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertSection";
            sqlCommand.Parameters.AddWithValue("@ID_Course", ID_Course);
            sqlCommand.Parameters.AddWithValue("@ID_Teacher", ID_Teacher);
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
        public Task<DataSet> PPGetOneSection(int ID)
        {
            return Task.Run(() =>
            {
                DataSet dataSet = new DataSet();
                con.OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "ppGetOneSection";
                sqlCommand.Parameters.AddWithValue("@ID_Section", ID);
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
        public Task<int> PPDeleteSection(int ID_Section)
        {
            return Task.Run(() =>
            {
                con.OpenConnection();
                int Respuesta = 0;
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "ppCloseOneSection";
                sqlCommand.Parameters.AddWithValue("@ID_Section", ID_Section);
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
        public DataSet PPMySections(int ID)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppMySections";
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
        public int ppInsertStudentCourse(int ID_Section, int ID_Student)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertStudentCourse";
            sqlCommand.Parameters.AddWithValue("@ID_Section", ID_Section);
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Student);
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
        }
    }
}
