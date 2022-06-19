using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIAcademic.DatabaseLayer.Model
{
    public class Student_Course
    {
        public int StudentCourse { get; set; }
        public int ID_Student { get; set; }
        public int ID_Course { get; set; }
        public int Qualification { get; set; }
        public int ID_Equivalent { get; set; }
    }
}
