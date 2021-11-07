using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.Models;
using fakewebapi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fakewebapi.Repositories.Implementation
{
    public class PostsService : IPosts
    {
        public async Task<List<Post>> GetPostsFromDb(List<Post> posts, string orderBy, string filter, string sort)
        {
            List<Post> SortedList;
            if (orderBy.Equals("id"))
            {
                //ListSort listSort = new ListSort();
                //posts.Sort(listSort);
                posts.OrderBy(o => o.Id).ToList();
                //posts = SortedList;
                if (sort.Equals("desc"))
                {
                    posts.OrderByDescending(p => p.Id).ToList();
                }
            }
            else if (orderBy.Equals("title"))
            {
                posts.OrderBy(o => o.Title).ToList();
                //posts = SortedList;
                if (sort.Equals("desc"))
                {
                    posts.OrderByDescending(p => p.Title).ToList();
                }
            }
            else
            {
                posts.OrderBy(o => o.Author).ToList();
                //posts = SortedList;
                if (sort.Equals("desc"))
                {
                    posts.OrderByDescending(p => p.Author).ToList();
                }
            }

            return posts;
        }

        public Task<IActionResult> GetPost()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetPostByAuthor()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CountPost()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> AddPost()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdatePost()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeletePost()
        {
            throw new NotImplementedException();
        }
    }
}
