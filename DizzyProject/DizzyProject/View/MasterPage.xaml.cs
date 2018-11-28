using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.ViewModels;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MasterPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)HomeMenuItemType.DizzyRegister, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)HomeMenuItemType.DizzyRegister:
                        MenuPages.Add(id, new NavigationPage(new DizzyRegisterPage()));
                        break;
                    case (int)HomeMenuItemType.StepCounter:
                        MenuPages.Add(id, new NavigationPage(new StepCounterPage()));
                        break;
                    case (int)HomeMenuItemType.Exercises:
                        MenuPages.Add(id, new NavigationPage(new ExercisesPage()));
                        break;
                    case (int)HomeMenuItemType.Journal:
                        MenuPages.Add(id, new NavigationPage(new JournalPage()));
                        break;
                    case (int)HomeMenuItemType.Logout:                       
                        break;
                    case (int)HomeMenuItemType.Statistics:
                        MenuPages.Add(id, new NavigationPage(new StatisticsPage()));
                        break;
                    case (int)HomeMenuItemType.EditProfile:
                        MenuPages.Add(id, new NavigationPage(new EditProfilePage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}