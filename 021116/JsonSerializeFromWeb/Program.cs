using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonSerializeFromWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString("https://jsonplaceholder.typicode.com/albums");
                //Console.WriteLine(json);

                List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(json);

                for (int i = 0; i < albums.Count; i++)
                {
                    Console.WriteLine(albums[i]);
                }
            }
        }
    }
}
