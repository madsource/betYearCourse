using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogSystem.Models;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogSystemDbContext()
            : base("BlogSystemConnection", throwIfV1Schema: false)

        { }
        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }

        public IDbSet<Post> Posts { get; set; } 
    }
}
