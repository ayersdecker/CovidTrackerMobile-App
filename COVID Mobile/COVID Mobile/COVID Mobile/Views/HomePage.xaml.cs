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
    public partial class HomePage : ContentPage
    {
        
        public HomePage()
        {
            InitializeComponent();

        }

        private void LoginSubmit_Clicked(object sender, EventArgs e)
        {
            Credential deckerLogin = new Credential("DeckerAyers", "1234");

            List<Credential> credentialList = new List<Credential>();
            credentialList.Add(deckerLogin);

            //List<Credential> credentialRun = new List<Credential>(from credential in credentialList
            //    where credential.Username == UsernameEntry.Text && credential.Password == PasswordEntry.Text
            //    select credential);

            foreach(Credential credential in credentialList)
            {
                if(credential.Username == UsernameEntry.Text && credential.Password == PasswordEntry.Text) 
                { 
                    WelcomeLabel.Text = "Welcome " + credential.ToString() + "!";
                }
            }

        }

    }
}