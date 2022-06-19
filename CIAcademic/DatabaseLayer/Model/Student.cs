using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIAcademic.DatabaseLayer.Model
{
    public class Student
    {
        public int ID_Student { get; set; }
        public float General_Index { get; set; }
        public int Accumulated_Credit { get; set; }
        public float Accumulated_Point { get; set; }
    }
}
