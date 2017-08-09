using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MenuProjectDAL;

namespace MenuProject
{
    [DataContract]
    public class CartDTO
    {
        [DataMember]
        public string name = "";
        [DataMember]
        public double cost { get; set; }
        [DataMember]
        public int quantity { get; set; }

        public CartDTO() { }
        public CartDTO(string cartItemName, double cartItemCost, int quantity)
        {
            name = cartItemName;
            cost = cartItemCost;
            this.quantity = quantity;
        }
    }
}
