namespace Task13._2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button saveButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Size = new System.Drawing.Size(560, 120);
            this.loadButton.Location = new System.Drawing.Point(12, 140);
            this.loadButton.Size = new System.Drawing.Size(120, 30);
            this.loadButton.Text = "Load file";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            this.recognizeButton.Location = new System.Drawing.Point(150, 140);
            this.recognizeButton.Size = new System.Drawing.Size(120, 30);
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Location = new System.Drawing.Point(12, 180);
            this.resultTextBox.Size = new System.Drawing.Size(560, 200);
            this.saveButton.Location = new System.Drawing.Point(290, 140);
            this.saveButton.Size = new System.Drawing.Size(120, 30);
            this.saveButton.Text = "Save result";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            this.ClientSize = new System.Drawing.Size(584, 391);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.recognizeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resultTextBox);
            this.Text = "Ordinal Recognizer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
