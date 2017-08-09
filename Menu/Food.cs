using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuProjectDAL;

namespace MenuProject
{
    public class Food
    {

        public string name { get; set; }
        public double cost { get; set; }

        public MenuDTO convertFoodtoDTO()
        {
            return new MenuDTO(name, cost);
        }

        public static Dictionary<string, Food> UpdateMenu()
        {
            Dictionary<string, Food> menu = new Dictionary<string, Food>();
            menu["Burger"] = new Entree("Burger", 4.99);
            menu["Cheeseburger"] = new Entree("Cheeseburger", 5.49);
            menu["Hot Dog"] = new Entree("Hot Dog", 3.99);
            menu["Chili Dog"] = new Entree("Chili Dog", 4.49);
            menu["Nachos"] = new Appetizer("Nachos", 5.99);
            menu["Soft Drink"] = new Beverage("Soft Drink", 1.99);
            menu["Wings"] = new Appetizer("Wings", 6.99);
            menu["Sundae"] = new Dessert("Sundae", 2.99);
            menu["Brownie"] = new Dessert("Brownie", 2.49);
            menu["Domestic Beer"] = new Beverage("Domestic Beer", 2.99);
            return menu;
        }

        public Food(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }

    }
}