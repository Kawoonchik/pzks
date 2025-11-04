using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AeroflotApp
{
    public partial class MainForm : Form
    {
        // Структура для збереження інформації про рейси
        struct AEROFLOT
        {
            public string City;  // Назва пункту призначення
            public int Num;      // Номер рейсу
            public string Type;  // Тип літака

            public AEROFLOT(string city, int num, string type)
            {
                City = city;
                Num = num;
                Type = type;
            }
        }

        // Список рейсів
        private List<AEROFLOT> airList = new List<AEROFLOT>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string city = cityTextBox.Text;
                int num = int.Parse(numTextBox.Text);
                string type = typeTextBox.Text;

                airList.Add(new AEROFLOT(city, num, type));

                cityTextBox.Clear();
                numTextBox.Clear();
                typeTextBox.Clear();

                MessageBox.Show("Flight added successfully!", "Info");
            }
            catch
            {
                MessageBox.Show("Invalid input data!", "Error");
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            airList = airList.OrderBy(a => a.City).ToList();
            MessageBox.Show("Flights sorted by city.", "Info");
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchType = searchTextBox.Text.Trim();
            var result = airList.Where(a => a.Type.Equals(searchType, StringComparison.OrdinalIgnoreCase)).ToList();

            resultListBox.Items.Clear();

            if (result.Count > 0)
            {
                foreach (var a in result)
                {
                    resultListBox.Items.Add($"City: {a.City}, Flight Nгьиук: {a.Num}");
                }
            }
            else
            {
                MessageBox.Show("No flights found for this plane type.", "Result");
            }
        }   

        private void showAllButton_Click(object sender, EventArgs e)
        {
            resultListBox.Items.Clear();

            foreach (var a in airList)
            {
                resultListBox.Items.Add($"City: {a.City}, Flight No: {a.Num}, Type: {a.Type}");
            }
        }
    }
}
