using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIAcademicApp.Pages
{
    public class VistaUsuarioModel : PageModel
    {
        public const string SessionKeyID = "_ID";
        public const string SessionKeyName = "_Name";
        public const string SessionKeyRol = "_Rol";
        public const string SessionKeyGeneralIndex = "_GeneralIndex";
        public const string SessionKeyTotalPoints = "_TotalPoints";
        public const string SessionKeyTotalCredits = "_TotalCredits";
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                Response.Redirect("Index");
            }
            ViewData["ID"] = HttpContext.Session.GetInt32(SessionKeyID); 
            ViewData["Name"] = HttpContext.Session.GetString(SessionKeyName);
            ViewData["Rol"] = HttpContext.Session.GetString(SessionKeyRol);
            ViewData["GeneralIndex"] = HttpContext.Session.GetString(SessionKeyGeneralIndex);
            ViewData["TotalPoints"] = HttpContext.Session.GetString(SessionKeyTotalPoints);
            ViewData["TotalCredits"] = HttpContext.Session.GetString(SessionKeyTotalCredits);
        }
    }
}
