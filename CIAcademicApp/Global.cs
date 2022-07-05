using System.Configuration.Assemblies;
namespace CIAcademicApp
{
    public class Global
    {
        public void StartApplication()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
