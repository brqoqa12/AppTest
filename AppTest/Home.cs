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
    public class Home : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {   
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeScreen);
            // Create your application here
            var imageclient = FindViewById<ImageButton>(Resource.Id.imageclient);
            var btnclient = FindViewById<Button>(Resource.Id.btnclient);
            var imagecommande = FindViewById<ImageButton>(Resource.Id.imagecommande);
            var btncommande = FindViewById<Button>(Resource.Id.btncommande);
            var imagestock = FindViewById<ImageButton>(Resource.Id.imagestock);
            var btnstock = FindViewById<Button>(Resource.Id.btnstock);
            var imagestats = FindViewById<ImageButton>(Resource.Id.imagestats);
            var btnstats = FindViewById<Button>(Resource.Id.btnstats);

            imageclient.Click += delegate
            {
                var intent = new Intent(this, typeof(Client));
                StartActivity(intent);
            };
            btnclient.Click += delegate
            {
                var intent = new Intent(this, typeof(Client));
                StartActivity(intent);
            };
            imagecommande.Click += delegate
            {
                var intent = new Intent(this, typeof(Commandes));
                StartActivity(intent);
            };
            btncommande.Click += delegate
            {
                var intent = new Intent(this, typeof(Commandes));
                StartActivity(intent);
            };
            imagestock.Click += delegate
            {
                var intent = new Intent(this, typeof(Stock));
                StartActivity(intent);
            };
            btnstock.Click += delegate
            {
                var intent = new Intent(this, typeof(Stock));
                StartActivity(intent);
            };
            imagestats.Click += delegate
            {
                var intent = new Intent(this, typeof(Statistics));
                StartActivity(intent);
            };
            btnstats.Click += delegate
            {
                var intent = new Intent(this, typeof(Statistics));
                StartActivity(intent);
            };




        }
        
       
    }
}