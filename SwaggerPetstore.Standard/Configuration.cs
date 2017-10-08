using System.Collections.Generic;
using System.Text;
using SwaggerPetstore.Standard.Utilities;
using SwaggerPetstore.Standard.Models;
namespace SwaggerPetstore.Standard
{
    public partial class Configuration
    {
        public delegate void OAuthTokenUpdateDelegate(OAuthToken token);

        public static OAuthToken OAuthToken;

        public static OAuthTokenUpdateDelegate OAuthTokenUpdateCallback;

        public enum Environments
        {
            PRODUCTION,
        }
        public enum Servers
        {
            DEFAULT,
            AUTH_SERVER,
        }

        //The current environment being used
        public static Environments Environment = Environments.PRODUCTION;

        //OAuth 2 Client ID
        //TODO: Replace the OAuthClientId with an appropriate value
        public static string OAuthClientId = "TODO: Replace";

        //OAuth 2 Client Secret
        //TODO: Replace the OAuthClientSecret with an appropriate value
        public static string OAuthClientSecret = "TODO: Replace";

        //OAuth 2 Resource Owner Username
        //TODO: Replace the OAuthUsername with an appropriate value
        public static string OAuthUsername = "TODO: Replace";

        //OAuth 2 Resource Owner Password
        //TODO: Replace the OAuthPassword with an appropriate value
        public static string OAuthPassword = "TODO: Replace";

        //A map of environments and their corresponding servers/baseurls
        public static Dictionary<Environments, Dictionary<Servers, string>> EnvironmentsMap =
            new Dictionary<Environments, Dictionary<Servers, string>>
            {
                { 
                    Environments.PRODUCTION,new Dictionary<Servers, string>
                    {
                        { Servers.DEFAULT,"http://petstore.swagger.io/v2" },
                        { Servers.AUTH_SERVER,"http://petstore.swagger.io/oauth" },
                    }
                },
            };

        /// <summary>
        /// Makes a list of the BaseURL parameters 
        /// </summary>
        /// <return>Returns the parameters list</return>
        internal static List<KeyValuePair<string, object>> GetBaseURIParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList; 
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        internal static string GetBaseURI(Servers alias = Servers.DEFAULT)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            APIHelper.AppendUrlWithTemplateParameters(Url, GetBaseURIParameters());
            return Url.ToString();        
        }
    }
}