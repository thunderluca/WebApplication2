﻿using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ContentArchive",
                url: "{controller}/Archivio/{page}/{tagId}/{tagTitle}",
                defaults: new
                {
                    controller = "Articoli",
                    action = "Archivio",
                    page = UrlParameter.Optional,
                    tagId = UrlParameter.Optional,
                    tagTitle = UrlParameter.Optional
                });

            //routes.MapRoute(
            //    name: "NewsArchive",
            //    url: "News/Archivio/{page}",
            //    defaults: new { controller = "News", action = "Archivio", page = UrlParameter.Optional }
            //    );

            //routes.MapRoute(
            //    name: "TipsArchive",
            //    url: "Tip/Archivio/{page}",
            //    defaults: new { controller = "Tip", action = "Archivio", page = UrlParameter.Optional }
            //    );

            //routes.MapRoute(
            //    name: "EventsArchive",
            //    url: "Eventi/Archivio/{page}",
            //    defaults: new { controller = "Eventi", action = "Archivio", page = UrlParameter.Optional }
            //    );

            routes.MapRoute(
                name: "MediaArchive",
                url: "Media/",
                defaults: new { controller = "Video", action = "Index", page = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "TipDetail",
                url: "Tip/{id}",
                defaults: new { controller = "Tip", action = "Index" }
                );

            routes.MapRoute(
                name: "NewsDetail",
                url: "News/{id}",
                defaults: new { controller = "News", action = "Index" }
                );

            routes.MapRoute(
                name: "MediaDetail",
                url: "Media/{id}",
                defaults: new { controller = "Media", action = "Index" }
                );

            routes.MapRoute(
                name: "ArticleDetail",
                url: "Articoli/{id}",
                defaults: new { controller = "Articoli", action = "Index" }
                );

            routes.MapRoute(
                name: "AuthorDetail",
                url: "Autore/{id}/{name}",
                defaults: new { controller = "Autore", action = "Index", name = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
