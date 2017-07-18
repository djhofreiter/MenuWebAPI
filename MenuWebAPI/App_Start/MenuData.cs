using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Menu;


namespace MenuWebAPI
{
    public class MenuData
    {
        public static List<Food> fooddata = new List<Food>()
        {
            new Food.FoodItem("Burger",4.99),
            new Food.FoodItem("Cheeseburger", 5.49),
            new Food.FoodItem("Hot Dog",3.99),
            new Food.FoodItem("Chili Dog", 4.49),
            new Food.FoodItem("Nachos",5.99),
            new Food.FoodItem("Soft Drink", 1.99),
            new Food.FoodItem("Wings", 6.99),
            new Food.FoodItem("Sundae", 2.99),
            new Food.FoodItem("Brownie", 2.49)
        };
    }
}