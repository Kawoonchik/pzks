using System;
using System.Windows.Forms;

namespace StreetWateringApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Увімкнення стилів Windows
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запуск головної форми
            Application.Run(new Form1());
        }
    }
}
