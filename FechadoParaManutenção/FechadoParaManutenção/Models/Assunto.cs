//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FechadoParaManutenção.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assunto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assunto()
        {
            this.TabAbtra = new HashSet<TabAbtra>();
        }
    
        public int AssuntoID { get; set; }
        public string Assunto1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabAbtra> TabAbtra { get; set; }
    }
}
