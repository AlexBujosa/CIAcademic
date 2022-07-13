using CIAcademicApp.DatabaseLayer;
using System.Data;

namespace CIAcademicApp.BusinessLayer
{
    public class Teacher
    {
        public Teacher()
        {
            
        }
        public DataSet ObtenerTodasMisSecciones(int ID_Teacher)
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            DataSet set = teacher.PPGetAllMySections(ID_Teacher);
            return set;
        }
        public DataSet ObtenerMisEstudiantes(int ID_Section)
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            DataSet set = teacher.PPGetMyStudents(ID_Section);
            return set;
        }
        public int ObtenerAsignaturaID(int ID_Section)
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            int resp = teacher.PPGetMyCourseID(ID_Section);
            return resp;
        }
        public DataSet ObtenerAsignaturaSeccion(int ID_Section)
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            DataSet set = teacher.PPGetMyCourseSection(ID_Section);
            return set;
        }
        public DataSet ObtenerEstudianteEspecifico(int ID_Section, int ID_Student)
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            DataSet set = teacher.PPGetSpecificStudent(ID_Section, ID_Student);
            return set;
        }
        public int Calificar(int ID_Student, int ID_Section, int ID_Course, int Qualification, int ID_Equivalent)
        {
            Qualify qualify = new Qualify();
            int resp = qualify.ppQualify(ID_Student, ID_Section, ID_Course, Qualification, ID_Equivalent);
            return resp;
        }
        public DataSet ConseguirCalificacionEstudiante(int ID_Section, int ID_Student)
        {
            DatabaseLayer.Teacher teacher = new DatabaseLayer.Teacher();
            DataSet set = teacher.PPGetQualificationStudent(ID_Section, ID_Student);
            return set;
        }
        public int RtnEquivalent(int Qualification)
        {
            int Equivalent = 0;
            if(Qualification <101 && Qualification > 89)
            {
                Equivalent = 1;
            }else if(Qualification < 90 && Qualification > 84)
            {
                Equivalent = 2;
            }else if (Qualification < 85 && Qualification > 79)
            {
                Equivalent = 3;
            }else if (Qualification < 80 && Qualification > 74)
            {
                Equivalent = 4;
            }else if (Qualification < 75 && Qualification > 69)
            {
                Equivalent = 5;
            }else if (Qualification < 70 && Qualification > 59)
            {
                Equivalent = 6;
            }else
            {
                Equivalent = 7; 
            }
            return Equivalent;
        }
    }

}
