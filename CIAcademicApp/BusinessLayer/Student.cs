using CIAcademicApp.DatabaseLayer;
using System.Data;

namespace CIAcademicApp.BusinessLayer
{
    public class Student
    {
        public Student()
        {
           
        }
        public DataSet MisSecciones(int ID)
        {
            Seccion seccion = new Seccion();
            DataSet set = seccion.PPMySections(ID);
            return set;
        }
        public int AgregarSeccion(int ID_Section, int ID_Student)
        {
            Seccion seccion = new Seccion();
            int resp = seccion.ppInsertStudentCourse(ID_Section, ID_Student);
            return resp;
        }
        public DataSet MisCalificacionesActuales(int ID_Student)
        {
            DatabaseLayer.Student student = new DatabaseLayer.Student();
            DataSet set = student.PPGetCurrentQualification(ID_Student);
            return set;
        }
        public DataSet MiHistorial(int ID_Student)
        {
            DatabaseLayer.Student student = new DatabaseLayer.Student();
            DataSet set = student.PPGetHistoryQualification(ID_Student);
            return set;
        }
        public DataSet MisCursos(int ID_Student)
        {
            DatabaseLayer.Student student = new DatabaseLayer.Student();
            DataSet set = student.PPGetStudentCourses(ID_Student);
            return set;
        }
        public int Retirar(int ID_Student, int ID_Section, int ID_Course)
        {
            Qualify qualify = new Qualify();
            int resp= qualify.PPQualifyR(ID_Student, ID_Section, ID_Course);
            return resp;
        }
    }
}
