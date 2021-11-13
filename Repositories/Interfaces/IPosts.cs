using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.DTO;
using fakewebapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace fakewebapi.Repositories.Interfaces
{
    public interface IPosts
    {
        public List<Post> GetPosts(string orderby, string filter, string sort);

        public Post GetPost(int id);

        public Post GetPostByAuthor(string author);

        public int CountPost();

        public bool AddPost(PostDTO post);

        public bool UpdatePost(Post post);

        public bool DeletePost(int id);
    }
}
