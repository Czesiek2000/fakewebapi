using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using fakeApi.Models;
using Newtonsoft.Json;

namespace fakeApi.Helpers
{
    public class Utils
    {
        private readonly string Path = "data/posts.json";
        private readonly string CommentsPath = "data/comments.json";

        public Utils()
        {

        }

        public List<Post> readFromFile()
        {
            List<Post> posts;
            using (StreamReader r = new StreamReader(this.Path))
            {
                string json = r.ReadToEnd();
                posts = JsonConvert.DeserializeObject<List<Post>>(json);
                
            }

            return posts;
        }

        public void saveToFile(List<Post> posts)
        {
            File.WriteAllText( this.Path, JsonConvert.SerializeObject( posts ) );
        }

        public void saveToFile(List<Comment> comments)
        {
            File.WriteAllText( this.CommentsPath, JsonConvert.SerializeObject( comments ) );
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
    }
}
