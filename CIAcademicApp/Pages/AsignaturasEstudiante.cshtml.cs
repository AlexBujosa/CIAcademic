using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class AsignaturasEstudianteModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyID = "_ID";
        public static int SessionID { get; set; }
        public DataTable TblMyCourses { get; set; }
        public void GetMyStudentCourses()
        {
            Student student = new Student();
            DataSet ds = student.MisCursos(SessionID);
            try
            {
                TblMyCourses = ds.Tables[0];
            }
            catch
            {
                TblMyCourses = new DataTable();
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
            GetMyStudentCourses();
            ViewData["TblMyCourses"] = TblMyCourses;
        }
    }
}
