using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Linq;

namespace CIAcademicApp.Pages
{
    public class CrearAsignaturaModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public static DataTable DataTable { get; set; }
        public static bool value = false;
       
        public void ObtenerAsignaturas()
        {
            User user = new User();
            DataSet Asignatura = user.ObtenerAsignaturas();
            DataTable = Asignatura.Tables[0];
           
        }
        public async void CheckTimeOut()
        {
            if (!value)
            {
                ObtenerAsignaturas();
                value = true;
                value = await AsyncTime();
                CheckTimeOut();
            }
        }
        public void ObtenerAsignaturasFiltradas(string codigo)
        {
            if (codigo == null)
                codigo = "";
            try
            {
                ViewData["Asignaturas"] = DataTable.AsEnumerable()
               .Where(row => row.Field<string>("Name_Course")
               .ToString().ToLower()
               .Contains(codigo.ToLower()) || row.Field<string>("Key_Course").ToString().ToLower().Contains(codigo.ToLower())).CopyToDataTable();
            }
            catch
            {
                DataTable table = new DataTable();
                ViewData["Asignaturas"] = table;
            }
           
            ViewData["Iteracion"] = 1;
            ViewData["Codigo"] = codigo;
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            CheckTimeOut();
            ViewData["Asignaturas"] = DataTable;
            ViewData["items"] = 0;
            ViewData["Iteracion"] = 1;
            ViewData["Search"] = "";

        }
        public void OnPostChange(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Asignaturas"] = DataTable;
            else
                ObtenerAsignaturasFiltradas(search);
            ViewData["Iteracion"] = iter + 1;
            ViewData["Search"] = search;
        }
        public void OnPostChangeMinus(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Asignaturas"] = DataTable;
            else
                ObtenerAsignaturasFiltradas(search);
            ViewData["Iteracion"] = iter - 1;
            ViewData["Search"] = search;
        }
        public void OnPostFilter(string search)
        {
            ObtenerAsignaturasFiltradas(search);
            ViewData["Search"] = search;
            ViewData["Iteracion"] = 1;
        }
        public static Task<bool> AsyncTime()
        {
            return Task.Run( () =>
            {
                Thread.Sleep(300000);
                return false;

            });
        }

    }
}
