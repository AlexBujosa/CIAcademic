using System.Data;
using System.Data.SqlClient;

namespace CIAcademicApp.DatabaseLayer
{
    public class Student
    {
        public Conexion con;
        public SqlCommand sqlCommand;
        public Student()
        {
            con = new Conexion();
        }
        public DataSet PPGetStudent()
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetStudent";
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
        public DataSet PPGetOneStudent(int ID_Student)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetOneStudent";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Student);
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
        public DataSet PPGetCurrentQualification(int ID_Student)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetCurrentQualification";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Student);
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
        public DataSet PPGetHistoryQualification(int ID_Student)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetHistoryQualification";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Student);
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
        public DataSet PPGetStudentCourses(int ID_Student)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetStudentCourses";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Student);
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
        public DataSet PPGetwithdrawableCourses(int ID_Student)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetwithdrawableCourses";
            sqlCommand.Parameters.AddWithValue("@ID_Student", ID_Student);
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
    }
}
