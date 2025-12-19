using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;

namespace NumberRecognizerApp
{
    public partial class Form1 : Form
    {
        private string loadedText;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                loadedText = File.ReadAllText(d.FileName);
                txtInput.Text = loadedText;
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            txtModified.Clear();

            var results = NumberRecognizer.RecognizeNumber(loadedText, Culture.English);

            string modified = loadedText;
            int shift = 0;

            foreach (var r in results)
            {
                string text = r.Text;
                int start = r.Start;
                int end = r.End;
                string val = r.Resolution["value"].ToString();

                txtOutput.AppendText(
                    "Розпізнаний текст (число): " + text + Environment.NewLine +
                    "Початковий індекс у рядку: " + start + Environment.NewLine +
                    "Кінцевий індекс у рядку: " + end + Environment.NewLine +
                    "Розпізнане значення числа: " + val + Environment.NewLine +
                    Environment.NewLine
                );

                int s = start + shift;
                int eIndex = end - start + 1;
                modified = modified.Remove(s, eIndex).Insert(s, val);
                shift += val.Length - eIndex;
            }

            txtModified.Text = modified;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var d = new SaveFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(d.FileName, txtModified.Text);
            }
        }
    }
}
