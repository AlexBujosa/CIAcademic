using CIAcademicApp.DatabaseLayer;
using System.Data;

namespace CIAcademicApp.BusinessLayer
{
    public class Administrator
    {
        public Administrator()
        {
           
        }
        public async Task<int> save_User(string Name, string LastName, string Email, string Password, int ID_Rol)
        {
            PersonCrud personCrud = new PersonCrud();
            Task<int> saving = personCrud.ppInsertPerson(Name, LastName, Email, Password, ID_Rol);
            int result = await saving;
            return result;
        }
        public async Task<int> RegistrarAsignatura(string Key, string Name, int Credit)
        {
            Course course = new Course();
            Task<int> respM = course.ppInsertCourse(Key, Name, Credit);
            int resp = await respM;   
            return resp;
        }
        public async Task<int> RegistrarSection(int ID_Course, int ID_Teacher)
        {
            Seccion section = new Seccion();
            Task<int> respM = section.PPInsertSection(ID_Course, ID_Teacher);
            int resp = await respM;
            return resp;
        } 
        public async Task<int> EliminarSection(int ID_Section)
        {
            Seccion section = new Seccion();
            Task<int> respM = section.PPDeleteSection(ID_Section);  
            int resp = await respM;
            return resp;
        } 
        public async Task<int> EliminarPersona(int ID_Person)
        {
            PersonCrud personCrud = new PersonCrud();
            Task<int> respM = personCrud.ppDeletePerson(ID_Person);
            int resp = await respM;
            return resp;
        }
    }
}
