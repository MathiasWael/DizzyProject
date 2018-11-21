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
        public Patient CreateLogin(string email, string password)
            => CreateLoginAsync(email, password).Result;

        public async Task<Patient> CreateLoginAsync(string email, string password)
        {
            Request request = new Request(Method.POST, "logins");
            request.Body["email"] = email;
            request.Body["password"] = password;
            JsonWebToken token = await ExecuteAsync<JsonWebToken>(request);
            Token = token.Token;
            return await new PatientResource().GetPatientAsync(token.Subject);
        }
    }
}
