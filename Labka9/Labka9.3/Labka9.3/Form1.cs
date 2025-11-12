using System;
using System.IO;
using System.Windows.Forms;

namespace BracketCheckerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Load expression from file
 
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                txtExpression.Text = File.ReadAllText(open.FileName).Trim();
            }
        }


        // Check brackets using a stack 

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string expr = txtExpression.Text;

            if (string.IsNullOrWhiteSpace(expr))
            {
                MessageBox.Show("Expression is empty!");
                return;
            }

            string result = CheckBrackets(expr);
            txtResult.Text = result;
        }


        // Save result to file

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResult.Text))
            {
                MessageBox.Show("Nothing to save!");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, txtResult.Text);
                MessageBox.Show("Saved successfully!");
            }
        }


        // Core 

        private string CheckBrackets(string expr)
        {
            int n = expr.Length;

            // stack implemented as an array
            int[] stack = new int[n];
            int top = -1;  // stack pointer

            var pairs = new System.Collections.Generic.List<(int open, int close)>();

            for (int i = 0; i < n; i++)
            {
                char c = expr[i];

                if (c == '(')
                {
                    // PUSH: increment top & store index
                    stack[++top] = i;
                }
                else if (c == ')')
                {
                    if (top < 0)
                    {
                        return "Brackets are NOT balanced. Extra closing bracket found.";
                    }

                    // POP: take index from stack
                    int openIndex = stack[top--];
                    pairs.Add((openIndex, i));
                }
            }

            if (top != -1)
            {
                return "Brackets are NOT balanced. Missing closing bracket(s).";
            }

            // Sort by closing position (ascending)
            pairs.Sort((a, b) => a.close.CompareTo(b.close));

            string output = "Brackets are BALANCED.\n\nPairs (open_pos, close_pos):\n";

            foreach (var pair in pairs)
            {
                output += $"({pair.open + 1}, {pair.close + 1})\n";
                // +1 to convert to human-friendly 1-based positions
            }

            return output;
        }
    }
}
