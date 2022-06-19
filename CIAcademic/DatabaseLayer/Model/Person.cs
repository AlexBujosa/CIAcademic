using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIAcademic.DatabaseLayer.Model
{
    public class Person
    {
        public int ID_Person { get; set; }
        public string Name_Person { get; set; }
        public string LastName_Person { get; set; }
        public string Email_Person { get; set; }
        public string Password { get; set; }
        public int Rol_Person { get; set; }

    }
}
