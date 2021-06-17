using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppTest
{
    [Activity(Label = "Home")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeScreen);
            // Create your application here
            var butt1 = FindViewById<ImageButton>(Resource.Id.imageView1);
            butt1.Click += (e, o) =>
            {
                Toast.MakeText(this, string.Format("image clicked"), ToastLength.Short).Show();
            };
            
        }
        
       
    }
}