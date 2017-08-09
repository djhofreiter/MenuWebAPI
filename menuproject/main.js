'use strict';

(window.main = function(User, Menu, Cart) {
//Declaring variables
var c = console;
var menuList = document.getElementById("menu");
var cartList = document.getElementById("cart");


window.onload = AppSetup();



function AppSetup()
{

//Creates a list item to be appended to a menu item
    function CreateListItem (listItemName, listItemCost, listItemQuantity)
    {
        var li = document.createElement("li");
        var foodName = document.createTextNode(listItemName)
        var foodCost = document.createTextNode(listItemCost)
        foodCost.style="float:right;"
        var listSpacer = document.createElement("span")
        

            li.appendChild(foodName)
            li.appendChild(listSpacer)
            li.appendChild(foodCost)

        return li;
    }

//Creates a menu item to be appended to the PopulateMenu function
    function MenuListItem (itemName, itemCost)
    {
        var MenuLi = CreateListItem(itemName, itemCost, 1)
        var addButton = document.createElement("button");
        // Assigns text to the button
        addButton.innerHTML = "+";
        //Uses bootstrap to make a green button
        addButton.setAttribute("class", "btn-success");
        //Creates a subtract button
        var subtractButton = document.createElement("button");
        //Assigns text to button
        subtractButton.innerHTML = "-";
        //Leverages bootstrap to make a red button
        subtractButton.setAttribute("class", "btn-danger");

            MenuLi.appendChild(addButton)
            MenuLi.appendChild(subtractButton)

        return MenuLi;

    }

    
    Menu.PopulateMenu(function(data)
    {
        for (var i=0; i<data.length; i++){
        menuList.appendChild(MenuListItem(data[i].name, data[i].cost))
        }
    });
    

    function CartListItem(itemName, itemCost, itemQuantity)
    {
        var CartLi = CreateListItem(itemName, itemCost, itemQuantity)
        var addButton = document.createElement("button");
        addButton.innerHTML = "+";
        addButton.setAttribute("class", "btn-success");
        var subtractButton = document.createElement("button");
        subtractButton.innerHTML = "-";
        subtractButton.setAttribute("class", "btn-danger");

            CartLi.appendChild(addButton)
            CartLi.appendChild(subtractButton)
    }

    
    LoadCart(function(data)
    {
        for (var i=0; i < data.length; i++) {
            cartList.appendChild(CartListItem(data[i].name, data[i].cost, data[i].Quantity))
        }
    })
    

    /*
    Incomplete

    addButton.addEventListener("click", function()
    {
        var ItemToBeAdded = something;
    })

    subtractButton.addEventListener("click", function()
    {

    })
*/


// Inserts the menu onto the page -- No longer works
// Keeping visible for ideas on eventlisteners
function InsertMenu(menuObj, cartObj)
    {

    for (i = 0; i < menuObj.FoodData.length; i++)
    { 
      
        //Executes function when button is clicked
        function AddHandler(index) {
            //Makes it easier to find the menu item in the array
            var tempMenuItem = menuObj.FoodData[index];

            addButton.addEventListener("click", function ()
            {
                //Pushes the menu item into the cart array
                cartObj.AddCartData(new CartItem(tempMenuItem));
                //Refreshes the Dom with new data every time the count changes
                UpdateDomFromCart(cartObj, cartItem, cartCount, cartCost, cartTotalCost);
            });
        }
        //links the Add button handler to the food data in the menu array
        AddHandler(i);

        function SubtractHandler(index)
        {
            var tempMenuItem = menuObj.FoodData[index];

            subtractButton.addEventListener("click", function () {
                cartObj.SubtractCartData(new CartItem(tempMenuItem));
                UpdateDomFromCart(cartObj, cartItem, cartCount, cartCost, cartTotalCost);
            });
        }

        SubtractHandler(i);
    }
}




}
})(window.user, window.menu, window.cart || window.user, window.menu, window.cart);