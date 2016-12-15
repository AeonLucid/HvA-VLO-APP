using HvA_VLO_APP.Net;
using Xamarin.Forms;

namespace HvA_VLO_APP.Views
{
    internal class DashboardPage : ContentPage
    {
        public DashboardPage(Client client)
        {
            Content = new Label
            {
                Text = $"Hello, {client.Username}"
            };
        }

    }
}
