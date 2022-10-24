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
    public partial class InsertData : ContentPage
    {
        List<COVID> addedCOVID = new List<COVID>();
        public InsertData()
        {
            InitializeComponent();

            List<string> variantNames = new List<string>();
            variantNames.Add("Omicron");
            variantNames.Add("Delta");
            variantNames.Add("Classic");

            List<Place> placeNames = new List<Place>();
            placeNames.Add(new Place("Owego", "NY"));
            placeNames.Add(new Place("Rochester", "NY"));
            placeNames.Add(new Place("Scranton", "PA"));
            
            DatePick.Date = DateNow();
            VariantPickerLoad(variantNames);
            LocationPickerLoad(placeNames);

            
        }
        private DateTime DateNow()
        {
            return DateTime.Now;
        }
        private void VariantPickerLoad(List<string> strings)
        {
            foreach(var item in strings){ VariantPicker.Items.Add(item);}
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
                aCovid.Infection = new AgeBracket( int.Parse(InfectUn.Text),
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

                addedCOVID.Add(aCovid);
                Title = "Insert Data";
            }
            else{ Title = "INPUT ERROR, REVISE"; }

        }
        private bool FormCheck()
        {
            bool flag = false;
            if(!(LocationPicker.SelectedItem != null && VariantPicker.SelectedItem != null))
            {
                flag = true;
            }
            if(InfectUn == null || Infect29 == null || Infect39 == null || Infect49 == null)
            {
                flag = true;
            }
            if(Infect59 == null || Infect69 == null || Infect79 == null || InfectOv == null)
            {
                flag = true;
            }
            if(MorbidUn == null || Infect29 == null || Infect39 == null || Infect49 == null)
            {
                flag = true;
            }
            if(Morbid59 == null || Morbid69 == null || Morbid79 == null || MorbidOv == null)
            {
                flag = true;
            }
            // UNKNOWNS OR NOTES NOT REQUIRED


            return flag;
        }
    }
}