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

        private byte isJoint = (byte)0;
        private bool isConnectted = false;
        private JogInstantCmd currentCmd;
        private PlaybackBufferCmd pdbCmd = new PlaybackBufferCmd();
        private Pose pose = new Pose();
        private Datei Arbeitskopie;
        private int zfl_höhe;
        private int zfl_breite;
        private double robot_höhe = 100;  //150mm
        private double robot_breite = 100; //150mm
        private double faktor_pixel_zu_mm = 0.264583;








        public Robotform(Datei übergebene_arbeitskopie, int höhe_orig_fläche, int breite_orig_fläche)
        {
            InitializeComponent();
            

            
            Arbeitskopie = übergebene_arbeitskopie;
            zfl_höhe = (int)((double)höhe_orig_fläche*faktor_pixel_zu_mm);
            zfl_breite =(int)((double) breite_orig_fläche*faktor_pixel_zu_mm);
            StartDobot();
            StartPeriodic();

        }
        #region eigene_funktionen
        private void StartDobot()
        {

            //DobotDll.ResetDobot();
            int ret;
            // start connect
            
            if ((ret = DobotDll.ConnectDobot()) >= (int)DobotResult.DobotResult_Error_Min)
            {
                MessageBox.Show("kein roboter gefunden");
                this.Close();
                return;
            }
            

            isConnectted = true;
            // reset and start

            DobotDll.SetCmdTimeout(500);
            DobotDll.SetEndType(EndType.EndTypeLaser);

            // Must set when sensor is not exist
            InitialPose initialPose;
            initialPose.joint2Angle = 45;
            initialPose.joint3Angle = 45;
            DobotDll.SetInitialPose(ref initialPose);


            JogStaticParams jsParam;
            jsParam.jointMaxVelocity = 15;
            jsParam.jointMaxAcceleration = 50;
            jsParam.servoMaxVelocity = 30;
            jsParam.servoMaxAcceleration = 10;
            jsParam.linearMaxVelocity = 40;
            jsParam.linearMaxAcceleration = 40;
            DobotDll.SetJogStaticParams(ref jsParam);

            JogDynamicParams jdParam;
            jdParam.velocityRatio = 30;
            DobotDll.SetJogDynamicParams(ref jdParam);

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

            PlaybackDynamicParams pbdParam;
            pbdParam.velocityRatio = 30;
            pbdParam.accelerationRatio = 30;
            DobotDll.SetPlaybackDynamicParams(ref pbdParam);

            Koordinaten_umrechnen();

        }
        private void StartPeriodic()
        {
            // start peridic cmd
            System.Windows.Forms.Timer cmdTimer = new System.Windows.Forms.Timer();
            cmdTimer.Interval = 100;
            cmdTimer.Tick += CmdTimer_Tick;
            cmdTimer.Start();

            // start get pose peridic cmd
            System.Windows.Forms.Timer posTimer = new System.Windows.Forms.Timer();
            posTimer.Interval = 100;
            posTimer.Tick += PosTimer_Tick;
            posTimer.Start();
        }

        private void Koordinaten_umrechnen() //beachten: y und x werden vertauscht, da das roboterkoordinatensystem invertiert ist.
        {

            double faktor_x = robot_höhe / zfl_breite;
            double faktor_y = robot_breite / zfl_höhe;




            foreach (Linie l in Arbeitskopie)
            {
                foreach (Koordinate k in l)
                {
                    
                    k.X = Convert.ToInt32((double)k.X*faktor_pixel_zu_mm*faktor_x); 
                    k.Y = Convert.ToInt32((double)k.Y * faktor_pixel_zu_mm*faktor_y);
                }
            }
            

    }
        
        #endregion
        #region timer-events
        private void PosTimer_Tick(object sender, EventArgs e)
        {
            if (!isConnectted)
                return;
            DobotDll.GetPose(ref pose);
        }

        private void CmdTimer_Tick(object sender, EventArgs e)
        {
            
            // called in 200ms
            DobotDll.PeriodicTask();
        }
        #endregion
        #region button-events

        private void btnxplus_MouseDown(object sender, MouseEventArgs e) //X+
        {
            currentCmd.cmd = JogCmd.JogAPPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        private void btnxplus_MouseUp(object sender, MouseEventArgs e) //stillstand (wird bei allen buttons bei mouse-down aufgerunfen
        {
            currentCmd.cmd = JogCmd.JogIdle;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        private void btnxminus_MouseDown(object sender, MouseEventArgs e)// X-
        {
            currentCmd.cmd = JogCmd.JogANPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        private void btnyplus_MouseDown(object sender, MouseEventArgs e)// Y+
        {
            currentCmd.cmd = JogCmd.JogBPPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        private void btnyminus_MouseDown(object sender, MouseEventArgs e)//Y-
        {
            currentCmd.cmd = JogCmd.JogBNPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        private void btnzplus_MouseDown(object sender, MouseEventArgs e)//Z+
        {
            currentCmd.cmd = JogCmd.JogCPPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        private void btnzminus_MouseDown(object sender, MouseEventArgs e)//Z-
        {
            currentCmd.cmd = JogCmd.JogCNPressed;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }
        #endregion

        private void btndobotbewegung_Click(object sender, EventArgs e)
        {
          
            
            float x_akt = pose.x;
            float y_akt = pose.y;
            float z_akt = pose.z;


          





            foreach (Linie l in Arbeitskopie)
            {
               DobotDll.SetCmdTimeout(1000);
                int liniencount = l.Count;
                int akt_pos = 0;
                foreach (Koordinate k in l)
                {
                   /* if (akt_pos == liniencount-1)
                    {
                        
                        pdbCmd.playbackPoint.motionStyle = 2;
                        pdbCmd.playbackPoint.x = x_akt + k.X;
                        pdbCmd.playbackPoint.y = y_akt + k.Y;
                       // pdbCmd.playbackPoint.z = z_akt;
                        pdbCmd.playbackPoint.pauseTime = 0;
                        
                       


                        DobotDll.SetPlaybackBufferCmd(ref pdbCmd);
                        DobotDll.PeriodicTask();
                        Thread.Sleep(500);


                        //springt von letzter koordinate einer linie zu der ersten koord. der neuen linie




                    }*/
                    if (akt_pos == 0)
                    {
                        
                        pdbCmd.playbackPoint.motionStyle = 0; //springt zum anfangspunkt

                        pdbCmd.playbackPoint.x = x_akt + k.X;
                       
                        pdbCmd.playbackPoint.y = y_akt + k.Y;
                       
                        pdbCmd.playbackPoint.z = z_akt;
                        pdbCmd.playbackPoint.pauseTime = 0;
                       


                        DobotDll.SetPlaybackBufferCmd(ref pdbCmd);
                        DobotDll.PeriodicTask();
                        Thread.Sleep(500);


                        akt_pos++;
                        




                    }
                    else
                    {
                        
                        pdbCmd.playbackPoint.motionStyle = 2; //normale lin. bewegung
                        pdbCmd.playbackPoint.x = x_akt + k.X;
                        pdbCmd.playbackPoint.y = y_akt + k.Y;
                        pdbCmd.playbackPoint.z = z_akt;
                        pdbCmd.playbackPoint.pauseTime = 0;
                      

                        DobotDll.SetPlaybackBufferCmd(ref pdbCmd);
                        DobotDll.PeriodicTask();
                        Thread.Sleep(500);
                        

                        akt_pos++;
                       



                    }



                }
                
            }
            this.Close();
        }

        private void btn_notaus_Click(object sender, EventArgs e)
        {
            currentCmd.cmd = JogCmd.JogIdle;
            DobotDll.SetJogInstantCmd(ref currentCmd);
        }

        private void Robotform_FormClosing(object sender, FormClosingEventArgs e)
        {
            DobotDll.DisconnectDobot();
        }
    }
}
