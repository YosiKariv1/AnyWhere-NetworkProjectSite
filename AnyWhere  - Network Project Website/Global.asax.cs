using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AnyWhere____Network_Project_Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer<AnyWhere___Network_Project_WebSite.Dal.DB>(new DropCreateDatabaseIfModelChanges<AnyWhere___Network_Project_WebSite.Dal.DB>());
            Database.SetInitializer<AnyWhere___Network_Project_WebSite.Dal.DB>(null);
        }
    }
}
