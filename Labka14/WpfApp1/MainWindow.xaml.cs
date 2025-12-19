using System;
using System.Threading;
using System.Windows;

namespace ThreadPoolDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private class TaskInfo
        {
            public int Seconds { get; set; }
            public int Delay { get; set; }
            public int Index { get; set; }
            public MainWindow Window { get; set; }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(SecondsInput.Text, out int seconds))
            {
                MessageBox.Show("Введіть секунди!");
                return;
            }

            ResultsList.Items.Clear();


            int[] delays = { 1000, 700, 1500 };

            for (int i = 0; i < delays.Length; i++)
            {
                var info = new TaskInfo
                {
                    Seconds = seconds,
                    Delay = delays[i],
                    Index = i + 1,
                    Window = this
                };

                ThreadPool.QueueUserWorkItem(RunCountdown, info);
            }
        }

        private void RunCountdown(object state)
        {
            TaskInfo info = (TaskInfo)state;

            for (int i = info.Seconds; i >= 0; i--)
            {
                info.Window.Dispatcher.Invoke(() =>
                {
                    info.Window.ResultsList.Items.Add(
                        $"Потік {info.Index} (затримка {info.Delay} мс): {i}"
                    );
                });

                Thread.Sleep(info.Delay);
            }

            info.Window.Dispatcher.Invoke(() =>
            {
                info.Window.ResultsList.Items.Add(
                    $"Потік {info.Index} завершився!"
                );
            });
        }
    }
}
