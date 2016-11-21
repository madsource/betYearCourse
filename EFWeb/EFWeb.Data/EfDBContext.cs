using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EFWeb.Model;

namespace EFWeb.Data
{
    public class EfDBContext : DbContext
    {
        public EfDBContext() : base("EfDBConnection")
        {

        }

        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Tag> Tags { get; set; }
    }
}
