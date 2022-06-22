using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace CIAcademic.DatabaseLayer
{
    public class Course
    {
        public SqlCommand sqlCommand;
        private IConfiguration configuration;
        public Conexion con;
        static filestream filestream;
        public Course()
        {
            con = new Conexion(configuration);
            filestream = new filestream();
        }
        public int ppInsertCourse(string Key_Course, string Name_Course, int Credit_Course)
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
                Respuesta = sqlCommand.ExecuteNonQuery();
                filestream.Info($"Hora:  {DateTime.Now}. Se ha agregado una nueva Asignatura. Codigo de asignatura {Key_Course}");
            }
            catch (Exception ex)
            {
                filestream.Error($"Hora {DateTime.Now}. Error algo ha ocurrido, tratando de agregar asignatura con codigo {Key_Course}  Mas detalle del error: {ex}");
            }
            con.CloseConnection();
            return Respuesta;
        }
        public int ppUpdateCourse(int ID_Course, string Key_Course, string Name_Course, int Credit_Course)
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
                filestream.Info($"Hora:  {DateTime.Now}. Se ha actualizado la Asignatura con ID: {ID_Course}, nueva Clave: {Key_Course}, nuevo nombre: {Name_Course}, credito: {Credit_Course}.");
            }
            catch (Exception ex)
            {
                filestream.Error($"Hora {DateTime.Now}. Error algo ha ocurrido, tratando de actualizar asignatura ID: {ID_Course}.  Mas detalle del error: {ex}");
            }
            con.CloseConnection();
            return Respuesta;
        }
        public int ppDeleteCourse(int ID_Course)
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
                filestream.Info($"Hora:  {DateTime.Now}. Se ha eliminado la Asignatura con ID: {ID_Course}.");
            }
            catch (Exception ex)
            {
                filestream.Error($"Hora: {DateTime.Now}. Error algo ha ocurrido, tratando de actualizar asignatura ID: {ID_Course}.  Mas detalle del error: {ex}");
            }
            con.CloseConnection();
            return Respuesta;
        }
    }
}
