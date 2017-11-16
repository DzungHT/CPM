namespace CPM_Website.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            Menus = new HashSet<Menu>();
            Resources = new HashSet<Resource>();
            DomainTypes = new HashSet<DomainType>();
        }

        public int ApplicationID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<DomainType> DomainTypes { get; set; }
    }
}
