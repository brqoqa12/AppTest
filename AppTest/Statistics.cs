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
            DrawChart("Graphique");
            chartOptionsText.Text = charttype;
        }

        void DrawChart(string charttype) 
        {
            List<ChartEntry> Datalist = new List<ChartEntry>();
            Datalist.Add(new ChartEntry(10000)
            {
                Label = "1 janvier",
                ValueLabel = "10000DHS",
                Color = SKColor.Parse("#dbfc03"),
                ValueLabelColor = SKColor.Parse("#dbfc03")
            });

            Datalist.Add(new ChartEntry(11000)
            {
                Label = "15 janvier",
                ValueLabel = "11000DHS",
                Color = SKColor.Parse("#9dfc03"),
                ValueLabelColor = SKColor.Parse("#9dfc03")
            });

            Datalist.Add(new ChartEntry(9000)
            {
                Label = "1 fèvrier",
                ValueLabel = "9000DHS",
                Color = SKColor.Parse("#fc4e03"),
                ValueLabelColor = SKColor.Parse("#fc4e03")
            });

            Datalist.Add(new ChartEntry(9500)
            {
                Label = "15 février",
                ValueLabel = "9500DHS",
                Color = SKColor.Parse("#fc8003"),
                ValueLabelColor = SKColor.Parse("#fc8003")
            });

            Datalist.Add(new ChartEntry(10000)
            {
                Label = "1 mars",
                ValueLabel = "10000DHS",
                Color = SKColor.Parse("#dbfc03"),
                ValueLabelColor=SKColor.Parse("#dbfc03")
            });

            Datalist.Add(new ChartEntry(11000)
            {
                Label = "15 mars",
                ValueLabel = "11000DHS",
                Color = SKColor.Parse("#9dfc03"),
                ValueLabelColor = SKColor.Parse("#9dfc03")
            });

            Datalist.Add(new ChartEntry(13000)
            {
                Label = "1 avril",
                ValueLabel = "13000DHS",
                Color = SKColor.Parse("#04c71b"),
                ValueLabelColor = SKColor.Parse("#04c71b")
            });
            if (charttype == "Graphique")
            {
                var chart = new LineChart()
                { Entries = Datalist, LabelTextSize = 30f };
                chartview.Chart = chart;
            }

            /*else if (charttype == "Graphique radar")
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
            }*/

        }
        
    }
}