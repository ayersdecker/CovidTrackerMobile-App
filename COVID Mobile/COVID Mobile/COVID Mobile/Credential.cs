using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace COVID_Mobile
{
    internal class Credential
    {
        public string Name { get; set; }

        private string email;
        public string Username { get { return email; } set { email = value; } }
        private string password;
        public string Password { get { return password; } set { password = value; } }

        public Credential(string _name, string _email, string _password)
        {
            this.Name = _name;
            this.email = _email;
            this.password = _password;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
