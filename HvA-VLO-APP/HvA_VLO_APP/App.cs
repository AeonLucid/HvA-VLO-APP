using System;
using HvA_VLO_APP.Views;
using Xamarin.Forms;

namespace HvA_VLO_APP
{
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new LoginPage());
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
