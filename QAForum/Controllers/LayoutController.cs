using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QAForum.Models;

namespace QAForum.Controllers
{
    public class LayoutController : Controller
    {
        private IStateRepository stateRepository = null;

        public LayoutController() : this(new SessionStaterepository())
        {

        }

        public LayoutController(IStateRepository sessionStateRepository)
        {
            this.stateRepository = sessionStateRepository;
        }

        public ContentResult Avatar()
        {
            string imgPath = "~/content/images/avatars/";

            ForumUserState forumUserState = stateRepository.GetForumUserState();

            if (forumUserState.AvatarFileName != string.Empty)
            {
                imgPath += forumUserState.AvatarFileName;
            }
            else
            {
                imgPath += "avatar1.jpg";
            }

            return new ContentResult() { Content = imgPath };
        }
    }
}