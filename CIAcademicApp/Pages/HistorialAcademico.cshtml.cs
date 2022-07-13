using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class HistorialAcademicoModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyID = "_ID";
        public static int SessionID { get; set; }
        public DataTable TblHistory { get; set; }
        public void GetMyHistory()
        {
            Student student = new Student();
            DataSet ds = new DataSet();
            ds = student.MiHistorial(SessionID);
            try
            {
                TblHistory = ds.Tables[0];
            }
            catch
            {
                TblHistory = new DataTable();
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
            GetMyHistory();
            ViewData["TblHistory"] = TblHistory;
        }
    }
}
