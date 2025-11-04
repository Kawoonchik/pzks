namespace QuizApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private ComboBox cmbClothingType;
        private Button btnShowInfo;
        private TextBox txtOutput;
        private Button btnExit;
        private Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            cmbClothingType = new ComboBox();
            btnShowInfo = new Button();
            txtOutput = new TextBox();
            btnExit = new Button();
            btnClear = new Button();
            SuspendLayout();

            // Label Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Text = "Select clothing type:";

            // ComboBox
            cmbClothingType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClothingType.Font = new Font("Segoe UI", 10F);
            cmbClothingType.Location = new Point(30, 60);
            cmbClothingType.Size = new Size(250, 30);

            // Show Info Button
            btnShowInfo.Font = new Font("Segoe UI", 10F);
            btnShowInfo.Location = new Point(300, 60);
            btnShowInfo.Size = new Size(100, 30);
            btnShowInfo.Text = "Show Info";
            btnShowInfo.Click += btnShowInfo_Click;

            // Output TextBox
            txtOutput.Font = new Font("Segoe UI", 10F);
            txtOutput.Location = new Point(30, 110);
            txtOutput.Multiline = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(500, 200);

            // Clear Button
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.Location = new Point(30, 330);
            btnClear.Size = new Size(100, 30);
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;

            // Exit Button
            btnExit.Font = new Font("Segoe UI", 10F);
            btnExit.Location = new Point(430, 330);
            btnExit.Size = new Size(100, 30);
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 400);
            Controls.Add(lblTitle);
            Controls.Add(cmbClothingType);
            Controls.Add(btnShowInfo);
            Controls.Add(txtOutput);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Text = "Clothing Quiz";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
