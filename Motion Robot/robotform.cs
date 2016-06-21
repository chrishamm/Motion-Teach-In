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


        



        public Robotform(Datei übergebene_arbeitskopie)
        {
            InitializeComponent();
            StartPeriodic();

            StartDobot();
            Arbeitskopie = übergebene_arbeitskopie;
        }
        #region eigene_funktionen
        private void StartDobot()
        {
            int ret;
            // start connect
            
            if ((ret = DobotDll.ConnectDobot()) >= (int)DobotResult.DobotResult_Error_Min)
            {
                MessageBox.Show("kein roboter gefunden");
                return;
            }
            

            isConnectted = true;
            // reset and start

            DobotDll.SetCmdTimeout(500);
            DobotDll.SetEndType(EndType.EndTypePump);

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
            pbsParam.jointMaxVelocity = 200;
            pbsParam.jointMaxAcceleration = 200;
            pbsParam.servoMaxVelocity = 200;
            pbsParam.servoMaxAcceleration = 200;
            pbsParam.linearMaxVelocity = 200;
            pbsParam.linearMaxAcceleration = 200;
            pbsParam.pauseTime = 100;
            pbsParam.jumpHeight = 20;
            DobotDll.SetPlaybackStaticParams(ref pbsParam);

            PlaybackDynamicParams pbdParam;
            pbdParam.velocityRatio = 30;
            pbdParam.accelerationRatio = 30;
            DobotDll.SetPlaybackDynamicParams(ref pbdParam);

        }
        private void StartPeriodic()
        {
            // start peridic cmd
            System.Windows.Forms.Timer cmdTimer = new System.Windows.Forms.Timer();
            cmdTimer.Interval = 200;
            cmdTimer.Tick += CmdTimer_Tick;
            cmdTimer.Start();

            // start get pose peridic cmd
            System.Windows.Forms.Timer posTimer = new System.Windows.Forms.Timer();
            posTimer.Interval = 600;
            posTimer.Tick += PosTimer_Tick;
            posTimer.Start();
        }

        private void Koordinaten_umrechnen()
        {
            double faktor_pixel_zu_mm = 0.264583;
            double x;
            double y;
            

            foreach (Linie l in Arbeitskopie)
            {
                foreach (Koordinate k in l)
                {
                    
                    k.X = Convert.ToInt32((double)k.X*faktor_pixel_zu_mm);
                    k.Y = Convert.ToInt32((double)k.Y * faktor_pixel_zu_mm);
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
    }
}
