//-------------------------------permissions --------------------------------------------

	<uses-permission android:name="android.permission.INTERNET" />

	<uses-permission android:name="android.permission.RECORD_AUDIO" />

//-------------------------------------------designe-----------------------------------------------
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent">
    <SeekBar
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/seekBar1" />
    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/linearLayout1">
        <Button
            android:id="@+id/bustart"
            android:text="Start"
            android:layout_width="wrap_content"
            android:layout_height="match_parent" />
        <Button
            android:text="Stop"
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:id="@+id/buStop" />
        <Button
            android:text="Pause"
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:id="@+id/buPause" />
    </LinearLayout>
</LinearLayout>
//--------------------------------------------code-------------------------------------------------
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Content.Res;

namespace mediaplayer
{
    [Activity(Label = "mediaplayer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MediaPlayer player;
        SeekBar seekbarMusic ;
        Button btnStart ;
        Button btnstop ;
        Button btnPause ;
        int path;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            // var path = Path.Combine(Directory.GetCurrentDirectory(), "data/SleepAway.mp3");
            // File path = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMusic), "SleepAway.mp3");
            // string path = "~\\data\\SleepAway.mp3";
            //  string path = "http://server6.mp3quran.net/thubti/001.mp3";
            //intializaPlayer(path);
             seekbarMusic = FindViewById<SeekBar>(Resource.Id.seekBar1);
             btnStart = FindViewById<Button>(Resource.Id.bustart);
             btnstop = FindViewById<Button>(Resource.Id.buStop);
             btnPause = FindViewById<Button>(Resource.Id.buPause);
            
             path = Resource.Raw.SleepAway;
            if(player==null) player = MediaPlayer.Create(this, path);
            seekbarMusic.Max = player.Duration;
            btnStart.Click += BtnStart_Click;
            btnstop.Click += Btnstop_Click;
            btnPause.Click += BtnPause_Click;
            seekbarMusic.ProgressChanged += SeekbarMusic_ProgressChanged;
        }

        private void SeekbarMusic_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            if (player == null) player = MediaPlayer.Create(this, path);
            seekbarMusic.Progress = e.Progress;
            player.SeekTo ( e.Progress);
        }

        private void BtnPause_Click(object sender, System.EventArgs e)
        {
            player.Pause();
        }

        private void Btnstop_Click(object sender, System.EventArgs e)
        {
            player.Stop();
            player = null;
            seekbarMusic.Progress = 0;
        }

        private void BtnStart_Click(object sender, System.EventArgs e)
        {
            if (player == null) player = MediaPlayer.Create(this, path);
            player.Start();
        }

        private void intializaPlayer (string path)
        {
            if (player == null)
            {
                player = new MediaPlayer();
            }
            player.Reset();
            player.SetDataSource(path);
            player.Prepare();
          //  seekBar1.Max = player.Duration;
        }


    }
}

