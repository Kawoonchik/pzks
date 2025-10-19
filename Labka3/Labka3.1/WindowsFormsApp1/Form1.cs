using System;
using System.Globalization;
using System.Windows.Forms;

namespace TextAnalyzerApp
{
    public partial class Form1 : Form
    {
        private readonly TextAnalyzer analyzer;

        public Form1()
        {
            InitializeComponent();
            analyzer = new TextAnalyzer();
        }

        
        private void analyzeButton_Click(object sender, EventArgs e)
        {
            string text = inputTextBox.Text ?? string.Empty;
            int count = analyzer.CountOccurrences(text, "абв");
            resultLabel.Text = $"Знайдено входжень \"абв\": {count}";
        }

        
        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
            resultLabel.Text = "Результат буде тут";
        }
    }

   
    public class TextAnalyzer
    {
        private readonly CultureInfo _culture = new CultureInfo("uk-UA");

        public int CountOccurrences(string text, string pattern, bool ignoreCase = true)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern)) return 0;
            if (ignoreCase)
            {
                text = text.ToLower(_culture);
                pattern = pattern.ToLower(_culture);
            }

            int count = 0;
            for (int i = 0; i <= text.Length - pattern.Length; i++)
                if (text.Substring(i, pattern.Length) == pattern)
                    count++;
            return count;
        }
    }
}
