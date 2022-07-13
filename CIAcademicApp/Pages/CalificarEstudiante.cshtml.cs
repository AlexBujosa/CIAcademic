using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class CalificarEstudianteModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionSectionID = "_SectionID";
        public static int StudentID { get; set; }   
        public static DataTable CourseSection { get; set; }
        public static DataTable StudentSection { get; set; }
        public static int SectionID { get; set; }
        public static int StudentQualification { get; set; }

        [BindProperty]
        [Required]
        public int Qualification { get; set; }
        public void ObtenerAsignaturaSeccion()
        {
            Teacher teacher = new Teacher();
            DataSet set  = teacher.ObtenerAsignaturaSeccion(SectionID);
            CourseSection = set.Tables[0];
        }
        public void ObtenerEstudianteEspecifico()
        {
            Teacher teacher = new Teacher();
            DataSet set = teacher.ObtenerEstudianteEspecifico(SectionID, StudentID);
            StudentSection = set.Tables[0];
        }
        public void ObtenerCalificacionEstudiante()
        {
            Teacher teacher = new Teacher();
            DataSet set = teacher.ConseguirCalificacionEstudiante(SectionID, StudentID);
            try
            {
                StudentQualification = int.Parse(set.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                StudentQualification = 0;
            }
            
        }
        public void OnGet(int ID)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            SectionID = int.Parse(HttpContext.Session.GetInt32(SessionSectionID).ToString());
            StudentID = ID; 
            ObtenerAsignaturaSeccion();
            ObtenerEstudianteEspecifico();
            ObtenerCalificacionEstudiante();
            ViewData["CourseSection"] = CourseSection;
            ViewData["StudentSection"] = StudentSection;
            ViewData["StudentQualification"] = StudentQualification;
        }
        public void OnPost()
        {
            Teacher teacher = new Teacher();
            int Equivalent = teacher.RtnEquivalent(Qualification);
            int CourseID = int.Parse(CourseSection.Rows[0][0].ToString());
            int resp = teacher.Calificar(StudentID, SectionID, CourseID, Qualification, Equivalent);
            if(resp > 0)
            {
                ViewData["Message"] = "Se ha Calificado o actualizado su calificacion al estudiante " + StudentSection.Rows[0][0].ToString();
                ViewData["CourseSection"] = CourseSection;
                ViewData["StudentSection"] = StudentSection;
                ViewData["StudentQualification"] = Qualification;
            }
        }
    }
}
