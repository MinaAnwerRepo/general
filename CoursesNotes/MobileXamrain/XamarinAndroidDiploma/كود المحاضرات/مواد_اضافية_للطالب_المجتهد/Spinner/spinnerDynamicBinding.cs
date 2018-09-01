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

