using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class LoginResource : Resource
    {
        public User CreateLogin(string email, string password)
            => CreateLoginAsync(email, password).Result;

        public async Task<User> CreateLoginAsync(string email, string password)
        {
            Request request = new Request(Method.POST, "logins");
            request.Body["email"] = email;
            request.Body["password"] = password;
            JsonWebToken token = await ExecuteAsync<JsonWebToken>(request);
            Token = token.Token;

            switch (token.UserType)
            {
                case UserType.Patient: return await new PatientResource().GetPatientAsync(token.Subject);
                case UserType.Physiotherapist: return await new PhysiotherapistResource().GetPhysiotherapistAsync(token.Subject);
            }
        }
    }
}
