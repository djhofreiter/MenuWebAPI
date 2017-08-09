using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuWebAPI.Models
{
    public class FoodMenu
    {
        //Instantiates a list composed of menu items
        public Dictionary <string, MenuItem> MainMenu = new Dictionary <string, MenuItem>();
        
    }
}