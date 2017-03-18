using System.Windows.Input;
using Xamarin.Forms;

namespace VloApp.ViewModels.Navigation
{
    public class MenuPageModel
    {
        public ICommand DashboardCommand { get; }

        public MenuPageModel()
        {
            DashboardCommand = new Command(OpenDashboard);
        }

        private static void OpenDashboard()
        {
            App.NavigationPage.Navigation.PopToRootAsync();
            App.MenuIsPresented = false;
        }
    }
}
