namespace CMP_Servive.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OAuthClientDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OAuthClientDetail()
        {
            OAuthDetails = new HashSet<OAuthDetail>();
        }

        [Key]
        [StringLength(50)]
        public string ClientId { get; set; }

        [StringLength(50)]
        public string ResourceIds { get; set; }

        [StringLength(50)]
        public string ClientSecret { get; set; }

        [StringLength(50)]
        public string Scope { get; set; }

        [StringLength(50)]
        public string GrantTypes { get; set; }

        [StringLength(50)]
        public string WebServerRedirectUri { get; set; }

        [StringLength(50)]
        public string Authorities { get; set; }

        public int? AccessTokenValidity { get; set; }

        public int? RefreshTokenValidity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OAuthDetail> OAuthDetails { get; set; }
    }
}
