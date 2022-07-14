using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class RetirarModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyID = "_ID";
        public static int StudentID;
        public static DataTable CoursesR;

        [BindProperty]
        [Required]
        public int Section { get; set; }

        [BindProperty]
        [Required]
        public int Course { get; set; }
        public void ConseguirAsignaturasRetirables()
        {
            Student student = new Student();
            DataSet set = student.ConseguirAsignaturasRetirables(StudentID);
            CoursesR = set.Tables[0];
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            StudentID = int.Parse(HttpContext.Session.GetInt32(SessionKeyID).ToString());
            ConseguirAsignaturasRetirables();
            ViewData["CoursesR"] = CoursesR;
        }
        public void OnPost()
        {
            Student student = new Student();
            int resp = student.Retirar(StudentID, Section, Course);
            if(resp > 0)
            {
                var respTable = (from row in CoursesR.AsEnumerable() where row.Field<int>("ID_Section") == Section select row).CopyToDataTable();
                ViewData["Message"] = "Ha retirado la asignatura " + respTable.Rows[0][1];
            }
            ConseguirAsignaturasRetirables();
            ViewData["CoursesR"] = CoursesR;
        }
    }
}
