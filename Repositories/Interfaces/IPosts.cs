using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace fakewebapi.Repositories.Interfaces
{
    public interface IPosts
    {
        public Task<List<Post>> GetPostsFromDb(List<Post> posts, string orderby, string filter, string sort);

        public Task<IActionResult> GetPost();

        public Task<IActionResult> GetPostByAuthor();

        public Task<IActionResult> CountPost();

        public Task<IActionResult> AddPost();

        public Task<IActionResult> UpdatePost();

        public Task<IActionResult> DeletePost();
    }
}
