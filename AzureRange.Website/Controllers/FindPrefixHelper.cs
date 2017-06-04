using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureRange.Website.Controllers
{
    public class FindPrefixHelper
    {
        internal static IPPrefix FindPrefix(IPPrefix p_inputPrefix)
        {
            var containingPrefix = new IPPrefix();
            // Load the XML file into ranges
            List<IPPrefix> ipPrefixes = Downloader.Download();
            containingPrefix = Generator.GetContainingPrefix(p_inputPrefix, ipPrefixes);

            return containingPrefix;
        }
    }
}