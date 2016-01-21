using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blog.Entidades
{
    public class Sobre
    {
        [Key]
        public int id { get; set; }
        public String titulo { get; set; }
        public String subTitulo { get; set; }
        public String caminhoImg { get; set; }
        public String texto { get; set; }

    }
}