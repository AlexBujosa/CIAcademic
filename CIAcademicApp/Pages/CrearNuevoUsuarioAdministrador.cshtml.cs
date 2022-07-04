using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CIAcademicApp.Pages
{
    public class CrearNuevoUsuarioAdministradorModel : PageModel
    {

        public string Message { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(35), MinLength(3)]   

        public string Name { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(35), MinLength(3)]
        public string LastName { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(100), MinLength(10)]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Rol { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(100), MinLength(8)]
        public string Password { get; set; }


        public void OnGet()
        {
            Message = "In get Used";
            ViewData["Message"] = Message;
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "Error";
                ViewData["Message"] = Message;
            }
            else
            {
                Message = "In Post used";
                ViewData["Message"] = Message + $" Su nombre es {Name}, apelido {LastName}, Email {Email}. Rol: {Rol}";
            }
            
          
        }
    }
}
