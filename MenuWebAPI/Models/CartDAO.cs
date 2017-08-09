using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuProjectDAL;

namespace MenuWebAPI.Models
{
    /*
     Please note. Entity Framework is a jerk. It reversed the Cart and CartItem Collections








     */
    public class CartDAO
    {
        WidowmakerEntities cartDatabase = new WidowmakerEntities();
        public Cart userCart = new Cart();
        
        /*public Cart UpdateCartDatabase (string userName, string Password)
        {
            //This will be used to add carts for new users once the functionality is available
        }
        */

        public Cart LoadCart(string userName, string Password)
        {
            WidowmakerEntities cartDatabase = new WidowmakerEntities();
            var UserSet = from u in cartDatabase.Customers
                       where u.pk_userName == userName && u.userPassword == Password
                       select u;    //Select a user based on a matching username and password

            var User = UserSet.FirstOrDefault();
            if (User != null)
            {
                var Cart = from c in cartDatabase.CartItems
                            from CartItemsInDatabase in c.Carts
                           where CartItemsInDatabase.fk_userName == User.pk_userName
                           select CartItemsInDatabase;    //Select a cart based on the matching user
                
                foreach (var itemInCart in Cart)
                {
                    userCart.cartItemCollection.Add(new CartItem(new MenuItem(itemInCart.CartItem.Food.foodName, itemInCart.CartItem.Food.foodCost), itemInCart.CartItem.quantity));            //Populate existing items in cart
                }
            }
            return userCart;
            
        }

        public CartItem AddToCart(CartItem ItemToBeAdded) //adds item to cart
        {
            var SelectedItem = userCart.cartItemCollection.FirstOrDefault(i => i.ItemToBeChanged.name == ItemToBeAdded.ItemToBeChanged.name);
            if (SelectedItem == null)
            {
                SelectedItem = ItemToBeAdded;
                userCart.cartItemCollection.Add(SelectedItem);
                SelectedItem.quantity = 1;
            }
            else
            {
                SelectedItem.quantity++;
            }

            return SelectedItem;
            

        }
        public CartItem RemoveFromCart(CartItem ItemToBeRemoved)
        {
            var SelectedItem = userCart.cartItemCollection.FirstOrDefault(i => i.ItemToBeChanged.name == ItemToBeRemoved.ItemToBeChanged.name);
            if (SelectedItem != null)
            {
                SelectedItem = ItemToBeRemoved;
                if (SelectedItem.quantity > 1) //If there is more than one cart item from list
                {
                    SelectedItem.quantity--; //decrement the quantity by 1
                }
                else
                {
                    userCart.cartItemCollection.Remove(SelectedItem); //Remove the item of class cart item from list
                }
            }
            return SelectedItem;

        }
        
    }
}