using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class ConsultarSeccionAdministradorModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public  DataSet ds { get; set; }
        [BindProperty]
        [Required]
        public int Id { get; set; }
        public void GetOneSection(int id)
        {
            User user = new User();
            Task<DataSet> dt = user.ObtenerUnaSeccion(id);
            ds = dt.Result;
        }
        
        public void OnGet(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            GetOneSection(id);
            ViewData["ID"] = id;
            ViewData["Key_Course"] = ds.Tables[0].Rows[0][0];
            ViewData["Name_Course"] = ds.Tables[0].Rows[0][1];
            ViewData["Credit"] = ds.Tables[0].Rows[0][2];
            ViewData["Name_Person"] = ds.Tables[0].Rows[0][3];
            ViewData["LastName_Person"] = ds.Tables[0].Rows[0][4];
        }

        public async Task OnPost()
        {
            Administrator administrator = new Administrator();
            Task<int> value = administrator.EliminarSection(Id);
            int result = await value;
            if (result == 1)
            {
                ViewData["Message"] = "Se ha eliminado la seccion" + ViewData["ID"] + " de asignatura " + ViewData["Name_Course"] + " y profesor" + ViewData["Name_Person"] + " " + ViewData["LastName_Person"];
            }
            Thread.Sleep(2000);
            Response.Redirect("CrearSeccion");
        }
    }
}
