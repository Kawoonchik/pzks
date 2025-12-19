using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.Sequence;

namespace RecognizerApp
{
    public partial class Form1 : Form
    {
        string inputText = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Text files|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                inputText = File.ReadAllText(dlg.FileName);
                txtInput.Text = inputText;
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            var currency = NumberWithUnitRecognizer.RecognizeCurrency(inputText, Culture.English);
            var dimension = NumberWithUnitRecognizer.RecognizeDimension(inputText, Culture.English);
            var temperature = NumberWithUnitRecognizer.RecognizeTemperature(inputText, Culture.English);
            var datetime = DateTimeRecognizer.RecognizeDateTime(inputText, Culture.English);
            var phone = SequenceRecognizer.RecognizePhoneNumber(inputText, Culture.English);
            var ip = SequenceRecognizer.RecognizeIpAddress(inputText, Culture.English);
            var email = SequenceRecognizer.RecognizeEmail(inputText, Culture.English);
            var url = SequenceRecognizer.RecognizeURL(inputText, Culture.English);
            var hashtag = SequenceRecognizer.RecognizeHashtag(inputText, Culture.English);

            WriteResults(sb, "Currency", currency);
            WriteResults(sb, "Dimension", dimension);
            WriteResults(sb, "Temperature", temperature);
            WriteResults(sb, "DateTime", datetime);
            WriteResults(sb, "Phone", phone);
            WriteResults(sb, "IP", ip);
            WriteResults(sb, "Email", email);
            WriteResults(sb, "URL", url);
            WriteResults(sb, "Hashtag", hashtag);

            txtOutput.Text = sb.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Text files|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, txtOutput.Text);
            }
        }

        void WriteResults(StringBuilder sb, string title, IList<ModelResult> list)
        {
            sb.AppendLine(title + ": " + list.Count);
            foreach (var r in list)
                sb.AppendLine(r.Text + " → " + r.Resolution["value"]);
            sb.AppendLine();
        }
    }
}
