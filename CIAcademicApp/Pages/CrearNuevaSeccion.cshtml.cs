using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class CrearNuevaSeccionModel : PageModel
    {
        public static DataTable TableTeacher { get; set; }
        public static DataTable TableCourse { get; set; }
        public static bool Value = false;
        public const string SessionKeyName = "_Name";
        [BindProperty]
        [Required]

        public int ID_Course { get; set; }
        [BindProperty]
        [Required]
        public int ID_Teacher { get; set; }
        public void GetTeacherCourse()
        {
            User user = new User();
            DataSet setTeacher = user.ObtenerProfesores();
            DataSet setCourse = user.ObtenerAsignaturas();
            TableTeacher = setTeacher.Tables[0];
            TableCourse = setCourse.Tables[0];
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            CheckTimeOut();
            ViewData["tblTeacher"] = TableTeacher;
            ViewData["tblCourse"] = TableCourse;
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Error";
            }
            else
            {
                Administrator administrator = new Administrator();
                Task<int> respR = administrator.RegistrarSection(ID_Course, ID_Teacher);
                if (respR.Result == 1)
                {
                    ViewData["Message"] = "Se ha registrado la asignatura";
                    ViewData["tblTeacher"] = TableTeacher;
                    ViewData["tblCourse"] = TableCourse;
                    Thread.Sleep(1000);
                    Response.Redirect("CrearSeccion");
                }


            }
        }
        public async void CheckTimeOut()
        {
            if (!Value)
            {
                GetTeacherCourse();
                Value = true;
                Value = await AsyncTime();
                CheckTimeOut();
            }
        }
        public static Task<bool> AsyncTime()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(300000);
                return false;

            });
        }
    }
}
