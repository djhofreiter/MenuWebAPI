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
    
    public partial class Cart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cart()
        {
            this.CompletedTransactions = new HashSet<CompletedTransaction>();
        }
    
        public int pk_cartID { get; set; }
        public string fk_userName { get; set; }
        public Nullable<int> fk_cartItemID { get; set; }
        public Nullable<decimal> totalCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompletedTransaction> CompletedTransactions { get; set; }
        public virtual CartItem CartItem { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
