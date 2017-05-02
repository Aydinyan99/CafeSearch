using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeSearch
{
    class Cafes
    {

        public static List<Cafe> cafes = new List<Cafe>();
        public static int theNumberOfCafes = cafes.Count;
        public Cafes()
        {
            cafes.Add(cafe1);
            cafes.Add(cafe2);
            cafes.Add(cafe3);
            cafes.Add(cafe4);
        }
        public string AllCafes()
        {
            string AllCafes = "";
            foreach (Cafe cafe in cafes)
            {
                AllCafes += cafe;
            }
            return AllCafes;
        }
        public string CafesOpenNow()
        {
            string cafesOpenNow = "";
            foreach (Cafe cafe in cafes)
            {
                if (DateTime.Now.TimeOfDay >= cafe.OpenHour && DateTime.Now.TimeOfDay <= cafe.CloseHour)
                    cafesOpenNow += cafe;
            }
            return cafesOpenNow;
        }
        public string CafesWithWifi()
        {
            string cafesWithWifi = "";
            foreach (Cafe cafe in cafes)
            {
                if (cafe.WifiAvailability)
                    cafesWithWifi += cafe;
            }
            return cafesWithWifi;
        }
        public void AddCafe(Cafe cafe)
        {
            cafes.Add(cafe);
        }
        public Cafe GetCafeByName(string name)
        {
            foreach (Cafe var in cafes)
            {
                if (var.Name == name)
                    return var;
            }
            return null;
        }
        public void GetCafesByDecliningRating()
        {
            List<Cafe> cafeRating = cafes;
            for (int i = 0; i < cafes.Count; i++)
            {
                for (int j = 0; j < cafes.Count - i - 1; j++)
                {
                    if (cafeRating[j].Rating < cafeRating[j + 1].Rating)
                    {
                        Cafe c;
                        c = cafeRating[j];
                        cafeRating[j] = cafeRating[j + 1];
                        cafeRating[j + 1] = c;
                    }
                }
            }
            foreach (Cafe var in cafeRating)
            {
                Console.WriteLine(var.ToString());
            }
        }
        public Cafe GetCafeByAddress(string adress)
        {
            foreach (Cafe var in cafes)
            {
                if (var.Address == adress)
                    return var;
            }
            return null;
        }
        public List<Cafe> GetCafes()
        {
            return new List<Cafe>();
        }
        Cafe cafe1 = new Cafe()
        {
            Name = "Tumanyan Shaurma",
            Address = "Tumanyan Street",
            OpenHour = new TimeSpan(09, 00, 00),
            CloseHour = new TimeSpan(20, 00, 00),
            Rating = 4f,
            OfficialWebsite = "http://tshaurma.com",
            WifiAvailability = true
        };

        Cafe cafe2 = new Cafe()
        {
            Name = "Loft",
            Address = "Moskovyan Street",
            OpenHour = new TimeSpan(09, 00, 00),
            CloseHour = new TimeSpan(11, 00, 00),
            Rating = 4.7f,
            OfficialWebsite = "http://loft.am",
            WifiAvailability = true
        };
        Cafe cafe3 = new Cafe()
        {
            Name = "Jose",
            Address = "Khanjyan Street",
            OpenHour = new TimeSpan(11, 00, 00),
            CloseHour = new TimeSpan(23, 59, 00),
            Rating = 4.3f,
            OfficialWebsite = "http://jose.am",
            WifiAvailability = true,
            Reviews = "Davit Mkoyan: Nice club-restaurant  to arrange birthdays and other events. Has live music. Is expensive.\n"
        };
        Cafe cafe4 = new Cafe()
        {
            Name = "Tashir",
            Address = "Teryan Street",
            OpenHour = new TimeSpan(10, 00, 00),
            CloseHour = new TimeSpan(23, 00, 00),
            Rating = 4.4f,
            OfficialWebsite = "http://tashirpizza.am",
            WifiAvailability = true
        };
    }
}
