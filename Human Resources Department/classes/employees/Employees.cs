using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Human_Resources_Department.classes.employees
{
    class Employees
    {
        private static Image img;
        public static bool isOpen;

        /// <summary>
        /// Get the picture of the active employee from the folder in the format (JPG|PNG).
        /// </summary>
        public static Image GetImage(int id)
        {
            CloseImage();

            string path = Config.currentFolder + "\\img\\" + id;

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

        public static void AddImage(int id)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Image Files(*.JPG, *.PNG) | *.JPG; *.PNG"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string pathImage = dialog.FileName;

                try
                {
                    File.Copy(
                        pathImage,
                        Config.currentFolder + "\\img\\" + id + Path.GetExtension(pathImage)
                    );
                }
                catch { }
            }
        }

        public static void DeleteImage(int id)
        {
            CloseImage();

            string path = Config.currentFolder + "\\img\\" + id;

            try
            {
                if ( File.Exists(path + ".jpg") )
                    File.Delete(path + ".jpg");
                else if ( File.Exists(path + ".png") )
                    File.Delete(path + ".png");
            }
            catch { MessageBox.Show("Зображення використовується"); }
        }

        public static void CloseImage()
        {
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
        }

        public static string GetInitial(string name)
        {
            if (name.Length > 0)
                return name.Substring(0, 1);

            return "";
        }
    }
}
