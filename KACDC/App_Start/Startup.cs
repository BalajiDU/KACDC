using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KACDC.App_Start.Startup))]

namespace KACDC.App_Start
{
    public class Startup
    {
        string HangfireConn = System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888


            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage(HangfireConn);
            app.UseHangfireDashboard("/dashboard/ScheduledTask");
            
            //app.UseHangfireDashboard("/dashboard/ScheduledTask", new DashboardOptions
            //{
            //    Authorization = new[] { new MyAuthorizationFilter() }
            //});
            app.UseHangfireServer();
            //Console.WriteLine();
        }
        //public class MyAuthorizationFilter : IDashboardAuthorizationFilter
        //{
        //    //public bool Authorize(DashboardContext context)
        //    //{
        //    //    var httpContext = context.GetHttpContext();
        //    //    if (System.Web.HttpContext.Current.Session["USERTYPE"] != "CASEWORKER")
        //    //    {
        //    //        return httpContext.User.Identity.IsAuthenticated;
        //    //    }

        //    //    // Allow all authenticated users to see the Dashboard (potentially dangerous).
        //    //    return httpContext.User.Identity.IsNotAuthenticated;
        //    //}
        //}
    }
}
