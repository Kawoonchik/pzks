using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TextProcessorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void processButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                resultLabel.Text = "Введіть текст!";
                return;
            }

            string result = ProcessText(input);
            resultLabel.Text = $"Результат: {result}";
        }

        
        private string ProcessText(string text)
        {
            
            string[] words = Regex.Split(text, @"\W+").Where(w => w.Length > 0).ToArray();

            if (words.Length == 0)
                return text;

            
            string lastWord = words[words.Length - 1];
            if (string.IsNullOrEmpty(lastWord))
                return text;

            
            char lastChar = lastWord[lastWord.Length - 1];

            
            for (int i = 0; i < words.Length; i++)
            {
                char lowerLastChar = char.ToLower(lastChar);
                words[i] = new string(words[i].Where(c => char.ToLower(c) != lowerLastChar).ToArray());
            }

            
            string result = string.Join(" ", words);
            return result;
        }
    }
}
