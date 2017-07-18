using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Food : MenuDTO
    {
        
        public class FoodItem : Food
        {

            public FoodItem(string name, double cost)
            {
                this.name = name;
                this.cost = cost;
            }
        }
    }
}
