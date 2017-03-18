using Android.App;
using Android.Content.PM;
using Android.OS;
using VloApp.Droid.Auth;
using Xamarin.Forms;

namespace VloApp.Droid
{
    [Activity(Label = "VloApp.Android", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            DependencyService.Register<CredentialsManager>();

            LoadApplication(new App());
        }
    }
}