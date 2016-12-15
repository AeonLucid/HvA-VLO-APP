using HvA_VLO_APP.Auth;
using Xamarin.Auth;
using Xamarin.Forms;

namespace HvA_VLO_APP.Droid.Auth
{
    internal class CredentialsManager : CredentialsManagerBase
    {
        protected override AccountStore GetAccountStore()
        {
            return AccountStore.Create(Forms.Context);
        }
    }
}