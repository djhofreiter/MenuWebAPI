using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuWebAPI.Models
{
    public class CartItem
    {
        //Quantity property
        public int quantity { get; set; }
        //Each cart item has the menu item property
        public MenuItem ItemToBeChanged{ get ; set; }

        public CartItem (MenuItem foodItem, int quantity)
        {
            //instantiates the itemToBeAdded by assigning it to the foodItem parameter
            ItemToBeChanged = foodItem;
            
        }
    }
}