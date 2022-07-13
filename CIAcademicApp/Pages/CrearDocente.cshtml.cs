using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class CrearDocenteModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public static DataSet dataSet { get; set; }
        public void ObtenerProfesoresFiltradas(string codigo)
        {
            if (codigo == null)
                codigo = "";
            try
            {
                ViewData["Profesores"] = dataSet.Tables[0].AsEnumerable()
                               .Where(row => row.Field<string>("Name_Person")
                               .ToString().ToLower()
                               .Contains(codigo.ToLower()) || row.Field<string>("LastName_Person").ToString().ToLower().Contains(codigo.ToLower())).CopyToDataTable();
            }
            catch
            {
                DataTable table = new DataTable();
                ViewData["Profesores"] = table;
            }

        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            ObtenerProfesor();
            ViewData["Profesores"] = dataSet.Tables[0];
            ViewData["Iteracion"] = 1;
            ViewData["Search"] = "";
        }
        public void OnPostChange(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Profesores"] = dataSet.Tables[0];
            else
                ObtenerProfesoresFiltradas(search);
            ViewData["Iteracion"] = iter + 1;
            ViewData["Search"] = search;
        }
        public void OnPostChangeMinus(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Profesores"] = dataSet.Tables[0];
            else
                ObtenerProfesoresFiltradas(search);
            ViewData["Iteracion"] = iter - 1;
            ViewData["Search"] = search;
        }
        public void OnPostFilter(string search)
        {
            ObtenerProfesoresFiltradas(search);
            ViewData["Search"] = search;
            ViewData["Iteracion"] = 1;
        }
        public void ObtenerProfesor()
        {
            User user = new User();
            DataSet set = user.ObtenerProfesores();
            dataSet = set;
        }
    }
}
