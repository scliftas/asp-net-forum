using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QAForum.Controllers
{
    public class ForumController : Controller
    {
        IForumRepository forumRepository;

        public ForumController() : this(new SQLForumRepository())
        {
            
        }

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Forum
        public ActionResult Index()
        {
            IEnumerable<Forum> forums = forumRepository.GetAllForums();

            ViewBag.Message = "QA Forums list";

            return View(forums);
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            Forum forum = forumRepository.GetForumByID(id);

            ViewBag.Threads = forumRepository.GetThreadsByForum(id);
            ViewBag.Message = "Forum Detail";

            return View(forum);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            Forum forum = new Forum();

            return View(forum);
        }

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(Forum forum)
        {
            try
            {
                forumRepository.AddForum(forum);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(forum);
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            Forum forum = forumRepository.GetForumByID(id);

            return View(forum);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Forum forum)
        {
            try
            {
                forumRepository.UpdateForum(forum);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(forum);
            }
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            Forum forum = forumRepository.GetForumByID(id);

            return View(forum);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Forum forum = forumRepository.GetForumByID(id);

            try
            {
                forumRepository.DeleteForum(forum);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(forum);
            }
        }
    }
}
