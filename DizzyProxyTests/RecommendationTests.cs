using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class RecommendationTests
    {
        public RecommendationResource RecommendationResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            RecommendationResource = new RecommendationResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllRecommendations_Patient_Succesful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<Recommendation> recommendations = RecommendationResource.GetAllRecommendations(Resource.UserId);

            // Assert
            Assert.AreEqual(2, recommendations.Count);
        }

        [TestMethod]
        public void GetAllRecommendations_Physiotherapist_Succesful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<Recommendation> recommendations = RecommendationResource.GetAllRecommendations(2);

            // Assert
            Assert.AreEqual(1, recommendations.Count);
        }
    }
}