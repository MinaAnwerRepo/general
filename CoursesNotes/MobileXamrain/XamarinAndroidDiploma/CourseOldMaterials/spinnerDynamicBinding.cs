
//----------------------------------------code-------------------------------------------------------------
using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;

namespace spinnerapp
{
    [Activity(Label = "spinnerapp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

             spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            #region binding from Resources 
            //var adapter = ArrayAdapter.CreateFromResource(
            //   this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);
            #endregion
                #region binding from Dynamic List
                var items = new List<string>() { "one", "two", "three","Four","six","seven","Eight" };
                var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            #endregion
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleListItemChecked);
            spinner.Adapter = adapter;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}
//-------------------------------------Designe-------------------------------------------------------------------------
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:padding="10dip"
    android:layout_width="fill_parent"
    android:layout_height="wrap_content">
    <TextView
        android:layout_width="fill_parent"
        android:layout_height="wrap_content"
        android:layout_marginTop="10dip"
        android:text="@string/planet_prompt"
    />
    <Spinner 
        android:id="@+id/spinner"
        android:layout_width="fill_parent"
        android:layout_height="wrap_content"
        android:prompt="@string/planet_prompt"
    />
</LinearLayout>
//--------------------------------------array at values file--------------------------------
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <string name="planet_prompt">Choose a planet</string>
    <string-array name="planets_array">
        <item>Mercury</item>
        <item>Venus</item>
        <item>Earth</item>
        <item>Mars</item>
        <item>Jupiter</item>
        <item>Saturn</item>
        <item>Uranus</item>
        <item>Neptune</item>
    </string-array>
</resources>






 
  
  
  
  
  
  
  
  
  
  
  
