//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MenuProjectDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuCategory
    {
        public int pk_menuCategoryID { get; set; }
        public string categoryName { get; set; }
        public int fk_foodID { get; set; }
    
        public virtual Food Food { get; set; }
    }
}
