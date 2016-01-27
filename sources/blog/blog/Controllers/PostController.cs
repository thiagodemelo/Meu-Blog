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

        public PostController()
        {
            this.dao = new PostDAO();
        }


        // GET: Post
        public ActionResult Index(int id)
        {
            ViewBag.Post = dao.BuscaPorId(id);
            return View();
        }
    }
}