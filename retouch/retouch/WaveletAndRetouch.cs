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
                    byte[] color = new byte[3];
                    byte[] color2 = new byte[3];
                    byte[] a = new byte[3];
                    byte[] d = new byte[3];

                    color[0] = (bmp.GetPixel(x, y)).R;
                    color2[0] = (bmp.GetPixel(x + 1, y)).R;
                    color[1] = (bmp.GetPixel(x, y)).G;
                    color2[1] = (bmp.GetPixel(x + 1, y)).G;
                    color[2] = (bmp.GetPixel(x, y)).B;
                    color2[2] = (bmp.GetPixel(x + 1, y)).B;

                    for (int i = 0; i < 3; i++)
                    {
                        a[i] = (byte)((color[i] + color2[i]) / 2);
                        d[i] = (byte)((color[i] - color2[i]) / 2);
                        d[i] = (byte)((d[i] <= threshold) ? 0 : d[i]);   /* Порог обнуления */

                    }

                    res_bmp.SetPixel(k, y, Color.FromArgb(a[0], a[1], a[2]));
                    res_bmp.SetPixel(size / 2 + k, y, Color.FromArgb(d[0], d[1], d[2]));

                }
            }

            bmp = new Bitmap(res_bmp);

            for (int y = 0, k = 0; y < size; y += 2, k++)
            {
                for (int x = 0; x < size; x++)
                {
                    byte[] color = new byte[3];
                    byte[] color2 = new byte[3];
                    byte[] a = new byte[3];
                    byte[] d = new byte[3];

                    color[0] = (bmp.GetPixel(x, y)).R;
                    color2[0] = (bmp.GetPixel(x, y + 1)).R;
                    color[1] = (bmp.GetPixel(x, y)).G;
                    color2[1] = (bmp.GetPixel(x, y + 1)).G;
                    color[2] = (bmp.GetPixel(x, y)).B;
                    color2[2] = (bmp.GetPixel(x, y + 1)).B;

                    for (int i = 0; i < 3; i++)
                    {
                        a[i] = (byte)((color[i] + color2[i]) / 2);
                        d[i] = (byte)((color[i] - color2[i]) / 2);
                        d[i] = (byte)((d[i] <= threshold) ? 0 : d[i]);   /* Порог обнуления */

                    }

                    res_bmp.SetPixel(x, k, Color.FromArgb(a[0], a[1], a[2]));
                    res_bmp.SetPixel(x, size / 2 + k, Color.FromArgb(d[0], d[1], d[2]));

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
                    byte[] a = new byte[3];
                    byte[] d = new byte[3];
                    byte[] y1 = new byte[3];
                    byte[] y2 = new byte[3];

                    a[0] = (bmp.GetPixel(x, k)).R;
                    d[0] = (bmp.GetPixel(x, size / 2 + k)).R;
                    a[1] = (bmp.GetPixel(x, k)).G;
                    d[1] = (bmp.GetPixel(x, size / 2 + k)).G;
                    a[2] = (bmp.GetPixel(x, k)).B;
                    d[2] = (bmp.GetPixel(x, size / 2 + k)).B;

                    for (int i = 0; i < 3; i++)
                    {
                        y1[i] = (byte)(a[i] + d[i]);
                        y2[i] = (byte)(a[i] - d[i]);
                    }

                    res_bmp.SetPixel(x, y, Color.FromArgb(y1[0], y1[1], y1[2]));
                    res_bmp.SetPixel(x, y + 1, Color.FromArgb(y2[0], y2[1], y2[2]));

                }
            }

            bmp = new Bitmap(res_bmp);

            //lines
            for (int y = 0; y < size; y++)
            {
                for (int x = 0, k = 0; x < size; x += 2, k++)
                {
                    byte[] a = new byte[3];
                    byte[] d = new byte[3];
                    byte[] x1 = new byte[3];
                    byte[] x2 = new byte[3];

                    a[0] = (bmp.GetPixel(k, y)).R;
                    d[0] = (bmp.GetPixel(size / 2 + k, y)).R;
                    a[1] = (bmp.GetPixel(k, y)).G;
                    d[1] = (bmp.GetPixel(size / 2 + k, y)).G;
                    a[2] = (bmp.GetPixel(k, y)).B;
                    d[2] = (bmp.GetPixel(size / 2 + k, y)).B;

                    for (int i = 0; i < 3; i++)
                    {
                        x1[i] = (byte)(a[i] + d[i]);
                        x2[i] = (byte)(a[i] - d[i]);
                    }

                    res_bmp.SetPixel(x, y, Color.FromArgb(x1[0], x1[1], x1[2]));
                    res_bmp.SetPixel(x + 1, y, Color.FromArgb(x2[0], x2[1], x2[2]));

                }
            }

            return new Bitmap(res_bmp);

        }

    }
}
