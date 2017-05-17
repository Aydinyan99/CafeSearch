using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeSearch
{
    class Cafe
    {
        public string Name { set; get; }
        public string Address { set; get; }
        public string Telephone { set; get; }
        public TimeSpan OpenHour;
        public TimeSpan CloseHour;
        public double Rating { set; get; }
        public string OfficialWebsite { set; get; }
        public bool WifiAvailability { set; get; }
        public string Reviews { set; get; }
        public double Latitude { set; get; }
        public double Longitude { set; get; }
        public int Distance { set; get; }
        public static int count { set; get; }
        public int NearPoint { set; get; }
        public Cafe()
        {
            count++;
        }

        public override string ToString()
        {
            string wifi;
            if (WifiAvailability)
                wifi = "Available";
            else
                wifi = "Unavailable";
            return "Name: " + Name + "\n" + "Adress: " + Address + "\n" +"Distance: " +Distance+"m\n"+ "Telephone: " + Telephone + "\n" + "Working Hours: " + OpenHour + " - " + CloseHour + "\n" + "Rating: " + new string('*', (int)(Rating)) + "  " + "( " + Rating + " )" + "\n" + "OfficialWebsite: " + OfficialWebsite + "\n" + "Wifi: " + wifi + "\n" + "Reviews: \n" + Reviews;
        }
    }
}
