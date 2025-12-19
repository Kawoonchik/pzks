using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows;

namespace PingTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnScan_Click(object sender, RoutedEventArgs e)
        {
            lstResults.Items.Clear();
            string subnet = txtSubnet.Text.Trim();

            if (!subnet.EndsWith("."))
            {
                subnet += ".";
            }

            txtStatus.Text = "Сканування запущено...";

            for (int i = 1; i < 255; i++)
            {
                string fullIp = subnet + i;

                Thread thread = new Thread(PingFunction);

                thread.Start(fullIp);
            }
        }

        private void PingFunction(object ipObj)
        {
            string ipAddress = (string)ipObj;
            Ping ping = new Ping();

            try
            {
                PingReply reply = ping.Send(ipAddress, 1000);

                if (reply.Status == IPStatus.Success)
                {

                    Dispatcher.Invoke(() =>
                    {
                        lstResults.Items.Add($"{ipAddress} - Активний (Ping: {reply.RoundtripTime}ms)");
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}