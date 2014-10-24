using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Services.Client;
using System.Net;
using System.Collections.ObjectModel;

namespace BingNewsService
{
    public class NewsService : INewsService
    {
        #region IRestServiceImpl Members
        private const string AccountKey = "grSrblWUETXeqmBqJMCK0TOcvL5pUwd15yQhWtgk7wI";
        private const string EMPTY_GUID = "{00000000-0000-0000-0000-000000000000}";
        public string XMLData(string id)
        {
            return "You requested product " + id;
        }

        public List<NewsResult> JSONData(string keyword)
        {
           
           List<NewsResult> newsResultListData = new List<NewsResult>();
           NewsResult newsResultStorage = new NewsResult();

           #region Proxy from MS
           // This is the query expression.
            string query = keyword;

            // Create a Bing container.
            string rootUrl = "https://api.datamarket.azure.com/Bing/Search";
            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUrl));

            // The market to use.
            string market = "en-us";

            // Get news for science and technology.
            string newsCat = "rt_ScienceAndTechnology";

            // Configure bingContainer to use your credentials.
            bingContainer.Credentials = new NetworkCredential(AccountKey, AccountKey);

            // Build the query, limiting to 10 results.
            var newsQuery =
                bingContainer.News(query, null, market, null, null, null, null, newsCat, null);
            newsQuery = newsQuery.AddQueryOption("$top", 11);

            #endregion Proxy from MS
            // Run the query and display the results.
            var newsResults = newsQuery.Execute();

            foreach (var result in newsResults)
            {
               
                Console.WriteLine("{0}-{1}\n\t{2}",
                result.Source, result.Title, result.Description);

                newsResultStorage.Date = result.Date;
                newsResultStorage.Description = result.Description;
                newsResultStorage.ID = result.ID;
                newsResultStorage.Source = result.Source;
                newsResultStorage.Title = result.Title;
                newsResultStorage.Url = result.Url;
                newsResultStorage = new NewsResult();
                if (newsResultStorage.ID.ToString() != EMPTY_GUID)
                {
                    newsResultListData.Add(newsResultStorage);
                }


            }
            //return "You requested product " + keyword;

            return newsResultListData;

        }

        #endregion
    }
}
