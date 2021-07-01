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
    [Activity(Label = "Commandes")]
    public class Commandes : Activity , Android.App.DatePickerDialog.IOnDateSetListener
    {
        

        private TextView date;

        int year, month, day;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.commandes);
            // Create your application here
            
            date = FindViewById<TextView>(Resource.Id.textView3);
            
            date.Click += openDialogOnclick;

            var menu = FindViewById<ImageButton>(Resource.Id.back);
            menu.Click += delegate { base.OnBackPressed(); };


        }

        private void openDialogOnclick(object sender, EventArgs e)
        {
            int datepickerdialogid = 1;
            ShowDialog(datepickerdialogid);
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == 1)
            {
                return new Android.App.DatePickerDialog(this, this, year, month, day);
            }
            return null;
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.year = year;
            this.month = month + 1;
            this.day = dayOfMonth;

            date.Text = dayOfMonth + "-" + month + "-" + year;
        }
    }
}