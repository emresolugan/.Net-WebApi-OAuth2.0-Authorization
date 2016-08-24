using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bus_Staj
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using(Bus_Staj.Models.DataContext  db=new Models.DataContext())
            {
                db.Database.CreateIfNotExists(); //database oluşmamışsa yeni oluşmasını sağlıyor.
            }
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
