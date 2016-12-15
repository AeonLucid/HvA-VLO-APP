using System;
using System.Net;
using HvA_VLO_APP.Auth;
using HvA_VLO_APP.Net;
using HvA_VLO_APP.Views;
using Xamarin.Forms;

namespace HvA_VLO_APP
{
    public class App : Application
    {
        public App()
        {
            // TODO: Move to onStart() and show a loading screen as default page.

            var credentialsManager = DependencyService.Get<CredentialsManagerBase>();
            var isAuthenticated = false;
            Client client = null;

            // First try, cookies.
            if (credentialsManager.Cookies != null)
            {
                client = new Client(credentialsManager.Username, credentialsManager.Cookies);

                if (client.IsLoggedIn())
                {
                    isAuthenticated = true;
                }
            }

            // If cookies failed;
            if (!isAuthenticated)
            {
                // create a new client.
                client = new Client();

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

            // Check if authenticated.
            if (isAuthenticated)
            {
                // Show dashboard
                MainPage = new NavigationPage(new DashboardPage(client));
            }
            else
            {
                // Show login screen 
                MainPage = new NavigationPage(new LoginPage(client));
            }
        }

        protected override void OnStart()
        {
            Console.WriteLine("################### ONSTART");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("################### ONSLEEP");
        }

        protected override void OnResume()
        {
            Console.WriteLine("################### ONRESUME");
        }
    }
}
