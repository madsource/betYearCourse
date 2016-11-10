using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonSerializeFromWeb
{
    public class Album
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string AlbumTitle { get; set; }

        public override string ToString()
        {
            return String.Format($"ID: {this.Id}, Title :{this.AlbumTitle}");
        }
    }
}
