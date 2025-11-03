using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PrintEditionApp
{
    public interface IPrintEdition
    {
        string Title { get; set; }
        string Publisher { get; set; }

        void PrintInfo();
        string GetInfo();
    }

    public interface ICustomer
    {
        string CustomerName { get; set; }
        void PlaceOrder();
        string GetCustomerInfo();
    }

    public class Magazine : IPrintEdition, ICustomer
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string CustomerName { get; set; }
        public int IssueNumber { get; set; }

        public Magazine(string title, string publisher, string customerName, int issueNumber)
        {
            Title = title;
            Publisher = publisher;
            CustomerName = customerName;
            IssueNumber = issueNumber;
        }

        public void PrintInfo()
        {
            MessageBox.Show($"Magazine '{Title}' by {Publisher}, issue #{IssueNumber}");
        }

        public string GetInfo()
        {
            return $"[Magazine] Title: {Title}, Publisher: {Publisher}, Issue: {IssueNumber}, Customer: {CustomerName}";
        }

        public void PlaceOrder()
        {
            MessageBox.Show($"{CustomerName} ordered magazine '{Title}'");
        }

        public string GetCustomerInfo()
        {
            return $"Customer: {CustomerName}";
        }

        // Specific method 
        public void RenewSubscription()
        {
            MessageBox.Show($"Subscription for '{Title}' renewed!");
        }
    }

    public class Book : IPrintEdition, ICustomer
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string CustomerName { get; set; }
        public string Author { get; set; }

        public Book(string title, string publisher, string customerName, string author)
        {
            Title = title;
            Publisher = publisher;
            CustomerName = customerName;
            Author = author;
        }

        public void PrintInfo()
        {
            MessageBox.Show($"Book '{Title}' by {Author}, published by {Publisher}");
        }

        public string GetInfo()
        {
            return $"[Book] Title: {Title}, Author: {Author}, Publisher: {Publisher}, Customer: {CustomerName}";
        }

        public void PlaceOrder()
        {
            MessageBox.Show($"{CustomerName} ordered book '{Title}'");
        }

        public string GetCustomerInfo()
        {
            return $"Customer: {CustomerName}";
        }

        public void RateBook(int stars)
        {
            MessageBox.Show($"'{Title}' rated {stars} stars!");
        }
    }

    // ---------- Main Form ----------
    public partial class Form1 : Form
    {
        private List<IPrintEdition> database = new List<IPrintEdition>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddMagazine_Click(object sender, EventArgs e)
        {
            try
            {
                int issue = int.Parse(txtExtra.Text);
                Magazine m = new Magazine(txtTitle.Text, txtPublisher.Text, txtCustomer.Text, issue);
                database.Add(m);
                MessageBox.Show("Magazine added successfully!");
            }
            catch
            {
                MessageBox.Show("Issue number must be an integer!");
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Book b = new Book(txtTitle.Text, txtPublisher.Text, txtCustomer.Text, txtExtra.Text);
            database.Add(b);
            MessageBox.Show("Book added successfully!");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();
            foreach (var item in database)
                lstOutput.Items.Add(item.GetInfo());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();
            string search = txtSearch.Text.ToLower();

            foreach (var item in database)
            {
                if (item is ICustomer customer && customer.CustomerName.ToLower().Contains(search))
                    lstOutput.Items.Add(item.GetInfo());
            }
        }
    }
}
