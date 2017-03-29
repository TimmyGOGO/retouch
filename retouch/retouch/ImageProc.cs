using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Windows.Forms;

namespace retouch
{
    public struct toch
    {
        public int R;
        public int O;
    }

    struct cirToch
    {
        public int A;
        public int B;
        public int R;
    }

    //обработка изображений и дополнительные алгоритмы
    public class ImageProc
    {
        //convert to grayscale image
        public static void ToGrayScale(ref Bitmap img){
            Int32 W = img.Width;
            Int32 H = img.Height;

            BitmapData bmData = img.LockBits(new Rectangle(0, 0, W, H), 
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
            unsafe
            {
                byte* ptr = (byte*)bmData.Scan0;

                for (int y = 0; y < H; y++)
                {
                    for (int x = 0; x < W; x++)
                    {
                        byte r = ptr[0];
                        byte g = ptr[1];
                        byte b = ptr[2];

                        byte gray = (byte)(0.30 * r + 0.59 * g + 0.11 * b);

                        ptr[0] = (byte)gray;
                        ptr[1] = (byte)gray;
                        ptr[2] = (byte)gray;
                        ptr += 3;
                    }
                    ptr += bmData.Stride - W * 3;
                }
            }
            img.UnlockBits(bmData);

        }
        
        //get full histogram of an image:
        public static void getFullHistogramm(out int[] hist, Bitmap bmp)
        {
            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //histogramm definition:
            hist = new int[256];

            unsafe
            {
                byte* ptr = (byte*)bmData.Scan0;

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        hist[(int)(ptr[0])]++; //red
                        ptr += 3;
                    }
                    ptr += bmData.Stride - bmp.Width * 3;
                }
            }
            bmp.UnlockBits(bmData);

        }
        
        //compute an entropy of an image:
        public static double calculateEntropy(Bitmap bmp)
        {
            int[] hist = null;
            getFullHistogramm(out hist, bmp);

            long N = bmp.Width * bmp.Height;

            double H = 0.0;

            for (int i = 0; i < 256; i++)
            {
                if (hist[i] != 0)
                {
                    H += hist[i] * Math.Log((double)(N / hist[i]), 2.0);
                }
            }
            H /= N;

            return Math.Abs(H);
        }

        //основной алгоритм Хаффа (составление таблицы H):
        public static ArrayList doLineSearch(ref Bitmap img)
        {
            //1. Предварительные вычисления:
            Int32 w = img.Width;
            Int32 h = img.Height;

            double temp = Math.Pow((double)w, 2.0) + Math.Pow((double)h, 2.0);
            int rmax = (int)(Math.Sqrt( temp )) + 1;
            int omax = 360;

            //2. занулим массив H:
            int[,] H = new int[rmax, omax];
            for(int i = 0; i < rmax; i++){
                for(int j = 0; j < omax; j++){
                    H[i,j] = 0;
                }        
            }   

            //3. цикл по черным точкам:
            BitmapData bmData = img.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* ptr = (byte*)bmData.Scan0;

                //массив по всем точкам растра:
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        //если точка черная:
                        if (ptr[0] == 0 && ptr[1] == 0 && ptr[2] == 0)
                        {
                            for (int T = 0; T < omax; T++)
                            {
                                double angle = Math.PI * T / 180.0;
                                double r = x * Math.Cos(angle) + y * Math.Sin(angle);
                                //MessageBox.Show(T.ToString() + " " + ((int)r).ToString());
                                H[ Math.Abs((int)r) , T]++;
                            }
                        }
                        ptr += 3;
                    }
                    ptr += bmData.Stride - w * 3;
                }
            }
            img.UnlockBits(bmData);

            //определяем порог и вспомогательные структуры
            int p = 90;
            toch point;
            point.R = 0;
            point.O = 0;
            ArrayList passT = new ArrayList();

            //5. находим прямую по выбранной ячейке
            for (int i = 0; i < rmax; i++)
            {
                for (int j = 0; j < omax; j++)
                {
                    if (H[i,j] >= p)
                    {
                        point.R = i;
                        point.O = (j > 180)? 180 - j : j;
                        passT.Add(point);
                    }
                }
            }

            return passT;


        }

        //алгоритм для поиска оружностей на растре
        public static ArrayList doCircleSearch(ref Bitmap img)
        {
            //1. Предварительные вычисления:
            Int32 w = img.Width;
            Int32 h = img.Height;

            double temp = Math.Pow((double)w, 2.0) + Math.Pow((double)h, 2.0);
            int R = (int)(Math.Sqrt(temp)) + 1;
            int A = w;
            int B = h;

            int[, ,] H = new int[w, h, R];
            //2. занулим массив H:
            for (int i = 0; i < A; i++)
            {
                for (int j = 0; j < B; j++)
                {
                    for (int k = 0; k < R; k++)
                    {
                        H[i,j,k] = 0;
                    }
                }
            }
            MessageBox.Show("Hooray!");

            //3. цикл по черным точкам:
            BitmapData bmData = img.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* ptr = (byte*)bmData.Scan0;

                //массив по всем точкам растра:
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        //если точка черная:
                        if (ptr[0] == 0 && ptr[1] == 0 && ptr[2] == 0)
                        {
                            //по всем А:
                            for (int a = 0; a < A; a++)
                            {
                                //по всем В:
                                for (int b = 0; b < B; b++)
                                {
                                    
                                    double r = Math.Sqrt(Math.Pow((double)(x - a), 2.0) + Math.Pow((double)(x - b), 2.0));
                                    //MessageBox.Show(r.ToString());
                                    H[a, b, (int)(r)]++;
                                
                                }
                            }
                            
                        }
                        ptr += 3;
                    }
                    ptr += bmData.Stride - w * 3;
                }
            }
            img.UnlockBits(bmData);

            //определяем порог и вспомогательные структуры
            int p = 100;
            cirToch point;
            point.A = 0;
            point.B = 0;
            point.R = 0;
            ArrayList passT = new ArrayList();

            //5. находим окружность по выбранной ячейке
            for (int i = 0; i < A; i++)
            {
                for (int j = 0; j < B; j++)
                {
                    for (int k = 0; k < R; k++)
                    {
                        if (H[i, j, k] >= p)
                        {
                            point.A = i;
                            point.B = j;
                            point.R = k;
                            passT.Add(point);
                        }
                    }
                }
            }
            //6. что можно считать окружностью?
            
            return passT;

        }
        

        public void MyActions()
        {
            //1. для каждой точки на растре
            /* в предположении что мы рисуем O( 360 ) прямых
               нарисовать на другом растре характерный график:
                r= 0...sqrt(w^2 + h^2)
                O = 0...359
                
                O = 180/0 => r = r0
                O = 90 => r = 0
                
             * осталось придумать перевод координат -> и все)
               
               координатная плоскость: O x r
            */


        }




        internal static void doLineSearch(Bitmap originBit, int[,] H)
        {
            throw new NotImplementedException();
        }
    }
}
