using blog.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class PostController : Controller
    {
        private PostDAO dao;

        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }


        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
    }
}