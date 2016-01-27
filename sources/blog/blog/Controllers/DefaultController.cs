using blog.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        private PostDAO dao;

        public DefaultController()
        {
            this.dao = new PostDAO();
        }
        public ActionResult Index()
        {
            ViewBag.listaPost = dao.Lista();
            return View();
        }
    }
}