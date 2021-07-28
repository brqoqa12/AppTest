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
            
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerClient);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.client_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinnerArticle);
            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.article_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter1;


        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
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