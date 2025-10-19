namespace UniversityApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblStudents = new System.Windows.Forms.Label();
            this.lblFaculties = new System.Windows.Forms.Label();
            this.lblRector = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();

            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtStudents = new System.Windows.Forms.TextBox();
            this.txtFaculties = new System.Windows.Forms.TextBox();
            this.txtRector = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Labels
            int x1 = 30, x2 = 200, y = 30, dy = 35;

            this.lblName.Location = new System.Drawing.Point(x1, y); this.lblName.Text = "Назва університету:"; y += dy;
            this.lblCity.Location = new System.Drawing.Point(x1, y); this.lblCity.Text = "Місто:"; y += dy;
            this.lblYear.Location = new System.Drawing.Point(x1, y); this.lblYear.Text = "Рік заснування:"; y += dy;
            this.lblStudents.Location = new System.Drawing.Point(x1, y); this.lblStudents.Text = "Кількість студентів:"; y += dy;
            this.lblFaculties.Location = new System.Drawing.Point(x1, y); this.lblFaculties.Text = "Кількість факультетів:"; y += dy;
            this.lblRector.Location = new System.Drawing.Point(x1, y); this.lblRector.Text = "Ректор:"; y += dy;
            this.lblRating.Location = new System.Drawing.Point(x1, y); this.lblRating.Text = "Рейтинг:";

            // TextBoxes
            y = 25;
            this.txtName.Location = new System.Drawing.Point(x2, y); y += dy;
            this.txtCity.Location = new System.Drawing.Point(x2, y); y += dy;
            this.txtYear.Location = new System.Drawing.Point(x2, y); y += dy;
            this.txtStudents.Location = new System.Drawing.Point(x2, y); y += dy;
            this.txtFaculties.Location = new System.Drawing.Point(x2, y); y += dy;
            this.txtRector.Location = new System.Drawing.Point(x2, y); y += dy;
            this.txtRating.Location = new System.Drawing.Point(x2, y);

            this.txtName.Size = this.txtCity.Size = this.txtYear.Size =
                this.txtStudents.Size = this.txtFaculties.Size = this.txtRector.Size =
                this.txtRating.Size = new System.Drawing.Size(180, 23);

            // Buttons
            this.btnSave.Location = new System.Drawing.Point(60, 320);
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.Text = "Зберегти у файл";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnShow.Location = new System.Drawing.Point(230, 320);
            this.btnShow.Size = new System.Drawing.Size(160, 35);
            this.btnShow.Text = "Показати інформацію";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblName, lblCity, lblYear, lblStudents, lblFaculties, lblRector, lblRating,
                txtName, txtCity, txtYear, txtStudents, txtFaculties, txtRector, txtRating,
                btnSave, btnShow
            });

            this.Name = "MainForm";
            this.Text = "Університет — ООП приклад";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

       

        private System.Windows.Forms.Label lblName, lblCity, lblYear, lblStudents, lblFaculties, lblRector, lblRating;
        private System.Windows.Forms.TextBox txtName, txtCity, txtYear, txtStudents, txtFaculties, txtRector, txtRating;
        private System.Windows.Forms.Button btnSave, btnShow;
    }
}
