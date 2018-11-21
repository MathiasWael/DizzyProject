using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DizzyProxy.Models
{
    public enum Type { Custom, Favorite, Recommended, Normal}
    public class Exercise
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("author_id")]
        public long AuthorId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        public Type Type { get; set; }

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
