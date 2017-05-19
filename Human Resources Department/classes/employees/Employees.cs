using System.IO;
using System.Drawing;

namespace Human_Resources_Department.classes.employees
{
    class Employees
    {
        /// <summary>
        /// Get the picture of the active employee from the folder in the format (JPG|PNG).
        /// </summary>
        public static Image GetImageUrl(object num)
        {
            Image img = null;
            string path = Config.currentFolder + "\\img\\" + num;

            try
            {
                if ( File.Exists(path + ".jpg") )
                    img = Image.FromFile(path + ".jpg");
                else if ( File.Exists(path + ".png") )
                    img = Image.FromFile(path + ".png");
            }
            catch { }

            return img;
        }


    }
}
