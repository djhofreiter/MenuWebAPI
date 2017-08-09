using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuProjectDAL;

namespace MenuProject
{
    public class CartItem
    {
        public int quantity { get; set; }
        public string name { get; set; }
        public double cost { get; set; }

        public double GetTotalItemCost()
            {
                return quantity * cost;
            }

        public CartDTO convertCartToDTO()
            {
                return new CartDTO(name, cost, quantity);
            }

        public CartItem(Food cartItemData, int quantity)
            {
                name = cartItemData.name;
                cost = cartItemData.cost;
                this.quantity = 1;
            }

    }
}
