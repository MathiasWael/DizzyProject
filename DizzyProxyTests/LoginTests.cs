using Microsoft.VisualStudio.TestTools.UnitTesting;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class LoginTests
    {
        public LoginResource LoginResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            LoginResource = new LoginResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void CreateLogin_Patient_Succesful()
        {
            // Arrange
            string email = "annalarsen@hotmail.com";
            string password = "Password123";

            // Act
            User user = LoginResource.CreateLogin(email, password);

            // Assert
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(typeof(Patient), user.GetType());
        }

        [TestMethod]
        public void CreateLogin_Physiotherapist_Succesful()
        {
            // Arrange
            string email = "hanspetersen@gmail.com";
            string password = "Password123";

            // Act
            User user = LoginResource.CreateLogin(email, password);

            // Assert
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(typeof(Physiotherapist), user.GetType());
        }
    }
}