using blog.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace blog
{
    public class EntidadesContext : DbContext
    {
        public EntidadesContext() : base("name=connectionstringsprod")
        {
          // Database.CreateIfNotExists();
            // Database.SetInitializer<EntidadesContext>(null);
            //
            //Database.SetInitializer<EntidadesContext>(new DropCreateDatabaseIfModelChanges<EntidadesContext>());
        }
        public DbSet<Contato> contato { get; set; }
        public DbSet<Post> post { get; set; }
        public DbSet<Sobre> sobre { get; set; }
        public DbSet<Usuario> usuario { get; set; }
    }


}






