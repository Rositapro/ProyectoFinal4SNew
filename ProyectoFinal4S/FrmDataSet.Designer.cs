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
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpen.Location = new Point(486, 608);
            btnOpen.Margin = new Padding(4, 5, 4, 5);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(146, 60);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // FrmDataSet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 760);
            Controls.Add(btnOpen);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmDataSet";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion
        private Button btnOpen;
    }
}