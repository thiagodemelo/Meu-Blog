using blog.dao;
using blog.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace blog.DAO
{
    public class SobreDAO
    {
       
        public SobreDAO()
        {
            
        }

        //public void Adiciona(Sobre Sobre)
        //{
        //    contexto.sobre.Add(Sobre);
        //    contexto.SaveChanges();
        //    contexto.Dispose();
        //}

        //public void Remove(Sobre Sobre)
        //{
        //    contexto.sobre.Remove(Sobre);
        //}

        //public void Atualiza(Sobre Sobre)
        //{
        //    contexto.Entry(Sobre).State = EntityState.Modified;
        //}

        public Sobre BuscaPorId(int id)
        {
            //return contexto.sobre.Find(id);
            ConectarBD AcessaDados = new ConectarBD();
            String comando = "SELECT * FROM thiagodesenv.Sobres";
            MySqlCommand cmd = new MySqlCommand(comando);
            DataSet tds = AcessaDados.ConsultaSQL(cmd, "teste");
            //da.Fill(tds, tds.Tables[0].TableName);
            Sobre s = new Sobre()
            {
                titulo = tds.Tables[0].Rows[0].ItemArray[1].ToString(),
                subTitulo = tds.Tables[0].Rows[0].ItemArray[2].ToString(),
                caminhoImg = tds.Tables[0].Rows[0].ItemArray[3].ToString(),
                texto = tds.Tables[0].Rows[0].ItemArray[4].ToString()
            };
            return s;
        }

        //public IEnumerable<Sobre> Lista()
        //{
        //    List<Sobre> lista = new List<Sobre>();
        //    foreach (var Sobre in contexto.sobre)
        //        lista.Add(Sobre);

        //    return lista;

        //}

    }
}