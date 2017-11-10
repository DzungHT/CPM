namespace CPM_Website.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Application
    {
        public Application()
        {
            Menus = new HashSet<Menu>();
            Resources = new HashSet<Resource>();
            DomainTypes = new HashSet<DomainType>();
        }

        public int ApplicationID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<DomainType> DomainTypes { get; set; }
    }
}
