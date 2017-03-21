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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnMDefects = new System.Windows.Forms.Button();
            this.btnSaveDefects = new System.Windows.Forms.Button();
            this.btnPerformRet = new System.Windows.Forms.Button();
            this.btnShowDefects = new System.Windows.Forms.Button();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnFindWrong = new System.Windows.Forms.Button();
            this.radioButtonPoint = new System.Windows.Forms.RadioButton();
            this.radioButtonLine = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.chckBxGrayScale = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnMakeGray = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1px = new System.Windows.Forms.RadioButton();
            this.radioButton2px = new System.Windows.Forms.RadioButton();
            this.btnWavelet = new System.Windows.Forms.Button();
            this.btnRevWavelet = new System.Windows.Forms.Button();
            this.textBoxWavelet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // btnMDefects
            // 
            this.btnMDefects.Location = new System.Drawing.Point(418, 139);
            this.btnMDefects.Name = "btnMDefects";
            this.btnMDefects.Size = new System.Drawing.Size(199, 29);
            this.btnMDefects.TabIndex = 4;
            this.btnMDefects.Text = "Make defects";
            this.btnMDefects.UseVisualStyleBackColor = true;
            this.btnMDefects.Click += new System.EventHandler(this.btnMDefects_Click);
            // 
            // btnSaveDefects
            // 
            this.btnSaveDefects.Location = new System.Drawing.Point(418, 174);
            this.btnSaveDefects.Name = "btnSaveDefects";
            this.btnSaveDefects.Size = new System.Drawing.Size(199, 34);
            this.btnSaveDefects.TabIndex = 5;
            this.btnSaveDefects.Text = "Save defects";
            this.btnSaveDefects.UseVisualStyleBackColor = true;
            this.btnSaveDefects.Click += new System.EventHandler(this.btnSaveDefects_Click);
            // 
            // btnPerformRet
            // 
            this.btnPerformRet.Image = ((System.Drawing.Image)(resources.GetObject("btnPerformRet.Image")));
            this.btnPerformRet.Location = new System.Drawing.Point(418, 365);
            this.btnPerformRet.Name = "btnPerformRet";
            this.btnPerformRet.Size = new System.Drawing.Size(199, 47);
            this.btnPerformRet.TabIndex = 6;
            this.btnPerformRet.Text = "Perform retouching";
            this.btnPerformRet.UseVisualStyleBackColor = true;
            this.btnPerformRet.Click += new System.EventHandler(this.btnPerformRet_Click);
            // 
            // btnShowDefects
            // 
            this.btnShowDefects.Location = new System.Drawing.Point(418, 214);
            this.btnShowDefects.Name = "btnShowDefects";
            this.btnShowDefects.Size = new System.Drawing.Size(199, 34);
            this.btnShowDefects.TabIndex = 5;
            this.btnShowDefects.Text = "Show defects";
            this.btnShowDefects.UseVisualStyleBackColor = true;
            this.btnShowDefects.Click += new System.EventHandler(this.btnShowDefects_Click);
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(419, 267);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(199, 20);
            this.textBoxThreshold.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 251);
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
            this.btnFindWrong.Location = new System.Drawing.Point(418, 293);
            this.btnFindWrong.Name = "btnFindWrong";
            this.btnFindWrong.Size = new System.Drawing.Size(200, 34);
            this.btnFindWrong.TabIndex = 9;
            this.btnFindWrong.Text = "Find wrong pixels";
            this.btnFindWrong.UseVisualStyleBackColor = true;
            this.btnFindWrong.Click += new System.EventHandler(this.btnFindWrong_Click);
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
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(418, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 65);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defects Shape";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(12, 418);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(107, 47);
            this.btnRestore.TabIndex = 13;
            this.btnRestore.Text = "Restore the original picture";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // chckBxGrayScale
            // 
            this.chckBxGrayScale.AutoSize = true;
            this.chckBxGrayScale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chckBxGrayScale.BackgroundImage")));
            this.chckBxGrayScale.Location = new System.Drawing.Point(424, 45);
            this.chckBxGrayScale.Name = "chckBxGrayScale";
            this.chckBxGrayScale.Size = new System.Drawing.Size(75, 17);
            this.chckBxGrayScale.TabIndex = 14;
            this.chckBxGrayScale.Text = "GrayScale";
            this.chckBxGrayScale.UseVisualStyleBackColor = true;
            this.chckBxGrayScale.CheckedChanged += new System.EventHandler(this.chckBxGrayScale_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(418, 333);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 26);
            this.progressBar1.TabIndex = 15;
            // 
            // btnMakeGray
            // 
            this.btnMakeGray.Location = new System.Drawing.Point(125, 418);
            this.btnMakeGray.Name = "btnMakeGray";
            this.btnMakeGray.Size = new System.Drawing.Size(94, 47);
            this.btnMakeGray.TabIndex = 16;
            this.btnMakeGray.Text = "Make gray";
            this.btnMakeGray.UseVisualStyleBackColor = true;
            this.btnMakeGray.Click += new System.EventHandler(this.btnMakeGray_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1px);
            this.groupBox2.Controls.Add(this.radioButton2px);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(522, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(97, 65);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Defects Size";
            // 
            // radioButton1px
            // 
            this.radioButton1px.AutoSize = true;
            this.radioButton1px.Location = new System.Drawing.Point(6, 19);
            this.radioButton1px.Name = "radioButton1px";
            this.radioButton1px.Size = new System.Drawing.Size(42, 17);
            this.radioButton1px.TabIndex = 10;
            this.radioButton1px.TabStop = true;
            this.radioButton1px.Text = "1px";
            this.radioButton1px.UseVisualStyleBackColor = true;
            this.radioButton1px.CheckedChanged += new System.EventHandler(this.radioButton1px_CheckedChanged);
            // 
            // radioButton2px
            // 
            this.radioButton2px.AutoSize = true;
            this.radioButton2px.Location = new System.Drawing.Point(6, 42);
            this.radioButton2px.Name = "radioButton2px";
            this.radioButton2px.Size = new System.Drawing.Size(42, 17);
            this.radioButton2px.TabIndex = 11;
            this.radioButton2px.TabStop = true;
            this.radioButton2px.Text = "2px";
            this.radioButton2px.UseVisualStyleBackColor = true;
            // 
            // btnWavelet
            // 
            this.btnWavelet.Location = new System.Drawing.Point(315, 418);
            this.btnWavelet.Name = "btnWavelet";
            this.btnWavelet.Size = new System.Drawing.Size(97, 47);
            this.btnWavelet.TabIndex = 17;
            this.btnWavelet.Text = "Do Wavelet filter";
            this.btnWavelet.UseVisualStyleBackColor = true;
            this.btnWavelet.Click += new System.EventHandler(this.btnWavelet_Click);
            // 
            // btnRevWavelet
            // 
            this.btnRevWavelet.Location = new System.Drawing.Point(625, 418);
            this.btnRevWavelet.Name = "btnRevWavelet";
            this.btnRevWavelet.Size = new System.Drawing.Size(97, 47);
            this.btnRevWavelet.TabIndex = 17;
            this.btnRevWavelet.Text = "Reverse Wavelet";
            this.btnRevWavelet.UseVisualStyleBackColor = true;
            this.btnRevWavelet.Click += new System.EventHandler(this.btnRevWavelet_Click);
            // 
            // textBoxWavelet
            // 
            this.textBoxWavelet.Location = new System.Drawing.Point(419, 434);
            this.textBoxWavelet.Name = "textBoxWavelet";
            this.textBoxWavelet.Size = new System.Drawing.Size(199, 20);
            this.textBoxWavelet.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Threshold for Wavelet:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1037, 471);
            this.Controls.Add(this.btnRevWavelet);
            this.Controls.Add(this.btnWavelet);
            this.Controls.Add(this.btnMakeGray);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chckBxGrayScale);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFindWrong);
            this.Controls.Add(this.btnMDefects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWavelet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.btnPerformRet);
            this.Controls.Add(this.btnShowDefects);
            this.Controls.Add(this.btnSaveDefects);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnLoad;
        private Button btnMDefects;
        private Button btnSaveDefects;
        private Button btnPerformRet;
        private Button btnShowDefects;
        private TextBox textBoxThreshold;
        private Label label1;
        private PictureBox pictureBox2;
        private Button btnFindWrong;
        private RadioButton radioButtonPoint;
        private RadioButton radioButtonLine;
        private GroupBox groupBox1;
        private Button btnRestore;
        private CheckBox chckBxGrayScale;
        private ProgressBar progressBar1;
        private Button btnMakeGray;
        private GroupBox groupBox2;
        private RadioButton radioButton1px;
        private RadioButton radioButton2px;
        private Button btnWavelet;
        private Button btnRevWavelet;
        private TextBox textBoxWavelet;
        private Label label2;
    }
}

