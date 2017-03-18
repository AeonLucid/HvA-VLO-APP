using VloApp.Services;

namespace VloApp.ViewModels
{
    public class DashboardPageModel
    {
        public DashboardPageModel(VloClient client)
        {
            Client = client;
        }

        public VloClient Client { get; private set; }
    }
}
