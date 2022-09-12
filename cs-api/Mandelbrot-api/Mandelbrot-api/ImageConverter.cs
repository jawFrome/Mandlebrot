

namespace Mandelbrot_api
{
    using System.Drawing;

    public class ImageConverter
    {
        public static byte[] ToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }
    }
}
