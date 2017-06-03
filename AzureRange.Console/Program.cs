using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AzureRange.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Variable declaration 
            List<IPPrefix> ipPrefixesInput = new List<IPPrefix>();
            List<IPPrefix> ipPrefixesOutput = new List<IPPrefix>();

            // Load the XML file into ranges
            //ipPrefixesInput = Downloader.Download();
            // add default private network prefixes
            ipPrefixesInput.Add(new IPPrefix("0.0.0.0/8"));
            //ipPrefixesInput.Add(new IPPrefix("1.0.0.0/8"));
            //ipPrefixesInput.Add(new IPPrefix("2.0.0.0/8"));
            //ipPrefixesInput.Add(new IPPrefix("3.0.0.0/8"));
            //ipPrefixesInput.Add(new IPPrefix("4.0.0.0/6"));
            ipPrefixesInput.Add(new IPPrefix("10.0.0.0/8"));
            //ipPrefixesInput.Add(new IPPrefix("128.0.0.0/1"));
            //ipPrefixesInput.Add(new IPPrefix("172.0.0.0/12"));
            ipPrefixesInput.Add(new IPPrefix("172.16.0.0/12"));
            //ipPrefixesInput.Add(new IPPrefix("172.32.0.0/11"));
            //ipPrefixesInput.Add(new IPPrefix("172.64.0.0/10"));
            //ipPrefixesInput.Add(new IPPrefix("172.128.0.0/9"));
            ipPrefixesInput.Add(new IPPrefix("169.254.0.0/16"));
            ipPrefixesInput.Add(new IPPrefix("192.168.0.0/16"));
            ipPrefixesInput.Add(new IPPrefix("224.0.0.0/3"));
            //ipPrefixesInput.Add(new IPPrefix("10.250.0.0/23"));
            //ipPrefixesInput.Add(new IPPrefix("10.250.2.0/23"));
            //ipPrefixesInput.Add(new IPPrefix("10.250.4.0/23"));
            //ipPrefixesInput.Add(new IPPrefix("10.250.6.0/23"));

            //Generator.Dedupe(ipPrefixesInput);
            ipPrefixesOutput = Generator.Summarize(ipPrefixesInput);
            // Order the ranges by increasing network ID
            //ipPrefixesOutput = Generator.Not(ipPrefixesInput);

            foreach (IPPrefix l_currentPrefix in ipPrefixesOutput)
            {
                Console.Write(String.Concat(l_currentPrefix.ReadableIP,"/",l_currentPrefix.Mask,"\n"));
            }
            Console.Write("Done!\n");
            Console.ReadKey();
            //Debugger.Break();
        }
    }
}
