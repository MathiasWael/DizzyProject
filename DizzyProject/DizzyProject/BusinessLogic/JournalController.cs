﻿using DizzyProject.ViewModels;
using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class JournalController
    {
        public async Task<List<JournalViewModel>> getAllJournalItemsAsync(DateTime dateTime)
        {
            string date = dateTime.Year.ToString() + "-" + dateTime.Month + "-" + (dateTime.Day + 1);
            List<Dizziness> dizzinesses = await new DizzinessController().getAllDizzinessesByDateAsync(date);
            List<JournalEntry> journalEntries = await new JournalEntryController().getAllJournalEntriesByDateAsync(date);

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
                    JournalViewModel journalViewModel = new JournalViewModel(dizziness);
                    Exercise exercise = await new ExerciseController().GetExerciseByIdAsync((long)dizziness.ExerciseId);
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
