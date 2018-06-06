using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    public class ForumUserState
    {
        public string AvatarFileName { get; set; }
        public bool RememberAvatar { get; set; }

        public ForumUserState()
        {
            AvatarFileName = string.Empty;
        }

        public void PersistAvatar(bool persist)
        {
            HttpContext context = HttpContext.Current;

            System.Web.HttpCookie c = new HttpCookie("AvatarFileName", AvatarFileName);

            if (persist)
            {
                c.Expires = DateTime.Now.AddMonths(3);
            }
            else
            {
                c.Expires = DateTime.Now.AddDays(-1D);
                c.Value = string.Empty;
            }

            context.Response.Cookies.Add(c);
        }
    }
}