using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class CalificacionesModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyID = "_ID";
        public static int SessionID { get; set; }  
        public DataTable TblCurrentQualification { get; set; }
        public void GetMyCurrentQualification()
        {
            Student student = new Student();
            DataSet ds = new DataSet();
            ds = student.MisCalificacionesActuales(SessionID);
            try
            {
                TblCurrentQualification = ds.Tables[0];
            }
            catch
            {
                TblCurrentQualification = new DataTable();
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
            GetMyCurrentQualification();
            ViewData["TblCurrent"] = TblCurrentQualification;
        }
    }
}
