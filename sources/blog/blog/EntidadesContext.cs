using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Mvc;
using System.Data.Entity;
using blog.Models;
using blog.Entidades;

namespace blog.DAO
{
    public class EntidadesContext : DbContext
    {
        public DbSet<Contato> contato { get; set; }
        public DbSet<Post> post { get; set; }
        public DbSet<Sobre> sobre { get; set; }
        public DbSet<Usuario> usuario { get; set; }
    }



}






