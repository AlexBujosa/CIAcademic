using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages.Shared
{
    public class EstudiantesAsignaturasModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionSectionID = "_SectionID";
        public static int SectionID { get; set; }
        public static DataTable TblMyStudents { get; set; }
        public void GetMyStudents()
        {
            Teacher teacher = new Teacher();
            DataSet ds = teacher.ObtenerMisEstudiantes(SectionID);
            try
            {
                TblMyStudents = ds.Tables[0];
            }
            catch
            {
                TblMyStudents = new DataTable();
            }
        }
        public void ObtenerAsignaturasFiltradas(string codigo)
        {
            if (codigo == null)
                codigo = "";
            try
            {
                ViewData["TblMyStudents"] = TblMyStudents.AsEnumerable()
               .Where(row => row.Field<string>("Name_Person")
               .ToString().ToLower()
               .Contains(codigo.ToLower()) || row.Field<int>("ID_Student")
               .ToString().ToLower()
               .Contains(codigo.ToLower())).CopyToDataTable();
            }
            catch
            {
                DataTable table = new DataTable();
                ViewData["TblMyStudents"] = table;
            }

        }
        public void OnPostFilter(string search)
        {
            ObtenerAsignaturasFiltradas(search);
            ViewData["Search"] = search;
        }
        public void OnGet(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            SectionID = id; 
            HttpContext.Session.SetInt32(SessionSectionID, id);
            GetMyStudents();
            ViewData["TblMyStudents"] = TblMyStudents;
            ViewData["Search"] = "";
        }
    }
}
