using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Device.Location;

namespace CafeSearch
{
    class Menu
    {
        public static Cafes cafes = new Cafes();

        public static void MyConsole()
        {
            Console.WriteLine("Welcome! \n");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("1. Sign In");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("2. Sign Up");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("3. Guest");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\nSelect what you want by numbers above!");
            string command = Console.ReadLine();
            while (!(command.Length == 1 && Convert.ToChar(command) > '0' && Convert.ToChar(command) < '4'))
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                command = Console.ReadLine();
            }
            switch (command)
            {
                case "1":
                    Console.Clear();
                    SignIn();
                    break;
                case "2":
                    Console.Clear();
                    SignUp();
                    break;
                case "3":
                    Console.Clear();
                    Guest();
                    break;
            }

        }

        private static void SignIn()
        {
            bool ans1 = true;
            bool ans2;
            Console.Write("Username: ");
            string username = Console.ReadLine();
            while (ans1)
            {
                ans2 = false;
                foreach (User user in Cafes.users)
                {

                    if (username == user.Username)
                    {
                        ans2 = true;
                        break;
                    }
                }
                if (!ans2)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Username");
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                }
                else ans1 = false;
            }

            ans1 = true;
            Console.Write("\nPassword: ");
            username = pwd();
            int k = 0;
            while (ans1)
            {
                ans2 = false;
                int i = 0;
                foreach (User user in Cafes.users)
                {
                    i++;
                    if (username == user.Password)
                    {
                        ans2 = true;
                        Cafes.DistanceMeasure(Cafes.users[i - 1].Latitude, Cafes.users[i - 1].Longitude);                  
                        break;
                    }
                }
                
                if (!ans2 && k < 3)
                {
                    k++;
                    Console.Clear();
                    Console.WriteLine("Wrong Password");
                    Console.Write("\nPassword: ");
                    username = pwd();
                    ans1 = true;
                }

                else if (!ans2)
                {
                    Console.Clear();
                    WrongAnswer("password");
                    Console.Write("Password: ");
                    username = pwd();
                }
                else ans1 = false;
            }
            Console.Clear();
            MainMethods();

        }

        private static void SignUp()
        {
            Console.WriteLine("\nPlease, fill in the following fields!");
            Console.Write("\nUsername: ");
            Cafes.linesUsers.Add(Console.ReadLine());
            Console.Write("\nPassword: ");
            Cafes.linesUsers.Add(Cafes.HidePassword(pwd()));
            Console.Write("\nE-mail: ");
            Cafes.linesUsers.Add(Console.ReadLine());
            Console.WriteLine("\nLatitude:");
            Cafes.linesUsers.Add(Console.ReadLine());
            Console.WriteLine("\nLongitude:");
            Cafes.linesUsers.Add(Console.ReadLine());
            StreamWriter file = new StreamWriter("users.txt");
            foreach (string var in Cafes.linesUsers)
            {
                file.WriteLine(var);
            }
            file.Close();

            int number = Cafes.linesUsers.Count;
            cafes.AddUser(new User()
            {
                Latitude = Convert.ToDouble(Cafes.linesUsers[number - 1]),
                Longitude = Convert.ToDouble(Cafes.linesUsers[number - 2]),
                Email = Cafes.linesUsers[(number - 3)],
                Password = Cafes.FindPassword(Cafes.linesUsers[(number - 4)]),
                Username = Cafes.linesUsers[(number - 5)],
            });
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n You have been registerd successfully");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            MyConsole();

        }

        private static void Guest()
        {
            Console.Clear();
            InputNumbers();
        }

        private static void WrongAnswer(string a)
        {
            Console.WriteLine("Wrong " + a + "!" + " Please wait 15 seconds for next try.");
            System.Threading.Thread.Sleep(2000);
            for (int i = 15; i > 0; i--)
            {
                Console.Clear();
                Console.Write("Wrong " + a + "!" + " Please wait: " + i);
                System.Threading.Thread.Sleep(600);
                Console.Clear();
            }

        }

        private static void MainMethods()
        {
            Console.WriteLine("What do you want?\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("1. Search cafes\n2. Add new cafes\n");
            string answer = Console.ReadLine();
            while (answer != "1" && answer != "2")
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                answer = Console.ReadLine();
            }
            if (answer == "1")
            {
                Console.Clear();
                InputNumbers();
            }

            else
            {
                Console.Clear();
                AddCafe();
            }
        }

        private static void InputNumbers()
        {
            Console.WriteLine("What do you want to know?\n");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("You can find: \n1. Cafes by name\n2. Cafes by address \n3. Now open cafes\n4. Cafes that have wifi\n5. Nearest cafes\n6. All cafes on map \n7. Get high rated cafes\n");
            System.Threading.Thread.Sleep(800);
            Console.WriteLine("Select what you want by its number above!\n");
            string numberOfFunction = Console.ReadLine();
            Console.WriteLine();
            while (!(numberOfFunction.Length == 1 && Convert.ToChar(numberOfFunction) > '0' && Convert.ToChar(numberOfFunction) < '8'))
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                numberOfFunction = Console.ReadLine();
            }
            switch (numberOfFunction)
            {
                case "1":
                    Console.Clear();
                    CafesByName();
                    break;
                case "2":
                    Console.Clear();
                    CafesByAddress();
                    break;
                case "3":
                    Console.Clear();
                    NowOpenCafes();
                    break;
                case "4":
                    Console.Clear();
                    CafesWithWifi();
                    break;
                case "5":
                    NearestCafes();
                    break;
                case "6":
                    Console.Clear();
                    AllCafes();
                    break;
                case "7":
                    Console.Clear();
                    GetCafesByDecliningRating();
                    break;
            }

        }

        private static void CafeReserve(Cafe cafe)
        {
            Console.WriteLine("\nName: " + cafe.Name + "\n" + "Adress: " + cafe.Address + "\n" + "Distance: " + cafe.Distance + "m\n" + "\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("1. Reserve this cafe.");
            Console.WriteLine("2. Show the way to " + cafe.Name + ".");
            Console.WriteLine("3. Rate and review.");
            Console.WriteLine("4. Go to main menu.\n");
            string answer2 = Console.ReadLine();
            while (answer2 != "1" && answer2 != "2" && answer2 != "3" && answer2 != "4")
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                answer2 = Console.ReadLine();
            }
            if (answer2 == "1")
            {
                Console.WriteLine("When do you want to go?");
                Console.ReadLine();
                Random rand = new Random();
                int random = rand.Next(10);
                if (random < 8)
                {
                    Console.WriteLine("Your table is reserved.\n");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    MyConsole();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, all tables are reserved!");
                    Console.WriteLine("Do you want to choose another cafe? (yes/no)");
                    string answer = Console.ReadLine();
                    Console.WriteLine();
                    while (answer != "yes" && answer != "no")
                    {
                        Console.WriteLine("Wrong input! Enter the word again.");
                        answer = Console.ReadLine();
                    }
                    if (answer == "yes")
                    {
                        Console.Clear();
                        InputNumbers();
                    }
                    else
                    {
                        Console.WriteLine("Good bye!");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            else if (answer2 == "2")
            {
                ShowPath(cafe);
            }
            else if (answer2 == "3")
            {
                Console.Clear();
                RateCafe(cafe);
            }
            else
            {
                Console.Clear();
                MyConsole();
            }
        }

        private static void AddCafe()
        {
            Console.Clear();
            Console.WriteLine("\nFill the following fields!\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Name:");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("Address:");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("Telephone:");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("Open Hour: (hh,mm,ss)");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("Close Hour: (hh,mm,ss)");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("Rating:");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("OfficialWebsite: (http:// ...)");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("WifiAvailability: (true/false)");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("Latitude:");
            Cafes.linesCafes.Add(Console.ReadLine());
            Console.WriteLine("Longitude:");
            Cafes.linesCafes.Add(Console.ReadLine());
            Cafes.linesCafes.Add(".");
            StreamWriter file = new StreamWriter(@"..\\..\\cafe.txt");
            foreach (string var in Cafes.linesCafes)
            {
                file.WriteLine(var);
            }
            file.Close();

            int number = Cafes.linesCafes.Count;
            string[] open = Cafes.linesCafes[number - 8].Split(',');
            string[] close = Cafes.linesCafes[number - 7].Split(',');
            cafes.AddCafe(new Cafe()
            {
                Name = Cafes.linesCafes[number - 11],
                Address = Cafes.linesCafes[number - 10],
                Telephone = Cafes.linesCafes[number - 9],
                OpenHour = new TimeSpan(Convert.ToInt32(open[0]), Convert.ToInt32(open[1]), Convert.ToInt32(open[2])),
                CloseHour = new TimeSpan(Convert.ToInt32(close[0]), Convert.ToInt32(close[1]), Convert.ToInt32(close[2])),
                Rating = (float)Convert.ToDouble(Cafes.linesCafes[number - 6]),
                OfficialWebsite = Cafes.linesCafes[number - 5],
                WifiAvailability = Convert.ToBoolean(Cafes.linesCafes[number - 4]),
                Latitude = Convert.ToDouble(Cafes.linesCafes[number - 3]),
                Longitude = Convert.ToDouble(Cafes.linesCafes[number - 2]),
                Reviews = Cafes.linesCafes[number - 1]
            });
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Cafe is added");
            Console.WriteLine("Do you want to add another cafe? (yes/no)");
            string answer = Console.ReadLine();
            Console.WriteLine();
            while (answer != "yes" && answer != "no")
            {
                Console.WriteLine("Wrong input! Enter the word again.");
                answer = Console.ReadLine();
            }
            if (answer == "yes")
                AddCafe();
            else
                InputNumbers();
        }

        private static void GetCafesByDecliningRating()
        {
            Console.Clear();
            cafes.GetCafesByDecliningRating();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName2(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            Console.Clear();
            CafeReserve(cafes.GetCafeByName2(cafe));
        }

        private static void CafesByName()
        {
            Console.Clear();
            Console.WriteLine("Search for cafes.\n");
            cafes.GetCafeByName(Console.ReadLine());
            Console.WriteLine("1. Enter the name of the cafe.");
            Console.WriteLine("2. Search for another cafes.\n");
            string answer = Console.ReadLine();
            Console.WriteLine();
            while (answer != "1" && answer != "2")
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                answer = Console.ReadLine();
            }
            Console.WriteLine();
            if (answer == "1")
            {
                Cafe cafe = cafes.GetCafeByName2(Console.ReadLine());

                while (cafe == null)
                {
                    Console.WriteLine("Cafe is not found!\n");
                    cafe = cafes.GetCafeByName2(Console.ReadLine());
                }
                Console.Clear();
                CafeReserve(cafe);
            }
            else
            {
                CafesByName();
            }
        }

        private static void CafesByAddress()
        {
            Console.Clear();
            Console.WriteLine("Enter the address of the cafe.");
            Cafe cafe = cafes.GetCafeByAddress(Console.ReadLine());
            while (cafe == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = cafes.GetCafeByName2(Console.ReadLine());
            }
            Console.Clear();
            CafeReserve(cafe);
        }

        private static void CafesWithWifi()
        {
            Console.Clear();
            cafes.CafesWithWifi();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName2(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            Console.Clear();
            CafeReserve(cafes.GetCafeByName2(cafe));
        }

        private static void NowOpenCafes()
        {
            Console.Clear();
            cafes.CafesOpenNow();
            Console.WriteLine("Which of them do you choose?\n");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName2(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            Console.Clear();
            CafeReserve(cafes.GetCafeByName2(cafe));
        }

        private static void NearestCafes()
        {
            Console.Clear();
            cafes.NearestCafes();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName2(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            Console.Clear();
            CafeReserve(cafes.GetCafeByName2(cafe));
        }

        private static void AllCafes()
        {
            Console.Clear();
            cafes.AllCafes();
            Console.WriteLine("Which of them do you choose?");
            string cafe = Console.ReadLine();
            while (cafes.GetCafeByName2(cafe) == null)
            {
                Console.WriteLine("Cafe is not found!");
                cafe = Console.ReadLine();
            }
            Console.Clear();
            CafeReserve(cafes.GetCafeByName2(cafe));
        }

        private static void RateCafe(Cafe cafe)
        {
            Console.Clear();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\nRate: (0-5)");
            string rate = Console.ReadLine();
            while (!(rate.Length == 1 && Convert.ToChar(rate) >= '0' && Convert.ToChar(rate) <= '5'))
            {
                Console.WriteLine("Wrong input! Enter the number again.");
                rate = Console.ReadLine();
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Do you want to leave a review?");
            string answer = Console.ReadLine();
            while (answer != "yes" && answer != "no")
            {
                Console.WriteLine("Wrong input! Enter the word again.");
                answer = Console.ReadLine();
            }
            string review;
            if (answer == "yes")
            {
                Console.WriteLine("\nReview:");
                review = Console.ReadLine();
                int index = 0;
                for (int i = 0; i < Cafes.linesCafes.Count; i += 11)
                {
                    if (Cafes.linesCafes[i] == cafe.Name)
                    {
                        index = i;
                        break;
                    }
                }
                int number = index + 10;
                if (Cafes.linesCafes[number].Length == 1)
                    Cafes.linesCafes[number] = review;
                else
                    Cafes.linesCafes[number] += " " + review;
                Cafes.cafes[number / 11].Reviews = Cafes.linesCafes[number];
                StreamWriter file = new StreamWriter("cafe.txt");
                foreach (string var in Cafes.linesCafes)
                {
                    file.WriteLine(var);
                }
                file.Close();
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000);
                CafeReserve(cafe);
            }
            else
            {
                Console.Clear();
                CafeReserve(cafe);
            }
        }

        private static string pwd()
        {
            string pwd = "";
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    Console.Write('\n');
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    pwd = pwd.Remove(pwd.Length - 1);
                    Console.Write("\b \b");
                }
                else
                {
                    pwd += i.KeyChar;
                    Console.Write("*");
                }
            }
            return pwd;
        }

        private static void ShowPath(Cafe cafe)
        {
            Distances distance = new Distances();
            List<double> coordX = distance.GetX();
            List<double> coordY = distance.GetY();
            cafes.NearestPoint(cafe);
            int index = cafe.NearPoint;
            distance.Run(Convert.ToString(index));
            Console.Write("to " + cafe.Name + " ");
            Console.WriteLine(Distances.FindDistance(coordX[index], coordY[index], cafe.Latitude, cafe.Longitude)+" meters");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine();
            CafeReserve(cafe);
        }
    }
}
