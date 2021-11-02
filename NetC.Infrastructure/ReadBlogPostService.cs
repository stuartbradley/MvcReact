using NetC.Application;
using NetC.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.Infrastructure
{
    public class ReadBlogPostService : IReadBlogPostService
    {
        private const string _fileName = "Blog-Posts.json";
        public BlogPost GetBlogPostByIdWithComments(int id)
        {
            var baseFolderLocation = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\"));

            var fileLocation = $"{baseFolderLocation}NetC.Infrastructure\\{_fileName}";
            StreamReader r = new StreamReader(fileLocation);
            string jsonString = r.ReadToEnd();
            BlogPostRead blogPost = JsonConvert.DeserializeObject<BlogPostRead>(jsonString); ;
            return blogPost.BlogPosts.Single(x => x.Id == id);
        }
    }
}
