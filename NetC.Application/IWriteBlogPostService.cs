using NetC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.Application
{
    public interface IWriteBlogPostService
    {
        void SaveBlogPost(BlogPost blogPost);
    }
}
