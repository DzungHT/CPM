namespace CMP_Servive.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OAuthRefreshToken")]
    public partial class OAuthRefreshToken
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OAuthRefreshToken()
        {
            OAuthAccessTokens = new HashSet<OAuthAccessToken>();
        }

        [Key]
        [StringLength(100)]
        public string TokenId { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        [StringLength(50)]
        public string Authentication { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OAuthAccessToken> OAuthAccessTokens { get; set; }
    }
}
