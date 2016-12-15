using System.Linq;
using System.Net;
using Xamarin.Auth;

namespace HvA_VLO_APP.Auth
{
    internal abstract class CredentialsManagerBase
    {

        public string Username
        {
            get
            {
                var account = GetAccountStore().FindAccountsForService(Constants.ServiceId).FirstOrDefault();

                return account?.Username;
            }
        }

        public string Password
        {
            get
            {
                var account = GetAccountStore().FindAccountsForService(Constants.ServiceId).FirstOrDefault();
                
                return account?.Properties["Password"];
            }
        }

        public CookieContainer Cookies
        {
            get
            {
                var account = GetAccountStore().FindAccountsForService(Constants.ServiceId).FirstOrDefault();
                
                return account?.Cookies;
            }
        }

        public void StoreAccount(string username, string password, CookieContainer cookieContainer)
        {
            var account = new Account(username, cookieContainer);
            account.Properties.Add("Password", password);

            GetAccountStore().Save(account, Constants.ServiceId);
        }

        public void DeleteAccount()
        {
            var accountStore = GetAccountStore();
            var account = accountStore.FindAccountsForService(Constants.ServiceId).FirstOrDefault();
            if (account != null)
            {
                accountStore.Delete(account, Constants.ServiceId);
            }
        }

        protected abstract AccountStore GetAccountStore();

    }
}
