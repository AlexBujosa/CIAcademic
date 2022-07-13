using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class SeleccionarAsignaturaModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyID = "_ID";
        public static List<int> SeccionesId { get; set; }
        public static DataTable DataTable { get; set; }
        public static DataTable MisSecciones { get; set; }

        public static bool value = false;
        public void ObtenerSecciones()
        {
            User user = new User();
            DataSet set = user.ObtenerSecciones();
            DataTable = set.Tables[0];
        }
        public void ObtenerMisSecciones()
        {
            Student student = new Student();
            int id = int.Parse(HttpContext.Session.GetInt32(SessionKeyID).ToString());
            DataSet set = student.MisSecciones(id);
            MisSecciones = set.Tables[0];
            SeccionesId = new List<int>();
            for(int i = 0; i<MisSecciones.Rows.Count; i++)
            {
                SeccionesId.Add(int.Parse(MisSecciones.Rows[i][0].ToString()));
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
                               .Contains(codigo.ToLower()) || row.Field<string>("Name_Person").ToString().ToLower().Contains(codigo.ToLower())
                               || row.Field<string>("LastName_Person").ToString().ToLower().Contains(codigo.ToLower())).CopyToDataTable();
            }
            catch
            {
                DataTable table = new DataTable();
                ViewData["Secciones"] = table;
            }

        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            ObtenerSecciones();
            ObtenerMisSecciones();
            ViewData["MisSecciones"] = SeccionesId ;
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
            ViewData["MisSecciones"] = SeccionesId;
        }
        public void OnPostChangeMinus(int iter, string search)
        {
            if (string.IsNullOrEmpty(search))
                ViewData["Secciones"] = DataTable;
            else
                ObtenerSeccionesFiltradas(search);
            ViewData["Iteracion"] = iter - 1;
            ViewData["Search"] = search;
            ViewData["MisSecciones"] = SeccionesId;
        }
        public void OnPostFilter(string search)
        {
            ObtenerSeccionesFiltradas(search);
            ViewData["Search"] = search;
            ViewData["Iteracion"] = 1;
            ViewData["MisSecciones"] = SeccionesId;
        }
        public void OnPostAddSection(int Seccion)
        {
            int id = int.Parse(HttpContext.Session.GetInt32(SessionKeyID).ToString());
            Student student = new Student();
            int resp = student.AgregarSeccion(Seccion, id);
            ObtenerSecciones();
            ObtenerMisSecciones();
            if (resp == 1)
            {
                ViewData["Message"] = "ha agregado la seccion con id " + Seccion;
            }
            ViewData["Search"] = "";
            ViewData["Iteracion"] = 1;
            ViewData["MisSecciones"] = SeccionesId;
            ViewData["Secciones"] = DataTable;

        }
       
    }
}