using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuProjectDAL;

namespace MenuProject
{
    public class Beverage : Food
    {
        public Beverage(string name, double cost) : base(name, cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}
