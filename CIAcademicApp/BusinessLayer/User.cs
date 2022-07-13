using CIAcademicApp.DatabaseLayer;
using System.Data;
using System.Data.SqlClient;
namespace CIAcademicApp.BusinessLayer
{
    public class User
    {
        public DataSet IniciarSesion(int ID, string Password)
        {
            
            Autenticarse autenticarse = new Autenticarse();
            DataSet set = autenticarse.GetAll(ID, Password);
            return set;
        }
        public DataSet ObtenerAsignaturas()
        {
            Course course = new Course();
            DataSet set = course.PPGetCourse();
            return set;
        }
        public async Task<DataSet> ObtenerAsignatura(int ID)
        {
            Course course = new Course();
            Task<DataSet> dt = course.PPGet1Course(ID);
            DataSet dataSet = await dt;
            return dataSet;   
        }
        public async Task<int> EliminarAsignatura(int ID)
        {
            Course course = new Course();
            Task<int> val = course.ppDeleteCourse(ID);
            int result = await val;
            return result;
        }
        public async Task<int> EditarAsignatura(int ID_Course, string Key_Course, string Name_Course, int Credit_Course)
        {
            Course course = new Course();
            Task<int> val = course.ppUpdateCourse(ID_Course, Key_Course,Name_Course, Credit_Course);
            int result = await val;
            return result;
        }
        public DataSet ObtenerSecciones()
        {
            Seccion seccion = new Seccion();
            DataSet set = seccion.PPGetSection();
            return set;
        }
        public DataSet ObtenerProfesores()
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            DataSet set = teacher.PPGetTeacher();
            return set;
        }
        public Task<DataSet> ObtenerUnaSeccion(int ID)
        {
            Seccion section = new Seccion();
            Task<DataSet> dt = section.PPGetOneSection(ID);
            return dt;
        }
        public DataSet ObtenerEstudiante()
        {
            DatabaseLayer.Student student = new DatabaseLayer.Student();
            DataSet set = student.PPGetStudent();
            return set;
        }
        public DataSet ObtenerUnEstudiante(int ID)
        {
            DatabaseLayer.Student student = new DatabaseLayer.Student();
            DataSet set = student.PPGetOneStudent(ID);
            return set;
        }
        public DataSet ObtenerUnProfesor(int ID)
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            DataSet set = teacher.PPGetOneTeacher(ID);
            return set;
        }
        public DataSet ObtenerUnaPersona(int ID)
        {
            PersonCrud personCrud = new PersonCrud();
            DataSet set = personCrud.ppGetOnePerson(ID);
            return set;
        }
        public int ActualizarPersona(int ID_Person, string Name, string LastName, string Email, string Password)
        {
            PersonCrud personCrud = new PersonCrud();
            int resp = personCrud.ppUpdatePerson(ID_Person, Name, LastName, Email, Password);
            return resp;
        }
    }
}
