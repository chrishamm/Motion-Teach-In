namespace Motion_Teach_In
{
    partial class Zeichenfläche
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
            this.SuspendLayout();
            // 
            // Zeichenfläche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "Zeichenfläche";
            this.Size = new System.Drawing.Size(719, 403);
            this.Load += new System.EventHandler(this.Zeichenfläche_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Zeichenfläche_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zeichenfläche_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Zeichenfläche_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Zeichenfläche_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
