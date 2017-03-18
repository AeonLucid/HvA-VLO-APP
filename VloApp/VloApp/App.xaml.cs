using VloApp.Services;
using VloApp.Views;

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
		    VloClient client = null;

            // First try, cookies.
            if (credentialsManager.Cookies != null)
            {
                client = new VloClient(credentialsManager.Username, credentialsManager.Cookies);

                if (client.IsLoggedIn())
                {
                    isAuthenticated = true;
                }
            }

            // If cookies failed;
            if (!isAuthenticated)
            {
                // create a new client.
                client = new VloClient();

                // Second try, reauthentication
                var username = credentialsManager.Username;
                var password = credentialsManager.Password;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    if (client.Login(username, password))
                    {
                        isAuthenticated = true;

                        credentialsManager.StoreAccount(username, password, client.Cookies);
                    }
                    else
                    {
                        // Credentials were invalid, so removing stored credentials.
                        credentialsManager.DeleteAccount();
                    }
                }
            }

            // Set main page
            Current.MainPage = isAuthenticated ? 
                new NavigationPage(new DashboardPage(client)) : 
                new NavigationPage(new LoginPage(client, credentialsManager));
        }
	}
}
