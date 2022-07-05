using System.Data;
using System.Data.SqlClient;

namespace CIAcademicApp.DatabaseLayer
{
    public class Qualify
    {
        public SqlCommand sqlCommand;
        private IConfiguration configuration;
        public Conexion con;
        static filestream filestream;
        public Qualify()
        {
            con = new Conexion();
            filestream = new filestream();
        }
        public int ppQualify(int ID_Student, int ID_Course, int Qualification, int ID_Equivalent)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppQualify";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Student);
            sqlCommand.Parameters.AddWithValue("@ID_Course", ID_Course);
            sqlCommand.Parameters.AddWithValue("@Qualification", Qualification);
            sqlCommand.Parameters.AddWithValue("@ID_Equivalent", ID_Equivalent);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Hora:  {DateTime.Now}. Se ha calificado a ID: {ID_Student} y de Codigo de asignatura: {ID_Course}");
            }
            catch (Exception ex)
            {
                filestream.Error($"Hora {DateTime.Now}. Error algo ha ocurrido tratando de calificar a ID: {ID_Student} y de Codigo de asignatura: {ID_Course}. Mas detalle del error: {ex}");
            }
            con.CloseConnection();
            return Respuesta;
        }
        public int ppDeleteQualification(int Student_Course, int ID_Student, int ID_Course)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppDeleteQualification";
            sqlCommand.Parameters.AddWithValue("@Student_Course", Student_Course);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Hora:  {DateTime.Now}. Se ha eliminado la calificacion previa de ID: {ID_Student} y de Codigo de asignatura: {ID_Course}");
            }
            catch (Exception ex)
            {
                filestream.Error($"Hora {DateTime.Now}. Error algo ha ocurrido tratando de eliminar la calificacion a ID: {ID_Student} y de Codigo de asignatura: {ID_Course}. Mas detalle del error: {ex}");
            }
            con.CloseConnection();
            return Respuesta;
        }
        public int ppUpdateQualification(int Student_Course, int ID_Student, int Qualification, int ID_Equivalent)
        {
            con.OpenConnection();
            int Respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppUpdateQualification";
            sqlCommand.Parameters.AddWithValue("@Student_Course", Student_Course);
            sqlCommand.Parameters.AddWithValue("@Qualification", Qualification);
            sqlCommand.Parameters.AddWithValue("@ID_Equivalent", ID_Equivalent);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            try
            {
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Hora:  {DateTime.Now}. Se ha actualizado la calificacion previa de ID: {ID_Student}.");
            }
            catch (Exception ex)
            {
                filestream.Error($"Hora {DateTime.Now}. Error algo ha ocurrido tratando de actualizar la calificacion de ID: {ID_Student}. Mas detalle del error: {ex}");
            }
            con.CloseConnection();
            return Respuesta;
        }
    }
}
