using System;
using DizzyProxy.Models;

namespace DizzyProject.ViewModels
{
    public enum ExerciseType { Custom, Recommended, Favorite, Normal }
    public class ExerciseViewModel
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Recommendation Recommendation { get; set; }
        public ExerciseType Type { get; set; }

        public bool IsRecommended => Type == ExerciseType.Recommended;

        public string Logo
        {
            get
            {
                switch (Type)
                {
                    case ExerciseType.Custom: return "wrench.png";
                    case ExerciseType.Favorite: return "star.png";
                    case ExerciseType.Recommended: return "thumbsup.png";
                    case ExerciseType.Normal: return "emptystar.png";
                    default: return "";
                }
            }
        }

        public int LogoSize
        {
            get
            {
                switch (Type)
                {
                    case ExerciseType.Custom: return 25;
                    case ExerciseType.Favorite: return 35;
                    case ExerciseType.Recommended: return 25;
                    case ExerciseType.Normal: return 35;
                    default: return 0;
                }
            }
        }

        public ExerciseViewModel() { }
        public ExerciseViewModel (Exercise exercise)
        {
            Id = exercise.Id;
            AuthorId = exercise.AuthorId;
            Name = exercise.Name;
            Description = exercise.Description;
            Created = exercise.Created;
            Updated = exercise.Updated;
        }
    }
}