﻿using Motion_View;

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
            this.btn_robotersteuerung = new System.Windows.Forms.ToolStripButton();
            this.spcInhalt = new System.Windows.Forms.SplitContainer();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblLinien = new System.Windows.Forms.Label();
            this.lstLinien = new System.Windows.Forms.ListBox();
            this.sfdDatei = new System.Windows.Forms.SaveFileDialog();
            this.ofdDatei = new System.Windows.Forms.OpenFileDialog();
            this.tmrWiedergabe = new System.Windows.Forms.Timer(this.components);
            this.splitContainerzeichenflächeundskala = new System.Windows.Forms.SplitContainer();
            this.zflInhalt = new Motion_View.Zeichenfläche();
            this.zazSkala = new Motion_View.Zeitanzeige();
            this.mnuMenu.SuspendLayout();
            this.tsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcInhalt)).BeginInit();
            this.spcInhalt.Panel1.SuspendLayout();
            this.spcInhalt.Panel2.SuspendLayout();
            this.spcInhalt.SuspendLayout();
            this.tlpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerzeichenflächeundskala)).BeginInit();
            this.splitContainerzeichenflächeundskala.Panel1.SuspendLayout();
            this.splitContainerzeichenflächeundskala.Panel2.SuspendLayout();
            this.splitContainerzeichenflächeundskala.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatei,
            this.mnuTransfer,
            this.mnuHilfe});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuMenu.Size = new System.Drawing.Size(1597, 28);
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
            this.mnuDatei.Size = new System.Drawing.Size(57, 24);
            this.mnuDatei.Text = "Datei";
            // 
            // mnuNeu
            // 
            this.mnuNeu.Image = ((System.Drawing.Image)(resources.GetObject("mnuNeu.Image")));
            this.mnuNeu.Name = "mnuNeu";
            this.mnuNeu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNeu.Size = new System.Drawing.Size(353, 26);
            this.mnuNeu.Text = "Neu";
            this.mnuNeu.Click += new System.EventHandler(this.mnuNeu_Click);
            // 
            // mnuÖffnen
            // 
            this.mnuÖffnen.Image = ((System.Drawing.Image)(resources.GetObject("mnuÖffnen.Image")));
            this.mnuÖffnen.Name = "mnuÖffnen";
            this.mnuÖffnen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuÖffnen.Size = new System.Drawing.Size(353, 26);
            this.mnuÖffnen.Text = "Öffnen";
            this.mnuÖffnen.Click += new System.EventHandler(this.mnuÖffnen_Click);
            // 
            // mnuSpeichern
            // 
            this.mnuSpeichern.Image = ((System.Drawing.Image)(resources.GetObject("mnuSpeichern.Image")));
            this.mnuSpeichern.Name = "mnuSpeichern";
            this.mnuSpeichern.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSpeichern.Size = new System.Drawing.Size(353, 26);
            this.mnuSpeichern.Text = "Speichern";
            this.mnuSpeichern.Click += new System.EventHandler(this.mnuSpeichern_Click);
            // 
            // mnuSpeichernUnter
            // 
            this.mnuSpeichernUnter.Name = "mnuSpeichernUnter";
            this.mnuSpeichernUnter.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSpeichernUnter.Size = new System.Drawing.Size(353, 26);
            this.mnuSpeichernUnter.Text = "Speichern unter...";
            this.mnuSpeichernUnter.Click += new System.EventHandler(this.mnuSpeichernUnter_Click);
            // 
            // tssDatei
            // 
            this.tssDatei.Name = "tssDatei";
            this.tssDatei.Size = new System.Drawing.Size(350, 6);
            // 
            // mnuBeenden
            // 
            this.mnuBeenden.Name = "mnuBeenden";
            this.mnuBeenden.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuBeenden.Size = new System.Drawing.Size(353, 26);
            this.mnuBeenden.Text = "Beenden";
            this.mnuBeenden.Click += new System.EventHandler(this.mnuBeenden_Click);
            // 
            // mnuTransfer
            // 
            this.mnuTransfer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGCodeErzeugen});
            this.mnuTransfer.Name = "mnuTransfer";
            this.mnuTransfer.Size = new System.Drawing.Size(74, 24);
            this.mnuTransfer.Text = "Transfer";
            // 
            // mnuGCodeErzeugen
            // 
            this.mnuGCodeErzeugen.Enabled = false;
            this.mnuGCodeErzeugen.Name = "mnuGCodeErzeugen";
            this.mnuGCodeErzeugen.Size = new System.Drawing.Size(200, 26);
            this.mnuGCodeErzeugen.Text = "G-Code erzeugen";
            // 
            // mnuHilfe
            // 
            this.mnuHilfe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuÜber});
            this.mnuHilfe.Name = "mnuHilfe";
            this.mnuHilfe.Size = new System.Drawing.Size(53, 24);
            this.mnuHilfe.Text = "Hilfe";
            // 
            // mnuÜber
            // 
            this.mnuÜber.Enabled = false;
            this.mnuÜber.Name = "mnuÜber";
            this.mnuÜber.Size = new System.Drawing.Size(116, 26);
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
            this.tsbUrsprungFestlegen,
            this.btn_robotersteuerung});
            this.tsToolbar.Location = new System.Drawing.Point(0, 28);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(1597, 31);
            this.tsToolbar.TabIndex = 3;
            this.tsToolbar.Text = "Toolbar";
            // 
            // tsbBewegen
            // 
            this.tsbBewegen.Image = ((System.Drawing.Image)(resources.GetObject("tsbBewegen.Image")));
            this.tsbBewegen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBewegen.Name = "tsbBewegen";
            this.tsbBewegen.Size = new System.Drawing.Size(98, 28);
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
            this.tsbZeichnenmodus.Size = new System.Drawing.Size(97, 28);
            this.tsbZeichnenmodus.Text = "Zeichnen";
            this.tsbZeichnenmodus.Click += new System.EventHandler(this.tsbZeichnenmodus_Click);
            // 
            // tsbLoeschmodus
            // 
            this.tsbLoeschmodus.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoeschmodus.Image")));
            this.tsbLoeschmodus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoeschmodus.Name = "tsbLoeschmodus";
            this.tsbLoeschmodus.Size = new System.Drawing.Size(90, 28);
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
            this.tsbWiedergabeStarten.Size = new System.Drawing.Size(168, 28);
            this.tsbWiedergabeStarten.Text = "Wiedergabe starten";
            this.tsbWiedergabeStarten.Click += new System.EventHandler(this.tsbWiedergabe_Click);
            // 
            // tsbWiedergabeStoppen
            // 
            this.tsbWiedergabeStoppen.Enabled = false;
            this.tsbWiedergabeStoppen.Image = ((System.Drawing.Image)(resources.GetObject("tsbWiedergabeStoppen.Image")));
            this.tsbWiedergabeStoppen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWiedergabeStoppen.Name = "tsbWiedergabeStoppen";
            this.tsbWiedergabeStoppen.Size = new System.Drawing.Size(177, 28);
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
            this.tsbUrsprungFestlegen.Size = new System.Drawing.Size(162, 28);
            this.tsbUrsprungFestlegen.Text = "Ursprung festlegen";
            this.tsbUrsprungFestlegen.Click += new System.EventHandler(this.tsbUrsprungFestlegen_Click);
            // 
            // btn_robotersteuerung
            // 
            this.btn_robotersteuerung.Image = ((System.Drawing.Image)(resources.GetObject("btn_robotersteuerung.Image")));
            this.btn_robotersteuerung.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_robotersteuerung.Name = "btn_robotersteuerung";
            this.btn_robotersteuerung.Size = new System.Drawing.Size(156, 28);
            this.btn_robotersteuerung.Text = "Robotersteuerung";
            this.btn_robotersteuerung.Click += new System.EventHandler(this.btn_robotersteuerung_Click);
            // 
            // spcInhalt
            // 
            this.spcInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcInhalt.Location = new System.Drawing.Point(0, 59);
            this.spcInhalt.Margin = new System.Windows.Forms.Padding(4);
            this.spcInhalt.Name = "spcInhalt";
            // 
            // spcInhalt.Panel1
            // 
            this.spcInhalt.Panel1.Controls.Add(this.tlpDetails);
            // 
            // spcInhalt.Panel2
            // 
            this.spcInhalt.Panel2.Controls.Add(this.splitContainerzeichenflächeundskala);
            this.spcInhalt.Panel2.Margin = new System.Windows.Forms.Padding(0, 68, 0, 0);
            this.spcInhalt.Size = new System.Drawing.Size(1597, 659);
            this.spcInhalt.SplitterDistance = 327;
            this.spcInhalt.SplitterWidth = 5;
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
            this.tlpDetails.Margin = new System.Windows.Forms.Padding(4);
            this.tlpDetails.Name = "tlpDetails";
            this.tlpDetails.RowCount = 2;
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetails.Size = new System.Drawing.Size(327, 659);
            this.tlpDetails.TabIndex = 0;
            // 
            // lblLinien
            // 
            this.lblLinien.AutoSize = true;
            this.lblLinien.Location = new System.Drawing.Point(4, 0);
            this.lblLinien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinien.Name = "lblLinien";
            this.lblLinien.Size = new System.Drawing.Size(108, 17);
            this.lblLinien.TabIndex = 0;
            this.lblLinien.Text = "Linienübersicht:";
            // 
            // lstLinien
            // 
            this.lstLinien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLinien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLinien.FormattingEnabled = true;
            this.lstLinien.ItemHeight = 25;
            this.lstLinien.Location = new System.Drawing.Point(4, 21);
            this.lstLinien.Margin = new System.Windows.Forms.Padding(4);
            this.lstLinien.Name = "lstLinien";
            this.lstLinien.Size = new System.Drawing.Size(319, 634);
            this.lstLinien.TabIndex = 1;
            this.lstLinien.SelectedIndexChanged += new System.EventHandler(this.lstLinien_SelectedIndexChanged);
            this.lstLinien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLinien_KeyDown);
            this.lstLinien.Leave += new System.EventHandler(this.lstLinien_Leave);
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
            // splitContainerzeichenflächeundskala
            // 
            this.splitContainerzeichenflächeundskala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerzeichenflächeundskala.Location = new System.Drawing.Point(0, 0);
            this.splitContainerzeichenflächeundskala.Name = "splitContainerzeichenflächeundskala";
            this.splitContainerzeichenflächeundskala.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerzeichenflächeundskala.Panel1
            // 
            this.splitContainerzeichenflächeundskala.Panel1.Controls.Add(this.zflInhalt);
            // 
            // splitContainerzeichenflächeundskala.Panel2
            // 
            this.splitContainerzeichenflächeundskala.Panel2.Controls.Add(this.zazSkala);
            this.splitContainerzeichenflächeundskala.Size = new System.Drawing.Size(1265, 659);
            this.splitContainerzeichenflächeundskala.SplitterDistance = 462;
            this.splitContainerzeichenflächeundskala.TabIndex = 0;
            // 
            // zflInhalt
            // 
            this.zflInhalt.BackColor = System.Drawing.Color.Green;
            this.zflInhalt.ControlModus = Motion_View.Zeichenfläche.Modus.Zeichenmodus;
            this.zflInhalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zflInhalt.Location = new System.Drawing.Point(0, 0);
            this.zflInhalt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zflInhalt.MarkierteLinie = null;
            this.zflInhalt.Name = "zflInhalt";
            this.zflInhalt.Size = new System.Drawing.Size(1265, 462);
            this.zflInhalt.TabIndex = 0;
           
            // 
            // zazSkala
            // 
            this.zazSkala.AutoSize = true;
            this.zazSkala.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zazSkala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zazSkala.Location = new System.Drawing.Point(0, 0);
            this.zazSkala.MaxZeit = 10;
            this.zazSkala.Name = "zazSkala";
            this.zazSkala.Size = new System.Drawing.Size(1265, 193);
            this.zazSkala.TabIndex = 0;
            this.zazSkala.Zeitwert = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1597, 718);
            this.Controls.Add(this.spcInhalt);
            this.Controls.Add(this.tsToolbar);
            this.Controls.Add(this.mnuMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(847, 580);
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
            ((System.ComponentModel.ISupportInitialize)(this.spcInhalt)).EndInit();
            this.spcInhalt.ResumeLayout(false);
            this.tlpDetails.ResumeLayout(false);
            this.tlpDetails.PerformLayout();
            this.splitContainerzeichenflächeundskala.Panel1.ResumeLayout(false);
            this.splitContainerzeichenflächeundskala.Panel2.ResumeLayout(false);
            this.splitContainerzeichenflächeundskala.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerzeichenflächeundskala)).EndInit();
            this.splitContainerzeichenflächeundskala.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton tsbBewegen;
        private System.Windows.Forms.ToolStripSeparator tssWiedergabe;
        private System.Windows.Forms.ToolStripButton tsbUrsprungFestlegen;
        private System.Windows.Forms.ToolStripButton btn_robotersteuerung;
        private System.Windows.Forms.SplitContainer splitContainerzeichenflächeundskala;
        private Zeichenfläche zflInhalt;
        private Zeitanzeige zazSkala;
    }
}

