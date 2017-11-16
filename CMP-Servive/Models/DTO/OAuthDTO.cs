using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;

namespace CMP_Servive.Models.DTO
{
    public class OAuthDetailDTO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string IpAccess { get; set; }

        public string Role { get; set; }

    }

    public class OAuthClientDetailDTO
    {
        public string ClientId { get; set; }

        public string ResourceIds { get; set; }

        public string ClientSecret { get; set; }

        public string Scope { get; set; }

        public string GrantTypes { get; set; }

        public string WebServerRedirectUri { get; set; }

        public string Authorities { get; set; }

        public int AccessTokenValidity { get; set; }

        public int RefreshTokenValidity { get; set; }

    }

    public class OAuthAccessTokenDTO
    {
        public string TokenId { get; set; }

        public string Token { get; set; }

        public string AuthenticationId { get; set; }

        public string UserName { get; set; }

        public string ClientId { get; set; }

        public string Authentication { get; set; }

        public string RefreshToken { get; set; }

    }

    public class OAuthRefreshTokenDTO
    {
        public string TokenId { get; set; }

        public string Token { get; set; }

        public string Authentication { get; set; }

    }

}