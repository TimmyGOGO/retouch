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

        //средства для окрашивания дефектов:
        private Brush defBrush;
        private Pen defPen;
        
        //сохранение дефектов:
        private Bitmap defects;
        private bool[,] caughtDefects;
        
        //режим использования окна (изображение слева)
        private int mode;
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
            defPen = new Pen(Color.Yellow, 1f);

            //режим:
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
                g.FillRectangle(defBrush, new Rectangle(e.X, e.Y, 1, 1));
                g1.FillRectangle(defBrush, new Rectangle(e.X, e.Y, 1, 1));
                pictureBox1.Refresh();
            }
            else if (mode == STAGE_2)
            {
                if (lineStart.X == -1) //если начала линии нет (начинаем рисовать новую)
                {
                    //фиксируем начало линии:
                    lineStart = new Point(e.X, e.Y);
                    g.FillRectangle(defBrush, new Rectangle(e.X, e.Y, 1, 1));
                    g1.FillRectangle(defBrush, new Rectangle(e.X, e.Y, 1, 1));
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
                    int[] r = new int[5]{0,0,0,0,0};
                    for (int m = 0; m < 3; m++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            r[0] += pointMask[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                            //идеальная ретушь для Этуша - 550 (на Черно-белое)
                            //  не работает:
                            
                            r[1] += lineMask[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                            r[2] += lineMask45[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                            r[3] += lineMask90[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                            r[4] += lineMask135[m, l] * (int)currBit.GetPixel(i + m, j + l).R;
                            
                        }
                    }
                    //взятие значений по модулю:
                    for (int m = 0; m < 5; m++) { r[m] = Math.Abs(r[m]); }

                    //сравним максимальное значение отклика с порогом:
                    if (r.Max() >= p)
                    {
                        caughtDefects[i + 1, j + 1] = true;
                    }
                }
            }

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
                        g.FillRectangle(defBrush, new Rectangle(x, y, 1, 1));
                    }
                }
            }
            pictureBox1.Refresh();
        }

        //ретуширование черно-белой фотографии:
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
                        int summ_component = 0;
                        for (int m = -1; m <= 1; m++)
                        {
                            for (int l = -1; l <= 1; l++){
                                if (m != 0 || l != 0){
                                    if (caughtDefects[x+m, y+l] == false)
                                    {
                                        nonDefPixAmount++;
                                        summ_component += (int) currBit.GetPixel(x + m, y + l).R;
                                    }
                                }
                            }
                        }
                        int cP = summ_component / nonDefPixAmount;
                        currBit.SetPixel(x, y, Color.FromArgb(cP, cP, cP));
                    }
                }
            }
            pictureBox1.Refresh();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            currBit = new Bitmap((Image)originBit);
            pictureBox1.Image = (Image)currBit;
            pictureBox1.Refresh();

        }

        
   
    }
}
