//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuoteSystemDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Business
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Business()
        {
            this.Coverages = new HashSet<Coverage>();
        }
    
        public int Id { get; set; }
        public string IndustryType { get; set; }
        public string Territory { get; set; }
        public int Exposure { get; set; }
        public int ProspectId { get; set; }
    
        public virtual Prospect Prospect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coverage> Coverages { get; set; }
        public virtual Address Address { get; set; }
    }
}