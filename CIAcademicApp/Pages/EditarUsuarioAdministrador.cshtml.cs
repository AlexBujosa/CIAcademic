using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class EditarEstudianteAdministradorModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public static int Id { get; set; }
        public static DataSet dataSet { get; set; }
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
        [MaxLength(100), MinLength(8)]
        public string Password { get; set; }

        public void ObtenerPersona(int id)
        {
            User user = new User();
            DataSet set = user.ObtenerUnaPersona(id);
            dataSet = set;
        }
        public void OnGet(int id)
        {
            Id = id;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            ObtenerPersona(id);
            ViewData["Name"] = dataSet.Tables[0].Rows[0][0];
            ViewData["LastName"] = dataSet.Tables[0].Rows[0][1];
            ViewData["Email"] = dataSet.Tables[0].Rows[0][2];
            ViewData["Password"] = dataSet.Tables[0].Rows[0][3];

        }
        public void OnPost()
        {
            User user = new User();
            int resp = user.ActualizarPersona(Id, Name,LastName, Email, Password);  
            if(resp > 0)
            {
                ViewData["Message"] = "Se ha actualizado el Id " + Id;
            }
            ViewData["Name"] = Name; ;
            ViewData["LastName"] = LastName;
            ViewData["Email"] = Email;
            ViewData["Password"] = Password;
        }
    }
}
