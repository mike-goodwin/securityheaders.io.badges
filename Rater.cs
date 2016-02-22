using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SecurityHeaders.io.badges
{
    internal class Rater
    {
        private const string SECURITYHEADERSIO = "SecurityHeadersIO";
        private const string DEFAULT_RATING = "?";
        private List<string> blackList = new List<string> { "securitybadges.azurewebsites.net" };
        internal string Rate(string domain)
        {
            string rating;

            try
            {
                rating = Parse(GetPageContent(domain));
            }
            catch(Exception e)
            {
                rating = DEFAULT_RATING;
                Trace.TraceError("Error ({0}) while rating domain {1}", e.Message, domain);
            }

            return rating;
        }

        private string GetPageContent(string domain)
        {
            string httpsDomain = WebUtility.UrlEncode(domain);
            string uriTemplate = ConfigurationManager.AppSettings[SECURITYHEADERSIO];
            string uri = string.Format(uriTemplate, httpsDomain);
            WebClient client = new WebClient();

            return client.DownloadString(uri);
        }

        private string Parse(string pageContent)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(pageContent);
            var score = document.DocumentNode
                .Descendants("div")
                .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("score")).Last()
                .Descendants("span").First().InnerText;

            return score;
        }
    }
}
