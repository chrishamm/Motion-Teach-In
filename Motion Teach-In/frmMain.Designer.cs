namespace Motion_Teach_In
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tssDatei = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBeenden = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.tsbZeichnenmodus = new System.Windows.Forms.ToolStripButton();
            this.tsbLoeschmodus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbWiedergabe = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.spcInhalt = new System.Windows.Forms.SplitContainer();
            this.zflInhalt = new Motion_Teach_In.Zeichenfläche();
            this.mnuMenu.SuspendLayout();
            this.tsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcInhalt)).BeginInit();
            this.spcInhalt.Panel2.SuspendLayout();
            this.spcInhalt.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(1070, 24);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.speichernUnterToolStripMenuItem,
            this.tssDatei,
            this.mnuBeenden});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("neuToolStripMenuItem.Image")));
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("speichernToolStripMenuItem.Image")));
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            // 
            // speichernUnterToolStripMenuItem
            // 
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.speichernUnterToolStripMenuItem.Text = "Speichern unter...";
            // 
            // tssDatei
            // 
            this.tssDatei.Name = "tssDatei";
            this.tssDatei.Size = new System.Drawing.Size(163, 6);
            // 
            // mnuBeenden
            // 
            this.mnuBeenden.Name = "mnuBeenden";
            this.mnuBeenden.Size = new System.Drawing.Size(166, 22);
            this.mnuBeenden.Text = "Beenden";
            this.mnuBeenden.Click += new System.EventHandler(this.mnuBeenden_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.überToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.überToolStripMenuItem.Text = "Über";
            // 
            // tsToolbar
            // 
            this.tsToolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZeichnenmodus,
            this.tsbLoeschmodus,
            this.toolStripSeparator2,
            this.tsbWiedergabe,
            this.tsbStop});
            this.tsToolbar.Location = new System.Drawing.Point(0, 24);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(1070, 31);
            this.tsToolbar.TabIndex = 3;
            this.tsToolbar.Text = "Toolbar";
            // 
            // tsbZeichnenmodus
            // 
            this.tsbZeichnenmodus.Checked = true;
            this.tsbZeichnenmodus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbZeichnenmodus.Image = ((System.Drawing.Image)(resources.GetObject("tsbZeichnenmodus.Image")));
            this.tsbZeichnenmodus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZeichnenmodus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZeichnenmodus.Name = "tsbZeichnenmodus";
            this.tsbZeichnenmodus.Size = new System.Drawing.Size(114, 28);
            this.tsbZeichnenmodus.Text = "Zeichenmodus";
            this.tsbZeichnenmodus.Click += new System.EventHandler(this.tsbZeichnenmodus_Click);
            // 
            // tsbLoeschmodus
            // 
            this.tsbLoeschmodus.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoeschmodus.Image")));
            this.tsbLoeschmodus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoeschmodus.Name = "tsbLoeschmodus";
            this.tsbLoeschmodus.Size = new System.Drawing.Size(103, 28);
            this.tsbLoeschmodus.Text = "Löschmodus";
            this.tsbLoeschmodus.Click += new System.EventHandler(this.tsbLoeschmodus_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbWiedergabe
            // 
            this.tsbWiedergabe.Image = ((System.Drawing.Image)(resources.GetObject("tsbWiedergabe.Image")));
            this.tsbWiedergabe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWiedergabe.Name = "tsbWiedergabe";
            this.tsbWiedergabe.Size = new System.Drawing.Size(98, 28);
            this.tsbWiedergabe.Text = "Wiedergabe";
            this.tsbWiedergabe.Click += new System.EventHandler(this.tsbWiedergabe_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.Enabled = false;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(144, 28);
            this.tsbStop.Text = "Wiedergabe stoppen";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // spcInhalt
            // 
            this.spcInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcInhalt.Location = new System.Drawing.Point(0, 0);
            this.spcInhalt.Name = "spcInhalt";
            // 
            // spcInhalt.Panel2
            // 
            this.spcInhalt.Panel2.Controls.Add(this.zflInhalt);
            this.spcInhalt.Size = new System.Drawing.Size(1070, 528);
            this.spcInhalt.SplitterDistance = 220;
            this.spcInhalt.TabIndex = 4;
            // 
            // zflInhalt
            // 
            this.zflInhalt.BackColor = System.Drawing.Color.Green;
            this.zflInhalt.ControlModus = Motion_Teach_In.Zeichenfläche.Modus.Zeichenmodus;
            this.zflInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zflInhalt.Location = new System.Drawing.Point(0, 0);
            this.zflInhalt.Name = "zflInhalt";
            this.zflInhalt.Size = new System.Drawing.Size(846, 528);
            this.zflInhalt.TabIndex = 1;
            this.zflInhalt.WiedergabeGestartet += new System.EventHandler(this.zflInhalt_WiedergabeGestartet);
            this.zflInhalt.WiedergabeGestoppt += new System.EventHandler(this.zflInhalt_WiedergabeGestoppt);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 528);
            this.Controls.Add(this.tsToolbar);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.spcInhalt);
            this.MainMenuStrip = this.mnuMenu;
            this.Name = "frmMain";
            this.Text = "Motion Teach-In";
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.spcInhalt.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcInhalt)).EndInit();
            this.spcInhalt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernUnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBeenden;
        private System.Windows.Forms.ToolStripSeparator tssDatei;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton tsbZeichnenmodus;
        private System.Windows.Forms.ToolStripButton tsbLoeschmodus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbWiedergabe;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.SplitContainer spcInhalt;
        private Zeichenfläche zflInhalt;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem;
    }
}

