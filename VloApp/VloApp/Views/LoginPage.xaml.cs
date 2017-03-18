using System;
using VloApp.Services;
using VloApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VloApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
	    private readonly VloClient _client;
	    private readonly CredentialsManagerBase _credentialsManager;

	    public LoginPageModel ViewModel;

		public LoginPage(VloClient client)
		{
		    _client = client;
		    _credentialsManager = DependencyService.Get<CredentialsManagerBase>();

		    InitializeComponent();
		    BindingContext = ViewModel = new LoginPageModel();
		}
        
        private async void Login_OnClicked(object sender, EventArgs e)
	    {
            var signIn = await _client.LoginAsync(ViewModel.Username, ViewModel.Password);
            if (!signIn) return;
            
            if (ViewModel.SaveCredentials)
            {
                _credentialsManager.StoreAccount(ViewModel.Username, ViewModel.Password, _client.Cookies);
            }

	        Application.Current.MainPage = App.RootPage;
	    }
	}
}
