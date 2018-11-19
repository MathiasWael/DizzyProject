using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        MasterPage RootPage { get => Application.Current.MainPage as MasterPage; }
        List<Model.MenuItem> menuItems;
		public MenuPage ()
		{
			InitializeComponent ();

            menuItems = new List<Model.MenuItem>
            {
                new Model.MenuItem {Type = Model.MenuItem.ItemType.DizzyRegister, Title = "Register Dizziness"},
                new Model.MenuItem {Type = Model.MenuItem.ItemType.StepCounter, Title = "Step Counter"},
                new Model.MenuItem {Type = Model.MenuItem.ItemType.Journal, Title = "Journal"},
                new Model.MenuItem {Type = Model.MenuItem.ItemType.Exercises, Title = "Exercises"},
                new Model.MenuItem {Type = Model.MenuItem.ItemType.Statistics, Title = "Statistics"},
                new Model.MenuItem {Type = Model.MenuItem.ItemType.Logout, Title = "Logout"},
            };

            ListView menuList = new ListView()
            {
                HasUnevenRows = true,
                ItemsSource = menuItems,
            };

            DataTemplate dataTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid();
                grid.SetBinding(BindingContextProperty, "Source");
                Label title = new Label();
                title.SetBinding(Label.TextProperty, "Title");
                grid.Children.Add(title);

                return new ViewCell { View =  grid};
            });

            menuList.ItemTemplate = dataTemplate;

            menuList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                int id = (int)((Model.MenuItem)e.SelectedItem).Type;
                await RootPage.NavigateFromMenu(id);
            };

            Content = new StackLayout
            {
                Children = { menuList },
                Orientation = StackOrientation.Vertical
            };
        }
	}
}