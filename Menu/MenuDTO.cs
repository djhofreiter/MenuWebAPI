using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Menu
{
    [DataContract]
    public class MenuDTO
    {
        [DataMember]
        public string name = "";
        [DataMember]
        public double cost { get; set; }

        public MenuDTO() { }
        public MenuDTO(string foodname, double foodcost)
        {
            name = foodname;
            cost = foodcost;
        }
    }
}