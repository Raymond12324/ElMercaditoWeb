using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElMercaditoWeb
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration() {

            var config = getconfig();
            clientId = "ATLmCSkbzC8bA7ijaYsDFQyBW_ZCopJOxLDynvJj3gvtHHuWWLim2gcdADai5xNYViUdktKoMrQ9UJtj";
            clientSecret = "EHnJmeWj-66RibRF95gpLDUSRnbqpI8sCYOcdri7JaVzlaRfkf3twdpvr0aws6kN3rsUWu6-WefrDu8V";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken() {

            string accesToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accesToken;
        }

        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}
