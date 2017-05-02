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

            Console.WriteLine("Welcome! \n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("What do you want to know? \n");
            InputNumbers(cafes);
        }
        public static void InputNumbers(Cafes cafes)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You can find: \n1. Cafes by name, 2. Cafes by address \n3. Now open cafes, 4. Cafes that have wifi\n5. All cafes on map \n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Select what you want by its number.");
            string numberOfFunction = Console.ReadLine();
            while (!(numberOfFunction.Length == 1 && Convert.ToChar(numberOfFunction) > '0' && Convert.ToChar(numberOfFunction) < '6'))
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
                    AllCafes(cafes);
                    break;
            }

        }
        public static void CafesByName(Cafes cafes)
        {
            Console.WriteLine("Enter the name of the cafe.");
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
            Console.WriteLine(cafes.CafesWithWifi());
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
            Console.WriteLine(cafes.CafesOpenNow());
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
            Console.WriteLine(cafes.AllCafes());
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
            Console.WriteLine("\n" + cafe.ToString() + "\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Do you want to go " + cafe.Name + "? (yes/no)");
            string answer = Console.ReadLine();
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
