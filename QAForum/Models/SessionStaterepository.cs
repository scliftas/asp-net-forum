using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    public class SessionStaterepository : IStateRepository
    {
        ForumUserState IStateRepository.GetForumUserState()
        {
            HttpContext context = HttpContext.Current;

            ForumUserState forumUserState = context.Session["ForumUserState"] as ForumUserState;

            if (forumUserState == null)
            {
                forumUserState = new ForumUserState();
                context.Session["ForumUserState"] = forumUserState;
            }

            return forumUserState;
        }
    }
}