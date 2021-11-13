using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.DTO;
using fakewebapi.Helpers;
using fakewebapi.Models;
using fakewebapi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fakewebapi.Repositories.Implementation
{
    public class PostsService : IPosts
    {
        public List<Post> GetPosts(string orderBy, string filter, string sort)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            if (orderBy.Equals("id"))
            {
                if (sort.Equals("desc"))
                {
                    posts = posts.OrderByDescending(p => p.Id).ToList();
                }
                else
                {
                    posts = posts.OrderBy(o => o.Id).ToList();
                }
            }

            if (orderBy.Equals("title"))
            {
                if (sort.Equals("desc"))
                {
                    posts = posts.OrderByDescending(p => p.Title).ToList();
                }else
                {
                    posts = posts.OrderBy(o => o.Title).ToList();
                }
            }

            return posts;
        }

        public Post GetPost(int id)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            var post = posts.FirstOrDefault(p => p.Id == id);
            return post;
        }

        public Post GetPostByAuthor(string author)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            Post post = posts.FirstOrDefault(p => p.Author == author);
            
            return post;
        }

        public int CountPost()
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            return posts.Count;
        }

        public bool AddPost(PostDTO post)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            
            var newPost = new Post
            {
                Id = posts.Max(p => p.Id) + 1,
                Author = post.Author,
                Content = post.Content,
                Title = post.Title
            };

            posts.Add(newPost);
            return utils.saveToFile(posts);
        }

        public bool UpdatePost(Post post)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            var singlePost = posts.Remove(posts.Single(x => x.Id == post.Id));
            var newPost = new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author
            };
            posts.Add(newPost);
            return utils.saveToFile(posts);
        }

        public bool DeletePost(int id)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            var status = posts.Remove(posts.Single(x => x.Id == id));
            return utils.saveToFile(posts);
        }
    }
}
