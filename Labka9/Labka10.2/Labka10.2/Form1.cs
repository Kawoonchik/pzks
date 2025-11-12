using System;
using System.Windows.Forms;

namespace GraphRepresentationApp
{
    public partial class MainForm : Form
    {
        string[] vertices = { "a", "b", "c", "d", "e" };
        string[] edges = { "a→a", "a→b", "a→e", "b→e", "c→e", "d→d", "d→e" };

        // Матриця суміжності
        int[,] adjacencyMatrix = {
            {1, 1, 0, 0, 1},  // a
            {0, 0, 0, 0, 1},  // b
            {0, 0, 0, 0, 1},  // c
            {0, 0, 0, 1, 1},  // d
            {0, 0, 0, 0, 0}   // e
        };

        // Матриця інцидентності
        int[,] incidenceMatrix = {
            // r1 r2 r3 r4 r5 r6 r7
            { 1,  1,  1,  0,  0,  0,  0 },   // a
            { 0, -1,  0,  1,  0,  0,  0 },   // b
            { 0,  0,  0,  0,  1,  0,  0 },   // c
            { 0,  0,  0,  0,  0,  1,  1 },   // d
            { -1, 0, -1, -1, -1, 0, -1 }     // e
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdjacency_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Adjacency Matrix";
            ShowMatrix(adjacencyMatrix, vertices, vertices);
        }

        private void btnIncidence_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Incidence Matrix";
            ShowMatrix(incidenceMatrix, vertices, edges);
        }

        private void ShowMatrix(int[,] matrix, string[] rowLabels, string[] colLabels)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Створюємо стовпці
            dataGridView1.Columns.Add("vertex", "");
            foreach (var col in colLabels)
            {
                dataGridView1.Columns.Add(col, col);
            }

            // Додаємо рядки
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] row = new string[matrix.GetLength(1) + 1];
                row[0] = rowLabels[i];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j + 1] = matrix[i, j].ToString();
                }
                dataGridView1.Rows.Add(row);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
