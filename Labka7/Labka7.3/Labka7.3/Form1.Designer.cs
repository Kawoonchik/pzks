using System.Windows.Forms;

namespace DomofonServiceApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtAddress;
        private TextBox txtSubscribers;
        private TextBox txtDate;
        private TextBox txtInterval;
        private TextBox txtCondition;
        private TextBox txtStartDate;
        private TextBox txtEndDate;
        private TextBox txtSearchDate;
        private Button btnAdd;
        private Button btnShowAll;
        private Button btnBetweenDates;
        private Button btnCountLastYear;
        private Button btnLastNextMonth;
        private Button btnSearchByDate;
        private ListBox listBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ініціалізація елементів
            txtAddress = new TextBox { PlaceholderText = "Address", Left = 20, Top = 20, Width = 200 };
            txtSubscribers = new TextBox { PlaceholderText = "Subscribers", Left = 20, Top = 50, Width = 200 };
            txtDate = new TextBox { PlaceholderText = "Last service date (DDMMYYYY)", Left = 20, Top = 80, Width = 200 };
            txtInterval = new TextBox { PlaceholderText = "Interval (days)", Left = 20, Top = 110, Width = 200 };
            txtCondition = new TextBox { PlaceholderText = "Condition", Left = 20, Top = 140, Width = 200 };

            btnAdd = new Button { Text = "Add", Left = 240, Top = 20, Width = 120 };
            btnAdd.Click += BtnAdd_Click;

            btnShowAll = new Button { Text = "Show All + Next Service", Left = 240, Top = 50, Width = 180 };
            btnShowAll.Click += BtnShowAll_Click;

            txtStartDate = new TextBox { PlaceholderText = "Start date (DDMMYYYY)", Left = 20, Top = 180, Width = 200 };
            txtEndDate = new TextBox { PlaceholderText = "End date (DDMMYYYY)", Left = 20, Top = 210, Width = 200 };
            btnBetweenDates = new Button { Text = "Show Between Dates", Left = 240, Top = 180, Width = 180 };
            btnBetweenDates.Click += BtnBetweenDates_Click;

            btnCountLastYear = new Button { Text = "Count Satisfactory Last Year", Left = 240, Top = 210, Width = 180 };
            btnCountLastYear.Click += BtnCountLastYear_Click;

            btnLastNextMonth = new Button { Text = "Find Last Service Next Month", Left = 240, Top = 240, Width = 180 };
            btnLastNextMonth.Click += BtnLastNextMonth_Click;

            txtSearchDate = new TextBox { PlaceholderText = "Search date (DDMMYYYY)", Left = 20, Top = 260, Width = 200 };
            btnSearchByDate = new Button { Text = "Search by Date", Left = 240, Top = 270, Width = 180 };
            btnSearchByDate.Click += BtnSearchByDate_Click;

            listBox = new ListBox { Left = 20, Top = 310, Width = 400, Height = 180 };

            // додавання елементів на форму
            Controls.Add(txtAddress);
            Controls.Add(txtSubscribers);
            Controls.Add(txtDate);
            Controls.Add(txtInterval);
            Controls.Add(txtCondition);
            Controls.Add(btnAdd);
            Controls.Add(btnShowAll);
            Controls.Add(txtStartDate);
            Controls.Add(txtEndDate);
            Controls.Add(btnBetweenDates);
            Controls.Add(btnCountLastYear);
            Controls.Add(btnLastNextMonth);
            Controls.Add(txtSearchDate);
            Controls.Add(btnSearchByDate);
            Controls.Add(listBox);

            // налаштування самої форми
            Text = "Domofon Service Manager";
            Width = 480;
            Height = 550;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }
    }
}
