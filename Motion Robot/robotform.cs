using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dobottest.CPlusDll;
using Motion_Model;
using Motion_View;
using System.Threading;



namespace Motion_Robot
{
    public partial class Robotform : Form
    {

        //Objekte zum Speichern der Position und der comands
        private bool isConnectted = false;
        private JogInstantCmd currentCmd;
        private PlaybackBufferCmd pdbCmd = new PlaybackBufferCmd();
        private Pose pose = new Pose();

        //Globale Variablen/Objekte die von der Hauptform an die Roboterform übergeben werden
        private Datei Arbeitskopie;
        private int zfl_höhe;
        private int zfl_breite;

        private double robot_höhe = 100;  //100mm
        private double robot_breite = 100; //100mm
        private double faktor_pixel_zu_mm = 0.264583; //ein mm entspricht 0.2645 pixel

        //timer 
        private System.Threading.Timer cmdTimer;

        private System.Threading.Timer posTimer;

        public Robotform(Datei übergebene_arbeitskopie, int höhe_orig_fläche, int breite_orig_fläche)
        {
            InitializeComponent();

            //Parameter und Objekte, die von der Hauptform an die Roboterform gegeben werden
            Arbeitskopie = übergebene_arbeitskopie;
            // Höhe und Breite der Zeichenfläche wird von Pixel auf mm umgerechnet
            zfl_höhe = (int)((double)höhe_orig_fläche * faktor_pixel_zu_mm);
            zfl_breite = (int)((double)breite_orig_fläche * faktor_pixel_zu_mm);

            //Startet Verbindung zum Roboter
            StartDobot();
            //startet die Timer
            StartPeriodic();

        }
        #region eigene_funktionen
        private void StartDobot()
        {
            //ret ist eine normale Zahl, die einen Fehlercode repräsentiert
            int ret;
            
            //Überprüft ob eine Verbindung zum Roboter gefunden wurde.Wenn nicht, wird die Form sofort geschlossen und es erscheint eine Benachrichtigung
            if ((ret = DobotDll.ConnectDobot()) >= (int) DobotResult.DobotResult_Error_Min)
            {
                MessageBox.Show("Kein Roboter gefunden");
                this.Close();
                return;
            }

            //Ist eine Verbindung vorhanden wird die Form aufgerufen und der Status isconnectted auf true gesetzt
            else
            {
                this.Show();
                isConnectted = true;
            }
            
            

            //Time-out für die comands
            DobotDll.SetCmdTimeout(500);


            //Gibt die Stellung in Winkelpositionen zwischen "Oberarm" und "Unterarm" an, die max. angefahren werden kann
            InitialPose initialPose;
            initialPose.joint2Angle = 45;
            initialPose.joint3Angle = 45;
            DobotDll.SetInitialPose(ref initialPose);

            //Statische Paramter die Beschleunigung und Geschwidigkeit der Joints, der Servormotoren und des liniearen Abfahrens angeben, gilt für die Jogs (Anfahren über Winkelpositionen)
            JogStaticParams jsParam;
            jsParam.jointMaxVelocity = 15;
            jsParam.jointMaxAcceleration = 50;
            jsParam.servoMaxVelocity = 30;
            jsParam.servoMaxAcceleration = 10;
            jsParam.linearMaxVelocity = 40;
            jsParam.linearMaxAcceleration = 40;
            DobotDll.SetJogStaticParams(ref jsParam);

            //Dynamischer Parameter, der die Beschleunigung angibt
            JogDynamicParams jdParam;
            jdParam.velocityRatio = 30;
            DobotDll.SetJogDynamicParams(ref jdParam);

            //Statische Paramter die Beschleunigung und Geschwidigkeit der Joints, der Servormotoren und des liniearen Abfahrens angeben, gilt für die Playbackcomands (Anfahren über Koordinaten)
            PlaybackStaticParams pbsParam;
            pbsParam.jointMaxVelocity = 100;
            pbsParam.jointMaxAcceleration = 100;
            pbsParam.servoMaxVelocity = 100;
            pbsParam.servoMaxAcceleration = 100;
            pbsParam.linearMaxVelocity = 100;
            pbsParam.linearMaxAcceleration = 100;
            pbsParam.pauseTime = 100;
            pbsParam.jumpHeight = 20;
            DobotDll.SetPlaybackStaticParams(ref pbsParam);

            //Dynamischer Parameter, der die Beschleunigung und die Geschwindigkeit angibt
            PlaybackDynamicParams pbdParam;
            pbdParam.velocityRatio = 30;
            pbdParam.accelerationRatio = 30;
            DobotDll.SetPlaybackDynamicParams(ref pbdParam);

            //Funktion zum Umrechnen der aufgenommenen Koordinaten 
            Koordinaten_umrechnen();

        }
        private void StartPeriodic()
        {
            //Startet Comand-Timer, wird alle 100ms aufgerungen
           
            cmdTimer = new System.Threading.Timer(state => DobotDll.PeriodicTask(), null, 0, 100);

            //Startet Positions-Timer, wird alle 100ms aufgerufen
            posTimer = new System.Threading.Timer(state => Positionsbestimmung(), null, 0, 100);
        }

