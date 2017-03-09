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
            this.pictureBox1 = new PictureBox();
            this.btnLoad = new Button();
            this.btnGS = new Button();
            this.btnMDefects = new Button();
            this.btnSaveDefects = new Button();
            this.btnPerformRet = new Button();
            this.btnShowDefects = new Button();
            this.textBoxThreshold = new TextBox();
            this.label1 = new Label();
            this.pictureBox2 = new PictureBox();
            this.btnFindWrong = new Button();
            this.btnPerformRetRGB = new Button();
            this.radioButtonPoint = new RadioButton();
            this.radioButtonLine = new RadioButton();
            this.groupBox1 = new GroupBox();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            ((ISupportInitialize)this.pictureBox2).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            this.pictureBox1.Location = new Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(400, 400);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new MouseEventHandler(this.pictureBox1_MouseDown);
            this.btnLoad.Location = new Point(419, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new Size(199, 26);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
            this.btnGS.Location = new Point(418, 45);
            this.btnGS.Name = "btnGS";
            this.btnGS.Size = new Size(199, 27);
            this.btnGS.TabIndex = 3;
            this.btnGS.Text = "To Grayscale";
            this.btnGS.UseVisualStyleBackColor = true;
            this.btnGS.Click += new EventHandler(this.btnGS_Click);
            this.btnMDefects.Location = new Point(6, 65);
            this.btnMDefects.Name = "btnMDefects";
            this.btnMDefects.Size = new Size(188, 29);
            this.btnMDefects.TabIndex = 4;
            this.btnMDefects.Text = "Make defects";
            this.btnMDefects.UseVisualStyleBackColor = true;
            this.btnMDefects.Click += new EventHandler(this.btnMDefects_Click);
            this.btnSaveDefects.Location = new Point(418, 192);
            this.btnSaveDefects.Name = "btnSaveDefects";
            this.btnSaveDefects.Size = new Size(199, 26);
            this.btnSaveDefects.TabIndex = 5;
            this.btnSaveDefects.Text = "Save defects";
            this.btnSaveDefects.UseVisualStyleBackColor = true;
            this.btnSaveDefects.Click += new EventHandler(this.btnSaveDefects_Click);
            this.btnPerformRet.Location = new Point(418, 365);
            this.btnPerformRet.Name = "btnPerformRet";
            this.btnPerformRet.Size = new Size(199, 47);
            this.btnPerformRet.TabIndex = 6;
            this.btnPerformRet.Text = "Perform retouching(Gray)";
            this.btnPerformRet.UseVisualStyleBackColor = true;
            this.btnShowDefects.Location = new Point(418, 224);
            this.btnShowDefects.Name = "btnShowDefects";
            this.btnShowDefects.Size = new Size(199, 34);
            this.btnShowDefects.TabIndex = 5;
            this.btnShowDefects.Text = "Show defects";
            this.btnShowDefects.UseVisualStyleBackColor = true;
            this.btnShowDefects.Click += new EventHandler(this.btnShowDefects_Click);
            this.textBoxThreshold.Location = new Point(418, 284);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new Size(199, 20);
            this.textBoxThreshold.TabIndex = 7;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(418, 261);
            this.label1.Name = "label1";
            this.label1.Size = new Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Threshold:";
            this.pictureBox2.Location = new Point(625, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(400, 400);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.btnFindWrong.Location = new Point(418, 311);
            this.btnFindWrong.Name = "btnFindWrong";
            this.btnFindWrong.Size = new Size(200, 48);
            this.btnFindWrong.TabIndex = 9;
            this.btnFindWrong.Text = "Find wrong pixels";
            this.btnFindWrong.UseVisualStyleBackColor = true;
            this.btnFindWrong.Click += new EventHandler(this.btnFindWrong_Click);
            this.btnPerformRetRGB.Location = new Point(418, 418);
            this.btnPerformRetRGB.Name = "btnPerformRetRGB";
            this.btnPerformRetRGB.Size = new Size(199, 47);
            this.btnPerformRetRGB.TabIndex = 6;
            this.btnPerformRetRGB.Text = "Perform retouching(RGB)";
            this.btnPerformRetRGB.UseVisualStyleBackColor = true;
            this.radioButtonPoint.AutoSize = true;
            this.radioButtonPoint.Location = new Point(6, 19);
            this.radioButtonPoint.Name = "radioButtonPoint";
            this.radioButtonPoint.Size = new Size(49, 17);
            this.radioButtonPoint.TabIndex = 10;
            this.radioButtonPoint.TabStop = true;
            this.radioButtonPoint.Text = "Point";
            this.radioButtonPoint.UseVisualStyleBackColor = true;
            this.radioButtonPoint.CheckedChanged += new EventHandler(this.radioButtonPoint_CheckedChanged);
            this.radioButtonLine.AutoSize = true;
            this.radioButtonLine.Location = new Point(6, 42);
            this.radioButtonLine.Name = "radioButtonLine";
            this.radioButtonLine.Size = new Size(45, 17);
            this.radioButtonLine.TabIndex = 11;
            this.radioButtonLine.TabStop = true;
            this.radioButtonLine.Text = "Line";
            this.radioButtonLine.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add((Control)this.radioButtonPoint);
            this.groupBox1.Controls.Add((Control)this.radioButtonLine);
            this.groupBox1.Controls.Add((Control)this.btnMDefects);
            this.groupBox1.Location = new Point(419, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(200, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defects";
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1037, 471);
            this.Controls.Add((Control)this.groupBox1);
            this.Controls.Add((Control)this.btnFindWrong);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.textBoxThreshold);
            this.Controls.Add((Control)this.btnPerformRetRGB);
            this.Controls.Add((Control)this.btnPerformRet);
            this.Controls.Add((Control)this.btnShowDefects);
            this.Controls.Add((Control)this.btnSaveDefects);
            this.Controls.Add((Control)this.btnGS);
            this.Controls.Add((Control)this.btnLoad);
            this.Controls.Add((Control)this.pictureBox2);
            this.Controls.Add((Control)this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((ISupportInitialize)this.pictureBox1).EndInit();
            ((ISupportInitialize)this.pictureBox2).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

