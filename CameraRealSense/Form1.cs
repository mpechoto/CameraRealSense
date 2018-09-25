using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraRealSense
{
    


    public partial class Form1 : Form
    {
        //public PXCMSession session = PXCMSession.CreateInstance();

        public PXCMSenseManager sm = PXCMSenseManager.CreateInstance();
        
        //PXCMSession.ImplVersion v = sm.session.version;

        



        public Form1()
        {
            InitializeComponent();
            //PXCMSession.ImplVersion v = sm.session.QueryVersion() ;
            //Console.WriteLine("SDK Version: {0}.{1}\n", v.major, v.minor);
            //Console.WriteLine("SDK Version: {0}.{1}", session.QueryVersion().major, session.QueryVersion().minor);
            // Set file playback name
            sm.captureManager.SetFileName("filename4.rssdk",true);

            sm.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 640, 480, 30);
            sm.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_DEPTH, 0,0);
            sm.Init();
            // Set realtime=true and pause=false
            //sm.captureManager.SetRealtime(false);
            //sm.captureManager.SetPause(true);

            for (; ; )

            {
                //pxcmStatus sts = sm.AcquireFrame(true);
                if (sm.AcquireFrame(true).IsError())
                {
                    Console.WriteLine("break");
                    break;
                }
                //PXCMCapture.Sample sample = sm.QuerySample();
                //pictureBox1.Image = sample.color;
                // process image
                //sm.ReleaseFrame();
                // retrieve the samples
                PXCMCapture.Sample sample = sm.QuerySample();
                if (sample != null)
                {
                    if (sample.color != null)
                    {
                        // work on the color sample
                        Console.Write("color");
                    }
                    if (sample.depth != null)
                    {
                        // work on the depth sample
                        Console.Write("depth");
                    }
                }
                // go fetching the next samples
                sm.ReleaseFrame();
            
            }
                sm.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
