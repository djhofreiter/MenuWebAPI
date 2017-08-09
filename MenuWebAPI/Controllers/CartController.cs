using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MenuProject;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using MenuProjectDAL;
using MenuWebAPI.Models;
using Newtonsoft.Json;


namespace MenuWebAPI.Controllers
{
    public class CartController : ApiController
    {
        WidowmakerEntities cartDatabase = new WidowmakerEntities();
        public Models.Cart userCart = new Models.Cart();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        /// <summary>
        /// default GET
        /// route : api/Cart
        /// </summary>
        /// <returns></returns>
        /*[HttpGet]
        public string GetCart()
        {
            List<Models.CartItem> returnedCart = CartDAO.LoadCart(userName, Password);
            string json = JsonConvert.SerializeObject(returnedCart);
            return json;
        }
        */

        /*public Cart UpdateCartDatabase (string userName, string Password)
        {
            //This will be used to add carts for new users once the functionality is available
        }
        */
        
        
        [HttpGet]
        [Route("api/Cart/{userName}/{Password}")]
        public string LoadCart(string userName, string Password)
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
                    var itemName = itemInCart.CartItem.Food.foodName;
                    var itemCost = itemInCart.CartItem.Food.foodCost;
                    //Populate existing items in cart
                    userCart.cartItemCollection.Add(itemName, new Models.CartItem(new MenuItem(itemName, itemCost), itemInCart.CartItem.quantity));
            }
        }

            string json = JsonConvert.SerializeObject(userCart);
            return json;
            

        }
        
        [HttpPost]
        [Route("api/Cart/{item}")]
        public Models.CartItem AddToCart(Models.CartItem ItemToBeAdded) //adds item to cart
        {
            //Create a local variable to the method
            string ItemToAdd = ItemToBeAdded.ItemToBeChanged.name;

            //Verifies item to be added is in cart
            bool checkIfItemInCart = userCart.cartItemCollection.ContainsKey(ItemToAdd);
            if (checkIfItemInCart == false)
            {
            //Adds item to cart and sets the default quantity to 1
                userCart.cartItemCollection.Add(ItemToAdd, ItemToBeAdded);
                ItemToBeAdded.quantity = 1;
            }
            else
            {
            //Increases specific item by name's quantity
                userCart.cartItemCollection[ItemToAdd].quantity++;
            }

            return ItemToBeAdded;


        }

        [HttpDelete]
        [Route("api/Cart/{item}")]
        public Models.CartItem RemoveFromCart(Models.CartItem ItemToBeRemoved)
        {
            //Checks if item is in cart
            bool checkIfItemInCart = userCart.cartItemCollection.ContainsKey(ItemToBeRemoved.ItemToBeChanged.name);
            if (checkIfItemInCart == true)
            {
                if (ItemToBeRemoved.quantity > 1) //If there is more than one cart item from list
                {
                    ItemToBeRemoved.quantity--; //decrement the quantity by 1
                }
                else
                {
                    userCart.cartItemCollection.Remove(ItemToBeRemoved.ItemToBeChanged.name); //Remove the item of class cart item from list
                }
            }
            return ItemToBeRemoved;

        }
        


    }
}