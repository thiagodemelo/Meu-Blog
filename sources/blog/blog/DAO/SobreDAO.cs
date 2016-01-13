using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.DAO
{
    public class SobreDAO
    {
        private EntidadesContext contexto;
        public SobreDAO(EntidadesContext contexto)
        {
            this.contexto = contexto;
        }
    }
}