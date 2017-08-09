using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuProjectDAL;

namespace MenuWebAPI.Models
{
    public class Cart
    {
        public decimal totalCost (CartItem itemToBeCalculated)
        {
                return itemToBeCalculated.quantity * itemToBeCalculated.ItemToBeChanged.cost;
        }

        //Creates a new list of cart items       
        public Dictionary<string, CartItem> cartItemCollection = new Dictionary<string, CartItem>();
        
    }
}