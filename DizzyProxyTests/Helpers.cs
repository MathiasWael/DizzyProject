using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxyTests
{
    public class Helpers
    {
        public static void SetBaseAddress()
        {
            Resource.BaseAddress = "http://localhost:4000/v1/";
        }

        public static void Login()
        {
            LoginResource loginResource = new LoginResource();
            loginResource.CreateLogin("annalarsen@hotmail.com", "Password123");
        }

        public static void Wipe()
        {
            WipeResource wipeResource = new WipeResource();
            wipeResource.CreateWipe();
        }
    }
}
