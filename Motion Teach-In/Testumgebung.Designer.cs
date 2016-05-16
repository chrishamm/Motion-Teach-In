namespace Motion_Teach_In
{
    partial class Testumgebung
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
            this.zeichenfläche1 = new Motion_Teach_In.Zeichenfläche();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zeichenfläche1
            // 
            this.zeichenfläche1.BackColor = System.Drawing.Color.Green;
            this.zeichenfläche1.Location = new System.Drawing.Point(132, 80);
            this.zeichenfläche1.Name = "zeichenfläche1";
            this.zeichenfläche1.Size = new System.Drawing.Size(567, 403);
            this.zeichenfläche1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(740, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Testumgebung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 520);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zeichenfläche1);
            this.Name = "Testumgebung";
            this.Text = "Testumgebung";
            this.ResumeLayout(false);

        }

        #endregion

        private Zeichenfläche zeichenfläche1;
        private System.Windows.Forms.Button button1;
    }
}