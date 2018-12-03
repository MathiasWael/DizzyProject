using DizzyProject.ViewModels;
using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class JournalController
    {
        public async Task<List<JournalViewModel>> GetAllJournalItemsAsync(DateTime dateTime)
        {
            List<Dizziness> dizzinesses = await new DizzinessController().GetAllDizzinessesByDateAsync(dateTime);
            List<JournalEntry> journalEntries = await new JournalEntryController().GetAllJournalEntriesByDateAsync(dateTime);

            List<JournalViewModel> journalViewModels = new List<JournalViewModel>();
            journalViewModels.AddRange(await DizzinessJournalViewModelConverter(dizzinesses));
            journalViewModels.AddRange(journalEntries.ConvertAll(new Converter<JournalEntry, JournalViewModel>(JournalEntryJournalViewModelConverter)));

            journalViewModels.Sort((x, y) => x.Created.CompareTo(y.Created));
            return journalViewModels;
        }

        private async Task<List<JournalViewModel>> DizzinessJournalViewModelConverter(List<Dizziness> dizzinesses)
        {
            List<JournalViewModel> temp = new List<JournalViewModel>();
            foreach (Dizziness dizziness in dizzinesses)
            {
                if (dizziness.ExerciseId != null)
                {
                    ExerciseController exerciseController = new ExerciseController();
                    JournalViewModel journalViewModel = new JournalViewModel(dizziness);
                    Exercise exercise = await exerciseController.GetExerciseByIdAsync((long)dizziness.ExerciseId);
                    journalViewModel.ExerciseViewModel = await exerciseController.GetExerciseViewModelByIdAsync((long)dizziness.ExerciseId);
                    journalViewModel.ExerciseName = exercise.Name;
                    temp.Add(journalViewModel);
                }
                else
                {
                    temp.Add(new JournalViewModel(dizziness));
                }
            }
            return temp;
        }

        private JournalViewModel JournalEntryJournalViewModelConverter(JournalEntry journalEntry)
        {
            return new JournalViewModel(journalEntry);
        }
    }
}
