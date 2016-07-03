namespace Motion_Robot
{
    partial class Robotform
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
            this.btnxplus = new System.Windows.Forms.Button();
            this.btnxminus = new System.Windows.Forms.Button();
            this.btnyplus = new System.Windows.Forms.Button();
            this.btnyminus = new System.Windows.Forms.Button();
            this.btnzplus = new System.Windows.Forms.Button();
            this.btnzminus = new System.Windows.Forms.Button();
            this.erklärungpositionierung = new System.Windows.Forms.Label();
            this.btndobotbewegung = new System.Windows.Forms.Button();
            this.btn_notaus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnxplus
            // 
            this.btnxplus.Location = new System.Drawing.Point(31, 34);
            this.btnxplus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnxplus.Name = "btnxplus";
            this.btnxplus.Size = new System.Drawing.Size(67, 62);
            this.btnxplus.TabIndex = 0;
            this.btnxplus.Text = "X+";
            this.btnxplus.UseVisualStyleBackColor = true;
            this.btnxplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnxplus_MouseDown);
            this.btnxplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnxplus_MouseUp);
            // 
            // btnxminus
            // 
            this.btnxminus.Location = new System.Drawing.Point(31, 126);
            this.btnxminus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnxminus.Name = "btnxminus";
            this.btnxminus.Size = new System.Drawing.Size(67, 62);
            this.btnxminus.TabIndex = 1;
            this.btnxminus.Text = "X-";
            this.btnxminus.UseVisualStyleBackColor = true;
            this.btnxminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnxminus_MouseDown);
            this.btnxminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnxplus_MouseUp);
            // 
            // btnyplus
            // 
            this.btnyplus.Location = new System.Drawing.Point(145, 34);
            this.btnyplus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnyplus.Name = "btnyplus";
            this.btnyplus.Size = new System.Drawing.Size(67, 62);
            this.btnyplus.TabIndex = 2;
            this.btnyplus.Text = "Y+";
            this.btnyplus.UseVisualStyleBackColor = true;
            this.btnyplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnyplus_MouseDown);
            this.btnyplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnxplus_MouseUp);
            // 
            // btnyminus
            // 
            this.btnyminus.Location = new System.Drawing.Point(145, 126);
            this.btnyminus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnyminus.Name = "btnyminus";
            this.btnyminus.Size = new System.Drawing.Size(67, 62);
            this.btnyminus.TabIndex = 3;
            this.btnyminus.Text = "Y-";
            this.btnyminus.UseVisualStyleBackColor = true;
            this.btnyminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnyminus_MouseDown);
            this.btnyminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnxplus_MouseUp);
            // 
            // btnzplus
            // 
            this.btnzplus.Location = new System.Drawing.Point(264, 34);
            this.btnzplus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnzplus.Name = "btnzplus";
            this.btnzplus.Size = new System.Drawing.Size(67, 62);
            this.btnzplus.TabIndex = 4;
            this.btnzplus.Text = "Z+";
            this.btnzplus.UseVisualStyleBackColor = true;
            this.btnzplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnzplus_MouseDown);
            this.btnzplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnxplus_MouseUp);
            // 
            // btnzminus
            // 
            this.btnzminus.Location = new System.Drawing.Point(264, 126);
            this.btnzminus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnzminus.Name = "btnzminus";
            this.btnzminus.Size = new System.Drawing.Size(67, 62);
            this.btnzminus.TabIndex = 5;
            this.btnzminus.Text = "Z-";
            this.btnzminus.UseVisualStyleBackColor = true;
            this.btnzminus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnzminus_MouseDown);
            this.btnzminus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnxplus_MouseUp);
            // 
            // erklärungpositionierung
            // 
            this.erklärungpositionierung.AutoSize = true;
            this.erklärungpositionierung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erklärungpositionierung.Location = new System.Drawing.Point(339, 34);
            this.erklärungpositionierung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.erklärungpositionierung.Name = "erklärungpositionierung";
            this.erklärungpositionierung.Size = new System.Drawing.Size(307, 48);
            this.erklärungpositionierung.TabIndex = 6;
            this.erklärungpositionierung.Text = "Bitte fuehren Sie den Roboterarm ueber die\r\n 6 Positionstasten auf die Nullpositi" +
    "on\r\n (Markierung an dem Roboterfuss)";
            // 
            // btndobotbewegung
            // 
            this.btndobotbewegung.Location = new System.Drawing.Point(31, 295);
            this.btndobotbewegung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndobotbewegung.Name = "btndobotbewegung";
            this.btndobotbewegung.Size = new System.Drawing.Size(285, 69);
            this.btndobotbewegung.TabIndex = 7;
            this.btndobotbewegung.Text = "Sende Bewegung an Dobot";
            this.btndobotbewegung.UseVisualStyleBackColor = true;
            this.btndobotbewegung.Click += new System.EventHandler(this.btndobotbewegung_Click);
            // 
            // btn_notaus
            // 
            this.btn_notaus.Location = new System.Drawing.Point(653, 13);
            this.btn_notaus.Name = "btn_notaus";
            this.btn_notaus.Size = new System.Drawing.Size(92, 69);
            this.btn_notaus.TabIndex = 8;
            this.btn_notaus.Text = "NOT-AUS";
            this.btn_notaus.UseVisualStyleBackColor = true;
            this.btn_notaus.Click += new System.EventHandler(this.btn_notaus_Click);
            // 
            // Robotform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 527);
            this.Controls.Add(this.btn_notaus);
            this.Controls.Add(this.btndobotbewegung);
            this.Controls.Add(this.erklärungpositionierung);
            this.Controls.Add(this.btnzminus);
            this.Controls.Add(this.btnzplus);
            this.Controls.Add(this.btnyminus);
            this.Controls.Add(this.btnyplus);
            this.Controls.Add(this.btnxminus);
            this.Controls.Add(this.btnxplus);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Robotform";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Robotform_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnxplus;
        private System.Windows.Forms.Button btnxminus;
        private System.Windows.Forms.Button btnyplus;
        private System.Windows.Forms.Button btnyminus;
        private System.Windows.Forms.Button btnzplus;
        private System.Windows.Forms.Button btnzminus;
        private System.Windows.Forms.Label erklärungpositionierung;
        private System.Windows.Forms.Button btndobotbewegung;
        private System.Windows.Forms.Button btn_notaus;
    }
}

