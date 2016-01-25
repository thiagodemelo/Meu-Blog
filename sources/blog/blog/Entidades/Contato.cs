using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blog.Entidades
{
    public class Contato
    {
        [Key]
        public int id { get; set; }
        public String nome {get;set;}
        public String email { get; set; }
        public String telefone { get; set; }
        public String mensagem { get; set; }
        public int newsletter { get; set; }

        
    }
}