using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIAcademic.DatabaseLayer.Model
{
    public class Section
    {
        public int ID_Section { get; set; }
        public int ID_Course { get; set; }
        public int ID_Teacher { get; set; }
        public int ON { get; set; }
    }
}
