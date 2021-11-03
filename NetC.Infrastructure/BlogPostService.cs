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
    public class BlogPostService : IReadBlogPostService, IWriteBlogPostService
    {
        private readonly string _fileLocation;

        public BlogPostService()
        {
            var baseFolderLocation = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\"));

            _fileLocation = $"{baseFolderLocation}NetC.Infrastructure\\Blog-Posts.json";
        }

        public BlogPost GetBlogPostByIdWithComments(int id)
        {
            return GetBlogPosts().BlogPosts.Single(x => x.Id == id);
        }

        private BlogPostRead GetBlogPosts()
        {
            
            StreamReader r = new StreamReader(_fileLocation);
            string jsonString = r.ReadToEnd();
            BlogPostRead blogPosts = JsonConvert.DeserializeObject<BlogPostRead>(jsonString);
            r.Dispose();
            return blogPosts;
        }

        public void SaveBlogPost(BlogPost blogPost)
        {
            var blogPostsCollection = GetBlogPosts();
            blogPostsCollection.BlogPosts.Remove(blogPostsCollection.BlogPosts.Single(x => x.Id == blogPost.Id));
            blogPostsCollection.BlogPosts.Add(blogPost);
            string json = JsonConvert.SerializeObject(blogPostsCollection);
            System.IO.File.WriteAllText(_fileLocation, json);
        }
    }
}
