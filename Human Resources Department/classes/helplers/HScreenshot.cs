using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Human_Resources_Department.classes.helplers
{
    class HScreenshot
    {
        public static void CreateWithDialog(Control c)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Image Files(*.jpg, *.png) | *.jpg; *.png"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(c.Width);
                int height = Convert.ToInt32(c.Height);

                Bitmap bmp = new Bitmap(width, height);

                c.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
            }
        }
    }
}
