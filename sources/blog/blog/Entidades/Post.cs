using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blog.Entidades
{
    public class Post
    {
        [Key]
        public int id { set; get; }
        public String titulo { set; get; }
        public String subtitulo { set; get; }
        public String autor { set; get; }
        public DateTime data  { set; get; }
}
}