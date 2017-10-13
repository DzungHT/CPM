using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Models
{
    public class TokenUserIdentity
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public string listRole { get; set; }
        public string ipAccess { get; set; }
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string grantType { get; set; }
    }

    public class TokenInfo
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public string accessTokenValidity { get; set; }
    }
}