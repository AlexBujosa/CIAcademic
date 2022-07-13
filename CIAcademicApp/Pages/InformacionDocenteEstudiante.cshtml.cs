using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIAcademicApp.Pages
{
    public class InformacionDocenteEstudianteModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
        }
    }
}
