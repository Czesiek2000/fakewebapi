using fakewebapi.Helpers;
using fakewebapi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.Repositories.Interfaces;
using fakewebapi.DTO;

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
        public IActionResult GetPosts(string orderBy = "id", string filter = "", string sort = "asc")
        {
            if(!orderBy.Equals("id") && !orderBy.Equals("title"))
            {
                return BadRequest("You should use id or title property of ordering");
            }

            if (string.IsNullOrEmpty(orderBy) || string.IsNullOrEmpty(sort))
            {
                return BadRequest("Orderby and sort cannot be empty");
            }

            return Ok(_posts.GetPosts(orderBy, filter, sort));
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var posts = _posts.GetPost(id);
            return Ok(posts);
        }

        [HttpGet("author")]
        public IActionResult GetPostsByAuthor (string author = "")
        {
            var posts = _posts.GetPostByAuthor(author);
            if (posts == null)
            {
                return NotFound($"Posts by author with author {author} not found");
            }
            return Ok(posts);
        }

        [HttpGet("count")]
        public IActionResult CountPosts()
        {
            return Ok(_posts.CountPost());
        }

        [HttpPost("add")]
        public IActionResult AddPost(PostDTO post)
        {
            if (string.IsNullOrEmpty(post.Author))
            {
                return BadRequest("Author is not defined");
            }

            if (string.IsNullOrEmpty(post.Title))
            {
                return BadRequest("Title is not defined");
            }

            if (string.IsNullOrEmpty(post.Content))
            {
                return BadRequest("Post has no body");
            }
            
            var added = _posts.AddPost(post);

            if (!added)
            {
                return BadRequest("Failed to save file");
            }

            return Ok("Post added");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePost(int id)
        {
            var deleted = _posts.DeletePost(id);
            if (!deleted)
            {
                return BadRequest("Failed to delete");
            }

            return Ok($"Post with id: {id} deleted");
        }

        [HttpPut("update")]
        public IActionResult UpdatePost(Post post)
        {
            var updated = _posts.UpdatePost(post);
            if (!updated)
            {
                return BadRequest("Failed to update");
            }

            return Ok($"Updated post with id: {post.Id} successfully");
        }
    }
}
