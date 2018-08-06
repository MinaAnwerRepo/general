using Android.App;
using Android.Widget;
using Android.OS;
using System.Timers;
using System;

namespace seekPar
{
    [Activity(Label = "seekPar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Timer t ;
        int counter;
        SeekBar seekpar;
        public MainActivity()
        {
            t = new Timer();
            t.Interval = 300;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
             SetContentView (Resource.Layout.Main);
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
			
             seekpar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            Button btnstart = FindViewById<Button>(Resource.Id.btnStart);
            Button btnstop = FindViewById<Button>(Resource.Id.btnStop);
            seekpar.Max = 100;
            btnstart.Click += Btnstart_Click;
            btnstop.Click += Btnstop_Click;
            seekpar.ProgressChanged += Seekpar_ProgressChanged;
        }

        private void Seekpar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            counter = e.Progress;
        }
        private void Btnstop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void Btnstart_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            seekpar.Progress = counter;
            counter++;
            if(counter>100)
            {
                t.Stop();
            }
        }
    }
}

