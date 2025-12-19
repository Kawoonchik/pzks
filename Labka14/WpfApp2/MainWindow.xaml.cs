using System;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncLoadingDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            LoadingBar.Value = 0;
            StatusLabel.Text = "Починаємо завантаження...";

            await SimulateBigLoading();
        }

        private async Task SimulateBigLoading()
        {
            int steps = 10; 
            int delay = 2000;

            for (int i = 1; i <= steps; i++)
            {
                await Task.Delay(delay);

                LoadingBar.Value = i * (100 / steps);
                StatusLabel.Text = $"Етап {i} з {steps}...";
            }

            StatusLabel.Text = "Завантаження завершено!";
        }
    }
}
