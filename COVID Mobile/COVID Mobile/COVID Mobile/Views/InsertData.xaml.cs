using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertData : ContentPage
    {
        // Storage for COVID Cases
        ObservableCollection<COVID> covidList = new ObservableCollection<COVID>();
        // Storage for Variants
        ObservableCollection<string> variantList = new ObservableCollection<string>();
        // Storage for Locations
        ObservableCollection<Place> locationList = new ObservableCollection<Place>();
        public InsertData()
        {

            InitializeComponent();
            LoadData();
            DatePick.Date = DateNow();
            

        }
        private DateTime DateNow()
        {
            return DateTime.Now;
        }
        private void VariantPickerLoad(List<string> strings)
        {
            foreach (var item in strings) { VariantPicker.Items.Add(item); }
        }
        private void LocationPickerLoad(List<Place> places)
        {
            foreach (var item in places) { LocationPicker.Items.Add(item.ToString()); }
        }
        private void Clear_Clicked(object sender, EventArgs e)
        {
            DatePick.Date = DateNow();
            LocationPicker.SelectedItem = null;
            VariantPicker.SelectedItem = null;
            InfectUn.Text = "";
            Infect29.Text = "";
            Infect39.Text = "";
            Infect49.Text = "";
            Infect59.Text = "";
            Infect69.Text = "";
            Infect79.Text = "";
            InfectOv.Text = "";
            InfectUnknown.Text = "";
            MorbidUn.Text = "";
            Morbid29.Text = "";
            Morbid39.Text = "";
            Morbid49.Text = "";
            Morbid59.Text = "";
            Morbid69.Text = "";
            Morbid79.Text = "";
            MorbidOv.Text = "";
            MorbidUnknown.Text = "";
            Notes.Text = "";

        }
        private void Submit_Clicked(object sender, EventArgs e)
        {
            if (!FormCheck())
            {
                COVID aCovid = new COVID();
                aCovid.Date = DatePick.Date;
                aCovid.LocationProp = LocationPicker.SelectedItem as Place;
                aCovid.VariantProp = VariantPicker.SelectedItem.ToString();
                aCovid.Infection = new AgeBracket(int.Parse(InfectUn.Text),
                    int.Parse(Infect29.Text), int.Parse(Infect39.Text),
                    int.Parse(Infect49.Text), int.Parse(Infect59.Text),
                    int.Parse(Infect69.Text), int.Parse(Infect79.Text),
                    int.Parse(InfectOv.Text), int.Parse(InfectUnknown.Text));
                aCovid.Morbidity = new AgeBracket(int.Parse(MorbidUn.Text),
                    int.Parse(Morbid29.Text), int.Parse(Morbid39.Text),
                    int.Parse(Morbid49.Text), int.Parse(Morbid59.Text),
                    int.Parse(Morbid69.Text), int.Parse(Morbid79.Text),
                    int.Parse(MorbidOv.Text), int.Parse(MorbidUnknown.Text));
                aCovid.Note = Notes.Text;

                covidList.Add(aCovid);
                LoadBackIntoFile();
                Title = "Insert Data";
            }
            else { Title = "INPUT ERROR, REVISE"; }

        }
        private bool FormCheck()
        {
            bool flag = false;
            if (!(LocationPicker.SelectedItem != null && VariantPicker.SelectedItem != null))
            {
                flag = true;
            }
            if (InfectUn == null || Infect29 == null || Infect39 == null || Infect49 == null)
            {
                flag = true;
            }
            if (Infect59 == null || Infect69 == null || Infect79 == null || InfectOv == null)
            {
                flag = true;
            }
            if (MorbidUn == null || Infect29 == null || Infect39 == null || Infect49 == null)
            {
                flag = true;
            }
            if (Morbid59 == null || Morbid69 == null || Morbid79 == null || MorbidOv == null)
            {
                flag = true;
            }
            // UNKNOWNS OR NOTES NOT REQUIRED


            return flag;
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
            
            VariantPickerLoad(variantList.ToList());
            LocationPickerLoad(locationList.ToList());
        }
        private void LoadBackIntoFile()
        {
            try
            {
                string covidFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "COVID.json");
                StreamWriter writer = new StreamWriter(covidFile);
                string listSerial = JsonConvert.SerializeObject(covidList);
                writer.Write(listSerial);
                writer.Close();

            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
           

                
        }
    }
}