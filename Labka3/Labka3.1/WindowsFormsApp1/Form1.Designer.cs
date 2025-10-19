using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextAnalyzerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        internal TextBox inputTextBox;
        internal Button analyzeButton;
        internal Button clearButton;
        internal Label resultLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(360, 120);
            this.inputTextBox.TabIndex = 0;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(12, 140);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(100, 30);
            this.analyzeButton.TabIndex = 1;
            this.analyzeButton.Text = "Порахувати";
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(128, 140);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 30);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Очистити";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 180);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(103, 13);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.Text = "Результат буде тут";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.resultLabel);
            this.Name = "Form1";
            this.Text = "Аналізатор тексту";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
