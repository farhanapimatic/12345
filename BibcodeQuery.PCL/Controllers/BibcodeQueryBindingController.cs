/*
 * BibcodeQuery.PCL
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using BibcodeQuery.PCL;
using BibcodeQuery.PCL.Utilities;
using BibcodeQuery.PCL.Http.Request;
using BibcodeQuery.PCL.Http.Response;
using BibcodeQuery.PCL.Http.Client;
using BibcodeQuery.PCL.Exceptions;

namespace BibcodeQuery.PCL.Controllers
{
    public partial class BibcodeQueryBindingController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static BibcodeQueryBindingController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static BibcodeQueryBindingController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new BibcodeQueryBindingController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// TODO: type endpoint description here
        /// </summary>
        /// <param name="bibcode">Required parameter: Example: </param>
        /// <param name="dbKey">Required parameter: Example: </param>
        /// <param name="dataType">Required parameter: Example: </param>
        /// <return>Returns the Models.ReturnBibcode response from the API call</return>
        public Models.ReturnBibcode GetBibcode(string bibcode, string dbKey, string dataType)
        {
            Task<Models.ReturnBibcode> t = GetBibcodeAsync(bibcode, dbKey, dataType);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// TODO: type endpoint description here
        /// </summary>
        /// <param name="bibcode">Required parameter: Example: </param>
        /// <param name="dbKey">Required parameter: Example: </param>
        /// <param name="dataType">Required parameter: Example: </param>
        /// <return>Returns the Models.ReturnBibcode response from the API call</return>
        public async Task<Models.ReturnBibcode> GetBibcodeAsync(string bibcode, string dbKey, string dataType)
        {
            //the base uri for api requests
            string _baseUri = Configuration.GetBaseURI();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/cgi-bin/nph-bib_query");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "bibcode", bibcode },
                { "db_key", dbKey },
                { "data_type", dataType }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);
            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.ReturnBibcode>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 