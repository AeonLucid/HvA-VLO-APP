using Android.App;
using Android.Content.PM;
using Android.OS;
using HvA_VLO_APP.Droid.Auth;
using Xamarin.Forms;

namespace HvA_VLO_APP.Droid
{
    [Activity(Label = "HvA VLO", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            DependencyService.Register<CredentialsManager>();
            
            LoadApplication(new App());
        }
    }
}

