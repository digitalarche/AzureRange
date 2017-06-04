using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Web.Http;

namespace AzureRange.Website.Controllers
{
    public class FindPrefixController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get([FromUri] string inputIP)
        {
            // Validate if it's a valid IP address (jquery validated but API calls could come from elsewhere...)
            string ipPattern = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            // Create an instance of System.Text.RegularExpressions.Regex

            bool isIPValid = Regex.IsMatch(inputIP, ipPattern);

            if (isIPValid)
            {
                var inputPrefix = new IPPrefix(inputIP + "/32");
                var outputPrefix = new IPPrefix();
                outputPrefix = FindPrefixHelper.FindPrefix(inputPrefix);
                string resultstring = String.Empty;

                if (outputPrefix != null)
                {
                    string prefixLocation;
                    if (outputPrefix.Region != null)
                        prefixLocation = outputPrefix.Region;
                    else
                        prefixLocation = outputPrefix.O365Service;

                    resultstring = ("Found " + inputPrefix.ToString() + " in " + outputPrefix.ToString() + " in region " + prefixLocation);
                }
                else resultstring = ("Prefix not found.");
                return new string[] { resultstring };
            }
            else
            {
                return new string[] { "Invalid IP address." };
            }
        }
    }
}