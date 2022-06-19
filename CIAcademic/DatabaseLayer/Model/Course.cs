using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIAcademic.DatabaseLayer.Model
{
    public class Course
    {
        public int ID_Course { get; set; }
        public string Key_Course { get; set; }
        public string Name_Course { get; set; }
        public int Credit_Course { get; set; }
    }
}
