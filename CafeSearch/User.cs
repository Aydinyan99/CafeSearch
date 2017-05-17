using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace CafeSearch
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public static List<User> UsersList = new List<User>();
        public static List<string> UsersString = new List<string>();
    }
}
