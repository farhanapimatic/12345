using System.Collections.Generic;
using System.Text;
using BibcodeQuery.PCL.Utilities;
using BibcodeQuery.PCL.Models;
namespace BibcodeQuery.PCL
{
    public partial class Configuration
    {

        public enum Environments
        {
            PRODUCTION,
        }
        public enum Servers
        {
            BIBCODEQUERYPORT,
        }

        //The current environment being used
        public static Environments Environment = Environments.PRODUCTION;

        //A map of environments and their corresponding servers/baseurls
        public static Dictionary<Environments, Dictionary<Servers, string>> EnvironmentsMap =
            new Dictionary<Environments, Dictionary<Servers, string>>
            {
                { 
                    Environments.PRODUCTION,new Dictionary<Servers, string>
                    {
                        { Servers.BIBCODEQUERYPORT,"http://adsabs.harvard.edu/" },
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
        /// <param name="alias">Default value:BIBCODEQUERYPORT</param>
        /// <return>Returns the baseurl</return>
        internal static string GetBaseURI(Servers alias = Servers.BIBCODEQUERYPORT)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            APIHelper.AppendUrlWithTemplateParameters(Url, GetBaseURIParameters());
            return Url.ToString();        
        }
    }
}