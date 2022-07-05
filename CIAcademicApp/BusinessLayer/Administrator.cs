using CIAcademicApp.DatabaseLayer;

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
    }
}
