using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;
using Path = System.IO.Path;
using System.Runtime.InteropServices.ComTypes;
using Xamarin.Forms.PlatformConfiguration;
using System.ComponentModel;
using static Xamarin.Forms.Internals.GIFBitmap;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {


        // Storage for COVID Cases
        ObservableCollection<COVID> covidList = new ObservableCollection<COVID>();
        // Storage for Variants
        ObservableCollection<string> variantList = new ObservableCollection<string>();
        // Storage for Locations
        ObservableCollection<Place> locationList = new ObservableCollection<Place>();

        //string covidFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "COVID.json");         // COVID JSON File - Used for database purposes
        //string variantFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "variants.json");    // Variant JSON File - Used for database purposes
       // string locationFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "locations.json");  // Location JSON File - Used for database purposes

        public DataPage()
        {
              
            InitializeComponent();
            LoadData(); 
            //GraphInfectData.Points = PointLoadUp(true, false);
            //GraphMorbidData.Points = PointLoadUp(false, false);
            
            
            //GraphInfectData.Points = DummyInfectLoad();
            //GraphMorbidData.Points = DummyMorbidLoad();
            SetTotals();
           

        }
        private void SetTotals()
        {
            double infectTotal = 0;
            double morbidTotal = 0;
            foreach(Point point in DummyInfectLoad())
            {
                point.Deconstruct(out double x, out double y);
                infectTotal += y;
            }
            foreach (Point point in DummyMorbidLoad())
            {
                point.Deconstruct(out double x, out double y);
                morbidTotal += y;
            }

            InfectNum_Label.Text = $"Recent Infections: {infectTotal}";
            MorbidNum_Label.Text = $"Recent Deaths: {morbidTotal}";
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (InfectRadio.IsChecked)
            {
                GraphInfectData.IsVisible = true;
                GraphMorbidData.IsVisible = false;
                InfectNum_Label.IsVisible = true;
                MorbidNum_Label.IsVisible = false;
            }
            else if (MorbidRadio.IsChecked)
            {
                GraphInfectData.IsVisible = false;
                GraphMorbidData.IsVisible = true;
                InfectNum_Label.IsVisible = false;
                MorbidNum_Label.IsVisible = true;
                MorbidNum_Label.Margin = new Thickness(15, 580, 0, 0);
            }
            else
            {
                GraphInfectData.IsVisible = true;
                GraphMorbidData.IsVisible = true;
                InfectNum_Label.IsVisible = true;
                MorbidNum_Label.IsVisible = true;
                MorbidNum_Label.Margin = new Thickness(15, 620, 0, 0);
            }
        }
        private void GraphTimeToggle_Toggled(object sender, ToggledEventArgs e)
        {
            if (GraphTimeToggle.IsToggled)
            {
                GraphTimeToggle_Label.Text = "All Data";
                InfectNum_Label.Text = "Total Infection: ";
                MorbidNum_Label.Text = "Total Deaths: ";
                this.GraphInfectData.Points = PointLoadUp(true, true);
                this.GraphMorbidData.Points = PointLoadUp(false, true);
            }
            else
            {
                GraphTimeToggle_Label.Text = "Recent Data";
                InfectNum_Label.Text = "Recent Infections: ";
                MorbidNum_Label.Text = "Recent Deaths: ";
                this.GraphInfectData.Points = PointLoadUp(true, false);
                this.GraphMorbidData.Points = PointLoadUp(false, false);

            }
        }
        private PointCollection PointLoadUp(bool toggleRate, bool toggleTime)
        {
            int[] xPair = new int[6] { 0, 20 , 40, 60 , 80, 100};
            int[] xPairGreater = new int[21] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
            PointCollection result = new PointCollection();
            if (toggleTime)
            {
                for (int i = 0; i < xPairGreater.Length; i++)
                {
                    Point point;
                    if (toggleRate) { point = new Point(xPairGreater[(xPairGreater.Length - 1) - i], 100 - covidList[(covidList.Count - 1) - i].Infection.TotalCount()); }
                    else { point = new Point(xPairGreater[(xPairGreater.Length - 1) - i], 100 - covidList[(covidList.Count - 1) - i].Morbidity.TotalCount()); }
                    result.Add(point);
                }
            } 
            else
            {
                for (int i = 0; i < xPair.Length; i++)
                {
                    Point point;
                    if (toggleRate) { point = new Point(xPair[(xPair.Length - 1) - i], 100 - covidList[(covidList.Count - 1) - i].Infection.TotalCount()); }
                    else { point = new Point(xPair[(xPair.Length - 1) - i], 100 - covidList[(covidList.Count - 1) - i].Morbidity.TotalCount()); }
                    result.Add(point);
                }
            }

            return result;
        }
        
        private PointCollection DummyMorbidLoad()
        {
            PointCollection morbidPoints = new PointCollection();
            morbidPoints.Add(new Point(0, 27));
            morbidPoints.Add(new Point(5, 20));
            morbidPoints.Add(new Point(10, 40));
            morbidPoints.Add(new Point(15, 70));
            morbidPoints.Add(new Point(20, 34));
            morbidPoints.Add(new Point(25, 19));
            morbidPoints.Add(new Point(30, 60));
            morbidPoints.Add(new Point(35, 60));
            morbidPoints.Add(new Point(40, 40));
            morbidPoints.Add(new Point(45, 73));
            morbidPoints.Add(new Point(50, 50));
            morbidPoints.Add(new Point(55, 60));
            morbidPoints.Add(new Point(60, 90));
            morbidPoints.Add(new Point(65, 83));
            morbidPoints.Add(new Point(70, 90));
            morbidPoints.Add(new Point(75, 95));
            morbidPoints.Add(new Point(80, 60));
            morbidPoints.Add(new Point(85, 87));
            morbidPoints.Add(new Point(90, 82));
            morbidPoints.Add(new Point(95, 70));
            morbidPoints.Add(new Point(100, 90));
            return morbidPoints;
        }
        private PointCollection DummyInfectLoad()
        {
            PointCollection infectPoints = new PointCollection();
            infectPoints.Add(new Point(0, 90));
            infectPoints.Add(new Point(5, 80));
            infectPoints.Add(new Point(10, 30));
            infectPoints.Add(new Point(15, 40));
            infectPoints.Add(new Point(20, 70));
            infectPoints.Add(new Point(25, 50));
            infectPoints.Add(new Point(30, 80));
            infectPoints.Add(new Point(35, 70));
            infectPoints.Add(new Point(40, 49));
            infectPoints.Add(new Point(45, 60));
            infectPoints.Add(new Point(50, 35));
            infectPoints.Add(new Point(55, 80));
            infectPoints.Add(new Point(60, 30));
            infectPoints.Add(new Point(65, 40));
            infectPoints.Add(new Point(70, 60));
            infectPoints.Add(new Point(75, 30));
            infectPoints.Add(new Point(80, 29));
            infectPoints.Add(new Point(85, 30));
            infectPoints.Add(new Point(90, 19));
            infectPoints.Add(new Point(95, 50));
            infectPoints.Add(new Point(100, 60));
            return infectPoints;
        }
        private async void LoadData()
        {
            
            using (var stream = await FileSystem.OpenAppPackageFileAsync("locations.json"))
            {
                StreamReader reader = new StreamReader(stream);
                string listRead = await reader.ReadToEndAsync();
                // Loads data into a temporary Collection List
                List<Place> aLocationList = JsonConvert.DeserializeObject<List<Place>>(listRead);
                // Close Reader before transfer
                reader.Close();
                // Transfers content from List into the ObservableCollection
                locationList = new ObservableCollection<Place>(aLocationList);
            }
            using (var stream = await FileSystem.OpenAppPackageFileAsync("variants.json"))
            {
                StreamReader reader = new StreamReader(stream);
                string listRead = await reader.ReadToEndAsync();
                // Loads data into a temporary Collection List
                List<string> aVariantList = JsonConvert.DeserializeObject<List<string>>(listRead);
                // Close Reader before transfer
                reader.Close();
                // Transfers content from List into the ObservableCollection
                variantList = new ObservableCollection<string>(aVariantList);
            }
            using (var stream = await FileSystem.OpenAppPackageFileAsync("COVID.json"))
            {
                StreamReader reader = new StreamReader(stream);
                string listRead = await reader.ReadToEndAsync();
                // Loads data into a temporary Collection List
                List<COVID> aCovidList = JsonConvert.DeserializeObject<List<COVID>>(listRead);
                // Close Reader before transfer
                reader.Close();
                // Transfers content from List into the ObservableCollection
                covidList = new ObservableCollection<COVID>(aCovidList);
            }

            GraphInfectData.Points = PointLoadUp(true, false);
            GraphMorbidData.Points = PointLoadUp(false, false);

        }
        

    }
}