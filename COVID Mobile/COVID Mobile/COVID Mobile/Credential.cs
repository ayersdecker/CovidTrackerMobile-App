using System;
using System.Collections.Generic;
using System.Text;

namespace COVID_Mobile
{
    internal class Credential
    {

        private string username;
        public string Username { get { return username; } set { username = value; } }
        private string password;
        public string Password { get { return password; } set { password = value; } }

        public Credential(string _username, string _password)
        {
            this.username = _username;
            this.password = _password;
        }
        public override string ToString()
        {
            return username;
        }
    }
}
