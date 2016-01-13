using blog.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato

        private ContatoDAO dao;

        public ContatoController(ContatoDAO dao)
        {
            this.dao = dao;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}