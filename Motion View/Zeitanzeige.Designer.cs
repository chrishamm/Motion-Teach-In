namespace Motion_View
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
            this.tlpInhalt = new System.Windows.Forms.TableLayoutPanel();
            this.slider = new System.Windows.Forms.TrackBar();
            this.pnlLabels = new System.Windows.Forms.Panel();
            this.tlpInhalt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpInhalt
            // 
            this.tlpInhalt.AutoSize = true;
            this.tlpInhalt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpInhalt.ColumnCount = 1;
            this.tlpInhalt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInhalt.Controls.Add(this.slider, 0, 1);
            this.tlpInhalt.Controls.Add(this.pnlLabels, 0, 0);
            this.tlpInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInhalt.Location = new System.Drawing.Point(0, 0);
            this.tlpInhalt.Name = "tlpInhalt";
            this.tlpInhalt.RowCount = 2;
            this.tlpInhalt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInhalt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInhalt.Size = new System.Drawing.Size(742, 65);
            this.tlpInhalt.TabIndex = 0;
            // 
            // slider
            // 
            this.slider.Dock = System.Windows.Forms.DockStyle.Top;
            this.slider.Location = new System.Drawing.Point(3, 17);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(736, 45);
            this.slider.TabIndex = 3;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
            // 
            // pnlLabels
            // 
            this.pnlLabels.AutoSize = true;
            this.pnlLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabels.Location = new System.Drawing.Point(3, 3);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlLabels.Size = new System.Drawing.Size(736, 8);
            this.pnlLabels.TabIndex = 4;
            this.pnlLabels.Resize += new System.EventHandler(this.pnlLabels_Resize);
            // 
            // Zeitanzeige
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tlpInhalt);
            this.Name = "Zeitanzeige";
            this.Size = new System.Drawing.Size(742, 65);
            this.tlpInhalt.ResumeLayout(false);
            this.tlpInhalt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpInhalt;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Panel pnlLabels;
    }
}
