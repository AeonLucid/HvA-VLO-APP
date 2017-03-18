using VloApp.Services;
using VloApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VloApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardPage : ContentPage
	{
	    public DashboardPageModel ViewModel;

		public DashboardPage(VloClient client)
		{
			InitializeComponent();
		    BindingContext = ViewModel = new DashboardPageModel(client);
		}
	}
}
