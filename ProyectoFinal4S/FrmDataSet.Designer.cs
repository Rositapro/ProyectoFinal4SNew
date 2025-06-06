namespace ProyectoFinal4S
{
    partial class FrmDataSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOpen = new Button();
            dgvData = new DataGridView();
            cmbDeleteType = new ComboBox();
            btnDelete = new Button();
            btnClearData = new Button();
            btnsqlDate = new Button();
            cmbExportFormat = new ComboBox();
            btnExport = new Button();
            cmbClassFilter = new ComboBox();
            btnFilterClass = new Button();
            textBox1 = new TextBox();
            txtPlainText = new TextBox();
            cmbViewOption = new ComboBox();
            lblView = new Label();
            cmbSortBy = new ComboBox();
            btnEnviarArchivo = new Button();
            treeView = new TreeView();
            btnSaveSqlChanges = new Button();
            progressBar1 = new ProgressBar();
            lblProgress = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpen.Location = new Point(13, 20);
            btnOpen.Margin = new Padding(4, 5, 4, 5);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(112, 34);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(4, 124);
            dgvData.Margin = new Padding(4, 5, 4, 5);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(904, 477);
            dgvData.TabIndex = 5;
            // 
            // cmbDeleteType
            // 
            cmbDeleteType.FormattingEnabled = true;
            cmbDeleteType.Location = new Point(11, 618);
            cmbDeleteType.Name = "cmbDeleteType";
            cmbDeleteType.Size = new Size(116, 33);
            cmbDeleteType.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(133, 618);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClearData
            // 
            btnClearData.Location = new Point(133, 658);
            btnClearData.Name = "btnClearData";
            btnClearData.Size = new Size(112, 34);
            btnClearData.TabIndex = 14;
            btnClearData.Text = "Clear Data";
            btnClearData.UseVisualStyleBackColor = true;
            btnClearData.Click += btnClearData_Click;
            // 
            // btnsqlDate
            // 
            btnsqlDate.Location = new Point(142, 20);
            btnsqlDate.Margin = new Padding(4, 5, 4, 5);
            btnsqlDate.Name = "btnsqlDate";
            btnsqlDate.Size = new Size(112, 34);
            btnsqlDate.TabIndex = 15;
            btnsqlDate.Text = "Sql";
            btnsqlDate.UseVisualStyleBackColor = true;
            btnsqlDate.Click += btnsqlDate_Click;
            // 
            // cmbExportFormat
            // 
            cmbExportFormat.FormattingEnabled = true;
            cmbExportFormat.Location = new Point(639, 618);
            cmbExportFormat.Name = "cmbExportFormat";
            cmbExportFormat.Size = new Size(144, 33);
            cmbExportFormat.TabIndex = 16;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(796, 616);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(112, 34);
            btnExport.TabIndex = 17;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // cmbClassFilter
            // 
            cmbClassFilter.FormattingEnabled = true;
            cmbClassFilter.Location = new Point(617, 14);
            cmbClassFilter.Name = "cmbClassFilter";
            cmbClassFilter.Size = new Size(182, 33);
            cmbClassFilter.TabIndex = 18;
            // 
            // btnFilterClass
            // 
            btnFilterClass.Location = new Point(805, 12);
            btnFilterClass.Name = "btnFilterClass";
            btnFilterClass.Size = new Size(112, 34);
            btnFilterClass.TabIndex = 19;
            btnFilterClass.Text = "Filter";
            btnFilterClass.UseVisualStyleBackColor = true;
            btnFilterClass.Click += btnFilterClass_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1259, 254);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(8, 31);
            textBox1.TabIndex = 20;
            // 
            // txtPlainText
            // 
            txtPlainText.Location = new Point(948, 14);
            txtPlainText.Multiline = true;
            txtPlainText.Name = "txtPlainText";
            txtPlainText.ScrollBars = ScrollBars.Vertical;
            txtPlainText.Size = new Size(721, 380);
            txtPlainText.TabIndex = 21;
            txtPlainText.Visible = false;
            // 
            // cmbViewOption
            // 
            cmbViewOption.FormattingEnabled = true;
            cmbViewOption.Location = new Point(72, 77);
            cmbViewOption.Name = "cmbViewOption";
            cmbViewOption.Size = new Size(182, 33);
            cmbViewOption.TabIndex = 22;
            // 
            // lblView
            // 
            lblView.AutoSize = true;
            lblView.Location = new Point(13, 77);
            lblView.Name = "lblView";
            lblView.Size = new Size(49, 25);
            lblView.TabIndex = 23;
            lblView.Text = "View";
            // 
            // cmbSortBy
            // 
            cmbSortBy.FormattingEnabled = true;
            cmbSortBy.Location = new Point(270, 77);
            cmbSortBy.Name = "cmbSortBy";
            cmbSortBy.Size = new Size(182, 33);
            cmbSortBy.TabIndex = 24;
            // 
            // btnEnviarArchivo
            // 
            btnEnviarArchivo.Location = new Point(796, 658);
            btnEnviarArchivo.Name = "btnEnviarArchivo";
            btnEnviarArchivo.Size = new Size(112, 34);
            btnEnviarArchivo.TabIndex = 25;
            btnEnviarArchivo.Text = "Enviar";
            btnEnviarArchivo.UseVisualStyleBackColor = true;
            btnEnviarArchivo.Click += btnEnviarArchivo_Click;
            // 
            // treeView
            // 
            treeView.Location = new Point(948, 432);
            treeView.Name = "treeView";
            treeView.Size = new Size(721, 323);
            treeView.TabIndex = 26;
            // 
            // btnSaveSqlChanges
            // 
            btnSaveSqlChanges.Location = new Point(270, 20);
            btnSaveSqlChanges.Margin = new Padding(4, 5, 4, 5);
            btnSaveSqlChanges.Name = "btnSaveSqlChanges";
            btnSaveSqlChanges.Size = new Size(112, 34);
            btnSaveSqlChanges.TabIndex = 27;
            btnSaveSqlChanges.Text = "changes";
            btnSaveSqlChanges.UseVisualStyleBackColor = true;
            btnSaveSqlChanges.Click += btnSaveSqlChanges_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(567, 76);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(232, 34);
            progressBar1.TabIndex = 28;
            progressBar1.Visible = false;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(805, 80);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(59, 25);
            lblProgress.TabIndex = 29;
            lblProgress.Text = "label1";
            // 
            // FrmDataSet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1776, 760);
            Controls.Add(lblProgress);
            Controls.Add(progressBar1);
            Controls.Add(btnSaveSqlChanges);
            Controls.Add(treeView);
            Controls.Add(btnEnviarArchivo);
            Controls.Add(cmbSortBy);
            Controls.Add(lblView);
            Controls.Add(cmbViewOption);
            Controls.Add(txtPlainText);
            Controls.Add(textBox1);
            Controls.Add(btnFilterClass);
            Controls.Add(cmbClassFilter);
            Controls.Add(btnExport);
            Controls.Add(cmbExportFormat);
            Controls.Add(btnsqlDate);
            Controls.Add(btnClearData);
            Controls.Add(btnDelete);
            Controls.Add(cmbDeleteType);
            Controls.Add(dgvData);
            Controls.Add(btnOpen);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmDataSet";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnOpen;
        private DataGridView dgvData;
        private ComboBox cmbDeleteType;
        private Button btnDelete;
        private Button btnClearData;
        private Button btnsqlDate;
        private ComboBox cmbExportFormat;
        private Button btnExport;
        private ComboBox cmbClassFilter;
        private Button btnFilterClass;
        private TextBox textBox1;
        private TextBox txtPlainText;
        private ComboBox cmbViewOption;
        private Label lblView;
        private ComboBox cmbSortBy;
        private Button btnEnviarArchivo;
        private TreeView treeView;
        private Button btnSaveSqlChanges;
        private ProgressBar progressBar1;
        private Label lblProgress;
    }
}