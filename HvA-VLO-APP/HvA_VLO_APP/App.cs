using System;
using HvA_VLO_APP.Net;
using HvA_VLO_APP.Views;
using Xamarin.Forms;

namespace HvA_VLO_APP
{
    public class App : Application
    {
        public App()
        {
            var client = new Client();

            // TODO: Some logic to retrieve old cookies.

            MainPage = new NavigationPage(new LoginPage(client));
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
