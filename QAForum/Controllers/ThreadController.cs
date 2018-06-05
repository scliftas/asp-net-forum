using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QAForum.Controllers
{
    public class ThreadController : Controller
    {
        IForumRepository forumRepository;

        public ThreadController() : this(new SQLForumRepository())
        {

        }

        public ThreadController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Thread
        public ActionResult Index()
        {
            IEnumerable<Thread> threads = forumRepository.GetAllThreads();

            ViewBag.Message = "QA Forums list [threads]";

            return View(threads);
        }

        // GET: Thread/Details/5
        public ActionResult Details(int id)
        {
            var result = forumRepository.GetThreadByID(id);

            ViewBag.Message = "Thread detail";

            return View(result);
        }

        // GET: Thread/Create
        public ActionResult Create()
        {
            Thread thread = new Thread();

            return View(thread);
        }

        // POST: Thread/Create
        [HttpPost]
        public ActionResult Create(Thread thread)
        {
            try
            {
                forumRepository.AddThread(thread);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(thread);
            }
        }

        // GET: Thread/Edit/5
        public ActionResult Edit(int id)
        {
            Thread thread = forumRepository.GetThreadByID(id);

            return View(thread);
        }

        // POST: Thread/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Thread thread)
        {
            try
            {
                forumRepository.UpdateThread(thread);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(thread);
            }
        }

        // GET: Thread/Delete/5
        public ActionResult Delete(int id)
        {
            Thread thread = forumRepository.GetThreadByID(id);

            return View(thread);
        }

        // POST: Thread/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Thread thread = forumRepository.GetThreadByID(id);

            try
            {
                forumRepository.DeleteThread(thread);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(thread);
            }
        }
    }
}
