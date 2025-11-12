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
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(26, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(166, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Select clothing type:";
            // 
            // cmbClothingType
            // 
            cmbClothingType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClothingType.Font = new Font("Segoe UI", 10F);
            cmbClothingType.Location = new Point(26, 45);
            cmbClothingType.Margin = new Padding(3, 2, 3, 2);
            cmbClothingType.Name = "cmbClothingType";
            cmbClothingType.Size = new Size(219, 25);
            cmbClothingType.TabIndex = 1;
            // 
            // btnShowInfo
            // 
            btnShowInfo.Font = new Font("Segoe UI", 10F);
            btnShowInfo.Location = new Point(251, 40);
            btnShowInfo.Margin = new Padding(3, 2, 3, 2);
            btnShowInfo.Name = "btnShowInfo";
            btnShowInfo.Size = new Size(88, 33);
            btnShowInfo.TabIndex = 2;
            btnShowInfo.Text = "Show Info";
            btnShowInfo.Click += btnShowInfo_Click;
            // 
            // txtOutput
            // 
            txtOutput.Font = new Font("Segoe UI", 10F);
            txtOutput.Location = new Point(26, 82);
            txtOutput.Margin = new Padding(3, 2, 3, 2);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(438, 151);
            txtOutput.TabIndex = 3;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 10F);
            btnExit.Location = new Point(376, 248);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(88, 32);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.Location = new Point(26, 248);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(88, 32);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 300);
            Controls.Add(lblTitle);
            Controls.Add(cmbClothingType);
            Controls.Add(btnShowInfo);
            Controls.Add(txtOutput);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Clothing Quiz";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
