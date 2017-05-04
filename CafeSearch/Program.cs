using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device;

namespace CafeSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafes cafes = new Cafes();

            Console.WriteLine("Welcome! \n");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            while (username != "martirosyanrafi")
            {
                Console.WriteLine("\nWrong username!");
                Console.WriteLine("Wait 15 seconds for next try.");
                System.Threading.Thread.Sleep(2500);
                for (int i = 15; i > 0; i--)
                {
                    Console.WriteLine("Username:");
                    
                    Console.WriteLine(i);
                    for (int j = 0; j < 22; j++)
                        Console.WriteLine();
                    System.Threading.Thread.Sleep(600);
                }
                Console.WriteLine();
                Console.WriteLine("Username:");
                username = Console.ReadLine();
            }
            Console.WriteLine("\nWhat do you want to know? \n");

            InputNumbers(cafes);
            
        }
        public static void InputNumbers(Cafes cafes)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You can find: \n1. Cafes by name\n2. Cafes by address \n3. Now open cafes\n4. Cafes that have wifi\n5. Nearest cafes\n6. All cafes on map \n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Select what you want by its number.\n");
            string numberOfFunction = Console.ReadLine();
            Console.WriteLine();
            while (!(numberOfFunction.Length == 1 && Convert.ToChar(numberOfFunction) > '0' && Convert.ToChar(numberOfFunction) < '7'))
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                numberOfFunction = Console.ReadLine();
            }
            switch (numberOfFunction)
            {
                case "1":
                    CafesByName(cafes);
                    break;
                case "2":
                    CafesByAddress(cafes);
                    break;
                case "3":
                    NowOpenCafes(cafes);
                    break;
                case "4":
                    CafesWithWifi(cafes);
                    break;
                case "5":
                    NearestCafes(cafes);
                    break;
                case "6":
                    AllCafes(cafes);
                    break;
            }

        }
        public static void CafesByName(Cafes cafes)
        {
            Console.WriteLine("Enter the name of the cafe.\n");
            Cafe cafe = cafes.GetCafeByName(Console.ReadLine());
            while (cafe == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = cafes.GetCafeByName(Console.ReadLine());
            }
            CafeReserve(cafes, cafe);
        }
        public static void CafesByAddress(Cafes cafes)
        {
            Console.WriteLine("Enter the address of the cafe.");
            Cafe cafe = cafes.GetCafeByAddress(Console.ReadLine());
            while (cafe == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = cafes.GetCafeByName(Console.ReadLine());
            }
            CafeReserve(cafes, cafe);
        }
        public static void CafesWithWifi(Cafes cafes)
        {
            cafes.CafesWithWifi();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            CafeReserve(cafes,cafes.GetCafeByName(cafe));
        }
        public static void NowOpenCafes(Cafes cafes)
        {
            cafes.CafesOpenNow();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            CafeReserve(cafes, cafes.GetCafeByName(cafe));
        }
        public static void NearestCafes(Cafes cafes)
        {
            cafes.NearestCafes();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            CafeReserve(cafes, cafes.GetCafeByName(cafe));
        }
        public static void AllCafes(Cafes cafes)
        {
            cafes.AllCafes();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            CafeReserve(cafes, cafes.GetCafeByName(cafe));
        }
        public static void CafeReserve(Cafes cafes, Cafe cafe)
        {
            Console.WriteLine("\nName: " + cafe.Name + "\n" + "Adress: " + cafe.Address + "\n" +"Distance: " +cafe.Distance+"m\n" + "\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Do you want to go " + cafe.Name + "? (yes/no)");
            string answer = Console.ReadLine();
            Console.WriteLine();
            while (answer != "yes" && answer != "no")
            {
                Console.WriteLine("Wrong input! Enter the word again.");
                answer = Console.ReadLine();
            }
            if (answer == "yes")
            {
                Console.WriteLine("When do you want to go?");
                Console.ReadLine();
                Random rand = new Random();
                int random = rand.Next(10);
                if (random < 8)
                {
                    Console.WriteLine("Your table is reserved.");
                }
                else
                {
                    Console.WriteLine("Sorry, all tables are reserved!");
                    Console.WriteLine("Do you want to choose another cafe? (yes/no)");
                    answer = Console.ReadLine();
                    Console.WriteLine();
                    while (answer != "yes" && answer != "no")
                    {
                        Console.WriteLine("Wrong input! Enter the word again.");
                        answer = Console.ReadLine();
                    }
                    if (answer == "yes")
                    {
                        InputNumbers(cafes);
                    }
                    else
                    {
                        Console.WriteLine("Good bye!");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            else
            {
                Console.WriteLine("Do you want to choose another cafe? (yes/no)");
                answer = Console.ReadLine();
                Console.WriteLine();
                while (answer != "yes" && answer != "no")
                {
                    Console.WriteLine("Wrong input! Enter the word again.");
                    answer = Console.ReadLine();
                }
                if (answer == "yes")
                {
                    InputNumbers(cafes);
                }
                else
                {
                    Console.WriteLine("Good bye!");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
