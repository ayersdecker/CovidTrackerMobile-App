using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExportData : ContentPage
    {
        public ExportData()
        {
            InitializeComponent();
        }

        private void CSV_Export_Clicked(object sender, EventArgs e)
        {
            //TODO <- Export Data to CSV
            Navigation.PopAsync();
        }

        private void Report_Export_Clicked(object sender, EventArgs e)
        {
            //TODO <- Export Data within a Generated Report
            Navigation.PopAsync();
        }
    }
}