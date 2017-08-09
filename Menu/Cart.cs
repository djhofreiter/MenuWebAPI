using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuProjectDAL;
    

namespace MenuProject
{
    public class Cart
    {
        public Dictionary<string, Food> CartData { get; set; }

        public void AddCartItem(Food item)
        {

            if (CartData.ContainsKey(item.name))
            {

            }
            else
            {

            }

        }

        public void RemoveCartItem(Food item)
        {
            if (CartData.ContainsKey(item.name))
            {

            }
            else
            {

            }
        }

        /*
        public int quantity(foodItem);
        string name;
        double cost;
        double totalItemCost(itemName) = quantity(itemName) * Food.FoodItem.cost;

        public Cart(string name, double cost)
        {

            this.name = Food.name;
            this.cost = Food.cost;

        }
        */


    }
}
