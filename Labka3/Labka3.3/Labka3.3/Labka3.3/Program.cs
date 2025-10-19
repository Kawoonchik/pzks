using System;
using System.Windows.Forms;
using Labka3._3;

namespace TextProcessorApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1()); 
        }
    }
}
