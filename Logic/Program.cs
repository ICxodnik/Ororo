using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Program
    {
        const string BaseUrl = "https://ororo.tv/ru";

        static void Main(string[] args)
        {
            Downloader load = new Downloader();
            var info = load.GetAllPosterInfoBriefly(BaseUrl);
            foreach(var item in info)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.DataLink);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.ImageLink);
                Console.WriteLine(item.Rating);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Year);
            }
            Console.ReadLine();
        }
    }
}
