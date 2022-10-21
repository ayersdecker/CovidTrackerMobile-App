using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Device;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preferences : ContentPage
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void Accent_Toggled(object sender, ToggledEventArgs e)
        {
            //TODO <- Toggle Accent App Color to Green && BACK 
        }

        private void Background_Toggled(object sender, ToggledEventArgs e)
        {
            //TODO <- Toggle Background App Color to Green && BACK
        }

        private void DarkMode_Toggled(object sender, ToggledEventArgs e)
        {
            //TODO <- Toggle App Theme to DarkMode && BACK
        }
    }
}