        //Rechnet die Koordianten um, auf die passende Größe und von pixel auf mm
        private void Positionsbestimmung()
        {

            DobotDll.GetPose(ref pose);


        }
        private void Koordinaten_umrechnen()
        {
            //Errechnen der Faktoren für x und y, dazu teilen der Roboterzeichenfläche durch die Programmzeichenfläche
            double faktor_x = robot_höhe / zfl_breite;
            double faktor_y = robot_breite / zfl_höhe;

            //Abarbeiten aller Linien
            foreach (Linie l in Arbeitskopie)
            {
                //Abarbeiten alle Koordinaten in der aktuellen Linie
                foreach (Koordinate k in l)
                {
                    //Werte werden zuerst in mm umgewandelt (faktor_pixel_zu_mm) und anschließend mit den Faktoren auf die richtige Größe skaliert
                    k.X = Convert.ToInt32((double)k.X * faktor_pixel_zu_mm * faktor_x);
                    k.Y = Convert.ToInt32((double)k.Y * faktor_pixel_zu_mm * faktor_y);
                }
            }
        }

        #endregion
        #region timer-events
        //Überprüft alle 100ms die aktuelle Position, wenn ein Roboter verbunden ist
        private void PosTimer_Tick(object sender, EventArgs e)
        {
            if (!isConnectted)
                return;
            DobotDll.GetPose(ref pose);
        }

        //Wird alle 100ms aufgerufen und startet die Bewegung
        private void CmdTimer_Tick(object sender, EventArgs e)
        {
            DobotDll.PeriodicTask();
        }
        #endregion


        #region events zum Ansteuern der Nullposition


        //X+
        private void btnxplus_MouseDown(object sender, MouseEventArgs e)
        {
            currentCmd.cmd = JogCmd.JogAPPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        //Stillstand (wird bei allen buttons bei mouse-down aufgerunfen)
        private void btnxplus_MouseUp(object sender, MouseEventArgs e)
        {
            currentCmd.cmd = JogCmd.JogIdle;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        //X-
        private void btnxminus_MouseDown(object sender, MouseEventArgs e)
        {
            currentCmd.cmd = JogCmd.JogANPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        //Y+
        private void btnyplus_MouseDown(object sender, MouseEventArgs e)
        {
            currentCmd.cmd = JogCmd.JogBPPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        //Y-
        private void btnyminus_MouseDown(object sender, MouseEventArgs e)
        {
            currentCmd.cmd = JogCmd.JogBNPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        //Z+
        private void btnzplus_MouseDown(object sender, MouseEventArgs e)
        {
            currentCmd.cmd = JogCmd.JogCPPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        //Z-
        private void btnzminus_MouseDown(object sender, MouseEventArgs e)
        {
            currentCmd.cmd = JogCmd.JogCNPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }
        #endregion
        #region Events zum Abfahren der Koordinaten und Formevents

        private void btndobotbewegung_Click(object sender, EventArgs e)
        {
            //speichern der Position, die zum  Anfahr-Zeitpunkt aktuelle ist 
            float xAkt = pose.x;
            float yAkt = pose.y;
            float zAkt = pose.z;



            foreach (Linie l in Arbeitskopie)
            {
                // anzahl der koordinaten innerhalb einer linie erfassen und aktuelle_position-count setzen
                int liniencount = l.Count;
                int akt_pos = 0;

                //abarbeiten aller linien und der beinhaltenden koordinaten
                foreach (Koordinate k in l)
                {
                    //ist die Koordinate ein Anfangspunkt einer linie, soll "gesprungen" werden (motionstyle = 0);
                    if (akt_pos == 0)
                    {
                        //angeben der koordinaten ( x,y,z,) die sich aus dem ausgangspunkt und der tatsächlichen koordinate zusammensetzt, z = const
                        pdbCmd.playbackPoint.motionStyle = 0; //springt zum anfangspunkt
                        pdbCmd.playbackPoint.x = xAkt + k.X;
                        pdbCmd.playbackPoint.y = yAkt + k.Y;
                        pdbCmd.playbackPoint.z = zAkt;
                        pdbCmd.playbackPoint.pauseTime = 0;

                        //übergeben des comand-obj (pdbCmd) an der Playbackbuffer, wird beim aufrufen des comand-timers erst wirklich ausgelöst
                        DobotDll.SetPlaybackBufferCmd(ref pdbCmd);
                        //0.5s warten, bis der roboter die bewegung ausgeführt hat, erst dann mit der schleifenabarbeitung fortsetzen
                        Thread.Sleep(500);

                        akt_pos++;

                    }

                    //Ist die Koordinate kein Anfangspunkt soll normal und liniar verfahren werden (motionstyle = 2)
                    else
                    {
                        //angeben der koordinaten ( x,y,z,) die sich aus dem ausgangspunkt und der tatsächlichen koordinate zusammensetzt, z = const
                        pdbCmd.playbackPoint.motionStyle = 2;
                        pdbCmd.playbackPoint.x = xAkt + k.X;
                        pdbCmd.playbackPoint.y = yAkt + k.Y;
                        pdbCmd.playbackPoint.z = zAkt;

                        //übergeben des comand-obj (pdbCmd) an der Playbackbuffer, wird beim aufrufen des comand-timers erst wirklich ausgelöst
                        DobotDll.SetPlaybackBufferCmd(ref pdbCmd);
                        //0.5s warten, bis der roboter die bewegung ausgeführt hat, erst dann mit der schleifenabarbeitung fortsetzen
                        Thread.Sleep(500);

                        akt_pos++;
                    }
                }
            }
            //schließen der Form nach Abarbeiten aller Linien
            this.Close();
        }

        //Notaus-Event, versetzt den roboter in den Ruhezustand
        private void btn_notaus_Click(object sender, EventArgs e)
        {
            currentCmd.cmd = JogCmd.JogIdle;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        //Beim schließen der Form wird die Verbindung zum Roboter unterbrochen
        private void Robotform_FormClosing(object sender, FormClosingEventArgs e)
        {
            DobotDll.DisconnectDobot();
        }
        #endregion
    }
}
