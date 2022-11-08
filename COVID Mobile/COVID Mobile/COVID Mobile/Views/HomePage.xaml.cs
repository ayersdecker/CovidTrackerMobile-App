using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        
        
        public HomePage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            
           
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "thisistheDAMNfile.json");
            File.WriteAllText(fileName, "ST.");
            
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
                    WelcomeLabel.TextColor = Color.Black;
                    EmailEntry.TextColor = Color.Black;
                    PasswordEntry.TextColor = Color.Black;
                    passedObjective = true;
                    Navigation.PushAsync(new DataPage());
                    Shell.SetTabBarIsVisible(this, true);                    
                } 
            }

            if (!passedObjective)
            {
                Login_load.IsRunning = false;
                EmailEntry.Text = EmailEntry.Placeholder;
                EmailEntry.TextColor = Color.Red;
                PasswordEntry.Text = "";
                PasswordEntry.TextColor = Color.Red;
                WelcomeLabel.TextColor = Color.Red;
                WelcomeLabel.Text = "Incorrect Credentials";
                Shell.SetTabBarIsVisible(this, false);
            }
            

        }

    }
}