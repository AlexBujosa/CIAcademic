using CIAcademicApp.BusinessLayer;
using CIAcademicApp.DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class ConsultarAsignaturaAdministradorModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        [BindProperty]
        [Required]
        public int Id { get; set; }
        public async Task OnGet(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            User user = new User();
            Task<DataSet> dt = user.ObtenerAsignatura(id);
            DataSet dataSet = await dt;
            ViewData["ID"] = id;
            ViewData["KeyCourse"] = dataSet.Tables[0].Rows[0][1].ToString();
            ViewData["NameCourse"] = dataSet.Tables[0].Rows[0][2].ToString();
            ViewData["Credit"] = dataSet.Tables[0].Rows[0][3].ToString();
        }
        public async Task OnPost()
        {
            User user = new User();
            Task<int> value = user.EliminarAsignatura(Id);
            int result = await value;
            if(result == 1)
            {
                ViewData["Message"] = "Se ha eliminado la asignatura " + ViewData["KeyCourse"];
            }
            Thread.Sleep(2000);
            Response.Redirect("CrearAsignatura");
        }
    }
}
