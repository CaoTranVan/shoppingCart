using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShoppingCart
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_Start(Object sender, EventArgs e)
        {
            HttpCookie cookieName = Request.Cookies["username"];
            if (cookieName != null)
            {
                Session["username"] = cookieName.Value.ToString();
            }
            else
            {
                Session["username"] = "";
            }

        }
        void Session_End(Object sender, EventArgs e)
        {

        }
    }
}
