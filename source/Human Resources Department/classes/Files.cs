using System.IO;
using System.Text;

namespace Human_Resources_Department.classes
{
    class Files
    {
        public void WriteToFile(string text, string uriFile)
        {
            using ( StreamWriter writer = new StreamWriter(uriFile, true, Encoding.Default) )
            {
                writer.WriteLine(text);
            }
        }
    }
}
