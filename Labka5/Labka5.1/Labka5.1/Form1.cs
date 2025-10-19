using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UniversityApp
{
    public partial class Form1 : Form
    {
        University uni = new University();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                uni.Name = txtName.Text;
                uni.City = txtCity.Text;
                uni.FoundedYear = int.Parse(txtYear.Text);
                uni.StudentCount = int.Parse(txtStudents.Text);
                uni.FacultyCount = int.Parse(txtFaculties.Text);
                uni.Rector = txtRector.Text;
                uni.Rating = double.Parse(txtRating.Text);

                File.WriteAllText("UniversityData.txt", uni.GetInfo());

                MessageBox.Show(" Дані збережено у файл UniversityData.txt", "Успіх");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string info = uni.GetInfo() + "\n\n";
            info += uni.GetUniversityAge() + "\n";
            info += $"Середня кількість студентів на факультет: {uni.AverageStudentsPerFaculty():F2}";
            MessageBox.Show(info, "Інформація про університет");
        }
    }
}
