using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CIAcademicApp.BusinessLayer;

namespace CIAcademicApp.Pages
{
    public class CrearNuevaAsignaturaModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        [BindProperty]
        [Required]
        [MaxLength(7), MinLength(6)]

        public string CodigoAsignatura { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(50), MinLength(6)]
        public string Asignatura { get; set; }
        [BindProperty]
        [Required]
        public int Creditos { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
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
                Task<int> respR = administrator.RegistrarAsignatura(CodigoAsignatura, Asignatura, Creditos);  
                if(respR.Result == 1)
                {
                    ViewData["Message"] = "Se ha registrado la asignatura";
                    Thread.Sleep(1000);
                    Response.Redirect("CrearAsignatura");
                } 


            }
        }
    }
}
