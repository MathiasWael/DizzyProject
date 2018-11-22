using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.Model
{
    public enum Type { Custom, Favorite, Recommended, Normal }
    public class ExerciseViewModel
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Recommendation Recommendation { get; set; }

        public Type Type { get; set; }

        public bool isRecommend {
            get {
                if (Type == Type.Recommended)
                    return true;
                else
                    return false;
            } }

        public string Logo
        {
            get
            {
                switch (Type)
                {
                    case Type.Custom:
                        return "wrench.png";
                    case Type.Favorite:
                        return "star.png";
                    case Type.Recommended:
                        return "thumbsup.png";
                    case Type.Normal:
                        return "emptystar.png";
                    default:
                        return "";
                }
            }
        }

        public int LogoSize
        {
            get
            {
                switch (Type)
                {
                    case Type.Custom:
                        return 25;
                    case Type.Favorite:
                        return 35;
                    case Type.Recommended:
                        return 25;
                    case Type.Normal:
                        return 35;
                    default:
                        return 0;
                }
            }
        }
    }
}
