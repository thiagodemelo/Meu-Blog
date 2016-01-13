using blog.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Filters
{
    public class SaveChangesFilter : System.Web.Mvc.ActionFilterAttribute
    {
        private EntidadesContext contexto;
        public SaveChangesFilter(EntidadesContext contexto)
        {
            this.contexto = contexto;
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                this.contexto.SaveChanges();
            }
            this.contexto.Dispose();
        }
    }
}