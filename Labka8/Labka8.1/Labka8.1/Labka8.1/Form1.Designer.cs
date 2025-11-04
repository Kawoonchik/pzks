using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace StreetWateringApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtStreet;
        private TextBox txtLength;
        private TextBox txtHouses;
        private TextBox txtSurface;
        private TextBox txtIndex;
        private Button btnAdd;
        private Button btnShowAll;
        private Button btnShowAverage;
        private Button btnShowDoubleWater;
        private Button btnShowSingle;
        private ListBox listBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Текстові поля
            txtStreet = new TextBox { PlaceholderText = "Street name", Left = 20, Top = 20, Width = 200 };
            txtLength = new TextBox { PlaceholderText = "Length (km)", Left = 20, Top = 50, Width = 200 };
            txtHouses = new TextBox { PlaceholderText = "Houses count", Left = 20, Top = 80, Width = 200 };
            txtSurface = new TextBox { PlaceholderText = "Surface type", Left = 20, Top = 110, Width = 200 };

            // Кнопки
            btnAdd = new Button { Text = "Add Street", Left = 240, Top = 20, Width = 160 };
            btnAdd.Click += BtnAdd_Click;

            btnShowAll = new Button { Text = "Show All", Left = 240, Top = 50, Width = 160 };
            btnShowAll.Click += BtnShowAll_Click;

            btnShowAverage = new Button { Text = "Show Average Length", Left = 240, Top = 80, Width = 160 };
            btnShowAverage.Click += BtnShowAverage_Click;

            btnShowDoubleWater = new Button { Text = "Double Water Streets", Left = 240, Top = 110, Width = 160 };
            btnShowDoubleWater.Click += BtnShowDoubleWater_Click;

            txtIndex = new TextBox { PlaceholderText = "Street index", Left = 20, Top = 150, Width = 200 };
            btnShowSingle = new Button { Text = "Show by Index", Left = 240, Top = 150, Width = 160 };
            btnShowSingle.Click += BtnShowSingle_Click;

            // Список для виводу результатів
            listBox = new ListBox { Left = 20, Top = 190, Width = 380, Height = 180 };

            // Додавання елементів на форму
            Controls.Add(txtStreet);
            Controls.Add(txtLength);
            Controls.Add(txtHouses);
            Controls.Add(txtSurface);
            Controls.Add(btnAdd);
            Controls.Add(btnShowAll);
            Controls.Add(btnShowAverage);
            Controls.Add(btnShowDoubleWater);
            Controls.Add(txtIndex);
            Controls.Add(btnShowSingle);
            Controls.Add(listBox);

            // Налаштування форми
            Text = "Street Watering Manager";
            Width = 440;
            Height = 440;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
    }
}
