using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retouch
{
    //алгоритмы для обработки изображений (Bitmap) и ретуширования:
    public class WaveletAndRetouch
    {
        //прямое вейвлет-преобразование
        public static Bitmap waveletFilter(Bitmap bmp, int size, int threshold)
        {
            Bitmap res_bmp = new Bitmap(bmp);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0, k = 0; x < size; x += 2, k++)
                {
                    byte color = (bmp.GetPixel(x, y)).R;
                    byte color2 = (bmp.GetPixel(x + 1, y)).R;
                    byte a = (byte)((color + color2) / 2);
                    byte d = (byte)((color - color2) / 2);
                    d = (byte)((d <= threshold) ? 0 : d);   /* Порог обнуления */

                    res_bmp.SetPixel(k, y, Color.FromArgb(a, a, a));
                    res_bmp.SetPixel(size / 2 + k, y, Color.FromArgb(d, d, d));

                }
            }

            bmp = new Bitmap(res_bmp);

            for (int y = 0, k = 0; y < size; y += 2, k++)
            {
                for (int x = 0; x < size; x++)
                {
                    byte color = (bmp.GetPixel(x, y)).R;
                    byte color2 = (bmp.GetPixel(x, y + 1)).R;
                    byte a = (byte)((color + color2) / 2);
                    byte d = (byte)((color - color2) / 2);
                    d = (byte)((d <= threshold) ? 0 : d);   /* Порог обнуления */

                    res_bmp.SetPixel(x, k, Color.FromArgb(a, a, a));
                    res_bmp.SetPixel(x, size / 2 + k, Color.FromArgb(d, d, d));

                }
            }

            return new Bitmap(res_bmp);

        }

        //обратное вейвлет-преобразование: (уровень преобразования на изображении)
        public static Bitmap reverseWavelet(Bitmap bmp, int size, int level)
        {

            for (int i = level; i > 1; i--)
            {
                size /= 2;
            }

            Bitmap res_bmp = new Bitmap(bmp);

            //columns:
            for (int y = 0, k = 0; y < size; y += 2, k++)
            {
                for (int x = 0; x < size; x++)
                {
                    byte a = (bmp.GetPixel(x, k)).R;
                    byte d = (bmp.GetPixel(x, size / 2 + k)).R;
                    byte y1 = (byte)(a + d);
                    byte y2 = (byte)(a - d);

                    res_bmp.SetPixel(x, y, Color.FromArgb(y1, y1, y1));
                    res_bmp.SetPixel(x, y + 1, Color.FromArgb(y2, y2, y2));

                }
            }

            bmp = new Bitmap(res_bmp);

            //lines
            for (int y = 0; y < size; y++)
            {
                for (int x = 0, k = 0; x < size; x += 2, k++)
                {
                    byte a = (bmp.GetPixel(k, y)).R;
                    byte d = (bmp.GetPixel(size / 2 + k, y)).R;
                    byte x1 = (byte)(a + d);
                    byte x2 = (byte)(a - d);

                    res_bmp.SetPixel(x, y, Color.FromArgb(x1, x1, x1));
                    res_bmp.SetPixel(x + 1, y, Color.FromArgb(x2, x2, x2));

                }
            }

            return new Bitmap(res_bmp);

        }

    }
}
