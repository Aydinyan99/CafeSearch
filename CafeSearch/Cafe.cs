using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeSearch
{
    class Cafe
    {
        public string  Name { set; get; }
        public string Adress { set; get; }
        public int OpenHour { set; get; }
        public int CloseHour { set; get; }
        public float Rating { set; get; }
        public string OfficialWebsite { set; get; }
        public bool WifiAvailability { set; get; }

        public override string ToString()
        {

            return "Name: " + Name + "\n" + "Adress: " + Adress;
        }

    }
}
