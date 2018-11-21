using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public enum Type { Custom, Favorite, Recommended, Normal}
    public class Exercise
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Custom { get; set; }

        public Type Type { get; set; }
        public string Logo
        {
            get
            {
                switch (Type)
                {
                    case Type.Custom:
                        return "custom.PNG";
                    case Type.Favorite:
                        return "star.png";
                    case Type.Recommended:
                        return "recommended.PNG";
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
