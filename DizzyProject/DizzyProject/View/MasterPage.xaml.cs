using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.ViewModels;
using DizzyProxy.Resources;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        Dictionary<HomeMenuItemType, NavigationPage> MenuPages = new Dictionary<HomeMenuItemType, NavigationPage>();

        public MasterPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            if(Resource.Token.UserType == DizzyProxy.Models.UserType.Patient)
            {
                Detail = new NavigationPage(new DizzyRegisterPage());
                MenuPages.Add(HomeMenuItemType.DizzyRegister, (NavigationPage)Detail);
            }
            else if(Resource.Token.UserType == DizzyProxy.Models.UserType.Physiotherapist)
            {
                Detail = new NavigationPage(new PatientsPage());
                MenuPages.Add(HomeMenuItemType.Patients, (NavigationPage)Detail);
            }
        }

        public void NavigateFromMenu(HomeMenuItemType id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case HomeMenuItemType.DizzyRegister: MenuPages.Add(id, new NavigationPage(new DizzyRegisterPage())); break;
                    case HomeMenuItemType.StepCounter: MenuPages.Add(id, new NavigationPage(new StepCounterPage())); break;
                    case HomeMenuItemType.Exercises: MenuPages.Add(id, new NavigationPage(new ExercisesPage())); break;
                    case HomeMenuItemType.Journal: MenuPages.Add(id, new NavigationPage(new JournalPage())); break;
                    case HomeMenuItemType.Statistics: MenuPages.Add(id, new NavigationPage(new StatisticsPage())); break;
                    case HomeMenuItemType.EditProfile: MenuPages.Add(id, new NavigationPage(new EditProfilePage())); break;
                    case HomeMenuItemType.Logout: break;
                    case HomeMenuItemType.Patients: MenuPages.Add(id, new NavigationPage(new PatientsPage())); break;
                }
            }

            NavigationPage newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                IsPresented = false;
            }
        }
    }
}