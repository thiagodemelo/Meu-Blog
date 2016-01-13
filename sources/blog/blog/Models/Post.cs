using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.Models
{
    public class Post
    {
        int id { set; get; }
        String titulo { set; get; }
        String subtitulo { set; get; }
        String autor { set; get; }
        DateTime data  { set; get; }
}
}