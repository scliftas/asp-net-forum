using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QAForum
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

        protected void Session_Start()
        {
            System.Web.HttpCookie c = Request.Cookies["AvatarFileName"];

            if (c != null)
            {
                IStateRepository stateRepository = new SessionStaterepository();

                ForumUserState forumUserState = stateRepository.GetForumUserState();

                forumUserState.AvatarFileName = c.Value;
                forumUserState.RememberAvatar = true;
            }
        }
    }
}
