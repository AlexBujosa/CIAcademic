using System.Data;
using System.Data.SqlClient;

namespace CIAcademicApp.DatabaseLayer
{
    public class Teacher
    {
        public Conexion con;
        public SqlCommand sqlCommand;
        public Teacher()
        {
            con = new Conexion();
        }
        public DataSet PPGetTeacher()
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetTeacher";
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
        public DataSet PPGetOneTeacher(int ID_Teacher)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetOneTeacher";
            sqlCommand.Parameters.AddWithValue("@ID_Teacher", ID_Teacher);
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
        public DataSet PPGetAllMySections(int ID_Teacher)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetAllMySections";
            sqlCommand.Parameters.AddWithValue("@ID_Teacher", ID_Teacher);
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
        public DataSet PPGetMyStudents(int ID_Section)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetMyStudent";
            sqlCommand.Parameters.AddWithValue("@ID_Section", ID_Section);
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
        public int PPGetMyCourseID(int ID_Section)
        {
            DataSet dataSet = new DataSet();
            int ID_Course = 0;
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetMyCourseID";
            sqlCommand.Parameters.AddWithValue("@ID_Section", ID_Section);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = con.sqlConnection;
            var adapter = new SqlDataAdapter(sqlCommand);
            try
            {
                adapter.Fill(dataSet);
                ID_Course = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {

            }
            con.CloseConnection();
            
            return ID_Course;
        }
        public DataSet PPGetMyCourseSection(int ID_Section)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetMyCourse";
            sqlCommand.Parameters.AddWithValue("@ID_Section", ID_Section);
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
        public DataSet PPGetSpecificStudent(int ID_Section, int ID_Student)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetSpecificStudent";
            sqlCommand.Parameters.AddWithValue("@ID_Section", ID_Section);
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
        public DataSet PPGetQualificationStudent(int ID_Section, int ID_Student)
        {
            DataSet dataSet = new DataSet();
            con.OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetQualificationStudent";
            sqlCommand.Parameters.AddWithValue("@ID_Section", ID_Section);
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
