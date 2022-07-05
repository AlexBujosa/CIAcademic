using System.Text;

namespace CIAcademicApp.DatabaseLayer
{
    public class filestream
    {
        public string path;
        public filestream()
        {
            path =  "info.txt";
        }
        public void Error(string value)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("Time: " + DateTime.Now + ". Error: " + value);
                // Add some information to the file.  
                fs.Write(info, 0, info.Length);
            }
        }
        public void Info(string value)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("Time: " + DateTime.Now + ". Info: " + value);
                // Add some information to the file.  
                fs.Write(info, 0, info.Length);
            }
        }
        public void Fatal(string value)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("Time: " + DateTime.Now + ". Fatal: " + value);
                // Add some information to the file.  
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
