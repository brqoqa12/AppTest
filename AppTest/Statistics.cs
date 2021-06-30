using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Microcharts.Droid;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;

namespace AppTest
{
    [Activity(Label = "Statistics")]
    public class Statistics : Activity
    {
        ChartView chartview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.statistics);
            // Create your application here
            var menu = FindViewById<ImageButton>(Resource.Id.back);
            menu.Click += delegate { base.OnBackPressed(); };

            chartview = (ChartView)FindViewById(Resource.Id.chartView1);
            DrawChart();
        }

        void DrawChart() 
        {
            List<ChartEntry> Datalist = new List<ChartEntry>();
            Datalist.Add(new ChartEntry(100)
            {
                Label = "Janvier",
                ValueLabel = "100",
                Color = SKColor.Parse("#e6654e"),
                ValueLabelColor=SKColor.Parse("#e6654e")
            });

            Datalist.Add(new ChartEntry(90)
            {
                Label = "Février",
                ValueLabel = "90",
                Color = SKColor.Parse("#de3012"),
                ValueLabelColor = SKColor.Parse("#de3012")
            });

            Datalist.Add(new ChartEntry(210)
            {
                Label = "Mars",
                ValueLabel = "210",
                Color = SKColor.Parse("#27bd02"),
                ValueLabelColor = SKColor.Parse("#27bd02")
            });

            Datalist.Add(new ChartEntry(200)
            {
                Label = "Avril",
                ValueLabel = "200",
                Color = SKColor.Parse("#bff230"),
                ValueLabelColor = SKColor.Parse("#bff230")
            });

            Datalist.Add(new ChartEntry(150)
            {
                Label = "Mai",
                ValueLabel = "150",
                Color = SKColor.Parse("#f06d22"),
                ValueLabelColor = SKColor.Parse("#f06d22")
            });

            var chart = new RadarChart()
            { Entries = Datalist, LabelTextSize = 30f };
            chartview.Chart = chart;

        }
        
    }
}