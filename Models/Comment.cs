using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int IdAuthor { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int Likes { get; set; }
        

    }
}
