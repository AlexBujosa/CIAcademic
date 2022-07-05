using CIAcademicApp.BusinessLayer;
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
        public int Rol { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(100), MinLength(8)]
        public string Password { get; set; }


        public void OnGet()
        {
            Message = "In get Used";
            ViewData["Message"] = Message;
        }
        public async void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "Error";
                ViewData["Message"] = Message;
            }
            else
            {
                Message = "In Post used";
                Administrator administrator = new Administrator();

                Task<int> result = administrator.save_User(Name, LastName, Email, Password, Rol);
                ViewData["Message"] = "klk";
                int intResult = await result;

                ViewData["Message"] = Message + $" Su nombre es {Name}, apelido {LastName}, Email {Email}. Rol: {Rol}";
            }
            
            
          
        }
    }
}
