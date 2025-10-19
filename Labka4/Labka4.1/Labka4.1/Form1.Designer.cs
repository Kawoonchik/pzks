namespace Book
{
    partial class Form1
    {
        /// <summary>
        /// Обов’язковий компонент контейнера.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очищення всіх використовуваних ресурсів.
        /// </summary>
        /// <param name="disposing">true, якщо необхідно звільнити керовані ресурси; інакше — false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelInput = new Label();
            textBoxInput = new TextBox();
            labelOutput = new Label();
            textBoxOutput = new TextBox();
            buttonLoad = new Button();
            buttonFilter = new Button();
            buttonSave = new Button();
            dataGridView1 = new DataGridView();
            labelStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Location = new Point(9, 11);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(57, 15);
            labelInput.TabIndex = 0;
            labelInput.Text = "Input file:";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(88, 8);
            textBoxInput.Margin = new Padding(3, 2, 3, 2);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(219, 23);
            textBoxInput.TabIndex = 1;
            textBoxInput.Text = "InputData.txt";
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(324, 11);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(67, 15);
            labelOutput.TabIndex = 2;
            labelOutput.Text = "Output file:";
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(411, 8);
            textBoxOutput.Margin = new Padding(3, 2, 3, 2);
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(219, 23);
            textBoxOutput.TabIndex = 3;
            textBoxOutput.Text = "OutputData.txt";
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(648, 6);
            buttonLoad.Margin = new Padding(3, 2, 3, 2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(131, 24);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "📂 Load Books";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += BtnLoad_Click;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(788, 6);
            buttonFilter.Margin = new Padding(3, 2, 3, 2);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(149, 24);
            buttonFilter.TabIndex = 5;
            buttonFilter.Text = "Filter: surname starts 'К'";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += BtnFilter_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(945, 6);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(149, 24);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "💾 Save Table";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += BtnSave_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 38);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1085, 435);
            dataGridView1.TabIndex = 7;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(9, 480);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(0, 15);
            labelStatus.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 510);
            Controls.Add(labelStatus);
            Controls.Add(dataGridView1);
            Controls.Add(buttonSave);
            Controls.Add(buttonFilter);
            Controls.Add(buttonLoad);
            Controls.Add(textBoxOutput);
            Controls.Add(labelOutput);
            Controls.Add(textBoxInput);
            Controls.Add(labelInput);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab 4 — Books (filter by surname 'К')";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelStatus;
    }
}
