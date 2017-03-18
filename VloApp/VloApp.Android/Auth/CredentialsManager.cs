using VloApp.Services;
using Xamarin.Auth;
using Xamarin.Forms;

namespace VloApp.Droid.Auth
{
    internal class CredentialsManager : CredentialsManagerBase
    {
        protected override AccountStore GetAccountStore()
        {
            return AccountStore.Create(Forms.Context);
        }
    }
}