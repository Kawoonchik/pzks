using System;
using System.Threading;
using System.Windows;

namespace CountdownThread
{
    public partial class MainWindow : Window
    {
        private Thread countdownThread;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(SecondsInput.Text, out int seconds) || seconds < 0)
            {
                MessageBox.Show("Введіть коректну кількість секунд!");
                return;
            }

            // Якщо попередній потік ще працює — зупиняємо
            countdownThread?.Abort();

            countdownThread = new Thread(() => StartCountdown(seconds));
            countdownThread.IsBackground = true;
            countdownThread.Start();
        }

        private void StartCountdown(int seconds)
        {
            for (int i = seconds; i >= 0; i--)
            {
                // Оновлюємо UI через Dispatcher
                Dispatcher.Invoke(() =>
                {
                    TimerLabel.Text = i.ToString();
                });

                Thread.Sleep(1000);
            }
        }
    }
}
