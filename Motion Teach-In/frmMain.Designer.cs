﻿namespace Motion_Teach_In
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
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
            this.zeichenfläche1.Location = new System.Drawing.Point(142, 12);
            this.zeichenfläche1.Name = "zeichenfläche1";
            this.zeichenfläche1.Size = new System.Drawing.Size(709, 378);
            this.zeichenfläche1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(965, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 402);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zeichenfläche1);
            this.Name = "frmMain";
            this.Text = "Motion Teach-In";
            this.ResumeLayout(false);

        }

        #endregion

        private Zeichenfläche zeichenfläche1;
        private System.Windows.Forms.Button button1;
    }
}

