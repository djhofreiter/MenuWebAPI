using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuProjectDAL;

namespace MenuWebAPI.Models
{
    public class MenuDAO
    {

        public static List<MenuItem> CreateMenu()
        {
            //Instantiates widowmakerMenu as a FoodMenu object
            FoodMenu widowmakerMenu = new FoodMenu();
            WidowmakerEntities menuDatabase = new WidowmakerEntities();

            foreach (var foodItem in menuDatabase.Foods)
            {
                widowmakerMenu.MainMenu.Add(new MenuItem(foodItem.foodName, foodItem.foodCost));
       
            }
            return widowmakerMenu.MainMenu;
            
            
        }
    }
}