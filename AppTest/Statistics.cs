using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Microcharts.Droid;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using Android.Views;

namespace AppTest
{
    [Activity(Label = "Statistics")]
    public class Statistics : Activity
    {
        ChartView chartview;
        TextView chartOptionsText;
        ImageView downarrow;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.statistics);
            // Create your application here
            var menu = FindViewById<ImageButton>(Resource.Id.back);
            menu.Click += delegate { base.OnBackPressed(); };

            chartview = (ChartView)FindViewById(Resource.Id.chartView1);
            chartOptionsText = FindViewById<TextView>(Resource.Id.chartOptions);
            downarrow = FindViewById<ImageView>(Resource.Id.downImage);

            chartOptionsText.Click += ChartOptionsText_Click;
            downarrow.Click += ChartOptionsText_Click;

            DrawChart("Graphique radar");
        }

        private void ChartOptionsText_Click(object sender, System.EventArgs e)
        {
            PopupMenu popup = new PopupMenu(this, chartOptionsText);
            popup.MenuItemClick += Popup_MenuItemClick;
            popup.Menu.Add(Menu.None, 1, 1, "Graphique en points");
            popup.Menu.Add(Menu.None, 2, 2, "Graphique linéaire");
            popup.Menu.Add(Menu.None, 3, 3, "Graphique en barres");
            popup.Menu.Add(Menu.None, 4, 4, "Graphique circulaire");
            popup.Menu.Add(Menu.None, 5, 5, "Graphique radar");

            popup.Show();
        }

        private void Popup_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            string charttype = e.Item.TitleFormatted.ToString();
            DrawChart(charttype);
            chartOptionsText.Text = charttype;
        }

        void DrawChart(string charttype) 
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

            if (charttype == "Graphique en points")
            {
                var chart = new PointChart()
                { Entries = Datalist, LabelTextSize = 30f };
                chartview.Chart = chart;
            }

            else if (charttype == "Graphique radar")
            {
                var chart = new RadarChart()
                { Entries = Datalist, LabelTextSize = 30f };
                chartview.Chart = chart;
            }

            else if (charttype == "Graphique circulaire")
            {
                var chart = new DonutChart()
                { Entries = Datalist, LabelTextSize = 30f };
                chartview.Chart = chart;
            }

            else if (charttype == "Graphique linéaire")
            {
                var chart = new LineChart()
                { Entries = Datalist, LabelTextSize = 30f };
                chartview.Chart = chart;
            }

            else if(charttype == "Graphique en barres")
            {
                var chart = new BarChart()
                { Entries = Datalist, LabelTextSize = 30f };
                chartview.Chart = chart;
            }

        }
        
    }
}