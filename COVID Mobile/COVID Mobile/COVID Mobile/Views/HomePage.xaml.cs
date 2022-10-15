using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Login_load.IsRunning = true;
            Credential deckerLogin = new Credential("Decker Ayers", "dra2214@rit.edu", "1234");

            bool passedObjective = false;

            List<Credential> credentialList = new List<Credential>();
            credentialList.Add(deckerLogin);


            foreach(Credential credential in credentialList)
            {   
                if(credential.Username == EmailEntry.Text && credential.Password == PasswordEntry.Text) 
                { 
                    WelcomeLabel.Text = "Welcome " + credential.ToString() + "!";
                    Login_load.IsRunning = false;
                    passedObjective = true;
                }
                
            }

            if (!passedObjective)
            {
                Login_load.IsRunning = false;
                EmailEntry.Text = EmailEntry.Placeholder;
                EmailEntry.TextColor = Color.Red;
                PasswordEntry.Text = PasswordEntry.Placeholder;
                PasswordEntry.TextColor = Color.Red;
                WelcomeLabel.TextColor = Color.Red;
                WelcomeLabel.Text = "Incorrect Credentials";

            }
            

        }

    }
}