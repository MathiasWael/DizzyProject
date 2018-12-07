using System;
using DizzyProxy.Models;

namespace DizzyProject.ViewModels
{
    public enum JournalItemType
    {
        JournalEntry, DizzyRegister, ExerciseFeedback
    }

    public class JournalViewModel
    {
        public JournalItemType Type { get; set; }
        public long Id { get; set; }
        public long PatientId { get; set; }
        public long? ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int? Level { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ExerciseViewModel ExerciseViewModel { get; set; }

        public string CreatedTimeString => $"{Created.Hour.ToString()}:{Created.Minute.ToString()}";
        public bool IsExercise => Type == JournalItemType.ExerciseFeedback;

        public string Logo
        {
            get
            {
                switch (Level)
                {
                    case 0: return "dizzy0.png";
                    case 1: return "dizzy1.png";
                    case 2: return "dizzy2.png";
                    case 3: return "dizzy3.png";
                    case 4: return "dizzy4.png";
                    case 5: return "dizzy5.png";
                    case 6: return "dizzy6.png";
                    case 7: return "dizzy7.png";
                    case 8: return "dizzy8.png";
                    case 9: return "dizzy9.png";
                    case 10: return "dizzy10.png";
                    default: return "";
                }
            }
        }

        public JournalViewModel(JournalEntry journalEntry)
        {
            Id = journalEntry.Id;
            PatientId = journalEntry.PatientId;
            Note = journalEntry.Note;
            Created = journalEntry.Created;
            Updated = journalEntry.Updated;
            Type = JournalItemType.JournalEntry;
        }

        public JournalViewModel(Dizziness dizziness)
        {
            Id = dizziness.Id;
            PatientId = dizziness.PatientId;
            Note = dizziness.Note;
            Created = dizziness.Created;
            Updated = dizziness.Updated;
            Level = dizziness.Level;

            if (dizziness.ExerciseId != null)
            {
                ExerciseId = dizziness.ExerciseId;
                Type = JournalItemType.ExerciseFeedback;
            }
            else
            {
                Type = JournalItemType.DizzyRegister;
            }
        }
    }
}