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
        public static List<User> users = new List<User>();
        public static int theNumberOfCafes = cafes.Count;
        private static string[] inputCafes = System.IO.File.ReadAllLines("cafe.txt");
        public static List<string> linesCafes = new List<string>();
        private static string[] inputUsers = System.IO.File.ReadAllLines("users.txt");
        public static List<string> linesUsers = new List<string>();
        public Cafes()
        {
            CafesInputFromFile();
            UsersInputFromFile();            
        }

        public static void DistanceMeasure(double Latitude,double Longitude)
        {
            GeoCoordinate ourCordinate = new GeoCoordinate(40.184806, 44.527166);
            GeoCoordinate cafeCordinate;
            for (int i = 0; i < cafes.Count; i++)
            {
                cafeCordinate = new GeoCoordinate(cafes[i].Latitude, cafes[i].Longitude);
                cafes[i].Distance = (int)ourCordinate.GetDistanceTo(cafeCordinate);
            }
        }

        private void UsersInputFromFile()
        {
            for (int i = 0; i < inputUsers.Length; i++)
            {
                linesUsers.Add(inputUsers[i]);
            }
            for (int i = 0; i < inputUsers.Length / 5; i++)
            {
                users.Add(new User()
                {
                    Username = linesUsers[(5 * i)],
                    Password = FindPassword(linesUsers[(5 * i) + 1]),
                    Email = linesUsers[(5 * i) + 2],
                    Latitude = Convert.ToDouble(linesUsers[(5 * i) + 3]),
                    Longitude =Convert.ToDouble( linesUsers[(5 * i) + 4]),

                });
            }
        }

        private void CafesInputFromFile()
        {
            for (int i = 0; i < inputCafes.Length; i++)
            {
                linesCafes.Add(inputCafes[i]);
            }
            for (int i = 0; i < inputCafes.Length / 11; i++)
            {
                string[] open = inputCafes[(11 * i) + 3].Split(',');
                string[] close = inputCafes[(11 * i) + 4].Split(',');
                cafes.Add(new Cafe()
                {
                    Name = linesCafes[(11 * i)],
                    Address = linesCafes[(11 * i) + 1],
                    Telephone = linesCafes[(11 * i) + 2],
                    OpenHour = new TimeSpan(Convert.ToInt32(open[0]), Convert.ToInt32(open[1]), Convert.ToInt32(open[2])),
                    CloseHour = new TimeSpan(Convert.ToInt32(close[0]), Convert.ToInt32(close[1]), Convert.ToInt32(close[2])),
                    Rating = double.Parse((linesCafes[(11 * i) + 5])),
                    OfficialWebsite = linesCafes[(11 * i) + 6],
                    WifiAvailability = Convert.ToBoolean(linesCafes[(11 * i) + 7]),
                    Latitude = Convert.ToDouble(linesCafes[(11 * i) + 8]),
                    Longitude = Convert.ToDouble(linesCafes[(11 * i) + 9]),
                    Reviews = linesCafes[(11 * i) + 10]
                });
            }
        }

        public void AddCafe(Cafe cafe)
        {
            cafes.Add(cafe);
        }

        public void AddUser(User user)
        {
            users.Add(user);
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
                if (var.Address.ToLower() == adress.ToLower())
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

        public int DifferenceBetweenTwoString(string s1, string s2)
        {
            int k = 0;
            s1 = s1.ToLower().Replace(" ", "");
            s2 = s2.ToLower().Replace(" ", "");
            if (s1 == s2) return s1.Length;
            else if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] == s2[i]) k++;
                }
            }
            return k;
        }

        public int LongestCommonSubstringLength(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return 0;

            List<int[]> num = new List<int[]>();
            int maxlen = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                num.Add(new int[str2.Length]);
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                        num[i][j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i][j] = 1;
                        else
                            num[i][j] = 1 + num[i - 1][j - 1];
                        if (num[i][j] > maxlen)
                            maxlen = num[i][j];
                    }
                    if (i >= 2)
                        num[i - 2] = null;
                }
            }
            return maxlen;
        }

        public Cafe GetCafeByName2(string name)
        {
            foreach (Cafe var in cafes)
            {
                if (var.Name.Replace(" ", "").ToLower() == name.Replace(" ", "").ToLower())
                    return var;
            }
            return null;
        }

        public void GetCafeByName(string name)
        {
            name = name.Replace(" ", "").ToLower();
            List<Cafe> CafeByName = new List<Cafe>();
            foreach (Cafe var in cafes)
            {
                if (var.Name.Replace(" ", "").ToLower() == name)
                    CafeByName.Add(var);
                else if (DifferenceBetweenTwoString(name, var.Name.Replace(" ", "").ToLower()) >= 2) CafeByName.Add(var);
            }
            foreach (Cafe var in cafes)
            {
                if (var.Name.Replace(" ", "").ToLower() == name) continue;
                else if (DifferenceBetweenTwoString(name, var.Name.Replace(" ", "").ToLower()) >= 2) continue;
                else if (LongestCommonSubstringLength(name, var.Name.Replace(" ", "").ToLower()) >= 2) CafeByName.Add(var);

            }
            Console.WriteLine();
            if (CafeByName.Count == 0)
            {
                Console.WriteLine("Cafe is not found!");
            }
            else
            {
                foreach (Cafe var in CafeByName)
                {
                    Console.WriteLine(var.Name + ": " + var.Distance + "m");
                }
                Console.WriteLine();
            }
        }

        public void NearestPoint(Cafe cafe)
        {
            Distances distance = new Distances();
            List<double> coordX = distance.GetX();
            List<double> coordY = distance.GetY();
            int index = 0;
            int min = Int32.MaxValue;
            for (int i = 0; i < coordX.Count; i++)
            {
                if (Distances.FindDistance(coordX[i], coordY[i], cafe.Latitude, cafe.Longitude) < min)
                {
                    min = Distances.FindDistance(coordX[i], coordY[i], cafe.Latitude, cafe.Longitude);
                    index = i;
                }
            }
            cafe.NearPoint = index;
        }

        public static string HidePassword(string password)
        {
            string keyboard = "`1234567890-=qwertyuiop[]\\asdfghjkl;\'zxcvbnm,./~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?`";
            string newPassword = password;
            for (int i = 0; i < password.Length; i++)
            {
                char member = password[i];
                int index = keyboard.IndexOf(member);
                newPassword = newPassword.Substring(0, i) + keyboard[index + 1] + newPassword.Substring(i + 1);
            }
            return newPassword;
        }

        public static string FindPassword(string password)
        {
            string keyboard = "?`1234567890-=qwertyuiop[]\\asdfghjkl;\'zxcvbnm,./~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?";
            string newPassword = password;
            for (int i = password.Length-1; i>=0; i--)
            {
                char member = password[i];
                int index = keyboard.IndexOf(member);
                newPassword = newPassword.Substring(0, i) + keyboard[index - 1] + newPassword.Substring(i + 1);
            }
            return newPassword;
        }
    }
}
