//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class RECIPES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RECIPES()
        {
            this.PRODUCTS = new HashSet<PRODUCTS>();
            this.SCHEDULES = new HashSet<SCHEDULES>();
        }
    
        public short CODE { get; set; }
        public string MAIL { get; set; }
        public string RECIPE_ID { get; set; }
        public string RECIPE_TITLE { get; set; }
        public string RECIPE_IMAGE { get; set; }
        public Nullable<int> SCHEDULING_STATUSE { get; set; }
        public System.DateTime DATE { get; set; }
        public Nullable<int> COUNT { get; set; }
    
        public virtual CLIENTS CLIENTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTS> PRODUCTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULES> SCHEDULES { get; set; }
    }
}
