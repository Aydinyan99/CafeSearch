﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeSearch
{
    class Cafes
    {
    
        public List<Cafe> cafes = new List<Cafe>();
        public void AddCafe(Cafe cafe)
        {
            cafes.Add(cafe);
        } 
        public Cafe GetCafeByName(string name)
        {
            foreach(Cafe var in cafes)
            {
                if (var.Name == name)
                    return var;
            }
            return null;
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
