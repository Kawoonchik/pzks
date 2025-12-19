namespace NumberRecognizerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtModified;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtModified = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Multiline = true;
            this.txtInput.Size = new System.Drawing.Size(560, 120);

            this.btnLoad.Location = new System.Drawing.Point(12, 140);
            this.btnLoad.Size = new System.Drawing.Size(120, 30);
            this.btnLoad.Text = "Load File";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.btnRecognize.Location = new System.Drawing.Point(150, 140);
            this.btnRecognize.Size = new System.Drawing.Size(120, 30);
            this.btnRecognize.Text = "Recognize";
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);

            this.txtOutput.Location = new System.Drawing.Point(12, 180);
            this.txtOutput.Multiline = true;
            this.txtOutput.Size = new System.Drawing.Size(560, 160);

            this.txtModified.Location = new System.Drawing.Point(12, 350);
            this.txtModified.Multiline = true;
            this.txtModified.Size = new System.Drawing.Size(560, 120);

            this.btnSave.Location = new System.Drawing.Point(12, 480);
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.Text = "Save Result";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.ClientSize = new System.Drawing.Size(584, 521);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtModified);
            this.Controls.Add(this.btnSave);
            this.Text = "Number Recognizer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
