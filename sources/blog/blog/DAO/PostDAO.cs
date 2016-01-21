using blog.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void Adiciona(Post Post)
        {
            contexto.post.Add(Post);
        }

        public void Remove(Post Post)
        {
            contexto.post.Remove(Post);
        }

        public void Atualiza(Post Post)
        {
            contexto.Entry(Post).State = EntityState.Modified;
        }

        public Post BuscaPorId(int id)
        {
            return contexto.post.Find(id);
        }

        public IEnumerable<Post> Lista()
        {
            List<Post> lista = new List<Post>();
            foreach (var Post in contexto.post)
                lista.Add(Post);

            return lista;

        }


    }
}