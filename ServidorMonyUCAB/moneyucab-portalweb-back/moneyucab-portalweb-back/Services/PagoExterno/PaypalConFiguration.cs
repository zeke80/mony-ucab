using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Services.PagoExterno
{
    public class PaypalConfiguration
    {
        public static string ClientId;
        public static string ClientSecret;
        public static IConfiguration Configuration;

        static PaypalConfiguration(){
            ClientId = "ASEGQYaYfkhK7Z31Nw9RVIa0mCIY1MAly9vvHBoGQl_dXKRvn_n_yvUwSd34ExwOVW4lk-U1cEehaLyH";
            ClientSecret = "EJoJziI6dvtP9WJTuEYEJcW68c4yeD5ZZql3ZVAjbwIuAcxD91Ce_Nc9RiP-pP1Hm_jcldL2rzInKVuq";
        }

        // Create the configuration map that contains mode and other optional configuration details.
        public static Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("clientId", ClientId);
            diccionario.Add("clientSecret", ClientSecret);
            diccionario.Add("mode", "sandbox");
            return diccionario;
        }

        // Create accessToken
        private static string GetAccessToken()
        {
            // ###AccessToken
            // Retrieve the access token from
            // OAuthTokenCredential by passing in
            // ClientID and ClientSecret
            // It is not mandatory to generate Access Token on a per call basis.
            // Typically the access token can be generated once and
            // reused within the expiry window                
            string accessToken = new OAuthTokenCredential(GetConfig()).GetAccessToken();
            return accessToken;
        }

        // Returns APIContext object
        public static APIContext GetAPIContext(string accessToken = "")
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            APIContext apiContext = new APIContext(string.IsNullOrEmpty(accessToken) ? GetAccessToken() : accessToken);
            apiContext.Config = GetConfig();

            // Use this variant if you want to pass in a request id  
            // that is meaningful in your application, ideally 
            // a order id.
            // String requestId = Long.toString(System.nanoTime();
            // APIContext apiContext = new APIContext(GetAccessToken(), requestId ));

            return apiContext;
        }

    }
}
