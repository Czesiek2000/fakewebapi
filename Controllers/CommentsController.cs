using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakeApi.Helpers;
using fakeApi.Models;
using fakeApi.Repositories.Interfaces;

namespace fakeApi.Controllers
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
            var utils = new Utils();
            var comments = utils.readComments();
            List<Comment> orderComments = new List<Comment>();
            if (!orderBy.Equals("id") && !orderBy.Equals("createTime") && !orderBy.Equals("email"))
            {
                return BadRequest("You should use id, createTime or email property of ordering");
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                if (orderBy.Equals("id"))
                {
                    if (sort.Equals("desc"))
                    {
                        comments = comments.OrderByDescending(o => o.Id).ToList();
                    }
                    else
                    {
                        comments = comments.OrderBy( o => o.Id ).ToList();
                    }
                }

                if (orderBy.Equals("createTime"))
                {
                    
                    if (sort.Equals("desc"))
                    {
                        comments = comments.OrderByDescending(o => o.CreateTime).ToList();
                    }
                    else
                    {
                        comments = comments.OrderBy(o => o.CreateTime).ToList();
                    }
                }
            }
            return Ok(comments);
        }

        [HttpGet("{id}")]

        public IActionResult GetComment(int id)
        {
            var utils = new Utils();
            var result = utils.readComments();
            var comment = result.FirstOrDefault(x => x.Id == id);
            return Ok(comment);
        }

        [HttpPost("add")]
        public IActionResult AddComments(Comment comment)
        {
            var utils = new Utils();
            var comments = utils.readComments();
            var comm = new Comment
            {
                Id = comments.Max( c => c.Id ) + 1,
                IdAuthor = comment.IdAuthor,
                Content = comment.Content,
                CreateTime = comment.CreateTime,
                Likes = comment.Likes
            };
            comments.Add( comm );
            utils.saveToFile( comments );
            return Ok("Comment added success");
        }
    }
}
