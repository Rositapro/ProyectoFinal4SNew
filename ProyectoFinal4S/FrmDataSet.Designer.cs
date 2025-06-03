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
            btnSave = new Button();
            cmbExportFormat = new ComboBox();
            btnExport = new Button();
            cmbClassFilter = new ComboBox();
            btnFilterClass = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpen.Location = new Point(310, 574);
            btnOpen.Margin = new Padding(4, 5, 4, 5);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(146, 60);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(310, 75);
            dgvData.Margin = new Padding(4, 5, 4, 5);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(904, 477);
            dgvData.TabIndex = 5;
            // 
            // cmbDeleteType
            // 
            cmbDeleteType.FormattingEnabled = true;
            cmbDeleteType.Location = new Point(36, 158);
            cmbDeleteType.Name = "cmbDeleteType";
            cmbDeleteType.Size = new Size(116, 33);
            cmbDeleteType.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(191, 158);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClearData
            // 
            btnClearData.Location = new Point(191, 101);
            btnClearData.Name = "btnClearData";
            btnClearData.Size = new Size(112, 34);
            btnClearData.TabIndex = 14;
            btnClearData.Text = "Clear Data";
            btnClearData.UseVisualStyleBackColor = true;
            btnClearData.Click += btnClearData_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(478, 574);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 55);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbExportFormat
            // 
            cmbExportFormat.FormattingEnabled = true;
            cmbExportFormat.Location = new Point(945, 574);
            cmbExportFormat.Name = "cmbExportFormat";
            cmbExportFormat.Size = new Size(144, 33);
            cmbExportFormat.TabIndex = 16;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(1102, 572);
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
            cmbClassFilter.Location = new Point(907, 34);
            cmbClassFilter.Name = "cmbClassFilter";
            cmbClassFilter.Size = new Size(182, 33);
            cmbClassFilter.TabIndex = 18;
            // 
            // btnFilterClass
            // 
            btnFilterClass.Location = new Point(1095, 32);
            btnFilterClass.Name = "btnFilterClass";
            btnFilterClass.Size = new Size(112, 34);
            btnFilterClass.TabIndex = 19;
            btnFilterClass.Text = "Filter";
            btnFilterClass.UseVisualStyleBackColor = true;
            btnFilterClass.Click += btnFilterClass_Click;
            // 
            // FrmDataSet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 760);
            Controls.Add(btnFilterClass);
            Controls.Add(cmbClassFilter);
            Controls.Add(btnExport);
            Controls.Add(cmbExportFormat);
            Controls.Add(btnSave);
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
        }

        #endregion
        private Button btnOpen;
        private DataGridView dgvData;
        private ComboBox cmbDeleteType;
        private Button btnDelete;
        private Button btnClearData;
        private Button btnSave;
        private ComboBox cmbExportFormat;
        private Button btnExport;
        private ComboBox cmbClassFilter;
        private Button btnFilterClass;
    }
}