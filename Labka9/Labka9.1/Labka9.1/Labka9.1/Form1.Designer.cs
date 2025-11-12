namespace SymmetricListApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnLoad;
        private Button btnProcess;
        private Button btnSave;
        private TextBox txtOriginal;
        private TextBox txtProcessed;
        private Label lblOriginal;
        private Label lblProcessed;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoad = new Button();
            btnProcess = new Button();
            btnSave = new Button();
            txtOriginal = new TextBox();
            txtProcessed = new TextBox();
            lblOriginal = new Label();
            lblProcessed = new Label();

            SuspendLayout();

            // Load button
            btnLoad.Text = "Load File";
            btnLoad.Location = new Point(30, 20);
            btnLoad.Size = new Size(120, 35);
            btnLoad.Click += btnLoad_Click;

            // Process button
            btnProcess.Text = "Build Symmetric List";
            btnProcess.Location = new Point(170, 20);
            btnProcess.Size = new Size(180, 35);
            btnProcess.Click += btnProcess_Click;

            // Save button
            btnSave.Text = "Save to File";
            btnSave.Location = new Point(370, 20);
            btnSave.Size = new Size(120, 35);
            btnSave.Click += btnSave_Click;

            // Original label
            lblOriginal.Text = "Original List:";
            lblOriginal.Location = new Point(30, 70);
            lblOriginal.AutoSize = true;

            // Original textbox
            txtOriginal.Multiline = true;
            txtOriginal.ScrollBars = ScrollBars.Vertical;
            txtOriginal.Location = new Point(30, 100);
            txtOriginal.Size = new Size(460, 120);

            // Processed label
            lblProcessed.Text = "Processed (Symmetric) List:";
            lblProcessed.Location = new Point(30, 240);
            lblProcessed.AutoSize = true;

            // Processed textbox
            txtProcessed.Multiline = true;
            txtProcessed.ScrollBars = ScrollBars.Vertical;
            txtProcessed.Location = new Point(30, 270);
            txtProcessed.Size = new Size(460, 140);

            // Form settings
            ClientSize = new Size(530, 430);
            Controls.Add(btnLoad);
            Controls.Add(btnProcess);
            Controls.Add(btnSave);
            Controls.Add(txtOriginal);
            Controls.Add(txtProcessed);
            Controls.Add(lblOriginal);
            Controls.Add(lblProcessed);
            Text = "Symmetric List Builder";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
