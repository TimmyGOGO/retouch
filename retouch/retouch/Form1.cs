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
        
          private const int STAGE_0 = 0;
            private const int STAGE_1 = 1;
            private const int STAGE_2 = 2;
    
            private Bitmap originBit;
    private Bitmap currBit;
    private Graphics g;
    private Graphics g1;
    private Bitmap defects;
    private byte[,] caughtDefects;
    private int mode;
    private Point lineStart;
    private int[,] pointMask;
    private int[,] lineMask;
    private int[,] lineMask45;
    private int[,] lineMask90;
    private int[,] lineMask135;
    private PictureBox pictureBox1;
    private Button btnLoad;
    private Button btnGS;
    private Button btnMDefects;
    private Button btnSaveDefects;
    private Button btnPerformRet;
    private Button btnShowDefects;
    private TextBox textBoxThreshold;
    private Label label1;
    private PictureBox pictureBox2;
    private Button btnFindWrong;
    private Button btnPerformRetRGB;
    private RadioButton radioButtonPoint;
    private RadioButton radioButtonLine;
    private GroupBox groupBox1;

    public Form1()
    {
        InitializeComponent();
      this.originBit = helpFunc.CreateNewBitmap(this.pictureBox1.Width, this.pictureBox1.Height);
      this.currBit = helpFunc.CreateNewBitmap(this.pictureBox1.Width, this.pictureBox1.Height);
      this.pictureBox1.Image = (Image) this.originBit;
      this.pictureBox2.Image = (Image) this.originBit;
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.mode = 0;
      this.lineStart = new Point(-1, -1);
      this.defects = helpFunc.CreateNewBitmap(this.pictureBox1.Width, this.pictureBox1.Height);
      this.caughtDefects = new byte[this.pictureBox1.Width, this.pictureBox1.Height];
      this.clearArray(ref this.caughtDefects, this.pictureBox1.Width, this.pictureBox1.Height);
      this.pointMask = new int[3, 3]
      {
        {
          -1,
          -1,
          -1
        },
        {
          -1,
          8,
          -1
        },
        {
          -1,
          -1,
          -1
        }
      };
      this.lineMask = new int[3, 3]
      {
        {
          -1,
          -1,
          -1
        },
        {
          2,
          2,
          2
        },
        {
          -1,
          -1,
          -1
        }
      };
      this.lineMask45 = new int[3, 3]
      {
        {
          -1,
          -1,
          2
        },
        {
          -1,
          2,
          -1
        },
        {
          2,
          -1,
          -1
        }
      };
      this.lineMask90 = new int[3, 3]
      {
        {
          -1,
          2,
          -1
        },
        {
          -1,
          2,
          -1
        },
        {
          -1,
          2,
          -1
        }
      };
      this.lineMask135 = new int[3, 3]
      {
        {
          2,
          -1,
          -1
        },
        {
          -1,
          2,
          -1
        },
        {
          -1,
          -1,
          2
        }
      };
    }
    
    //Additional methods:
    private void clearArray(ref byte[,] a, int w, int h)
    {
      for (int index1 = 0; index1 < h; ++index1)
      {
        for (int index2 = 0; index2 < w; ++index2)
          a[index2, index1] = (byte) 0;
      }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Image Files (*.BMP, *.JPG, *.PNG)|*.jpg;*.bmp;*.png";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.originBit = new Bitmap(openFileDialog.FileName);
      this.currBit = new Bitmap(openFileDialog.FileName);
      this.pictureBox1.Image = (Image) this.currBit;
      this.pictureBox2.Image = (Image) this.originBit;
    }

    private void btnGS_Click(object sender, EventArgs e)
    {
      ImageProc.ToGrayScale(ref this.currBit);
      this.pictureBox1.Image = (Image) this.currBit;
    }

    private void btnMDefects_Click(object sender, EventArgs e)
    {
      this.defects = helpFunc.CreateNewBitmap(this.pictureBox1.Width, this.pictureBox1.Height);
      this.g = Graphics.FromImage((Image) this.currBit);
      this.g1 = Graphics.FromImage((Image) this.defects);
      if (this.radioButtonPoint.Checked)
        this.mode = 1;
      else if (this.radioButtonLine.Checked)
      {
        this.mode = 2;
      }
      else
      {
        int num = (int) MessageBox.Show("Choose the type of defect", "Warning!");
      }
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (this.mode == 1)
      {
        this.g.FillRectangle(Brushes.Pink, new Rectangle(e.X, e.Y, 1, 1));
        this.g1.FillRectangle(Brushes.Pink, new Rectangle(e.X, e.Y, 1, 1));
        this.pictureBox1.Refresh();
      }
      else
      {
        if (this.mode != 2)
          return;
        if (this.lineStart.X == -1)
        {
          this.lineStart = new Point(e.X, e.Y);
          this.g.FillRectangle(Brushes.Pink, new Rectangle(e.X, e.Y, 1, 1));
          this.g1.FillRectangle(Brushes.Pink, new Rectangle(e.X, e.Y, 1, 1));
          this.pictureBox1.Refresh();
        }
        else
        {
          this.g.DrawLine(new Pen(Color.Pink, 1f), this.lineStart, e.Location);
          this.g1.DrawLine(new Pen(Color.Pink, 1f), this.lineStart, e.Location);
          this.lineStart = new Point(-1, -1);
          this.pictureBox1.Refresh();
        }
      }
    }

    private void btnSaveDefects_Click(object sender, EventArgs e)
    {
      this.mode = 0;
    }

    private void radioButtonPoint_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButtonPoint.Checked)
        this.mode = 1;
      else
        this.mode = 2;
    }

    private void btnFindWrong_Click(object sender, EventArgs e)
    {
      int num1;
      try
      {
        num1 = int.Parse(this.textBoxThreshold.Text.ToString());
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.Message, "Error!");
        return;
      }
      int width = this.pictureBox1.Width;
      int height = this.pictureBox1.Height;
      this.clearArray(ref this.caughtDefects, this.pictureBox1.Width, this.pictureBox1.Height);
      for (int index1 = 0; index1 < height - 3; ++index1)
      {
        for (int index2 = 0; index2 < width - 3; ++index2)
        {
          int num2 = 0;
          for (int index3 = 0; index3 < 3; ++index3)
          {
            for (int index4 = 0; index4 < 3; ++index4)
              num2 += this.pointMask[index4, index3] * (int) this.currBit.GetPixel(index2 + index4, index1 + index3).R;
          }
          if (num2 >= num1)
            this.caughtDefects[index2 + 1, index1 + 1] = byte.MaxValue;
        }
      }
    }

    private void btnShowDefects_Click(object sender, EventArgs e)
    {
      int width = this.pictureBox1.Width;
      int height = this.pictureBox1.Height;
      for (int y = 0; y < height; ++y)
      {
        for (int x = 0; x < width; ++x)
        {
          if ((int) this.caughtDefects[x, y] == (int) byte.MaxValue)
          {
            this.g.FillRectangle(Brushes.Red, new Rectangle(x, y, 1, 1));
            this.pictureBox1.Refresh();
          }
        }
      }
    }

        
        }
    }
}
