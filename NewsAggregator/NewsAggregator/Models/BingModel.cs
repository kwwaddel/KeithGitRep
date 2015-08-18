using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bing;
using System.Data.Services.Client;
using System.Diagnostics;
using HtmlAgilityPack;

namespace NewsAggregator.Models
{
    public class BingModel
    {
        private const string _accountKey = "w4TavPa6b63DWTzhi+XEtqjqk7/xqt8ND5K+pN5xTbE";

        public List<NewsResult> GetResults()
        {
            // This is the query expression.

            string query = "kevin white";

            // Create a Bing container.

            string rootUrl = "https://api.datamarket.azure.com/Bing/Search";

            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUrl));

            // The market to use.

            string market = "en-us";

            string newsCat = "rt_Sports";
            // Configure bingContainer to use your credentials.

            bingContainer.Credentials = new NetworkCredential(_accountKey, _accountKey);

            // Build the query, limiting to 10 results.

            DataServiceQuery<NewsResult> newsQuery =

            bingContainer.News(query, null, market, null, null, null, null, newsCat, null);

            newsQuery = newsQuery.AddQueryOption("$top", 10);
            //webQuery = webQuery.AddQueryOption("NewsCategory", "Sports");

            // Run the query and display the results.

            List<NewsResult> newsResults = new List<NewsResult>(newsQuery.Execute());

            String url = newsResults.ElementAt(2).Url;
            Debug.WriteLine("URL: " + url);
            //System.Net.WebClient wc = new System.Net.WebClient();
            //byte[] raw = wc.DownloadData(url);

            //String data = System.Text.Encoding.UTF8.GetString(raw);
            //Debug.WriteLine(data);
            //List<String> subset = new List<String>();

            HtmlWeb hw = new HtmlWeb();

            HtmlDocument doc = hw.Load(url);
            //"//a[@href]"
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//img[@src]"))
            {
                HtmlAttribute att = link.Attributes["src"];

                if (att.Value.Contains("jpg") || att.Value.Contains("jpeg"))
                    Debug.WriteLine(att.Value);
            }
            
            return newsResults;
        }
    }
}