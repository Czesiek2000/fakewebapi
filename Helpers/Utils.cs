using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using fakewebapi.Models;
using Newtonsoft.Json;

namespace fakewebapi.Helpers
{
    public class Utils
    {
        private readonly string PostPath = "data/posts.json";
        private readonly string CommentsPath = "data/comments.json";
        private readonly string AuthorsPath = "data/authors.json";

        public Utils()
        {

        }

        public List<Post> readFromFile()
        {
            List<Post> posts;
            using (StreamReader r = new StreamReader(this.PostPath))
            {
                string json = r.ReadToEnd();
                posts = JsonConvert.DeserializeObject<List<Post>>(json);
                
            }

            return posts;
        }

        public bool saveToFile(List<Post> posts)
        {
            bool stat = true;
            try
            {
                File.WriteAllText( this.PostPath, JsonConvert.SerializeObject( posts ) );
                stat = true;
            }
            catch (Exception)
            {
                stat = false;
            }

            return stat;
        }

        public bool saveToFile(List<Comment> comments)
        {
            bool status = true;
            try
            {
                File.WriteAllText( this.CommentsPath, JsonConvert.SerializeObject( comments ) );
                status = true;
            }catch
            {
                status = false;
            }

            return status;
        }

        public List<Comment> readComments()
        {
            List<Comment> comments;
            using ( StreamReader r = new StreamReader( this.CommentsPath ) )
            {
                string json = r.ReadToEnd();
                comments = JsonConvert.DeserializeObject<List<Comment>>( json );

            }

            return comments;
        }

        public List<Author> readAuthors()
        {
            List<Author> authors;
            using (StreamReader r = new StreamReader(this.AuthorsPath))
            {
                string json = r.ReadToEnd();
                authors = JsonConvert.DeserializeObject<List<Author>>(json);

            }

            return authors;
        }
    }
}
