using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProject.ViewModels;
using DizzyProxy.Models;

namespace DizzyProject.BusinessLogic
{
    public class JournalController
    {
        private DizzinessController _dizzinessController;
        private JournalEntryController _journalEntryController;
        private ExerciseController _exerciseController;

        public JournalController()
        {
            _dizzinessController = new DizzinessController();
            _journalEntryController = new JournalEntryController();
            _exerciseController = new ExerciseController();
        }

        public async Task<List<JournalViewModel>> GetAllJournalItemsAsync(DateTime dateTime)
        {
            List<Dizziness> dizzinesses = await _dizzinessController.GetAllDizzinessesByDateAsync(dateTime);
            List<JournalEntry> journalEntries = await _journalEntryController.GetAllJournalEntriesByDateAsync(dateTime);

            List<JournalViewModel> viewModels = new List<JournalViewModel>();
            viewModels.AddRange(await DizzinessJournalViewModelConverter(dizzinesses));
            viewModels.AddRange(journalEntries.ConvertAll(new Converter<JournalEntry, JournalViewModel>(JournalEntryJournalViewModelConverter)));
            viewModels.Sort((a, b) => a.Created.CompareTo(b.Created));

            return viewModels;
        }

        private async Task<List<JournalViewModel>> DizzinessJournalViewModelConverter(List<Dizziness> dizzinesses)
        {
            List<JournalViewModel> viewModels = new List<JournalViewModel>();

            foreach (Dizziness dizziness in dizzinesses)
            {
                if (dizziness.ExerciseId != null)
                {
                    JournalViewModel journalViewModel = new JournalViewModel(dizziness);
                    Exercise exercise = await _exerciseController.GetExerciseAsync((long)dizziness.ExerciseId);
                    journalViewModel.ExerciseViewModel = await _exerciseController.GetExerciseViewModelAsync((long)dizziness.ExerciseId);
                    journalViewModel.ExerciseName = exercise.Name;
                    viewModels.Add(journalViewModel);
                }
                else
                {
                    viewModels.Add(new JournalViewModel(dizziness));
                }
            }

            return viewModels;
        }

        private JournalViewModel JournalEntryJournalViewModelConverter(JournalEntry journalEntry)
        {
            return new JournalViewModel(journalEntry);
        }

        public async Task<List<JournalViewModel>> GetAllJournalItemsByIdAsync(DateTime dateTime, long patientId)
        {
            List<Dizziness> dizzinesses = await _dizzinessController.GetAllDizzinessesByDateAsync(dateTime);
            List<JournalEntry> journalEntries = await _journalEntryController.GetAllJournalEntriesByDateAsync(dateTime);

            List<JournalViewModel> viewModels = new List<JournalViewModel>();
            viewModels.AddRange(await DizzinessJournalViewModelConverter(dizzinesses));
            viewModels.AddRange(journalEntries.ConvertAll(new Converter<JournalEntry, JournalViewModel>(JournalEntryJournalViewModelConverter)));
            viewModels.Sort((a, b) => a.Created.CompareTo(b.Created));

            return viewModels;
        }
    }
}