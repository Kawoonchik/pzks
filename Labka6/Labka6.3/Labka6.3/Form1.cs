using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ComputerSorterApp
{
    
    public class Computer : IComparable<Computer>
    {
        public string Brand { get; set; }
        public double Price { get; set; }
        public int HDD { get; set; } //gb

        public Computer(string brand, double price, int hdd)
        {
            Brand = brand;
            Price = price;
            HDD = hdd;
        }

        //  price
        public int CompareTo(Computer other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{Brand} | ${Price:F2} | HDD: {HDD} GB";
        }
    }

    //
    public class ComputerComparer : IComparer<Computer>
    {
        public int Compare(Computer x, Computer y)
        {
            if (x == null || y == null) return 0;

            int priceCompare = x.Price.CompareTo(y.Price);
            if (priceCompare != 0)
                return priceCompare;

            return x.HDD.CompareTo(y.HDD);
        }
    }

    
    public class ComputerCollection : IEnumerable<Computer>
    {
        private List<Computer> computers = new List<Computer>();

        public void Add(Computer c) => computers.Add(c);
        public IEnumerator<Computer> GetEnumerator() => computers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Sort(IComparer<Computer> comparer)
        {
            computers.Sort(comparer);
        }

        public void Sort() => computers.Sort();
    }

    // ---------- Main Form ----------
    public partial class Form1 : Form
    {
        private ComputerCollection computers = new ComputerCollection();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string brand = txtBrand.Text;
                double price = double.Parse(txtPrice.Text);
                int hdd = int.Parse(txtHDD.Text);

                computers.Add(new Computer(brand, price, hdd));
                MessageBox.Show("Computer added successfully!");
            }
            catch
            {
                MessageBox.Show("Invalid input! Check numbers.");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();
            foreach (var c in computers)
                lstOutput.Items.Add(c.ToString());
        }

        private void btnSortPrice_Click(object sender, EventArgs e)
        {
            computers.Sort();
            lstOutput.Items.Clear();
            foreach (var c in computers)
                lstOutput.Items.Add(c.ToString());
        }

        private void btnSortPriceHDD_Click(object sender, EventArgs e)
        {
            computers.Sort(new ComputerComparer());
            lstOutput.Items.Clear();
            foreach (var c in computers)
                lstOutput.Items.Add(c.ToString());
        }
    }
}
