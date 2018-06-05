using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QAForum.Controllers
{
    public class PostController : Controller
    {
        IForumRepository forumRepository;

        public PostController() : this(new SQLForumRepository())
        {

        }

        public PostController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Post
        public ActionResult Index()
        {
            IEnumerable<Post> Posts = forumRepository.GetAllPosts();

            ViewBag.Message = "QA Forums list [Posts]";

            return View(Posts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var result = forumRepository.GetPostByID(id);

            ViewBag.Message = "Post detail";

            return View(result);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            Post Post = new Post();

            return View(Post);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post Post)
        {
            try
            {
                forumRepository.AddPost(Post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(Post);
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            Post Post = forumRepository.GetPostByID(id);

            return View(Post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Post Post)
        {
            try
            {
                forumRepository.UpdatePost(Post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(Post);
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            Post Post = forumRepository.GetPostByID(id);

            return View(Post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Post Post = forumRepository.GetPostByID(id);

            try
            {
                forumRepository.DeletePost(Post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(Post);
            }
        }
    }
}
