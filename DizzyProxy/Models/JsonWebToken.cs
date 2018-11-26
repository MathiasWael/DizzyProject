using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace DizzyProxy.Models
{
    public class JsonWebToken
    {
        [JsonProperty("token")]
        public string Encoded { get; set; }

        public long Subject
        {
            get
            {
                JwtSecurityToken token = new JwtSecurityToken(Encoded);
                return Convert.ToInt64(token.Subject);
            }
        }

        public UserType UserType
        {
            get
            {
                JwtSecurityToken token = new JwtSecurityToken(Encoded);
                return (UserType)Enum.Parse(typeof(UserType), token.Payload["type"].ToString(), true);
            }
        }
    }
}