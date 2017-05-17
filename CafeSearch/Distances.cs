using System;
using System.Collections.Generic;
using System.Device.Location;

namespace CafeSearch
{
    class Distances
    {
        List<double> coordX = AddCoordX();
        List<double> coordY = AddCoordY();
        public static List<string> paths = new List<string>();
        public void Run(string start)
        {
            List<double> coordX = AddCoordX();
            List<double> coordY = AddCoordY();
            Dictionary<int, string> point = AddPaths();
            List<string> name = AddNames();            
            FindPaths(name, point, point[0], start, "");
            string path = FindShortestPath(paths, coordX, coordY);
            ShowPath(path, name, coordX, coordY);

        }

        public List<double> GetX()
        {
            return coordX;
        }

        public List<double> GetY()
        {
            return coordY;
        }

        private void FindPaths(List<string> name, Dictionary<int, string> point, string startPoint, string lastPoint, string path)
        {
            if (startPoint.Length == 0)
            {
                //Console.WriteLine(path);
                return;
            }
            string[] points = startPoint.Split();
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == lastPoint)
                {
                    path += " " + lastPoint;
                    paths.Add(path);
                    return;
                }
                FindPaths(name, point, point[Convert.ToInt32(points[i])], lastPoint, path + " " + Convert.ToInt32(points[i]));
            }
        }

        private List<string> AddNames()
        {
            List<string> name = new List<string>();
            name.Add("ArmSoft");
            name.Add("Nalbandyan-Charenc");
            name.Add("Nalbandyan-Khanjyan");
            name.Add("Nalbandyan-Sayat-Nova");
            name.Add("Nalbandyan-Tumanyan");
            name.Add("Nalbandyan-Vardananc");
            name.Add("Republic Square");
            name.Add("Abovyan-Koryun");
            name.Add("Abovyan-Moskovyan");
            name.Add("Abovyan-Sayat-Nova");
            name.Add("Abovyan-Tumanyan");
            name.Add("Teryan-Koryun");
            name.Add("Teryan-Moskovyan");
            name.Add("Teryan-Sayat-Nova");
            name.Add("Teryan-Tumanyan");
            name.Add("Teryan-Amiryan");
            name.Add("Mesrop Mashtots-Koryun");
            name.Add("Mesrop Mashtots-Moskovyan");
            name.Add("Mesrop Mashtots-Sayat-Nova");
            name.Add("Mesrop Mashtots-Tumanyan");
            name.Add("Mesrop Mashtots-Amiryan");
            return name;
        }

        private Dictionary<int, string> AddPaths()
        {
            Dictionary<int, string> point = new Dictionary<int, string>();
            point[0] = "1";
            point[1] = "2 7";
            point[2] = "3 8";
            point[3] = "4 9";
            point[4] = "5 10";
            point[5] = "6";
            point[6] = "15";
            point[7] = "8 11";
            point[8] = "9 12";
            point[9] = "10 13";
            point[10] = "6 14";
            point[11] = "12 16";
            point[12] = "13 17";
            point[13] = "14 18";
            point[14] = "15 19";
            point[15] = "20";
            point[16] = "17";
            point[17] = "18";
            point[18] = "19";
            point[19] = "20";
            point[20] = "";
            return point;
        }

        public static List<double> AddCoordX()
        {
            List<double> coordX = new List<double>();
            coordX.Add(40.185428);
            coordX.Add(40.185543);
            coordX.Add(40.183805);
            coordX.Add(40.182035);
            coordX.Add(40.181067);
            coordX.Add(40.179657);
            coordX.Add(40.177780);
            coordX.Add(40.188114);
            coordX.Add(40.186015);
            coordX.Add(40.183671);
            coordX.Add(40.182425);
            coordX.Add(40.189310);
            coordX.Add(40.187196);
            coordX.Add(40.184974);
            coordX.Add(40.183712);
            coordX.Add(40.179327);
            coordX.Add(40.190488);
            coordX.Add(40.188202);
            coordX.Add(40.187225);
            coordX.Add(40.185499);
            coordX.Add(40.180927);
            return coordX;
        }

        public static List<double> AddCoordY()
        {
            List<double> coordY = new List<double>();
            coordY.Add(44.526959);
            coordY.Add(44.526326);
            coordY.Add(44.523451);
            coordY.Add(44.520822);
            coordY.Add(44.519256);
            coordY.Add(44.516842);
            coordY.Add(44.512658);
            coordY.Add(44.524058);
            coordY.Add(44.521580);
            coordY.Add(44.518844);
            coordY.Add(44.517406);
            coordY.Add(44.522277);
            coordY.Add(44.519788);
            coordY.Add(44.517127);
            coordY.Add(44.515582);
            coordY.Add(44.510089);
            coordY.Add(44.519299);
            coordY.Add(44.516381);
            coordY.Add(44.515245);
            coordY.Add(44.513142);
            coordY.Add(44.507768);
            return coordY;
        }

        public static int FindDistance(double cordX1, double cordY1, double cordX2, double cordY2)
        {
            GeoCoordinate cordinate1 = new GeoCoordinate(cordX1, cordY1);
            GeoCoordinate cordinate2 = new GeoCoordinate(cordX2, cordY2);
            return (int)cordinate1.GetDistanceTo(cordinate2);
        }

        public static string FindShortestPath(List<string> paths, List<double> coordX, List<double> coordY)
        {
            List<int> pathLengths = new List<int>();
            for (int i = 0; i < paths.Count; i++)
            {
                string[] way = paths[i].Split();
                int pathLength = 0;
                for (int j = 1; j < way.Length; j++)
                {
                    int number = Convert.ToInt32(way[j]);
                    if (j < way.Length - 1)
                    {
                        int number2 = Convert.ToInt32(way[j + 1]);
                        pathLength += FindDistance(coordX[number], coordY[number], coordX[number2], coordY[number2]);
                    }
                }
                pathLengths.Add(pathLength);
            }
            int index = 0;
            int min = Int32.MaxValue;
            for (int i = 0; i < pathLengths.Count; i++)
            {
                if (pathLengths[i] < min)
                {
                    min = pathLengths[i];
                    index = i;
                }
            }
            return paths[index];
        }

        public static void ShowPath(string path, List<string> name, List<double> coordX, List<double> coordY)
        {
            string[] way = path.Split();
            for (int j = 1; j < way.Length; j++)
            {
                int number = Convert.ToInt32(way[j]);
                if (j < way.Length - 1)
                {
                    int number2 = Convert.ToInt32(way[j + 1]);
                    Console.Write("From " + name[number]+" to " + name[number2]+" ");
                    Console.WriteLine(FindDistance(coordX[number], coordY[number], coordX[number2], coordY[number2])+"meters");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    Console.Write("From " + name[number]+" ");
                }
            }
        }
    }
}
