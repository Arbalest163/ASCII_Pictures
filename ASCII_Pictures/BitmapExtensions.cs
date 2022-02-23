using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_Pictures
{
    public static class BitmapExtensions
    {
        /// <summary>
        /// Преобразование изображения в чёрно-белый формат
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns>Ч/б изображение</returns>
        public static Bitmap ToGrayScale(this Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    var average = (pixel.R + pixel.G + pixel.B) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, average, average, average));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Метод изменения размера по указанной ширине с сохранением пропорции
        /// </summary>
        /// <param name="source">Источник изображения</param>
        /// <param name="width">Желаемая ширина</param>
        /// <param name="pixelAspect">Соотношение пикселя в консоли</param>
        /// <returns></returns>
        public static Bitmap Resize(this Bitmap source, int width = 480, float pixelAspect = 11.0f / 24.0f)
        {
            if (width < source.Width)
            {
                var aspect = (float)source.Width / source.Height;
                var newHeight = width / aspect * pixelAspect;
                return new Bitmap(source, new Size(width, (int)newHeight));
            }

            return source;
        }
    }
}
