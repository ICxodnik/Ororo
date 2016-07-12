using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Logic
{
    public class Downloader
    {

        List<Poster> allPosters = new List<Poster>();

        public List<Poster> GetAllPosterInfoBriefly(string link)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var html = client.DownloadString(link);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            //var channel = content.SelectNodes("//div[@id='content']//div[@id='home']/div[@class='ui grid' or @class='channels' ]/div/ ") ;
            var shows = doc.GetElementbyId("home").SelectNodes("//div[@class='index show']");

            if (shows != null)
            {
                foreach (var show in shows)
                {
                    allPosters.Add(GetPosterInfoBriefly(show));
                }
            }
            return allPosters;

        }

        public Poster GetPosterInfoBriefly(HtmlNode show)
        {
            Poster poster = new Poster();

            poster.DataLink = show.SelectSingleNode("a").Attributes["href"].Value;
            poster.ImageLink = show.SelectSingleNode("a/img").Attributes["src"].Value;
            var infoNode = show.SelectSingleNode("a//div[@class='info']");

            poster.Rating = infoNode.SelectSingleNode("span[@class='cam']/span").InnerText;
            poster.Year = infoNode.SelectSingleNode("span[@class='star']/span").InnerText;

            poster.Description = infoNode.SelectSingleNode("div[@class='desc']/p").InnerText;
            poster.Title = infoNode.SelectSingleNode("div[@class='desc']/div[@class='title']").InnerText;


            return poster;
        }

    }
}
