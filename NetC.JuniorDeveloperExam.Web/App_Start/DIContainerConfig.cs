using Autofac;
using Autofac.Integration.Mvc;
using MediatR.Extensions.Autofac.DependencyInjection;
using NetC.Application;
using NetC.Application.Queries;
using NetC.Infrastructure;
using NetC.JuniorDeveloperExam.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web.App_Start
{
    public class DIContainerConfig
    {
        internal static void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(BlogPostsController).Assembly);

            builder.RegisterMediatR(typeof(GetBlogPostByIdQuery).Assembly);
            builder.RegisterType<BlogPostService>().As<IReadBlogPostService>();
            builder.RegisterType<BlogPostService>().As<IWriteBlogPostService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
