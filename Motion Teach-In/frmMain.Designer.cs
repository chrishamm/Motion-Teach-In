using Motion_View;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuDatei = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNeu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuÖffnen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpeichern = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpeichernUnter = new System.Windows.Forms.ToolStripMenuItem();
            this.tssDatei = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBeenden = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGCodeErzeugen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHilfe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuÜber = new System.Windows.Forms.ToolStripMenuItem();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.tsbBewegen = new System.Windows.Forms.ToolStripButton();
            this.tsbZeichnenmodus = new System.Windows.Forms.ToolStripButton();
            this.tsbLoeschmodus = new System.Windows.Forms.ToolStripButton();
            this.tssModus = new System.Windows.Forms.ToolStripSeparator();
            this.tsbWiedergabeStarten = new System.Windows.Forms.ToolStripButton();
            this.tsbWiedergabeStoppen = new System.Windows.Forms.ToolStripButton();
            this.tssWiedergabe = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUrsprungFestlegen = new System.Windows.Forms.ToolStripButton();
            this.spcInhalt = new System.Windows.Forms.SplitContainer();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblLinien = new System.Windows.Forms.Label();
            this.lstLinien = new System.Windows.Forms.ListBox();
            this.zflInhalt = new Motion_View.Zeichenfläche();
            this.zazSkala = new Motion_View.Zeitanzeige();
            this.sfdDatei = new System.Windows.Forms.SaveFileDialog();
            this.ofdDatei = new System.Windows.Forms.OpenFileDialog();
            this.tmrWiedergabe = new System.Windows.Forms.Timer(this.components);
            this.robottest = new System.Windows.Forms.Button();
            this.mnuMenu.SuspendLayout();
            this.tsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcInhalt)).BeginInit();
            this.spcInhalt.Panel1.SuspendLayout();
            this.spcInhalt.Panel2.SuspendLayout();
            this.spcInhalt.SuspendLayout();
            this.tlpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatei,
            this.mnuTransfer,
            this.mnuHilfe});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(1070, 24);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuDatei
            // 
            this.mnuDatei.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNeu,
            this.mnuÖffnen,
            this.mnuSpeichern,
            this.mnuSpeichernUnter,
            this.tssDatei,
            this.mnuBeenden});
            this.mnuDatei.Name = "mnuDatei";
            this.mnuDatei.Size = new System.Drawing.Size(46, 20);
            this.mnuDatei.Text = "Datei";
            // 
            // mnuNeu
            // 
            this.mnuNeu.Image = ((System.Drawing.Image)(resources.GetObject("mnuNeu.Image")));
            this.mnuNeu.Name = "mnuNeu";
            this.mnuNeu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNeu.Size = new System.Drawing.Size(291, 22);
            this.mnuNeu.Text = "Neu";
            this.mnuNeu.Click += new System.EventHandler(this.mnuNeu_Click);
            // 
            // mnuÖffnen
            // 
            this.mnuÖffnen.Image = ((System.Drawing.Image)(resources.GetObject("mnuÖffnen.Image")));
            this.mnuÖffnen.Name = "mnuÖffnen";
            this.mnuÖffnen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuÖffnen.Size = new System.Drawing.Size(291, 22);
            this.mnuÖffnen.Text = "Öffnen";
            this.mnuÖffnen.Click += new System.EventHandler(this.mnuÖffnen_Click);
            // 
            // mnuSpeichern
            // 
            this.mnuSpeichern.Image = ((System.Drawing.Image)(resources.GetObject("mnuSpeichern.Image")));
            this.mnuSpeichern.Name = "mnuSpeichern";
            this.mnuSpeichern.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSpeichern.Size = new System.Drawing.Size(291, 22);
            this.mnuSpeichern.Text = "Speichern";
            this.mnuSpeichern.Click += new System.EventHandler(this.mnuSpeichern_Click);
            // 
            // mnuSpeichernUnter
            // 
            this.mnuSpeichernUnter.Name = "mnuSpeichernUnter";
            this.mnuSpeichernUnter.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSpeichernUnter.Size = new System.Drawing.Size(291, 22);
            this.mnuSpeichernUnter.Text = "Speichern unter...";
            this.mnuSpeichernUnter.Click += new System.EventHandler(this.mnuSpeichernUnter_Click);
            // 
            // tssDatei
            // 
            this.tssDatei.Name = "tssDatei";
            this.tssDatei.Size = new System.Drawing.Size(288, 6);
            // 
            // mnuBeenden
            // 
            this.mnuBeenden.Name = "mnuBeenden";
            this.mnuBeenden.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuBeenden.Size = new System.Drawing.Size(291, 22);
            this.mnuBeenden.Text = "Beenden";
            this.mnuBeenden.Click += new System.EventHandler(this.mnuBeenden_Click);
            // 
            // mnuTransfer
            // 
            this.mnuTransfer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGCodeErzeugen});
            this.mnuTransfer.Name = "mnuTransfer";
            this.mnuTransfer.Size = new System.Drawing.Size(62, 20);
            this.mnuTransfer.Text = "Transfer";
            // 
            // mnuGCodeErzeugen
            // 
            this.mnuGCodeErzeugen.Enabled = false;
            this.mnuGCodeErzeugen.Name = "mnuGCodeErzeugen";
            this.mnuGCodeErzeugen.Size = new System.Drawing.Size(166, 22);
            this.mnuGCodeErzeugen.Text = "G-Code erzeugen";
            // 
            // mnuHilfe
            // 
            this.mnuHilfe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuÜber});
            this.mnuHilfe.Name = "mnuHilfe";
            this.mnuHilfe.Size = new System.Drawing.Size(44, 20);
            this.mnuHilfe.Text = "Hilfe";
            // 
            // mnuÜber
            // 
            this.mnuÜber.Enabled = false;
            this.mnuÜber.Name = "mnuÜber";
            this.mnuÜber.Size = new System.Drawing.Size(99, 22);
            this.mnuÜber.Text = "Über";
            // 
            // tsToolbar
            // 
            this.tsToolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBewegen,
            this.tsbZeichnenmodus,
            this.tsbLoeschmodus,
            this.tssModus,
            this.tsbWiedergabeStarten,
            this.tsbWiedergabeStoppen,
            this.tssWiedergabe,
            this.tsbUrsprungFestlegen});
            this.tsToolbar.Location = new System.Drawing.Point(0, 24);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(1070, 31);
            this.tsToolbar.TabIndex = 3;
            this.tsToolbar.Text = "Toolbar";
            // 
            // tsbBewegen
            // 
            this.tsbBewegen.Image = ((System.Drawing.Image)(resources.GetObject("tsbBewegen.Image")));
            this.tsbBewegen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBewegen.Name = "tsbBewegen";
            this.tsbBewegen.Size = new System.Drawing.Size(83, 28);
            this.tsbBewegen.Text = "Bewegen";
            this.tsbBewegen.Click += new System.EventHandler(this.tsbBewegen_Click);
            // 
            // tsbZeichnenmodus
            // 
            this.tsbZeichnenmodus.Checked = true;
            this.tsbZeichnenmodus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbZeichnenmodus.Image = ((System.Drawing.Image)(resources.GetObject("tsbZeichnenmodus.Image")));
            this.tsbZeichnenmodus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZeichnenmodus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZeichnenmodus.Name = "tsbZeichnenmodus";
            this.tsbZeichnenmodus.Size = new System.Drawing.Size(84, 28);
            this.tsbZeichnenmodus.Text = "Zeichnen";
            this.tsbZeichnenmodus.Click += new System.EventHandler(this.tsbZeichnenmodus_Click);
            // 
            // tsbLoeschmodus
            // 
            this.tsbLoeschmodus.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoeschmodus.Image")));
            this.tsbLoeschmodus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoeschmodus.Name = "tsbLoeschmodus";
            this.tsbLoeschmodus.Size = new System.Drawing.Size(79, 28);
            this.tsbLoeschmodus.Text = "Löschen";
            this.tsbLoeschmodus.Click += new System.EventHandler(this.tsbLoeschmodus_Click);
            // 
            // tssModus
            // 
            this.tssModus.Name = "tssModus";
            this.tssModus.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbWiedergabeStarten
            // 
            this.tsbWiedergabeStarten.Image = ((System.Drawing.Image)(resources.GetObject("tsbWiedergabeStarten.Image")));
            this.tsbWiedergabeStarten.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWiedergabeStarten.Name = "tsbWiedergabeStarten";
            this.tsbWiedergabeStarten.Size = new System.Drawing.Size(137, 28);
            this.tsbWiedergabeStarten.Text = "Wiedergabe starten";
            this.tsbWiedergabeStarten.Click += new System.EventHandler(this.tsbWiedergabe_Click);
            // 
            // tsbWiedergabeStoppen
            // 
            this.tsbWiedergabeStoppen.Enabled = false;
            this.tsbWiedergabeStoppen.Image = ((System.Drawing.Image)(resources.GetObject("tsbWiedergabeStoppen.Image")));
            this.tsbWiedergabeStoppen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWiedergabeStoppen.Name = "tsbWiedergabeStoppen";
            this.tsbWiedergabeStoppen.Size = new System.Drawing.Size(144, 28);
            this.tsbWiedergabeStoppen.Text = "Wiedergabe stoppen";
            this.tsbWiedergabeStoppen.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tssWiedergabe
            // 
            this.tssWiedergabe.Name = "tssWiedergabe";
            this.tssWiedergabe.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbUrsprungFestlegen
            // 
            this.tsbUrsprungFestlegen.Image = ((System.Drawing.Image)(resources.GetObject("tsbUrsprungFestlegen.Image")));
            this.tsbUrsprungFestlegen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUrsprungFestlegen.Name = "tsbUrsprungFestlegen";
            this.tsbUrsprungFestlegen.Size = new System.Drawing.Size(135, 28);
            this.tsbUrsprungFestlegen.Text = "Ursprung festlegen";
            this.tsbUrsprungFestlegen.Click += new System.EventHandler(this.tsbUrsprungFestlegen_Click);
            // 
            // spcInhalt
            // 
            this.spcInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcInhalt.Location = new System.Drawing.Point(0, 55);
            this.spcInhalt.Name = "spcInhalt";
            // 
            // spcInhalt.Panel1
            // 
            this.spcInhalt.Panel1.Controls.Add(this.tlpDetails);
            // 
            // spcInhalt.Panel2
            // 
            this.spcInhalt.Panel2.Controls.Add(this.zflInhalt);
            this.spcInhalt.Panel2.Controls.Add(this.zazSkala);
            this.spcInhalt.Panel2.Margin = new System.Windows.Forms.Padding(0, 55, 0, 0);
            this.spcInhalt.Size = new System.Drawing.Size(1070, 473);
            this.spcInhalt.SplitterDistance = 220;
            this.spcInhalt.TabIndex = 4;
            // 
            // tlpDetails
            // 
            this.tlpDetails.ColumnCount = 1;
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetails.Controls.Add(this.lblLinien, 0, 0);
            this.tlpDetails.Controls.Add(this.lstLinien, 0, 1);
            this.tlpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetails.Location = new System.Drawing.Point(0, 0);
            this.tlpDetails.Name = "tlpDetails";
            this.tlpDetails.RowCount = 2;
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetails.Size = new System.Drawing.Size(220, 473);
            this.tlpDetails.TabIndex = 0;
            // 
            // lblLinien
            // 
            this.lblLinien.AutoSize = true;
            this.lblLinien.Location = new System.Drawing.Point(3, 0);
            this.lblLinien.Name = "lblLinien";
            this.lblLinien.Size = new System.Drawing.Size(81, 13);
            this.lblLinien.TabIndex = 0;
            this.lblLinien.Text = "Linienübersicht:";
            // 
            // lstLinien
            // 
            this.lstLinien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLinien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLinien.FormattingEnabled = true;
            this.lstLinien.ItemHeight = 20;
            this.lstLinien.Location = new System.Drawing.Point(3, 16);
            this.lstLinien.Name = "lstLinien";
            this.lstLinien.Size = new System.Drawing.Size(214, 454);
            this.lstLinien.TabIndex = 1;
            this.lstLinien.SelectedIndexChanged += new System.EventHandler(this.lstLinien_SelectedIndexChanged);
            this.lstLinien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLinien_KeyDown);
            this.lstLinien.Leave += new System.EventHandler(this.lstLinien_Leave);
            // 
            // zflInhalt
            // 
            this.zflInhalt.BackColor = System.Drawing.Color.Green;
            this.zflInhalt.ControlModus = Motion_View.Zeichenfläche.Modus.Zeichenmodus;
            this.zflInhalt.Cursor = System.Windows.Forms.Cursors.Default;
            this.zflInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zflInhalt.Location = new System.Drawing.Point(0, 0);
            this.zflInhalt.MarkierteLinie = null;
            this.zflInhalt.Name = "zflInhalt";
            this.zflInhalt.Size = new System.Drawing.Size(846, 392);
            this.zflInhalt.TabIndex = 0;
            this.zflInhalt.WiedergabeZeit = 0;
            this.zflInhalt.ModusGeaendert += new Motion_View.Zeichenfläche.ModusGeaendertEvent(this.zflInhalt_ModusGeaendert);
            this.zflInhalt.DateiGeaendert += new Motion_View.Zeichenfläche.DateiGeaendertEvent(this.zflInhalt_DateiGeaendert);
            this.zflInhalt.WiedergabeGestartet += new System.EventHandler(this.zflInhalt_WiedergabeGestartet);
            this.zflInhalt.WiedergabeGestoppt += new System.EventHandler(this.zflInhalt_WiedergabeGestoppt);
            // 
            // zazSkala
            // 
            this.zazSkala.AutoSize = true;
            this.zazSkala.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zazSkala.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.zazSkala.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zazSkala.Location = new System.Drawing.Point(0, 392);
            this.zazSkala.MaxZeit = 10;
            this.zazSkala.Name = "zazSkala";
            this.zazSkala.Size = new System.Drawing.Size(846, 81);
            this.zazSkala.TabIndex = 1;
            this.zazSkala.Visible = false;
            this.zazSkala.Zeitwert = 0;
            this.zazSkala.SliderBewegt += new System.EventHandler(this.zazSkala_SliderBewegt);
            // 
            // sfdDatei
            // 
            this.sfdDatei.Filter = "Motion Teach-In Dateien (*.mti)|*.mti|Alle Dateien (*.*)|*.*";
            // 
            // ofdDatei
            // 
            this.ofdDatei.Filter = "Motion Teach-In Dateien (*.mti)|*.mti|Alle Dateien (*.*)|*.*";
            // 
            // tmrWiedergabe
            // 
            this.tmrWiedergabe.Interval = 250;
            this.tmrWiedergabe.Tick += new System.EventHandler(this.tmrWiedergabe_Tick);
            // 
            // robottest
            // 
            this.robottest.Location = new System.Drawing.Point(720, 24);
            this.robottest.Name = "robottest";
            this.robottest.Size = new System.Drawing.Size(133, 23);
            this.robottest.TabIndex = 5;
            this.robottest.Text = "nur zum testen";
            this.robottest.UseVisualStyleBackColor = true;
            this.robottest.Click += new System.EventHandler(this.robottest_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 528);
            this.Controls.Add(this.robottest);
            this.Controls.Add(this.spcInhalt);
            this.Controls.Add(this.tsToolbar);
            this.Controls.Add(this.mnuMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "frmMain";
            this.Text = "Motion Teach-In";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.spcInhalt.Panel1.ResumeLayout(false);
            this.spcInhalt.Panel2.ResumeLayout(false);
            this.spcInhalt.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcInhalt)).EndInit();
            this.spcInhalt.ResumeLayout(false);
            this.tlpDetails.ResumeLayout(false);
            this.tlpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDatei;
        private System.Windows.Forms.ToolStripMenuItem mnuNeu;
        private System.Windows.Forms.ToolStripMenuItem mnuSpeichern;
        private System.Windows.Forms.ToolStripMenuItem mnuSpeichernUnter;
        private System.Windows.Forms.ToolStripMenuItem mnuBeenden;
        private System.Windows.Forms.ToolStripSeparator tssDatei;
        private System.Windows.Forms.ToolStripMenuItem mnuHilfe;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton tsbZeichnenmodus;
        private System.Windows.Forms.ToolStripButton tsbLoeschmodus;
        private System.Windows.Forms.ToolStripSeparator tssModus;
        private System.Windows.Forms.ToolStripButton tsbWiedergabeStarten;
        private System.Windows.Forms.ToolStripButton tsbWiedergabeStoppen;
        private System.Windows.Forms.SplitContainer spcInhalt;
        private System.Windows.Forms.ToolStripMenuItem mnuÜber;
        private System.Windows.Forms.ToolStripMenuItem mnuTransfer;
        private System.Windows.Forms.ToolStripMenuItem mnuÖffnen;
        private System.Windows.Forms.ToolStripMenuItem mnuGCodeErzeugen;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private System.Windows.Forms.SaveFileDialog sfdDatei;
        private System.Windows.Forms.OpenFileDialog ofdDatei;
        private System.Windows.Forms.Timer tmrWiedergabe;
        private System.Windows.Forms.Label lblLinien;
        private System.Windows.Forms.ListBox lstLinien;
        private Zeichenfläche zflInhalt;
        private Zeitanzeige zazSkala;
        private System.Windows.Forms.ToolStripButton tsbBewegen;
        private System.Windows.Forms.ToolStripSeparator tssWiedergabe;
        private System.Windows.Forms.ToolStripButton tsbUrsprungFestlegen;
        private System.Windows.Forms.Button robottest;
    }
}

