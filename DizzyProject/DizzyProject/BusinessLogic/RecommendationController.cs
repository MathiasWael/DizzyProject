using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class RecommendationController
    {
        private RecommendationResource _recommendationResource;

        public RecommendationController()
        {
            _recommendationResource = new RecommendationResource();
        }
    }
}