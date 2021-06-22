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
    [Activity(Label = "Stock")]
    public class Stock : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.stock);
            // Create your application here
            var menu = FindViewById<ImageButton>(Resource.Id.back);
            menu.Click += delegate
            {
                var intent = new Intent(this, typeof(Home));
                StartActivity(intent);
            };
            
        }
    }
}