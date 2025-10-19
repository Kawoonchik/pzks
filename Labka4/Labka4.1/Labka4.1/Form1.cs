using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Book
{
    public partial class Form1 : Form
    {
        // Number of parameters for a book (Title; Surname; Name; Year; Publisher; Cost; Price; Profit)
        private const int COLS = 8;

        // Static 2D array [N, COLS]
        private string[,]? data;

        // List for easier filtering
        private List<Book> rows = new();

        // UI
        public Form1()
        {
            InitializeComponent();
        }




        private void BtnLoad_Click(object? sender, EventArgs e)
        {
            try
            {
                var path = textBoxInput.Text.Trim();
                if (!File.Exists(path))
                {
                    MessageBox.Show($"File not found: {path}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var lines = File.ReadAllLines(path);
                rows = new List<Book>(lines.Length);


                foreach (var raw in lines)
                {
                    if (string.IsNullOrWhiteSpace(raw)) continue;
                    // split and trim entries
                    var parts = raw.Split(';', StringSplitOptions.TrimEntries);
                    if (parts.Length != COLS)
                        throw new InvalidDataException($"Line has {parts.Length} fields, expected {COLS}.\n\"{raw}\"");

                    rows.Add(Book.Parse(parts));
                }



                // Fill the static 2D array [N, COLS]
                data = new string[rows.Count, COLS];
                for (int i = 0; i < rows.Count; i++)
                {
                    var arr = rows[i].ToStringArray();
                    for (int j = 0; j < COLS; j++)
                        data[i, j] = arr[j];
                }

                // Show in DataGridView
                dataGridView1.DataSource = BuildDataTableFrom2D(data);
                labelStatus.Text = $"Loaded records: {rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void BtnFilter_Click(object? sender, EventArgs e)
        {
            if (rows.Count == 0)
            {
                MessageBox.Show("Please load data first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Filter: books where author's surname starts with k
            var filtered = rows.Where(r => !string.IsNullOrWhiteSpace(r.Surname)
                                           && r.Surname.Trim().StartsWith("K", StringComparison.OrdinalIgnoreCase))
                               .ToList();

            // Update DataGridView
            var table = BuildDataTableFromList(filtered);
            dataGridView1.DataSource = table;

            // Write to file
            var outPath = textBoxOutput.Text.Trim();
            var lines = filtered.Select(f => string.Join(';', f.ToStringArray()));
            File.WriteAllLines(outPath, lines);
            labelStatus.Text = $"Selected: {filtered.Count}. Written to file: {outPath}";
        }


        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.DataSource is not DataTable dt)
            {
                MessageBox.Show("No data to save.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var outPath = textBoxOutput.Text.Trim();
            var lines = new List<string>(dt.Rows.Count);

            foreach (DataRow r in dt.Rows)
            {
                var items = r.ItemArray.Select(x => x?.ToString() ?? string.Empty);
                lines.Add(string.Join(';', items));
            }

            File.WriteAllLines(outPath, lines);
            labelStatus.Text = $"Saved {lines.Count} rows to {outPath}";
        }

        // Convert static 2D array into DataTable
        private static DataTable BuildDataTableFrom2D(string[,] arr)
        {
            var dt = CreateHeader();

            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                var obj = new object[cols];
                for (int j = 0; j < cols; j++)
                    obj[j] = arr[i, j];
                dt.Rows.Add(obj);
            }
            return dt;
        }

        // Build table from List<Book>
        private static DataTable BuildDataTableFromList(List<Book> list)
        {
            var dt = CreateHeader();
            foreach (var b in list)
                dt.Rows.Add(b.ToStringArray());
            return dt;
        }

        // Table headers (8 columns for book)
        private static DataTable CreateHeader()
        {
            var dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("AuthorSurname");
            dt.Columns.Add("AuthorName");
            dt.Columns.Add("Year");
            dt.Columns.Add("Publisher");
            dt.Columns.Add("Cost");
            dt.Columns.Add("Price");
            dt.Columns.Add("Profit");
            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    // Book model
    public class Book
    {
        public string Title { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Name { get; set; } = "";
        public int Year { get; set; }
        public string Publisher { get; set; } = "";
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Profit { get; set; }

        public static Book Parse(string[] p)
        {
            // p length assumed validated earlier
            return new Book
            {
                Title = p[0].Trim(),
                Surname = p[1].Trim(),
                Name = p[2].Trim(),
                Year = int.Parse(p[3], CultureInfo.InvariantCulture),
                Publisher = p[4].Trim(),
                Cost = decimal.Parse(p[5], CultureInfo.InvariantCulture),
                Price = decimal.Parse(p[6], CultureInfo.InvariantCulture),
                Profit = decimal.Parse(p[7], CultureInfo.InvariantCulture)
            };
        }

        public string[] ToStringArray() => new[]
        {
            Title,
            Surname,
            Name,
            Year.ToString(CultureInfo.InvariantCulture),
            Publisher,
            Cost.ToString(CultureInfo.InvariantCulture),
            Price.ToString(CultureInfo.InvariantCulture),
            Profit.ToString(CultureInfo.InvariantCulture)
        };
    }
}
