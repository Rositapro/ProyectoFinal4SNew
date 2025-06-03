namespace ProyectoFinal4S
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            btnAPI = new Button();
            btnDataSet = new Button();
            SuspendLayout();
            // 
            // btnAPI
            // 
            btnAPI.Font = new Font("Yu Gothic", 11.25F);
            btnAPI.Location = new Point(405, 116);
            btnAPI.Name = "btnAPI";
            btnAPI.Size = new Size(124, 41);
            btnAPI.TabIndex = 0;
            btnAPI.Text = "NASA API";
            btnAPI.UseVisualStyleBackColor = true;
            btnAPI.Click += btnAPI_Click;
            // 
            // btnDataSet
            // 
            btnDataSet.Font = new Font("Yu Gothic", 11.25F);
            btnDataSet.Location = new Point(405, 183);
            btnDataSet.Name = "btnDataSet";
            btnDataSet.Size = new Size(124, 36);
            btnDataSet.TabIndex = 1;
            btnDataSet.Text = "DATA SET";
            btnDataSet.UseVisualStyleBackColor = true;
            btnDataSet.Click += btnDataSet_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(822, 475);
            Controls.Add(btnDataSet);
            Controls.Add(btnAPI);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAPI;
        private Button btnDataSet;
    }
}