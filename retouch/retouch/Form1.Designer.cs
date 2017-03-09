using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace retouch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGS = new System.Windows.Forms.Button();
            this.btnMDefects = new System.Windows.Forms.Button();
            this.btnSaveDefects = new System.Windows.Forms.Button();
            this.btnPerformRet = new System.Windows.Forms.Button();
            this.btnShowDefects = new System.Windows.Forms.Button();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnFindWrong = new System.Windows.Forms.Button();
            this.btnPerformRetRGB = new System.Windows.Forms.Button();
            this.radioButtonPoint = new System.Windows.Forms.RadioButton();
            this.radioButtonLine = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(419, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(199, 26);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnGS
            // 
            this.btnGS.Location = new System.Drawing.Point(418, 45);
            this.btnGS.Name = "btnGS";
            this.btnGS.Size = new System.Drawing.Size(199, 27);
            this.btnGS.TabIndex = 3;
            this.btnGS.Text = "To Grayscale";
            this.btnGS.UseVisualStyleBackColor = true;
            this.btnGS.Click += new System.EventHandler(this.btnGS_Click);
            // 
            // btnMDefects
            // 
            this.btnMDefects.Location = new System.Drawing.Point(6, 65);
            this.btnMDefects.Name = "btnMDefects";
            this.btnMDefects.Size = new System.Drawing.Size(188, 29);
            this.btnMDefects.TabIndex = 4;
            this.btnMDefects.Text = "Make defects";
            this.btnMDefects.UseVisualStyleBackColor = true;
            this.btnMDefects.Click += new System.EventHandler(this.btnMDefects_Click);
            // 
            // btnSaveDefects
            // 
            this.btnSaveDefects.Location = new System.Drawing.Point(418, 192);
            this.btnSaveDefects.Name = "btnSaveDefects";
            this.btnSaveDefects.Size = new System.Drawing.Size(199, 26);
            this.btnSaveDefects.TabIndex = 5;
            this.btnSaveDefects.Text = "Save defects";
            this.btnSaveDefects.UseVisualStyleBackColor = true;
            this.btnSaveDefects.Click += new System.EventHandler(this.btnSaveDefects_Click);
            // 
            // btnPerformRet
            // 
            this.btnPerformRet.Location = new System.Drawing.Point(418, 365);
            this.btnPerformRet.Name = "btnPerformRet";
            this.btnPerformRet.Size = new System.Drawing.Size(199, 47);
            this.btnPerformRet.TabIndex = 6;
            this.btnPerformRet.Text = "Perform retouching(Gray)";
            this.btnPerformRet.UseVisualStyleBackColor = true;
            this.btnPerformRet.Click += new System.EventHandler(this.btnPerformRet_Click);
            // 
            // btnShowDefects
            // 
            this.btnShowDefects.Location = new System.Drawing.Point(418, 224);
            this.btnShowDefects.Name = "btnShowDefects";
            this.btnShowDefects.Size = new System.Drawing.Size(199, 34);
            this.btnShowDefects.TabIndex = 5;
            this.btnShowDefects.Text = "Show defects";
            this.btnShowDefects.UseVisualStyleBackColor = true;
            this.btnShowDefects.Click += new System.EventHandler(this.btnShowDefects_Click);
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(418, 284);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(199, 20);
            this.textBoxThreshold.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Threshold:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(625, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 400);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnFindWrong
            // 
            this.btnFindWrong.Location = new System.Drawing.Point(418, 311);
            this.btnFindWrong.Name = "btnFindWrong";
            this.btnFindWrong.Size = new System.Drawing.Size(200, 48);
            this.btnFindWrong.TabIndex = 9;
            this.btnFindWrong.Text = "Find wrong pixels";
            this.btnFindWrong.UseVisualStyleBackColor = true;
            this.btnFindWrong.Click += new System.EventHandler(this.btnFindWrong_Click);
            // 
            // btnPerformRetRGB
            // 
            this.btnPerformRetRGB.Location = new System.Drawing.Point(418, 418);
            this.btnPerformRetRGB.Name = "btnPerformRetRGB";
            this.btnPerformRetRGB.Size = new System.Drawing.Size(199, 47);
            this.btnPerformRetRGB.TabIndex = 6;
            this.btnPerformRetRGB.Text = "Perform retouching(RGB)";
            this.btnPerformRetRGB.UseVisualStyleBackColor = true;
            // 
            // radioButtonPoint
            // 
            this.radioButtonPoint.AutoSize = true;
            this.radioButtonPoint.Location = new System.Drawing.Point(6, 19);
            this.radioButtonPoint.Name = "radioButtonPoint";
            this.radioButtonPoint.Size = new System.Drawing.Size(49, 17);
            this.radioButtonPoint.TabIndex = 10;
            this.radioButtonPoint.TabStop = true;
            this.radioButtonPoint.Text = "Point";
            this.radioButtonPoint.UseVisualStyleBackColor = true;
            this.radioButtonPoint.CheckedChanged += new System.EventHandler(this.radioButtonPoint_CheckedChanged);
            // 
            // radioButtonLine
            // 
            this.radioButtonLine.AutoSize = true;
            this.radioButtonLine.Location = new System.Drawing.Point(6, 42);
            this.radioButtonLine.Name = "radioButtonLine";
            this.radioButtonLine.Size = new System.Drawing.Size(45, 17);
            this.radioButtonLine.TabIndex = 11;
            this.radioButtonLine.TabStop = true;
            this.radioButtonLine.Text = "Line";
            this.radioButtonLine.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPoint);
            this.groupBox1.Controls.Add(this.radioButtonLine);
            this.groupBox1.Controls.Add(this.btnMDefects);
            this.groupBox1.Location = new System.Drawing.Point(419, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defects";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1037, 471);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFindWrong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.btnPerformRetRGB);
            this.Controls.Add(this.btnPerformRet);
            this.Controls.Add(this.btnShowDefects);
            this.Controls.Add(this.btnSaveDefects);
            this.Controls.Add(this.btnGS);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
    }
}

