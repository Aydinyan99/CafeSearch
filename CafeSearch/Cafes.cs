using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace CafeSearch
{
    class Cafes
    {

        public static List<Cafe> cafes = new List<Cafe>();
        public static int theNumberOfCafes = cafes.Count;
        private string[] input = System.IO.File.ReadAllLines("cafe.txt");
        public static List<string> lines = new List<string>();
        public Cafes()
        {
            for (int i = 0; i < input.Length; i++)
                lines.Add(input[i]);
                for (int i = 0; i < input.Length / 10; i++)
            {
                string[] open = input[(10*i) + 3].Split(',');
                string[] close = input[(10 * i) + 4].Split(',');
                cafes.Add(new Cafe()
                {
                    Name = lines[(10 * i)],
                    Address = lines[(10 * i) + 1],
                    Telephone = lines[(10 * i) + 2],
                    OpenHour = new TimeSpan(Convert.ToInt32(open[0]), Convert.ToInt32(open[1]), Convert.ToInt32(open[2])),
                    CloseHour = new TimeSpan(Convert.ToInt32(close[0]), Convert.ToInt32(close[1]), Convert.ToInt32(close[2])),
                    Rating = (float)Convert.ToDouble(lines[(10 * i) + 5]),
                    OfficialWebsite = lines[(10 * i) + 6],
                    WifiAvailability = Convert.ToBoolean(lines[(10 * i) + 7]),
                    Latitude = Convert.ToDouble(lines[(10 * i) + 8]),
                    Longitude = Convert.ToDouble(lines[(10 * i) + 9])
                });
            }
            GeoCoordinate ourCordinate = new GeoCoordinate(40.184806, 44.527166);
            GeoCoordinate cafeCordinate;
            for (int i = 0; i < cafes.Count; i++)
            {
                cafeCordinate = new GeoCoordinate(cafes[i].Latitude, cafes[i].Longitude);
                cafes[i].Distance = (int)ourCordinate.GetDistanceTo(cafeCordinate);
            }
        }
        public void AddCafe(Cafe cafe)
        {
            cafes.Add(cafe);
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
        public void NearestCafes()
        {
            List<Cafe> nearCafes = cafes;
            for (int i = 0; i < cafes.Count; i++)
            {
                for (int j = 0; j < cafes.Count - i - 1; j++)
                {
                    if (nearCafes[j].Distance > nearCafes[j + 1].Distance)
                    {
                        Cafe c;
                        c = nearCafes[j];
                        nearCafes[j] = nearCafes[j + 1];
                        nearCafes[j + 1] = c;
                    }
                }
            }
            foreach (Cafe var in nearCafes)
            {
                Console.WriteLine(var.Name + ": " + var.Distance + "m");
            }
            Console.WriteLine();
        }
    }
}
