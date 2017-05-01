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

        public  string cafesOpenNow()
        {
            string cafesOpenNow="";
            foreach (Cafe cafe in cafes)
            {
                if (DateTime.Now.TimeOfDay >= cafe.OpenHour && DateTime.Now.TimeOfDay <= cafe.CloseHour)
                    cafesOpenNow = cafesOpenNow + (cafe);
            }
            return cafesOpenNow;
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
            float rating = 5;
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
       
    }
}
