using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuWebAPI.Models
{
    public class MenuItem
    {
        //Assigns each menu item properties of a name, cost, and category
        public string name { get; set; }
        public decimal cost { get; set; }
        public string category { get; set; }
        public MenuItem (string name, decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}