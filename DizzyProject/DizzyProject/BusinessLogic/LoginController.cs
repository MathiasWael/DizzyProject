using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class LoginController
    {
        private LoginResource _loginResource;

        public LoginController()
        {
            _loginResource = new LoginResource();
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            return await _loginResource.CreateLoginAsync(email, password);
        }
    }
}