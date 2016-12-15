using System;
using System.Net;
using HvA_VLO_APP.Auth;
using HvA_VLO_APP.Net;
using Xamarin.Forms;

namespace HvA_VLO_APP.Views
{
    internal class LoginPage : ContentPage
    {
        private readonly Client _client;

        private readonly Switch _saveCredentialsSwitch;

        private readonly Entry _usernameEntry, _passwordEntry;

        public LoginPage(Client client)
        {
            _client = client;

            // User Interface
            _saveCredentialsSwitch = new Switch();

            _usernameEntry = new Entry
            {
                Placeholder = "Username",
            };

            _passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
            };

            var loginButton = new Button
            {
                Text = "Login"
            };

            loginButton.Clicked += LoginButtonOnClicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label
                    {
                        Text = "HBO-ICT VLO",
                        FontSize = 20
                    },
                    new Label
                    {
                        Text = "Username"
                    },
                    _usernameEntry,
                    new Label
                    {
                        Text = "Password"
                    },
                    _passwordEntry,
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            _saveCredentialsSwitch,
                            new Label
                            {
                                VerticalTextAlignment = TextAlignment.Center,
                                Text = "Deze gegevens onthouden"
                            }
                        }
                    },
                    loginButton
                }
            };
        }

        private async void LoginButtonOnClicked(object sender, EventArgs eventArgs)
        {
            var username = _usernameEntry.Text;
            var password = _passwordEntry.Text;

            var signIn = await _client.LoginAsync(username, password);
            if (!signIn) return;

            var credentialsManager = DependencyService.Get<CredentialsManagerBase>();

            if (_saveCredentialsSwitch.IsToggled)
            {
                credentialsManager.StoreAccount(username, password, _client.Cookies);
            }

            Navigation.InsertPageBefore(new DashboardPage(_client), this);
            await Navigation.PopAsync();
        }
    }
}
