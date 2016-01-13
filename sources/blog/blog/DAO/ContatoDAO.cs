using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.DAO
{
    public class ContatoDAO
    {
        private EntidadesContext contexto;
        public ContatoDAO(EntidadesContext contexto)
        {
            this.contexto = contexto;
        }
    }
}