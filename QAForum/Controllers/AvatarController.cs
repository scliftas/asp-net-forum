using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QAForum.Models;
using QAForum.Resources;

namespace QAForum.Controllers
{
    public class AvatarController : Controller
    {
        private IStateRepository stateRepository = null;

        public AvatarController() : this(new SessionStaterepository())
        {
            
        }

        public AvatarController(IStateRepository sessionStateRepository)
        {
            this.stateRepository = sessionStateRepository;
        }

        public ActionResult SelectAvatar()
        {
            var avatarUtilities = new AvatarUtilities();

            ViewBag.RememberAvatar = stateRepository.GetForumUserState().RememberAvatar;

            return View(avatarUtilities.GetAllAvatars());
        }

        public ActionResult PersistChosenAvatar(string avatarName)
        {
            ForumUserState forumUserState = stateRepository.GetForumUserState();

            forumUserState.AvatarFileName = avatarName;

            forumUserState.PersistAvatar(forumUserState.RememberAvatar);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RememberAvatar(bool chkRemember)
        {
            ForumUserState forumUserState = stateRepository.GetForumUserState();

            if (chkRemember == true)
            {
                forumUserState.RememberAvatar = true;
                forumUserState.PersistAvatar(true);
            }
            else
            {
                forumUserState.RememberAvatar = false;
                forumUserState.PersistAvatar(false);
            }

            return RedirectToAction("SelectAvatar", "Avatar");
        }
    }
}