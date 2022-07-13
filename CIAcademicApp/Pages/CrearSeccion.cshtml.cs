using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class CrearSeccionModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public static DataTable DataTable { get; set; }
        public static bool value = false;
        public void ObtenerSecciones()
        {
            User user = new User();
            DataSet set = user.ObtenerSecciones();
            DataTable = set.Tables[0];
        }
        public async void CheckTimeOut()
        {
            if (!value)
            {
                ObtenerSecciones();
                value = true;
                value = await AsyncTime();
                CheckTimeOut();
            }
        }
        public void ObtenerSeccionesFiltradas(string codigo)
        {
            if (codigo == null)
                codigo = "";
            try
            {
                ViewData["Secciones"] = DataTable.AsEnumerable()
                               .Where(row => row.Field<string>("Name_Course")
                               .ToString().ToLower()
                               .Contains(codigo.ToLower()) || row.Field<string>("Name_Person").ToString().ToLower().Contains(codigo.ToLower())).CopyToDataTable();
            }
            catch
            {
                DataTable table  = new DataTable();
                ViewData["Secciones"] = table;
            }
           
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            CheckTimeOut();
            ViewData["Secciones"] = DataTable;
            ViewData["Iteracion"] = 1;
            ViewData["Search"] = "";

        }
        public void OnPostChange(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Secciones"] = DataTable;
            else
                ObtenerSeccionesFiltradas(search);
            ViewData["Iteracion"] = iter + 1;
            ViewData["Search"] = search;
        }
        public void OnPostChangeMinus(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Secciones"] = DataTable;
            else
                ObtenerSeccionesFiltradas(search);
            ViewData["Iteracion"] = iter - 1;
            ViewData["Search"] = search;
        }
        public void OnPostFilter(string search)
        {
            ObtenerSeccionesFiltradas(search);
            ViewData["Search"] = search;
            ViewData["Iteracion"] = 1;
        }
        public static Task<bool> AsyncTime()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(10000);
                return false;

            });
        }
    }
}
