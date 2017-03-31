using System;
using System.IO;
using System.Text;

namespace Human_Resources_Department.classes
{
    class Files
    {
        public string errorFile = new Config().projectFolder + "\\error.txt";

        public void WriteToFile(string text, string uriFile, bool cur_time = true)
        {
            using ( StreamWriter writer = new StreamWriter(uriFile, true, Encoding.Default) )
            {
                string time = cur_time ? DateTime.Now.ToString() + "\n" : "";

                writer.WriteLine(time + text + "\n");
            }
        }
    }
}
