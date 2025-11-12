using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BracketCheckerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnLoad;
        private Button btnCheck;
        private Button btnSave;
        private TextBox txtExpression;
        private TextBox txtResult;
        private Label lblExpression;
        private Label lblResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoad = new Button();
            btnCheck = new Button();
            btnSave = new Button();
            txtExpression = new TextBox();
            txtResult = new TextBox();
            lblExpression = new Label();
            lblResult = new Label();

            SuspendLayout();

            // btnLoad
            btnLoad.Text = "Load Expression";
            btnLoad.Location = new Point(30, 20);
            btnLoad.Size = new Size(150, 35);
            btnLoad.Click += btnLoad_Click;

            // btnCheck
            btnCheck.Text = "Check Brackets";
            btnCheck.Location = new Point(200, 20);
            btnCheck.Size = new Size(150, 35);
            btnCheck.Click += btnCheck_Click;

            // btnSave
            btnSave.Text = "Save Result";
            btnSave.Location = new Point(370, 20);
            btnSave.Size = new Size(150, 35);
            btnSave.Click += btnSave_Click;

            // lblExpression
            lblExpression.Text = "Expression:";
            lblExpression.Location = new Point(30, 70);
            lblExpression.AutoSize = true;

            // txtExpression
            txtExpression.Location = new Point(30, 95);
            txtExpression.Size = new Size(490, 30);
            txtExpression.Font = new Font("Segoe UI", 11);

            // lblResult
            lblResult.Text = "Result:";
            lblResult.Location = new Point(30, 140);
            lblResult.AutoSize = true;

            // txtResult
            txtResult.Location = new Point(30, 165);
            txtResult.Size = new Size(490, 200);
            txtResult.Multiline = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Font = new Font("Segoe UI", 11);

            // Form1
            ClientSize = new Size(560, 400);
            Controls.Add(btnLoad);
            Controls.Add(btnCheck);
            Controls.Add(btnSave);
            Controls.Add(lblExpression);
            Controls.Add(txtExpression);
            Controls.Add(lblResult);
            Controls.Add(txtResult);
            Text = "Bracket Checker";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
