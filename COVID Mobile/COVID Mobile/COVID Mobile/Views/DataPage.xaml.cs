using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public DataPage()
        {
            InitializeComponent();
            Point data1 = new Point(0, 100);
            Point data2 = new Point(20, 70);
            Point data3 = new Point(40, 50);
            Point data4 = new Point(60, 60);
            Point data5 = new Point(80, 50);

            PointCollection points = new PointCollection();
            points.Add(data1);
            points.Add(data2);
            points.Add(data3);
            points.Add(data4);
            points.Add(data5);
            this.GraphData.Points = points;
        }
    }
}