using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakewebapi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int IdAuthor { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int Likes { get; set; }

    }
}
