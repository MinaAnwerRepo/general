//--------------------manifest file -------------------------------------------------------------------

<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="VideoRecorderandPlayer.VideoRecorderandPlayer" android:versionCode="1" android:versionName="1.0" android:installLocation="preferExternal">
	<uses-sdk android:minSdkVersion="16" />
	<uses-permission android:name="android.permission.INTERNET" />
	<uses-permission android:name="android.permission.CAMERA" />
	<uses-permission android:name="android.permission.RECORD_AUDIO" />
	<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
	<application android:label="VideoRecorderandPlayer"></application>
</manifest>


//-------------------------designe----------------------------------------------------------------------
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <LinearLayout
        android:orientation="vertical"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/linearLayout1">
        <Button
            android:text="Record"
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:id="@+id/btnRecord" />
        <Button
            android:text="stop"
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:id="@+id/btnstop" />
        <Button
            android:text="play"
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:id="@+id/btnplay" />
    </LinearLayout>
    <VideoView
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/videoView1" />
</LinearLayout>

//---------------------------------------------------------------code----------------------------------
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace VideoRecorderandPlayer
{
    [Activity(Label = "VideoRecorderandPlayer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        MediaRecorder recorder;
        string path;
        VideoView video;
        public MainActivity()
        {
            path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.mp4";
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            video = FindViewById<VideoView>(Resource.Id.videoView1);
            Button btnRecord = FindViewById<Button>(Resource.Id.btnRecord);
            Button btnstop = FindViewById<Button>(Resource.Id.btnstop);
            Button btnplay = FindViewById<Button>(Resource.Id.btnplay);
            btnRecord.Click += BtnRecord_Click;
            btnplay.Click += Btnplay_Click;
            btnstop.Click += Btnstop_Click;
        }

        private void Btnstop_Click(object sender, System.EventArgs e)
        {
          if(recorder!=null)
            {
                recorder.Stop();
                recorder.Release();
            }
        }

        private void Btnplay_Click(object sender, System.EventArgs e)
        {
            var uri = Android.Net.Uri.Parse(path);
            video.SetVideoURI(uri);
            video.Start();
        }

        private void BtnRecord_Click(object sender, System.EventArgs e)
        {
            video.StopPlayback();
            recorder = new MediaRecorder();
            recorder.SetVideoSource(VideoSource.Camera);
            recorder.SetAudioSource(AudioSource.Mic);
            recorder.SetOutputFormat(OutputFormat.Default);
            recorder.SetVideoEncoder(VideoEncoder.Default);
            recorder.SetAudioEncoder(AudioEncoder.Default);
            recorder.SetOutputFile(path);
            recorder.SetPreviewDisplay(video.Holder.Surface);
            recorder.Prepare();
            recorder.Start();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (recorder != null)
            {
                recorder.Release();
                recorder.Dispose();
                recorder = null;
            }
        }


    }
}



