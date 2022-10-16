using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_Mobile
{
    class Place
    {
        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = city != "" ? value : "[Naming Error -- City-Location]";
            }
        }
        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = state != "" ? value : "[Naming Error -- State-Location]";
            }
        }
        public Place(string _city, string _state)
        {
            City = _city;
            State = _state;
        }
        public override string ToString()
        {
            return $"{City}, {State}";
        }
    }
}