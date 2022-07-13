using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class ConsultarDocenteAdministradorModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public static DataSet DataSet { get; set; }
        [BindProperty]
        [Required]
        public int Id { get; set; }
        public void ObtenerUnProfesor(int id)
        {
            User user = new User();
            DataSet ds = user.ObtenerUnProfesor(id);
            DataSet = ds;

        }
        public void OnGet(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            ObtenerUnProfesor(id);
            ViewData["ID"] = id;
            ViewData["Name"] = DataSet.Tables[0].Rows[0][1];
            ViewData["LastName"] = DataSet.Tables[0].Rows[0][2];
            ViewData["Email"] = DataSet.Tables[0].Rows[0][3];
            ViewData["Asignaturas"] = DataSet.Tables[1].Rows[0][0];
            ViewData["Estudiantes"] = DataSet.Tables[2].Rows[0][0];
        }
        public async Task OnPost()
        {
            Administrator administrator = new Administrator();
            Task<int> value = administrator.EliminarPersona(Id);
            int result = await value;
            if (result == 1)
            {
                ViewData["Message"] = "Se ha eliminado el docente " + DataSet.Tables[0].Rows[0][1] + " " + DataSet.Tables[0].Rows[0][2];
            }
            Thread.Sleep(2000);
            ViewData["ID"] = Id;
            ViewData["Name"] = DataSet.Tables[0].Rows[0][1];
            ViewData["LastName"] = DataSet.Tables[0].Rows[0][2];
            ViewData["Email"] = DataSet.Tables[0].Rows[0][3];
            ViewData["Asignaturas"] = DataSet.Tables[1].Rows[0][0];
            ViewData["Estudiantes"] = DataSet.Tables[2].Rows[0][0];
            Response.Redirect("CrearDocente");
        }
    }
}
