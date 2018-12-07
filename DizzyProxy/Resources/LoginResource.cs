using DizzyProxy.Models;
using System;
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
            Token = await ExecuteAsync<JsonWebToken>(request);

            switch (Token.UserType)
            {
                case UserType.Patient: return await new PatientResource().GetPatientAsync(Token.Subject);
                case UserType.Physiotherapist: return await new PhysiotherapistResource().GetPhysiotherapistAsync(Token.Subject);
                default: throw new ApplicationException("Unknown user type.");
            }
        }
    }
}