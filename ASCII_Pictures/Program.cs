using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ASCII_Pictures
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images(*.bmp, *.png, *.jpg, *.JPEG) | *.bmp; *.png; *.jpg; *.JPEG"
            };

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Images(*.bmp, *.png, *.jpg, *.JPEG) | *.bmp; *.png; *.jpg; *.JPEG"
            };

            Console.WriteLine("Нажмите Enter для старта...\n");
            Console.ReadLine();

            while (true)
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    break;

                Console.Clear();

                var bitmapWB = new Bitmap(openFileDialog.FileName).Resize(480).ToGrayScale();

                var converter = new BitmapASCIIConverter(bitmapWB);

                var rows = converter.Convert();

                foreach (var row in rows)
                {
                    Console.WriteLine(row);
                }

                Console.SetCursorPosition(0, 0);

                Console.ReadLine();

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    continue;
                }
                var rowsNegative = converter.ConvertNegative();

                File.WriteAllLines(saveFileDialog.FileName, rowsNegative.Select(r => new string(r)));

            }
        }

    }
}
