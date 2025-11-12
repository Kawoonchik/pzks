namespace GraphRepresentationApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAdjacency;
        private System.Windows.Forms.Button btnIncidence;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAdjacency = new System.Windows.Forms.Button();
            this.btnIncidence = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // Кнопка Adjacency
            this.btnAdjacency.Location = new System.Drawing.Point(20, 20);
            this.btnAdjacency.Size = new System.Drawing.Size(200, 40);
            this.btnAdjacency.Text = "Show Adjacency Matrix";
            this.btnAdjacency.Click += new System.EventHandler(this.btnAdjacency_Click);

            // Кнопка Incidence
            this.btnIncidence.Location = new System.Drawing.Point(240, 20);
            this.btnIncidence.Size = new System.Drawing.Size(200, 40);
            this.btnIncidence.Text = "Show Incidence Matrix";
            this.btnIncidence.Click += new System.EventHandler(this.btnIncidence_Click);

            // Заголовок
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 80);
            this.lblTitle.Text = "Select a matrix to display";

            // Таблиця
            this.dataGridView1.Location = new System.Drawing.Point(20, 120);
            this.dataGridView1.Size = new System.Drawing.Size(650, 300);
            this.dataGridView1.ReadOnly = true;

            // Головна форма
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.btnAdjacency);
            this.Controls.Add(this.btnIncidence);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTitle);
            this.Text = "Graph Representation";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
