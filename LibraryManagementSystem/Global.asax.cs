using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryManagementSystem
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
} 