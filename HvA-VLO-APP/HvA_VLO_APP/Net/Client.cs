using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HvA_VLO_APP.Net
{
    internal class Client
    {

        private readonly CookieContainer _cookieContainer;

        private readonly HttpClient _httpClient;

        public Client()
        {
            _cookieContainer = new CookieContainer(); // TODO: Persistent cookies.
            _httpClient = new HttpClient(new HttpClientHandler
            {
                CookieContainer = _cookieContainer
            });

            _httpClient.DefaultRequestHeaders.AcceptLanguage.TryParseAdd(Constants.Language);
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
        }

        /// <summary>
        /// Sign in into the website.
        /// </summary>
        /// <param name="username">The user his username.</param>
        /// <param name="password">The user his password.</param>
        /// <returns>Returns true when successfully signed in.</returns>
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Step 1: Request the correct cookies (and CSRF protection tokens later, which is.. disabled atm??)
            await _httpClient.GetStringAsync($"{Constants.ChamiloUrl}/index.php");

            // Step 2: Login using entered credentials
            using (var loginResponse = await _httpClient.PostAsync($"{Constants.ChamiloUrl}/index.php", 
                new FormUrlEncodedContent(
                    new Dictionary<string, string>
                    {
                        { "login", username },
                        { "password", password },
                        { "submitAuth", string.Empty },
                        { "_qf_formLogin", string.Empty }
                    })))
            {
                var loginResponseText = await loginResponse.Content.ReadAsStringAsync();

                return !loginResponseText.Contains("Login failed - incorrect login or password.");
            }
        }

        /// <summary>
        /// Checks if the client is signed into the website.
        /// </summary>
        /// <returns>Returns true when signed into the website.</returns>
        public async Task<bool> IsLoggedInAsync()
        {
            var testPage = await _httpClient.GetStringAsync($"{Constants.ChamiloUrl}/user_portal.php");

            return !testPage.Contains("You are not allowed to see this page.");
        }

        public void DebugCookies()
        {
            Console.WriteLine("Client cookies:");

            foreach (Cookie cookie in _cookieContainer.GetCookies(new Uri(Constants.ChamiloUrl)))
            {
                Console.WriteLine($"\t- {cookie}");
            }
        }

    }
}
