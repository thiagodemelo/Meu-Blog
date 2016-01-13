using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.DAO
{
    public class PostDAO
    {
        private EntidadesContext contexto;
        public PostDAO(EntidadesContext contexto)
        {
            this.contexto = contexto;
        }
    }
}