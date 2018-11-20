using System;
using System.IdentityModel.Tokens.Jwt;

namespace DizzyProxy.Models
{
    public class JsonWebToken
    {
        public string Token { get; set; }

        public long UserId
        {
            get
            {
                JwtSecurityToken token = new JwtSecurityToken(Token);
                return Convert.ToInt64(token.Id);
            }
        }
    }
}