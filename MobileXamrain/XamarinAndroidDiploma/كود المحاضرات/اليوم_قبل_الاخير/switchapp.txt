//--------------------------------------code--------------------------------------------
Switch s = FindViewById<Switch> (Resource.Id.monitored_switch);

s.CheckedChange += delegate(object sender, CompoundButton.CheckedChangeEventArgs e) {
    var toast = Toast.MakeText (this, "Your answer is " +
        (e.IsChecked ?  "correct" : "incorrect"), ToastLength.Short);
    toast.Show ();
};

//---------------------------------designe---------------------------------------
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="40.5dp"
        android:id="@+id/linearLayout1"
        android:layout_marginTop="30px"
        android:layout_marginRight="30px"
        android:layout_marginLeft="30px"
        android:layout_marginBottom="30px">
        <TextView
            android:text="Enable Data Transfer"
            android:layout_width="233.5dp"
            android:layout_height="match_parent"
            android:id="@+id/textView1"
            android:paddingBottom="5px"
            android:paddingRight="5px"
            android:paddingTop="20px" />
        <Switch
            android:id="@+id/switch1"
            android:layout_width="80.0dp"
            android:layout_height="match_parent"
            android:layout_marginLeft="0.0dp" />
    </LinearLayout>
</LinearLayout>
//-----------------------------------------------------------------------------------------------------

















