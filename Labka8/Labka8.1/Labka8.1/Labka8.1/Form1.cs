using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StreetWateringApp
{
    public partial class Form1 : Form
    {
        // Список кортежів (вулиця, довжина, кількість будинків, покриття)
        private readonly List<(string street, double length, int houses, string surface)> streets = new();

        public Form1()
        {
            InitializeComponent();
        }

        // Додати нову вулицю
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string street = txtStreet.Text;
                double length = double.Parse(txtLength.Text);
                int houses = int.Parse(txtHouses.Text);
                string surface = txtSurface.Text;

                streets.Add((street, length, houses, surface));
                MessageBox.Show("Street added successfully!");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Очистити поля
        private void ClearFields()
        {
            txtStreet.Clear();
            txtLength.Clear();
            txtHouses.Clear();
            txtSurface.Clear();
        }

        // Показати всі вулиці
        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            if (streets.Count == 0)
            {
                listBox.Items.Add("No streets added yet.");
                return;
            }

            foreach (var s in streets)
                listBox.Items.Add($"{s.street} | {s.length} km | Houses: {s.houses} | Surface: {s.surface}");
        }

        // Показати середню довжину
        private void BtnShowAverage_Click(object sender, EventArgs e)
        {
            if (streets.Count == 0)
            {
                MessageBox.Show("No data to calculate average.");
                return;
            }

            double avg = streets.Average(s => s.length);
            MessageBox.Show($"Average street length: {avg:F2} km");
        }

        // Показати вулиці, що потребують подвійного поливу
        private void BtnShowDoubleWater_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            if (streets.Count == 0)
            {
                listBox.Items.Add("No data available.");
                return;
            }

            double avg = streets.Average(s => s.length);
            var doubleWater = streets.Where(s => s.length > avg).ToList();

            if (doubleWater.Count == 0)
            {
                listBox.Items.Add("No streets need double watering.");
            }
            else
            {
                listBox.Items.Add("=== Streets for double watering ===");
                foreach (var s in doubleWater)
                    listBox.Items.Add($"{s.street} ({s.length} km)");
                listBox.Items.Add($"Total: {doubleWater.Count}");
            }
        }

        // Показати конкретний елемент за індексом
        private void BtnShowSingle_Click(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(txtIndex.Text) - 1;

                if (index < 0 || index >= streets.Count)
                {
                    MessageBox.Show("Invalid index!");
                    return;
                }

                var s = streets[index];
                MessageBox.Show($"Street #{index + 1}\n" +
                    $"Name: {s.street}\n" +
                    $"Length: {s.length} km\n" +
                    $"Houses: {s.houses}\n" +
                    $"Surface: {s.surface}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
