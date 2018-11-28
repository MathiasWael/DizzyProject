using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class LoginController
    {
        private LoginResource _logins;

        public LoginController()
        {
            _logins = new LoginResource();
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            return await _logins.CreateLoginAsync(email, password);
        }
    }
}
