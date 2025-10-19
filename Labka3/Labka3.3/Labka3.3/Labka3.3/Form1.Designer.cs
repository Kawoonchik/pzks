namespace TextProcessorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Label resultLabel;

        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.processButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // inputTextBox
            this.inputTextBox.Location = new System.Drawing.Point(20, 20);
            this.inputTextBox.Size = new System.Drawing.Size(300, 20);

            // processButton
            this.processButton.Location = new System.Drawing.Point(20, 60);
            this.processButton.Size = new System.Drawing.Size(120, 30);
            this.processButton.Text = "Обробити";
            this.processButton.Click += new System.EventHandler(this.processButton_Click);

            // resultLabel
            this.resultLabel.Location = new System.Drawing.Point(20, 110);
            this.resultLabel.Size = new System.Drawing.Size(400, 30);

            // Form1
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.resultLabel);
            this.Text = "Text Processor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
