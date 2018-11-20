using RestSharp.Deserializers;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace DizzyProxy.Models
{
    public class JsonWebToken
    {
        [DeserializeAs(Name = "token")]
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