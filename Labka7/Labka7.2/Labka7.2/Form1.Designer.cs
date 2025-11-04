namespace AeroflotApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.ListBox resultListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.showAllButton = new System.Windows.Forms.Button();
            this.resultListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Text = "City:";

            // cityTextBox
            this.cityTextBox.Location = new System.Drawing.Point(120, 22);
            this.cityTextBox.Size = new System.Drawing.Size(200, 23);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Text = "Flight number:";

            // numTextBox
            this.numTextBox.Location = new System.Drawing.Point(120, 62);
            this.numTextBox.Size = new System.Drawing.Size(200, 23);

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 105);
            this.label3.Text = "Plane type:";

            // typeTextBox
            this.typeTextBox.Location = new System.Drawing.Point(120, 102);
            this.typeTextBox.Size = new System.Drawing.Size(200, 23);

            // addButton
            this.addButton.Location = new System.Drawing.Point(25, 140);
            this.addButton.Size = new System.Drawing.Size(140, 30);
            this.addButton.Text = "Add flight";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // sortButton
            this.sortButton.Location = new System.Drawing.Point(180, 140);
            this.sortButton.Size = new System.Drawing.Size(140, 30);
            this.sortButton.Text = "Sort by city";
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 190);
            this.label4.Text = "Search by plane type:";

            // searchTextBox
            this.searchTextBox.Location = new System.Drawing.Point(180, 187);
            this.searchTextBox.Size = new System.Drawing.Size(140, 23);

            // searchButton
            this.searchButton.Location = new System.Drawing.Point(340, 185);
            this.searchButton.Size = new System.Drawing.Size(100, 27);
            this.searchButton.Text = "Search";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);

            // showAllButton
            this.showAllButton.Location = new System.Drawing.Point(460, 185);
            this.showAllButton.Size = new System.Drawing.Size(100, 27);
            this.showAllButton.Text = "Show all";
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);

            // resultListBox
            this.resultListBox.Location = new System.Drawing.Point(25, 230);
            this.resultListBox.Size = new System.Drawing.Size(535, 180);

            // MainForm
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.showAllButton);
            this.Controls.Add(this.resultListBox);
            this.Text = "Aeroflot Flights";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
