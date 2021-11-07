using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.Helpers;
using fakewebapi.Models;
using fakewebapi.Repositories.Interfaces;

namespace fakewebapi.Controllers
{
    [ApiController]
    [Route("/api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly IComments _comments;

        public CommentsController(IComments comments)
        {
            _comments = comments;
        }

        [HttpGet]
        public IActionResult GetComments (string orderBy = "" , string sort = "asc")
        {
            if (!orderBy.Equals("id") && !orderBy.Equals("createTime") && !orderBy.Equals("email"))
            {
                return BadRequest("You should use id, createTime or email property of ordering");
            }
            
            return Ok(_comments.GetComments(orderBy, sort));
        }

        [HttpGet("{id}")]

        public IActionResult GetComment(int id)
        {
            var comment = _comments.GetComment(id);
            return Ok(comment);
        }

        [HttpPost("add")]
        public IActionResult AddComments(Comment comment)
        {
            if (!_comments.AddComment(comment))
            {
                return StatusCode(500);
            }

            return Ok("Comment was successfully added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            if (!_comments.DeleteComment(id))
            {
                return StatusCode(500);
            }

            return Ok($"Comment with id: {id} was successfully removed");
        }
    }
}
