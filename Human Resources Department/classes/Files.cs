using System;
using System.IO;
using System.Text;

namespace Human_Resources_Department.classes
{
    class Files
    {
        public static string errorFile = Config.projectFolder + "\\error.txt";

        public static void WriteToFile(string text, string uriFile, bool cur_time = true)
        {
            using ( StreamWriter writer = new StreamWriter(uriFile, true, Encoding.Default) )
            {
                string time = cur_time ? DateTime.Now.ToString() + "\n" : "";

                writer.WriteLine(time + text + "\n");
            }
        }

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }

        public static void DeleteFile(string path)
        {
            if ( File.Exists(path) )
            {
                File.Delete(path);
            }
        }
    }
}
