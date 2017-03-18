using VloApp.Services;
using VloApp.Views;
using VloApp.Views.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VloApp
{
	public partial class App : Application
	{

        public App()
		{
			InitializeComponent();

            var credentialsManager = DependencyService.Get<CredentialsManagerBase>();
            var isAuthenticated = false;

            // First try, cookies.
            if (credentialsManager.Cookies != null)
            {
                Client = new VloClient(credentialsManager.Username, credentialsManager.Cookies);

                if (Client.IsLoggedIn())
                {
                    isAuthenticated = true;
                }
            }

            // If cookies failed;
            if (!isAuthenticated)
            {
                // create a new client.
                Client = new VloClient();

                // Second try, reauthentication
                var username = credentialsManager.Username;
                var password = credentialsManager.Password;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    if (Client.Login(username, password))
                    {
                        isAuthenticated = true;

                        credentialsManager.StoreAccount(username, password, Client.Cookies);
                    }
                    else
                    {
                        // Credentials were invalid, so removing stored credentials.
                        credentialsManager.DeleteAccount();
                    }
                }
            }

            // Set properties
		    NavigationPage = new NavigationPage(new DashboardPage(Client));
		    RootPage = new RootPage
		    {
		        Master = new MenuPage(),
		        Detail = NavigationPage
		    };

            // Set the main page
            if (!isAuthenticated)
            {
                Current.MainPage = new LoginPage(Client);
            }
            else
            {
                Current.MainPage = RootPage;
            }
        }

        private VloClient Client { get; }

        public static RootPage RootPage { get; private set; }

	    public static NavigationPage NavigationPage { get; private set; }

        public static bool MenuIsPresented
        {
            get
            {
                return RootPage.IsPresented;
            }
            set
            {
                RootPage.IsPresented = value;
            }
        }
	}
}
