using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafes cafes = new Cafes();
            Cafe cafe1 = new Cafe()
            {
                Name = "Tumanyan Shaurma",
                Adress = "Tumanyan Street",
                OpenHour = 10,
                CloseHour = 24,
                Rating = 4,
                OfficialWebsite = "http://tshaurma.com",
                WifiAvailability = true
            };
            Cafe cafe2 = new Cafe()
            {
                Name = "Loft",
                Adress = "Moskovyan Street",
                OpenHour = 0,
                CloseHour = 24,
                Rating = 4.7f,
                OfficialWebsite = "http://loft.am",
                WifiAvailability = true
            };
            Cafe cafe3 = new Cafe()
            {
                Name = "Jose",
                Adress = "Khanjyan Street",
                OpenHour = 11,
                CloseHour = 24,
                Rating = 4.3f,
                OfficialWebsite = "http://jose.am",
                WifiAvailability = true
            };
            Cafe cafe4 = new Cafe()
            {
                Name = "Tashir",
                Adress = "Teryan Street",
                OpenHour = 11,
                CloseHour = 24,
                Rating = 4.4f,
                OfficialWebsite = "http://tashirpizza.am",
                WifiAvailability = true
            };
            cafes.AddCafe(cafe1);
            cafes.AddCafe(cafe2);
            cafes.AddCafe(cafe3);
            cafes.AddCafe(cafe4);

            Console.WriteLine(cafes.cafes[0]); 
        }
    }
}
