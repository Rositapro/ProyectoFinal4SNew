namespace ProyectoFinal4S
{
    partial class FrmAPI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvData = new DataGridView();
            btnSearch = new Button();
            cbMonth = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.BackgroundColor = SystemColors.ControlLight;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(0, 0, 64);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            dgvData.Location = new Point(229, 285);
            dgvData.Margin = new Padding(4, 5, 4, 5);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 62;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1300, 680);
            dgvData.TabIndex = 0;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Yu Gothic UI", 12F);
            btnSearch.Location = new Point(437, 188);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 62);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbMonth
            // 
            cbMonth.Font = new Font("Yu Gothic UI", 12F);
            cbMonth.FormattingEnabled = true;
            cbMonth.Location = new Point(229, 197);
            cbMonth.Margin = new Padding(4, 5, 4, 5);
            cbMonth.Name = "cbMonth";
            cbMonth.Size = new Size(171, 40);
            cbMonth.TabIndex = 2;
            cbMonth.SelectedIndexChanged += cbMonth_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(736, 80);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(309, 48);
            label1.TabIndex = 3;
            label1.Text = "Picture of the day";
            // 
            // FrmAPI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1731, 1050);
            Controls.Add(label1);
            Controls.Add(cbMonth);
            Controls.Add(btnSearch);
            Controls.Add(dgvData);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmAPI";
            Text = "Form1";
            TransparencyKey = SystemColors.ScrollBar;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvData;
        private Button btnSearch;
        private ComboBox cbMonth;
        private Label label1;
    }
}
