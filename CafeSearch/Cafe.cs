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
        public int OpenHour { set; get; }
        public int CloseHour { set; get; }
        public float Rating { set; get; }
        public string OfficialWebsite { set; get; }
        public bool WifiAvailability { set; get; }

        public override string ToString()
        {
            string wifi;
            if (WifiAvailability)
                wifi = "Available";
            else
                wifi = "Unavailable";
            return "Name: " + Name + "\n" + "Adress: " + Address + "\n" + "Working Hours: " + OpenHour + ":00-" + CloseHour + ":00" + "\n" + "Rating:" + new string('*', (int)(Rating)) + "\n" + "OfficialWebsite: " + OfficialWebsite + "\n" + "Wifi: " + wifi;
        }

    }
}
