using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIAcademicApp.Pages
{
    public class VistaAdministradorModel : PageModel
    {
        public const string SessionKeyID = "_ID";
        public const string SessionKeyName = "_Name";
        public const string SessionKeyRol = "_Rol";
        public const string SessionKeyEmail = "_Email";
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            ViewData["ID"] = HttpContext.Session.GetInt32(SessionKeyID);
            ViewData["Name"] = HttpContext.Session.GetString(SessionKeyName);
            ViewData["Rol"] = HttpContext.Session.GetString(SessionKeyRol);
            ViewData["Email"] = HttpContext.Session.GetString(SessionKeyEmail);
        }
    }
}
