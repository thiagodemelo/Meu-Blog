using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blog.Entidades
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }

        public string senha { get; set; }
    }
}