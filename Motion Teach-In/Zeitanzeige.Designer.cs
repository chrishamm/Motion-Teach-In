﻿namespace Motion_Teach_In
{
    partial class Zeitanzeige
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.slider = new System.Windows.Forms.TrackBar();
            this.skala = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // slider
            // 
            this.slider.Dock = System.Windows.Forms.DockStyle.Top;
            this.slider.Location = new System.Drawing.Point(0, 0);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(736, 45);
            this.slider.TabIndex = 0;
            // 
            // skala
            // 
            this.skala.AutoSize = true;
            this.skala.Dock = System.Windows.Forms.DockStyle.Top;
            this.skala.Location = new System.Drawing.Point(0, 45);
            this.skala.Name = "skala";
            this.skala.Size = new System.Drawing.Size(126, 13);
            this.skala.TabIndex = 1;
            this.skala.Text = "hier kommt eine skala hin";
            // 
            // Zeitanzeige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skala);
            this.Controls.Add(this.slider);
            this.Name = "Zeitanzeige";
            this.Size = new System.Drawing.Size(736, 64);
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Label skala;
    }
}