using System;
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
            var signIn = await _client.LoginAsync(_usernameEntry.Text, _passwordEntry.Text);
            if (signIn)
            {
                if (_saveCredentialsSwitch.IsToggled)
                {
                    // TODO: Figure out how to securely store credentials.
                }
            }

//            Console.WriteLine($"{_usernameEntry.Text}\n{_passwordEntry.Text}\n{_saveCredentialsSwitch.IsToggled}");
//            Navigation.InsertPageBefore(new ContentPage(), this);
//            await Navigation.PopAsync();
        }
    }
}
