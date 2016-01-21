using blog.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void Adiciona(Sobre Sobre)
        {
            contexto.sobre.Add(Sobre);
            contexto.SaveChanges();
            contexto.Dispose();
        }

        public void Remove(Sobre Sobre)
        {
            contexto.sobre.Remove(Sobre);
        }

        public void Atualiza(Sobre Sobre)
        {
            contexto.Entry(Sobre).State = EntityState.Modified;
        }

        public Sobre BuscaPorId(int id)
        {
            return contexto.sobre.Find(id);
        }

        public IEnumerable<Sobre> Lista()
        {
            List<Sobre> lista = new List<Sobre>();
            foreach (var Sobre in contexto.sobre)
                lista.Add(Sobre);

            return lista;

        }

    }
}