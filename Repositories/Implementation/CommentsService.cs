using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakewebapi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using fakewebapi.Models;
using fakewebapi.Helpers;
using fakewebapi.Repositories;
using fakewebapi.Controllers;
using fakewebapi.DTO;

namespace fakewebapi.Repositories.Implementation
{
    public class CommentsService : IComments
    {
        public List<Comment> GetComments(string orderBy, string sort)
        {
            var utils = new Utils();
            var comments = utils.readComments();

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
                        comments = comments.OrderBy(o => o.Id).ToList();
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
            return comments;
        }

        public bool AddComment(Comment comment)
        {
            var utils = new Utils();
            var comments = utils.readComments();
            var comm = new Comment
            {
                Id = comments.Max(c => c.Id) + 1,
                IdAuthor = comment.IdAuthor,
                Content = comment.Content,
                CreateTime = comment.CreateTime,
                Likes = comment.Likes
            };
            comments.Add(comm);
            return utils.saveToFile(comments);
        }

        public CommentDTO GetComment(int id)
        {
            var utils = new Utils();
            var comments = utils.readComments();
            var authors = utils.readAuthors();

            var comment = comments.FirstOrDefault(x => x.Id == id);
            var fullComment = new CommentDTO{ Id = id, Content = comment.Content, CreateTime = comment.CreateTime, Author = authors.Find(x => x.Id == comment.IdAuthor).Name };
            return fullComment;
        }

        public bool DeleteComment(int id)
        {
            var utils = new Utils();
            var comments = utils.readComments();
            var status = comments.Remove(comments.Single(x => x.Id == id));
            utils.saveToFile(comments);
            return status;
            
        }
    }
}
