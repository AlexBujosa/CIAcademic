using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class CrearEstudianteModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public static DataSet dataSet { get; set; }
        public void ObtenerEstudiantesFiltradas(string codigo)
        {
            if (codigo == null)
                codigo = "";
            try
            {
                ViewData["Estudiantes"] = dataSet.Tables[0].AsEnumerable()
                               .Where(row => row.Field<string>("Name_Person")
                               .ToString().ToLower()
                               .Contains(codigo.ToLower()) || row.Field<string>("LastName_Person").ToString().ToLower().Contains(codigo.ToLower())).CopyToDataTable();
            }
            catch
            {
                DataTable table = new DataTable();
                ViewData["Estudiantes"] = table;
            }

        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            ObtenerEstudiante();
            ViewData["Estudiantes"] = dataSet.Tables[0];
            ViewData["Iteracion"] = 1;
            ViewData["Search"] = "";
        }
        public void OnPostChange(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Estudiantes"] = dataSet.Tables[0];
            else
                ObtenerEstudiantesFiltradas(search);
            ViewData["Iteracion"] = iter + 1;
            ViewData["Search"] = search;
        }
        public void OnPostChangeMinus(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Estudiantes"] = dataSet.Tables[0];
            else
                ObtenerEstudiantesFiltradas(search);
            ViewData["Iteracion"] = iter - 1;
            ViewData["Search"] = search;
        }
        public void OnPostFilter(string search)
        {
            ObtenerEstudiantesFiltradas(search);
            ViewData["Search"] = search;
            ViewData["Iteracion"] = 1;
        }
        public void ObtenerEstudiante()
        {
            User user = new User();
            DataSet set = user.ObtenerEstudiante();
            dataSet = set;
        }

    }
}
