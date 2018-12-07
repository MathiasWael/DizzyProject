namespace DizzyProject.ViewModels
{
    public enum HomeMenuItemType
    {
        DizzyRegister,
        StepCounter,
        Exercises,
        Journal,
        Logout,
        Statistics,
        EditProfile
    }

    public class HomeMenuItem
    {
        public HomeMenuItemType Type { get; set; }
        public string Title { get; set; }
    }
}