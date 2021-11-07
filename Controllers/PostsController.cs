using fakewebapi.Helpers;
using fakewebapi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.Repositories.Interfaces;

namespace fakewebapi.Controllers
{
    [ApiController]
    [Route("/api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPosts _posts;

        public PostsController(IPosts posts)
        {
            _posts = posts;
        }

        [HttpGet]
        public IActionResult GetPosts(string orderBy, string filter, string sort)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            if ( !string.IsNullOrEmpty( orderBy ) )
            {

                _posts.GetPostsFromDb(posts, orderBy, filter, sort);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                if (filter.Equals("name"))
                {
                    //foreach (var post in posts)
                    //{
                    //    if (post.Title == filter)
                    //    {
                    //        posts.Clear();
                    //        posts.Add(post);
                    //    }
                    //}
                    posts.Where(p => p.Title == "Another post");
                }
            }
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            Post result = null;
            
            foreach (var post in posts)
            {
                if (post.Id == id)
                {
                    result = post;
                    return Ok(result);
                }
            }

            return NotFound($"Post {id} is not inside in database");
        }

        [HttpGet("author")]
        public IActionResult GetPostsByAuthor ( string name )
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            Post post = null;

            post = posts.FirstOrDefault( p => p.Author == name );
            return Ok( post );
        }

        [HttpGet("count")]
        public IActionResult CountPosts()
        {
            var utils = new Utils();
            var posts = utils.readFromFile();
            int number = posts.Count();
            return Ok($"total posts number: {number}");
        }

        [HttpPost("add")]
        public IActionResult AddPost(Post post)
        {
            var utils = new Utils();
            var posts = utils.readFromFile();

            if (string.IsNullOrEmpty(post.Author))
            {
                return BadRequest("Author is not defined");
            }

            if (string.IsNullOrEmpty(post.Title))
            {
                return BadRequest("Post title is not defined");
            }

            if (string.IsNullOrEmpty(post.Content))
            {
                return BadRequest("Post has no body");
            }

            var newPost = new Post
            {
                Id = posts.Max(p => p.Id) + 1,
                Author = post.Author,
                Content = post.Content,
                Title = post.Title
            };

            posts.Add(newPost);
            utils.saveToFile(posts);
            return Ok("Post added");
        }
    }
}
