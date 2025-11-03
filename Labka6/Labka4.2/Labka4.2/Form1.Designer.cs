namespace PrintEditionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtExtra;
        private System.Windows.Forms.Button btnAddMagazine;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.Label lblSearch;

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtExtra = new System.Windows.Forms.TextBox();
            this.btnAddMagazine = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblExtra = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Labels
            lblTitle.Text = "Title:";
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblPublisher.Text = "Publisher:";
            lblPublisher.Location = new System.Drawing.Point(20, 60);
            lblCustomer.Text = "Customer:";
            lblCustomer.Location = new System.Drawing.Point(20, 100);
            lblExtra.Text = "Author/Issue:";
            lblExtra.Location = new System.Drawing.Point(20, 140);
            lblSearch.Text = "Search by customer:";
            lblSearch.Location = new System.Drawing.Point(20, 260);

            // TextBoxes
            txtTitle.Location = new System.Drawing.Point(120, 20);
            txtPublisher.Location = new System.Drawing.Point(120, 60);
            txtCustomer.Location = new System.Drawing.Point(120, 100);
            txtExtra.Location = new System.Drawing.Point(120, 140);
            txtSearch.Location = new System.Drawing.Point(160, 260);

            // Buttons
            btnAddMagazine.Text = "Add Magazine";
            btnAddMagazine.Location = new System.Drawing.Point(20, 180);
            btnAddMagazine.Click += new System.EventHandler(this.btnAddMagazine_Click);

            btnAddBook.Text = "Add Book";
            btnAddBook.Location = new System.Drawing.Point(140, 180);
            btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);

            btnShowAll.Text = "Show All";
            btnShowAll.Location = new System.Drawing.Point(260, 180);
            btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(360, 260);
            btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // ListBox
            lstOutput.Location = new System.Drawing.Point(20, 300);
            lstOutput.Size = new System.Drawing.Size(440, 150);

            // Form
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitle, txtTitle,
                lblPublisher, txtPublisher,
                lblCustomer, txtCustomer,
                lblExtra, txtExtra,
                btnAddMagazine, btnAddBook, btnShowAll,
                lblSearch, txtSearch, btnSearch,
                lstOutput
            });
            this.Text = "Print Edition Manager";
            this.ResumeLayout(false);
        }
    }
}
