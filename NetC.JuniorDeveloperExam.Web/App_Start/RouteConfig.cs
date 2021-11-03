using System.Web.Mvc;
using System.Web.Routing;

namespace NetC.JuniorDeveloperExam.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "BlogPost",
                url: "BlogPost",
                defaults: new { controller = "BlogPosts", action = "GetBlogPost" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BlogPosts", action = "Index", id = 1 }

            );
        }
    }
}
