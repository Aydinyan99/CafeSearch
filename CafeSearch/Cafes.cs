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
            cafes.Add(cafe5);
        }
        public void AllCafes()
        {
            List<Cafe> AllCafes = new List<Cafe>();
            foreach (Cafe cafe in cafes)
            {
                AllCafes.Add(cafe);
            }
            foreach (Cafe var in AllCafes)
            {
                Console.WriteLine(var + "\n");
            }
        }
        public void CafesOpenNow()
        {
            List<Cafe> cafesOpenNow = new List<Cafe>();
            foreach (Cafe cafe in cafes)
            {
                if (DateTime.Now.TimeOfDay >= cafe.OpenHour && DateTime.Now.TimeOfDay <= cafe.CloseHour)
                    cafesOpenNow.Add(cafe);
            }
            foreach (Cafe var in cafesOpenNow)
            {
                Console.WriteLine(var + "\n");
            }

        }
        public void CafesWithWifi()
        {
            List<Cafe> cafesWithWifi = new List<Cafe>();
            foreach (Cafe cafe in cafes)
            {
                if (cafe.WifiAvailability)
                    cafesWithWifi.Add(cafe);
            }
            foreach (Cafe var in cafesWithWifi)
            {
                Console.WriteLine(var + "\n");
            }
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
                Console.WriteLine(var + "\n");
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
            Name = "Cafe Champagne",
            Address = "27 Mesrop Mashtots Ave",
            Telephone = "+374 43 011118",
            OpenHour = new TimeSpan(11, 00, 00),
            CloseHour = new TimeSpan(23, 30, 00),
            Rating = 5f,
            OfficialWebsite = "http://cafechampagne.am",
            WifiAvailability = true
        };

        Cafe cafe2 = new Cafe()
        {
            Name = "Jazzve",
            Address = "Tumanyan Street",
            Telephone = "+374 10 533633",
            OpenHour = new TimeSpan(10, 00, 00),
            CloseHour = new TimeSpan(23, 00, 00),
            Rating = 3.9f,
            OfficialWebsite = "http://jazzve.am",
            WifiAvailability = true
        };
        Cafe cafe3 = new Cafe()
        {
            Name = "Jose",
            Address = "Khanjyan Street",
            Telephone = "+374 91 540020",
            OpenHour = new TimeSpan(22, 00, 00),
            CloseHour = new TimeSpan(23, 45, 00),
            Rating = 4.4f,
            OfficialWebsite = "http://jose.am",
            WifiAvailability = true,
            Reviews = "Davit Mkoyan: Nice club-restaurant  to arrange birthdays and other events. Has live music. Is expensive."
        };
        Cafe cafe4 = new Cafe()
        {
            Name = "Segafredo",
            Address = "Teryan Street",
            Telephone = "+374 60 521190",
            OpenHour = new TimeSpan(8, 30, 00),
            CloseHour = new TimeSpan(23, 45, 00),
            Rating = 4.4f,
            OfficialWebsite = "http://segafredo.it",
            WifiAvailability = true
        };
        Cafe cafe5 = new Cafe()
        {
            Name = "Malocco",
            Address = "Tamanyan Street",
            Telephone = "+374 96 531327",
            OpenHour = new TimeSpan(8, 30, 00),
            CloseHour = new TimeSpan(23, 45, 00),
            Rating = 4.4f,
            OfficialWebsite = "http://malocco.com",
            WifiAvailability = true
        };
    }
}
