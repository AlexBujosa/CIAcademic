using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class AsignaturasProfesorModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyID = "_ID";
        public static int SessionID { get; set; }
        public DataTable TblSections { get; set; }
        public void GetMySections()
        {
            Teacher teacher = new Teacher();
            DataSet ds = new DataSet();
            ds = teacher.ObtenerTodasMisSecciones(SessionID);
            try
            {
                TblSections = ds.Tables[0];
            }
            catch
            {
                TblSections = new DataTable();
            }

        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            string S = HttpContext.Session.GetInt32(SessionKeyID).ToString();
            SessionID = int.Parse(S);
            GetMySections();
            ViewData["TblSections"] = TblSections;
        }
    }
}
