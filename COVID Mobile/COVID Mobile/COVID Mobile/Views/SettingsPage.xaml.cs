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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Preferences_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Preferences());
        }

        private void SystemInfo_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SystemInfo());
        }

        private void InsertData_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertData());
        }

        private void ExportData_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ExportData());
        }
    }
}