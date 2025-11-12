using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SymmetricListApp
{
    public partial class Form1 : Form
    {
        private List<int> list = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        // Load numbers from file
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    list = File.ReadAllText(open.FileName)
                               .Split(new[] { ' ', ',', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

                    txtOriginal.Text = string.Join(", ", list);
                    txtProcessed.Clear();

                    MessageBox.Show("File successfully loaded!");
                }
                catch
                {
                    MessageBox.Show("Error reading file!");
                }
            }
        }

        // Build symmetric list
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                MessageBox.Show("List is empty!");
                return;
            }

            List<int> reversed = list.AsEnumerable().Reverse().ToList();
            List<int> symmetric = new List<int>(list);
            symmetric.AddRange(reversed);

            txtProcessed.Text = string.Join(", ", symmetric);
        }

        // Save processed list into file (7 numbers per line)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProcessed.Text))
            {
                MessageBox.Show("Nothing to save!");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var numbers = txtProcessed.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    List<string> lines = new List<string>();
                    for (int i = 0; i < numbers.Length; i += 7)
                    {
                        var chunk = numbers.Skip(i).Take(7);
                        lines.Add(string.Join(" ", chunk));
                    }

                    File.WriteAllLines(save.FileName, lines);

                    MessageBox.Show("File saved successfully!");
                }
                catch
                {
                    MessageBox.Show("Error saving file!");
                }
            }
        }
    }
}
