using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text;

namespace Task13._2
{
    public partial class Form1 : Form
    {
        string loadedText = "";
        int count = 0;

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadedText = File.ReadAllText(ofd.FileName);
                inputTextBox.Text = loadedText;
            }
        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            count = 0;

            var results = NumberRecognizer.RecognizeOrdinal(loadedText, Culture.English);

            foreach (var r in results)
            {
                string text = r.Text;
                string value = r.Resolution["value"].ToString();

                resultTextBox.AppendText($"{text} – {value}{Environment.NewLine}");
                count++;
            }

            resultTextBox.AppendText($"{Environment.NewLine}Count: {count}");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, $"Count: {count}\n" + resultTextBox.Text);
            }
        }
    }
}
