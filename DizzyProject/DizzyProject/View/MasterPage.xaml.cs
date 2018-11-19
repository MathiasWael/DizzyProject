using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.Model;

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

            MenuPages.Add((int)ItemType.DizzyRegister, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)ItemType.DizzyRegister:
                        MenuPages.Add(id, new NavigationPage(new DizzyRegisterPage()));
                        break;
                    case (int)ItemType.StepCounter:
                        MenuPages.Add(id, new NavigationPage(new StepCounterPage()));
                        break;
                    case (int)ItemType.Exercises:
                        MenuPages.Add(id, new NavigationPage(new ExercisesPage()));
                        break;
                    case (int)ItemType.Journal:
                        MenuPages.Add(id, new NavigationPage(new JournalPage()));
                        break;
                    case (int)ItemType.Logout:
                        
                        break;
                    case (int)ItemType.Statistics:
                        MenuPages.Add(id, new NavigationPage(new StatisticsPage()));
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