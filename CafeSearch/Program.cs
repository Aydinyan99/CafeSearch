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
                Address = "Tumanyan Street",
                OpenHour = 10,
                CloseHour = 24,
                Rating = 4,
                OfficialWebsite = "http://tshaurma.com",
                WifiAvailability = true
            };
            Cafe cafe2 = new Cafe()
            {
                Name = "Loft",
                Address = "Moskovyan Street",
                OpenHour = 0,
                CloseHour = 24,
                Rating = 4.7f,
                OfficialWebsite = "http://loft.am",
                WifiAvailability = true
            };
            Cafe cafe3 = new Cafe()
            {
                Name = "Jose",
                Address = "Khanjyan Street",
                OpenHour = 11,
                CloseHour = 24,
                Rating = 4.3f,
                OfficialWebsite = "http://jose.am",
                WifiAvailability = true,
                Reviews = "Davit Mkoyan: Nice club-restaurant  to arrange birthdays and other events. Has live music. Is expensive. "
            };
            Cafe cafe4 = new Cafe()
            {
                Name = "Tashir",
                Address = "Teryan Street",
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

            Console.WriteLine("Thanks for using our program! \n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("What do you want to know? \n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You can find: \n1. Cafes by name, 2. Cafes by address \n3. Now open cafes, 4. Cafes that have wifi\n5. All cafes on map \n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Select what you want by its number.");

            string numberOfFunction = Console.ReadLine();
            int number;
            while (!(numberOfFunction.Length == 1 && Convert.ToChar(numberOfFunction) > '0' && Convert.ToChar(numberOfFunction) < '6'))
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                numberOfFunction = Console.ReadLine();
            }
            number = Convert.ToInt32(numberOfFunction);
            switch (number)
            {
                case 1:
                    Console.WriteLine("Enter the name of the cafe.");
                    Cafe cafe = cafes.GetCafeByName(Console.ReadLine());
                    if ( cafe != null)
                        Console.WriteLine("\n" + cafe.ToString());
                    else
                        Console.WriteLine("\nCafe is not found!");
                    break;
                case 2:
                    Console.WriteLine("Enter the address of the cafe.");
                    cafe = cafes.GetCafeByAddress(Console.ReadLine());
                    if ( cafe != null)
                        Console.WriteLine("\n" + cafe.ToString());
                    else
                        Console.WriteLine("\nCafe is not found!");
                    break;
            }
        }

    }
}
