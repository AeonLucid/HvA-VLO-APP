using System;
using Xamarin.Forms;

namespace HvA_VLO_APP.Views
{
    internal class LoginPage : ContentPage
    {

        private readonly Switch _saveCredentialsSwitch;

        private readonly Button _loginButton;

        private readonly Entry _usernameEntry, _passwordEntry;

        public LoginPage()
        {
            _saveCredentialsSwitch = new Switch();

            _loginButton = new Button
            {
                Text = "Login"
            };

            _loginButton.Clicked += LoginButtonOnClicked;

            _usernameEntry = new Entry
            {
                Placeholder = "Username",
            };

            _passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
            };

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
                    _loginButton
                }
            };
        }

        private async void LoginButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"{_usernameEntry.Text}\n{_passwordEntry.Text}\n{_saveCredentialsSwitch.IsToggled}");

            //            Navigation.InsertPageBefore(new ContentPage(), this);
            //            await Navigation.PopAsync();
        }
    }
}
