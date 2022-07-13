using CIAcademicApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CIAcademicApp.Pages
{
    public class IndexModel : PageModel
    {
        public const string SessionKeyID = "_ID";
        public const string SessionKeyName = "_Name";
        public const string SessionKeyRol = "_Rol";
        public const string SessionKeyGeneralIndex = "_GeneralIndex";
        public const string SessionKeyTotalPoints = "_TotalPoints";
        public const string SessionKeyTotalCredits = "_TotalCredits";
        public const string SessionKeyEmail = "_Email";
        private readonly ILogger<IndexModel> _logger;  
        [BindProperty]
        [Required]
        public int ID_User { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(100), MinLength(8)]
        public string Password { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
    
        public void OnGet()
        {
        }
        public void OnPost()
        {
            int result = 0;
            bool valid = false;
            User user = new User();
            DataSet dataSet = user.IniciarSesion(ID_User, Password);
            try
            {
                valid = int.TryParse(dataSet.Tables[0].Rows[0][5].ToString(), out result);
            }
            catch
            {
                Response.Redirect("Index");
            }
            
            if (valid && result == 1)
            {
                _logger.LogInformation("Ha iniciado sesión el estudiante "+ dataSet.Tables[0].Rows[0][1] + " " +dataSet.Tables[0].Rows[0][2]);
                HttpContext.Session.SetInt32(SessionKeyID, int.Parse(dataSet.Tables[0].Rows[0][0].ToString()));
                HttpContext.Session.SetString(SessionKeyName, dataSet.Tables[0].Rows[0][1].ToString());
                HttpContext.Session.SetString(SessionKeyGeneralIndex, dataSet.Tables[0].Rows[0][3].ToString());
                HttpContext.Session.SetString(SessionKeyTotalCredits, dataSet.Tables[0].Rows[0][4].ToString());
                HttpContext.Session.SetString(SessionKeyTotalPoints, dataSet.Tables[0].Rows[0][6].ToString());
                HttpContext.Session.SetString(SessionKeyRol, dataSet.Tables[0].Rows[0][5].ToString());
                Response.Redirect("VistaUsuario");

            }
            else if(valid && result == 2)
            {
                _logger.LogInformation("Ha iniciado sesión el profesor " + dataSet.Tables[0].Rows[0][1] + " " + dataSet.Tables[0].Rows[0][2]);
                HttpContext.Session.SetInt32(SessionKeyID, int.Parse(dataSet.Tables[0].Rows[0][0].ToString()));
                HttpContext.Session.SetString(SessionKeyName, dataSet.Tables[0].Rows[0][1].ToString());
                HttpContext.Session.SetString(SessionKeyRol, dataSet.Tables[0].Rows[0][5].ToString());
                HttpContext.Session.SetString(SessionKeyEmail, dataSet.Tables[0].Rows[0][3].ToString());
                Response.Redirect("VistaProfesor");
            }
            else if (valid && result == 3)
            {
                _logger.LogInformation("Ha iniciado sesión el administrador " + dataSet.Tables[0].Rows[0][1] + " " + dataSet.Tables[0].Rows[0][2]);
                HttpContext.Session.SetInt32(SessionKeyID, int.Parse(dataSet.Tables[0].Rows[0][0].ToString()));
                HttpContext.Session.SetString(SessionKeyName, dataSet.Tables[0].Rows[0][1].ToString());
                HttpContext.Session.SetString(SessionKeyRol, dataSet.Tables[0].Rows[0][5].ToString());
                HttpContext.Session.SetString(SessionKeyEmail, dataSet.Tables[0].Rows[0][3].ToString());
                Response.Redirect("VistaAdministrador");
            }
            else
            {

            }
        }
    }
}
