using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using fakewebapi.Models;
using fakewebapi.DTO;

namespace fakewebapi.Repositories.Interfaces
{
    public interface IComments
    {
        public List<Comment> GetComments(string orderby, string sort);
        public bool AddComment(Comment comment);

        public CommentDTO GetComment(int id);

        public bool DeleteComment(int id);
    }
}
