using System;
using System.Windows.Forms;

namespace DomofonServiceApp
{
    public partial class Form1 : Form
    {
        private readonly ServiceManager manager = new ServiceManager();

        public Form1()
        {
            InitializeComponent(); // автоматично викликає метод із Designer.cs
        }

        // Додавання нового запису
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                manager.Add(txtAddress.Text, txtSubscribers.Text, txtDate.Text, txtInterval.Text, txtCondition.Text);
                MessageBox.Show("Added successfully!");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Очистка текстових полів
        private void ClearFields()
        {
            txtAddress.Clear();
            txtSubscribers.Clear();
            txtDate.Clear();
            txtInterval.Clear();
            txtCondition.Clear();
        }

        // Вивід усіх записів з наступною датою обслуговування
        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (var s in manager.GetAllSortedByAddress())
                listBox.Items.Add($"{s.Address} | Next service: {s.NextServiceDate:dd.MM.yyyy}");
        }

        // Пошук у діапазоні дат
        private void BtnBetweenDates_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            var data = manager.GetBetweenDates(txtStartDate.Text, txtEndDate.Text);
            foreach (var s in data)
                listBox.Items.Add($"{s.Address} | Last: {s.LastServiceDate:dd.MM.yyyy}");
            if (listBox.Items.Count == 0)
                listBox.Items.Add("No services found in this period.");
        }

        // Підрахунок профілактик за минулий рік із "satisfactory"
        private void BtnCountLastYear_Click(object sender, EventArgs e)
        {
            int count = manager.CountSatisfactoryLastYear();
            MessageBox.Show($"Number of satisfactory services last year: {count}");
        }

        // Останній об'єкт у наступному місяці
        private void BtnLastNextMonth_Click(object sender, EventArgs e)
        {
            var last = manager.GetLastServiceNextMonth();
            if (last.HasValue)
                MessageBox.Show($"Last service next month:\n{last.Value.Address} ({last.Value.NextServiceDate:dd.MM.yyyy})");
            else
                MessageBox.Show("No services next month.");
        }

        // Пошук за конкретною датою
        private void BtnSearchByDate_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            var result = manager.GetByExactDate(txtSearchDate.Text);
            foreach (var s in result)
                listBox.Items.Add($"{s.Address} | Condition: {s.Condition}");
            if (listBox.Items.Count == 0)
                listBox.Items.Add("No services found on this date.");
        }
    }
}
