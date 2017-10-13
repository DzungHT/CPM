using CMP_Servive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Providers.Authentication
{
    public interface IServiceToken
    {
        TokenUserIdentity crateUser(TokenUserIdentity obj);

        TokenUserIdentity login(TokenUserIdentity obj);

        bool validateToken(string tokenId);

        TokenInfo getToken(TokenUserIdentity obj);

        TokenInfo refreshToken(TokenUserIdentity obj);

        bool Kill(string tokenId);
    }
}