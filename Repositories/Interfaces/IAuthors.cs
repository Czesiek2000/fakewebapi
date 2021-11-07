using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using fakewebapi.Models;


namespace fakewebapi.Repositories.Interfaces
{
    public interface IAuthors
    {
        public List<Author> GetAuthors();
        public Author GetAuthor();
        public List<Author> GetAuthorPosts();
        public int CountAuthorPosts();
    }
}
