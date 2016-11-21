using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWeb.Model
{
    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }
        public string Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

    }
}
