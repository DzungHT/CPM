namespace CMP_Servive.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OAuthAccessToken")]
    public partial class OAuthAccessToken
    {
        [Key]
        [StringLength(50)]
        public string TokenId { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        [StringLength(50)]
        public string AuthenticationId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientId { get; set; }

        [StringLength(50)]
        public string Authentication { get; set; }

        [Required]
        [StringLength(100)]
        public string RefreshToken { get; set; }

        public virtual OAuthRefreshToken OAuthRefreshToken { get; set; }
    }
}
