using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfDemo.Models;

namespace EfDemo.Data
{
    public class EfDBContext : DbContext
    {
        public EfDBContext():base("EfDBConnection")
        {
            
        }

        public IDbSet<Post> Posts { get; set; }
    }
}
