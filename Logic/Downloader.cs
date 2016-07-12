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


            var content = doc.GetElementbyId("content");
            //var channel = content.SelectNodes("//div[@id='content']//div[@id='home']/div[@class='ui grid' or @class='channels' ]/div/ ") ;
            var shows = content.SelectNodes("//div[@id='content']//div[@id='home']/div[@class='ui grid']/div/div ");

            if (shows!=null)
            foreach(var show in shows) 
            {
                    Poster poster = new Poster();
                    allPosters.Add(GetPosterInfoBriefly(show, ref poster));
            }
            return allPosters;
             
        }

        public Poster GetPosterInfoBriefly(HtmlNode show, ref Poster poster)
        {

            poster.DataLink = show.SelectSingleNode("//div[@class='index show']/a").Attributes["href"].Value;
            poster.ImageLink = show.SelectSingleNode("//div[@class='index show']/a/img").Attributes["src"].Value;

            poster.Rating = show.SelectSingleNode("//div[@class = 'index show']/a/div[@class='show-info']/div[@class='info']/span[@class='cam']/span[@class='value']").InnerText;
            poster.Year = show.SelectSingleNode("//div[@class='index show']/a/div[@class='show-info']/div[@class='info']/span[@class='star']/span[@class='value']").InnerText;

            poster.Description = show.SelectSingleNode("//div[@class='index show']/a/div[@class='show-info']/div[@class='info']/div[@class='desc']/p").InnerText;
            poster.Title = show.SelectSingleNode("//div[@class='index show']/a/div[@class='show-info']/div[@class='info']/div[@class='desc']/div[@class='title']").InnerText;


            return poster;
        }

    }
}
