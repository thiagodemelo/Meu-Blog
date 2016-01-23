using blog.DAO;
using blog.Entidades;
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

        public SobreController()
        {
            this.dao = new SobreDAO();
        }
        // GET: Sobre
        public ActionResult Index()
        {
            //Sobre s = new Sobre() { id = 1, titulo = "teste", subTitulo = "123", texto = "ronaldo", caminhoImg = "aa" };
            //dao.Adiciona(s);
            ViewBag.sobre = dao.BuscaPorId(1);
            return View();
        }
    }
}