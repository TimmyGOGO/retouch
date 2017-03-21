using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace retouch
{
    public partial class Form1 : Form
    {
        //константы состояния (для нанесения дефектов)
        private const int STAGE_0 = 0; //не наносим дефект
        private const int STAGE_1 = 1; //рисуем точку
        private const int STAGE_2 = 2; //рисуем линию 

        
        //работа с основной графикой:
        private Bitmap originBit;
        private Bitmap currBit;
        private Graphics g;
        private Graphics g1;

        //средства для визуализации дефектов:
        private Brush defBrush;
        private Brush defShowBrush;
        private Pen defPen;
        private int size;
        
        //сохранение дефектов:
        private Bitmap defects;
        private bool[,] caughtDefects;
        
        //режим использования окна (изображение слева)
        private int mode;
        //переход на вейвлет
        private bool isWavelet;

        //переменная для учета линий:
        private Point lineStart;
        
        //набор масок:
        private int[,] pointMask;
        private int[,] lineMask;
        private int[,] lineMask45;
        private int[,] lineMask90;
        private int[,] lineMask135;

        public Form1()
        {
            InitializeComponent();
            
            //окна для картинок:
            originBit = helpFunc.CreateNewBitmap(pictureBox1.Width, pictureBox1.Height);
            currBit = helpFunc.CreateNewBitmap(pictureBox1.Width, pictureBox1.Height);
            
            //отображение картинок:
            pictureBox1.Image = (Image) originBit;
            pictureBox2.Image = (Image) originBit;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //цвет для дефектов красный (по умолчанию):
            defBrush = Brushes.Yellow;
            defShowBrush = Brushes.Red;
            defPen = new Pen(Color.Yellow, 1f);

            //размер дефектов:
            radioButton1px.Checked = true;
            size = 1;

            //режим:
            isWavelet = false;
            radioButtonPoint.Checked = true;
            mode = STAGE_0;
            
            //учет линий (-1,-1) - нет начальной точки
            lineStart = new Point(-1, -1);
            
            //сохранение дефектов:
            defects = helpFunc.CreateNewBitmap(pictureBox1.Width, pictureBox1.Height);
            caughtDefects = new bool[pictureBox1.Width, pictureBox1.Height];
            Array.Clear(caughtDefects, 0, caughtDefects.Length);
            
            //инициализация масок:
            pointMask = new int[3, 3]
            {
                {-1,-1,-1},
                {-1,8,-1},
                {-1,-1,-1}
            };
            lineMask = new int[3, 3]
            {
                {-1,-1,-1},
                {2,2,2},
                {-1,1,-1}
            };
            lineMask45 = new int[3, 3]
            {
                {-1,-1,2},
                {-1,2,-1},
                {2,-1,-1}
            };
            lineMask90 = new int[3, 3]
            {
                {-1,2,-1},
                {-1,2,-1},
                {-1, 2,-1}
            };
            lineMask135 = new int[3, 3]
            {
                {2,-1,-1},
                {-1,2,-1},
                {-1,-1,2}
            };

            //для отображения прогресса:
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.BMP, *.JPG, *.PNG)|*.jpg;*.bmp;*.png";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            originBit = new Bitmap(openFileDialog.FileName);
            currBit = new Bitmap(openFileDialog.FileName);
          
            pictureBox1.Image = (Image) currBit;
            pictureBox2.Image = (Image) originBit;
        }

        private void btnGS_Click(object sender, EventArgs e)
        {
            ImageProc.ToGrayScale(ref currBit);
            pictureBox1.Image = (Image) currBit;
        }

        private void btnMDefects_Click(object sender, EventArgs e)
        {
            defects = helpFunc.CreateNewBitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage((Image) currBit);
            g1 = Graphics.FromImage((Image) defects); //прорисовка дефектов на отдельном полотне

            if (radioButtonPoint.Checked)
            {
                mode = STAGE_1;
            }
            else if (radioButtonLine.Checked)
            {
                mode = STAGE_2;
            }
            else
            {
                MessageBox.Show("Choose the type of defect", "Warning!");
            }
        }

        //нанесение дефектов:
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == STAGE_1)
            {
                //рисуем точку, заполняя прямоугольник 1х1:
                g.FillRectangle(defBrush, new Rectangle(e.X, e.Y, size, size));
                g1.FillRectangle(defBrush, new Rectangle(e.X, e.Y, size, size));
                pictureBox1.Refresh();
            }
            else if (mode == STAGE_2)
            {
                if (lineStart.X == -1) //если начала линии нет (начинаем рисовать новую)
                {
                    //фиксируем начало линии:
                    lineStart = new Point(e.X, e.Y);
                    g.FillRectangle(defBrush, new Rectangle(e.X, e.Y, size, size));
                    g1.FillRectangle(defBrush, new Rectangle(e.X, e.Y, size, size));
                    pictureBox1.Refresh();
                }
                else //если начало есть, то фиксируем конец линии:
                {
                    g.DrawLine(defPen, lineStart, e.Location);
                    g1.DrawLine(defPen, lineStart, e.Location);
                    
                    //заполняем точку начала значением (-1,-1) - нет фиксированной точки
                    lineStart = new Point(-1, -1);
                    pictureBox1.Refresh();
                }
            }
        }

        private void btnSaveDefects_Click(object sender, EventArgs e)
        {
            mode = STAGE_0;
        }

        //если изменили тип дефекта:
        private void radioButtonPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPoint.Checked)
            {
                mode = STAGE_1;
            }
            else
            {
                mode = STAGE_2;
            }
                
        }

        //выделим функции поиска и исправления дефектов:
        //private bool[,] findDefectedPixels(Bitmap 

        //найти битые пиксели!
        private void btnFindWrong_Click(object sender, EventArgs e)
        {
            int p; //значение порога
            try
            {
                p = int.Parse(textBoxThreshold.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error of the threshold value!");
                return;
            }

            //для отображения прогресса:
            progressBar1.Value = 0;

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            
            //очистка ранее найденных дефектов:
            Array.Clear(caughtDefects, 0, caughtDefects.Length);
            
            //основной цикл:
            for (int j = 0; j < height - 3; j++)
            {
                for (int i = 0; i < width - 3; i++)
                {
                    //найдем значения откликов по 5-ти маскам:
                    int[,] r = new int[3,5];
                    int gray = (chckBxGrayScale.Checked == true) ? 1 : 3;

                    for (int m = 0; m < 3; m++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            for (int g = 0; g < gray; g++)
                            {
                                r[g, 0] += pointMask[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                                //идеальная ретушь для Этуша - 550 (на Черно-белое)
                                //  не работает:

                                r[g, 1] += lineMask[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                                r[g, 2] += lineMask45[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                                r[g, 3] += lineMask90[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                                r[g, 4] += lineMask135[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                            }
                            
                        }
                    }

                    //взятие значений по модулю и поиск макисмума:
                    int maxR = 0;
                    for (int g = 0; g < gray; g++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            r[g, m] = Math.Abs(r[g, m]);
                            maxR = (r[g,m] > maxR)? r[g,m] : maxR;
                        }
                    }

                    //сравним максимальное значение отклика с порогом:
                    if (maxR >= p)
                    {
                        caughtDefects[i + 1, j + 1] = true;
                    }
                }

                //для отображения прогресса: (при условии что height = 400!)
                if ((j + 1) % 4 == 0) //цикл на 400 итераций, через каждые 4 прибавляется 1% (в итоге - 100%) 
                {
                    progressBar1.Value += 1;
                }
            }

            progressBar1.Value += 1;
            //оповещение:
            MessageBox.Show("Defective pixels have been found!", "All is right", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //показать найденные дефекты:
        private void btnShowDefects_Click(object sender, EventArgs e)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (caughtDefects[x, y] == true)
                    {
                        g.FillRectangle(defShowBrush, new Rectangle(x, y, 1, 1));
                    }
                }
            }
            pictureBox1.Refresh();
        }

        //ретуширование черно-белой/цветной фотографии:
        private void btnPerformRet_Click(object sender, EventArgs e)
        {

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (caughtDefects[x, y] == true)
                    {
                        //восстановление битого пикселя:
                        int nonDefPixAmount = 0;
                        int[] sumPix = new int[3]{0,0,0};

                        for (int m = -1; m <= 1; m++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                if (m != 0 || l != 0) //если элемент не в середине
                                {
                                    if (caughtDefects[x + m, y + l] == false)
                                    {
                                        nonDefPixAmount++;
                                        sumPix[0] += (int)currBit.GetPixel(x + m, y + l).R;
                                        sumPix[1] += (int)currBit.GetPixel(x + m, y + l).G;
                                        sumPix[2] += (int)currBit.GetPixel(x + m, y + l).B;
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            sumPix[i] = sumPix[i] / nonDefPixAmount; 
                        }
                        currBit.SetPixel(x, y, Color.FromArgb(sumPix[0], sumPix[1], sumPix[2]));
                    }
                }

            }
            pictureBox1.Refresh();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            currBit = new Bitmap((Image)originBit);
            pictureBox1.Image = (Image)currBit;
            chckBxGrayScale.Checked = false;
            pictureBox1.Refresh();

        }

        private void chckBxGrayScale_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBxGrayScale.Checked == true)
            {
                ImageProc.ToGrayScale(ref currBit);
                pictureBox1.Image = (Image)currBit;
            }
            else
            {
                currBit = new Bitmap((Image)originBit);
                pictureBox1.Image = (Image)currBit;
                pictureBox1.Refresh();
            }
        }

        private void btnMakeGray_Click(object sender, EventArgs e)
        {
            ImageProc.ToGrayScale(ref currBit);
            pictureBox1.Image = (Image)currBit;
            chckBxGrayScale.Checked = true;
        }

        private void radioButton1px_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1px.Checked)
            {
                size = 1;
                defPen = new Pen(Color.Yellow, 1f);
            }
            else
            {
                size = 2;
                defPen = new Pen(Color.Yellow, 2f);
            }
        }

        private void btnWavelet_Click(object sender, EventArgs e)
        {
            int p; //значение порога
            try
            {
                p = int.Parse(textBoxWavelet.Text.ToString());
                if (p <= 0)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error of wavelet's threshold value!");
                return;
            }

            //переход в серое
            btnMakeGray.PerformClick();
            
            //переход на вейвлет:
            isWavelet = true;
            
            currBit = WaveletAndRetouch.waveletFilter(currBit, p);
            pictureBox1.Image = (Image)currBit;
            pictureBox1.Refresh();

        }

        private void btnRevWavelet_Click(object sender, EventArgs e)
        {
            //переход на вейвлет:
            if (isWavelet == false)
            {
                MessageBox.Show("Check your actions!", "The Wavelet filter hasn't been used on the image!");
                return;
            }

            isWavelet = false;

            currBit = WaveletAndRetouch.reverseWavelet(currBit, 1);
            pictureBox1.Image = (Image)currBit;
            pictureBox1.Refresh();

        }


        
   
    }
}
