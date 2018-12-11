using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.ViewModels;
using DizzyProxy.Resources;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MasterPage RootPage { get => Application.Current.MainPage as MasterPage; }
        List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            if (Resource.Token.UserType == DizzyProxy.Models.UserType.Patient)
            {
                menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem {Type = HomeMenuItemType.DizzyRegister, Title = "Register Dizziness"},
                    new HomeMenuItem {Type = HomeMenuItemType.StepCounter, Title = "Step Counter"},
                    new HomeMenuItem {Type = HomeMenuItemType.Journal, Title = "Journal"},
                    new HomeMenuItem {Type = HomeMenuItemType.Exercises, Title = "Exercises"},
                    new HomeMenuItem {Type = HomeMenuItemType.Statistics, Title = "Statistics"},
                    new HomeMenuItem {Type = HomeMenuItemType.EditProfile, Title = "Edit Profile"},
                    new HomeMenuItem {Type = HomeMenuItemType.Logout, Title = "Logout"},
                };
            }
            else if(Resource.Token.UserType == DizzyProxy.Models.UserType.Physiotherapist)
            {
                menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem {Type = HomeMenuItemType.Patients, Title = "Patients"}
                };
            }

            ListViewMenu.ItemsSource = menuItems;
            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += ListViewMenu_ItemSelected;
        }

        private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            HomeMenuItemType id = ((HomeMenuItem)e.SelectedItem).Type;
            RootPage.NavigateFromMenu(id);
        }
    }
}