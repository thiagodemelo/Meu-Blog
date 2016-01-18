using blog.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class SobreController : Controller
    {

        private SobreDAO dao;

        //public SobreController(SobreDAO dao)
        //{
        //    this.dao = dao;
        //}
        // GET: Sobre
        public ActionResult Index()
        {
            return View();
        }
    }
}