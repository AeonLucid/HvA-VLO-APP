using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace HvA_VLO_APP.Droid
{
    [Activity(Label = "HvA_VLO_APP", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}