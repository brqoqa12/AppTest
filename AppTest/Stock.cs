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
            SetContentView(Resource.Layout.Stock);
            base.OnCreate(savedInstanceState);
            var menu = FindViewById<ImageButton>(Resource.Id.back);
            menu.Click +=delegate { base.OnBackPressed(); };
        }
    }
}