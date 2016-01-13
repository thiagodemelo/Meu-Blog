using blog.Entidades;
using blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;

namespace blog.DAO
{
    public class UsuariosDAO
    {
        private EntidadesContext contexto;

        public UsuariosDAO()
        {
            this.contexto = new EntidadesContext();
        }

        public void Adiciona(Usuario usuario)
        {
            contexto.usuario.Add(usuario);
        }

        public void Remove(Usuario usuario)
        {
            contexto.usuario.Remove(usuario);
        }

        public void Atualiza(Usuario usuario)
        {
            contexto.Entry(usuario).State = EntityState.Modified;
        }

        public Usuario BuscaPorId(int id)
        {
            return contexto.usuario.Find(id);
        }

        public IEnumerable<Usuario> Lista()
        {
            List<Usuario> lista = new List<Usuario>();
            foreach (var usuario in contexto.usuario)
               lista.Add(usuario);

            return lista;
            
        }
    }
}