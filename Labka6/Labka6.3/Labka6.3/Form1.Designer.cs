namespace ComputerSorterApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtHDD;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSortPrice;
        private System.Windows.Forms.Button btnSortPriceHDD;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblHDD;

        private void InitializeComponent()
        {
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtHDD = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSortPrice = new System.Windows.Forms.Button();
            this.btnSortPriceHDD = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblHDD = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Labels
            this.lblBrand.Text = "Brand:";
            this.lblBrand.Location = new System.Drawing.Point(20, 20);
            this.lblPrice.Text = "Price ($):";
            this.lblPrice.Location = new System.Drawing.Point(20, 60);
            this.lblHDD.Text = "HDD (GB):";
            this.lblHDD.Location = new System.Drawing.Point(20, 100);

            // TextBoxes
            this.txtBrand.Location = new System.Drawing.Point(120, 20);
            this.txtPrice.Location = new System.Drawing.Point(120, 60);
            this.txtHDD.Location = new System.Drawing.Point(120, 100);

            // Buttons
            this.btnAdd.Text = "Add Computer";
            this.btnAdd.Location = new System.Drawing.Point(20, 140);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Location = new System.Drawing.Point(140, 140);
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            this.btnSortPrice.Text = "Sort by Price";
            this.btnSortPrice.Location = new System.Drawing.Point(260, 140);
            this.btnSortPrice.Click += new System.EventHandler(this.btnSortPrice_Click);

            this.btnSortPriceHDD.Text = "Sort by Price + HDD";
            this.btnSortPriceHDD.Location = new System.Drawing.Point(380, 140);
            this.btnSortPriceHDD.Click += new System.EventHandler(this.btnSortPriceHDD_Click);

            // ListBox
            this.lstOutput.Location = new System.Drawing.Point(20, 190);
            this.lstOutput.Size = new System.Drawing.Size(500, 200);

            // Form
            this.ClientSize = new System.Drawing.Size(550, 420);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblBrand, txtBrand,
                lblPrice, txtPrice,
                lblHDD, txtHDD,
                btnAdd, btnShowAll, btnSortPrice, btnSortPriceHDD,
                lstOutput
            });
            this.Text = "Computer Sorter";
            this.ResumeLayout(false);
        }
    }
}
