namespace CMP_Servive.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OAuthRefreshToken")]
    public partial class OAuthRefreshToken
    {
        [Key]
        [StringLength(50)]
        public string TokenId { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        [StringLength(50)]
        public string Authentication { get; set; }

        public virtual OAuthAccessToken OAuthAccessToken { get; set; }
    }
}
