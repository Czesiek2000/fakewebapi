using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakewebapi.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int Likes { get; set; }
    }
}
