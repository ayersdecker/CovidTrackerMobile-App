using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NSwag.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;
using Path = System.IO.Path;
using Xamarin.Forms.PlatformConfiguration;
using System.IO.IsolatedStorage;
using PCLStorage;
using System.Runtime.CompilerServices;

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
        
        string covidFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"COVID.json");         // COVID JSON File - Used for database purposes
        string variantFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"variants.json");    // Variant JSON File - Used for database purposes
        string locationFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"locations.json");  // Location JSON File - Used for database purposes

        public DataPage()
        {
            InitializeComponent();
            LoadAllData();
            
            IFolder folder = FileSystem.Current.LocalStorage;
            

            this.GraphInfectData.Points = PointLoadUp(true, true);
            this.GraphMorbidData.Points = PointLoadUp(false, true);

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
                MorbidNum_Label.Margin = new Thickness(15, 510, 0, 0);
            }
            else
            {
                GraphInfectData.IsVisible = true;
                GraphMorbidData.IsVisible = true;
                InfectNum_Label.IsVisible = true;
                MorbidNum_Label.IsVisible = true;
                MorbidNum_Label.Margin = new Thickness(15, 550, 0, 0);
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
            PointCollection result = new PointCollection();
            if (toggleTime){
                for(int i = (covidList.Count - 100); i < covidList.Count; i++)
                {
                    Point point;
                    if (toggleRate) { point = new Point(i, covidList[i].Infection.TotalCount()); }
                    else {  point = new Point(i, covidList[i].Morbidity.TotalCount()); }
                    result.Add(point);
                } 
            }
            else
            {
                for (int i = (covidList.Count); i < covidList.Count; i++)
                {
                    Point point;
                    if (toggleRate) { point = new Point(i, covidList[i].Infection.TotalCount()); }
                    else { point = new Point(i, covidList[i].Morbidity.TotalCount()); }
                    result.Add(point);
                }
            }
            
            return result;
        }
        private void LoadAllData()
        {

            if (File.Exists(covidFile)) // Test-Loads COVIDs Json
            {

                StreamReader reader = new StreamReader(covidFile);
                string listRead = reader.ReadToEnd();
                // Loads data into a temporary Collection List
                List<COVID> aCovidList = JsonConvert.DeserializeObject<List<COVID>>(listRead);
                // Close Reader before transfer
                reader.Close();
                // Transfers content from List into the ObservableCollection
                covidList = new ObservableCollection<COVID>(aCovidList);
            }
            else { }

            if (File.Exists(variantFile)) // Test-Loads Variants Json 
            {
                StreamReader reader = new StreamReader(variantFile);
                string listRead = reader.ReadToEnd();
                // Loads data into a temporary Collection List
                List<string> aVariants = JsonConvert.DeserializeObject<List<string>>(listRead);
                // Close Reader before transfer
                reader.Close();
                // Transfers content from List into the ObservableCollection
                variantList = new ObservableCollection<string>(aVariants);
            }
            else { }

            if (File.Exists(locationFile)) // Test-Loads Locations Json
            {
                StreamReader reader = new StreamReader(locationFile);
                string listRead = reader.ReadToEnd();
                // Loads data into a temporary Collection List
                List<Place> aLocationList = JsonConvert.DeserializeObject<List<Place>>(listRead);
                // Close Reader before transfer
                reader.Close();
                // Transfers content from List into the ObservableCollection
                locationList = new ObservableCollection<Place>(aLocationList);
            }
            else { }
        }


    }
}