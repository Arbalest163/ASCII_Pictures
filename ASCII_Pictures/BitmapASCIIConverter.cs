using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_Pictures
{
    public class BitmapASCIIConverter
    {
        private readonly char[] _asciiTable = { '.', ',', ':', '+', '?', '%', 'S', '#', '@' };
        private readonly char[] _asciiTableNegative = { '@', '#', 'S', '%', '?', '+', ':', ',', '.' };
        private readonly Bitmap _bitmap;

        public BitmapASCIIConverter(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        
        /// <summary>
        /// Конвертировать изображение в двумерный массив символов
        /// </summary>
        /// <returns>Конвертированное изображение</returns>
        public char[][] Convert()
        {
            return Convert(_asciiTable);
        }

        /// <summary>
        /// Конвертировать изображение в двумерный массив символов, переданных в качестве аргумента
        /// </summary>
        /// <param name="characterArray">Массив символов для конвертации</param>
        /// <returns>Конвертированное изображение</returns>
        public char[][] ConvertCustom(char[] characterArray)
        {
            return Convert(characterArray);
        }

        /// <summary>
        /// Конвертировать изображение в двумерный массив символов(Негатив)
        /// </summary>
        /// <returns>Конвертированное изображение</returns>
        public char[][] ConvertNegative()
        {
            return Convert(_asciiTableNegative);
        }

        private char[][] Convert(char[] characterArray)
        {
            var result = new char[_bitmap.Height][];

            for (int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];

                for (int x = 0; x < _bitmap.Width; x++)
                {
                    var mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, characterArray.Length - 1);
                    result[y][x] = characterArray[mapIndex];
                }
            }

            return result;
        }

        private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
        {
            return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
    }
}
