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
        ConectarBD AcessaDados;
        public SobreDAO()
        {
            AcessaDados = new ConectarBD();
        }

        public int Adiciona(Sobre Sobre)
        {
            String comando = @"INSERT INTO thiagodesenv.Sobres(titulo,subTitulo,caminhoImg,texto) 
            VALUES(@titulo,@subTitulo,@caminhoImg,@texto)";
            MySqlCommand cmd = new MySqlCommand(comando);
            cmd.Parameters.AddWithValue("@titulo", Sobre.titulo);
            cmd.Parameters.AddWithValue("@subTitulo", Sobre.subTitulo);
            cmd.Parameters.AddWithValue("@caminhoImg", Sobre.caminhoImg);
            cmd.Parameters.AddWithValue("@texto", Sobre.texto);
            return AcessaDados.ExecutaComandoSQL(cmd, "AdicionaSobre");
        }

        public int Remove(int id)
        {
            String comando = @"DELETE FROM thiagodesenv.Sobres where id = @id";
            MySqlCommand cmd = new MySqlCommand(comando);
            cmd.Parameters.AddWithValue("@id", id);
            return AcessaDados.ExecutaComandoSQL(cmd, "RemoveSobre");
        }

        public int Atualiza(Sobre Sobre)
        {
            String comando = @"UPDATE FROM thiagodesenv.Sobres 
            SET titulo = @titulo,subTitulo = @subTitulo,
            caminhoImg = @caminhoImg,texto = @texto where id = @id";
            MySqlCommand cmd = new MySqlCommand(comando);
            cmd.Parameters.AddWithValue("@titulo", Sobre.titulo);
            cmd.Parameters.AddWithValue("@subTitulo", Sobre.subTitulo);
            cmd.Parameters.AddWithValue("@caminhoImg", Sobre.caminhoImg);
            cmd.Parameters.AddWithValue("@texto", Sobre.texto);
            cmd.Parameters.AddWithValue("@id", Sobre.id);

            return AcessaDados.ExecutaComandoSQL(cmd, "AtualizaSobre");
        }

        public Sobre BuscaPorId(int id)
        {
            //return contexto.sobre.Find(id);
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

        public IEnumerable<Sobre> Lista()
        {
            String comando = "SELECT * FROM thiagodesenv.Sobres";
            MySqlCommand cmd = new MySqlCommand(comando);
            MySqlDataReader dr = AcessaDados.ConsultaSQL2(cmd, "ListaSobre");
            List<Sobre> lista = new List<Sobre>();
            if (dr != null)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Sobre s = new Sobre()
                        {
                            titulo = dr[1].ToString(),
                            subTitulo = dr[2].ToString(),
                            caminhoImg = dr[3].ToString(),
                            texto = dr[4].ToString()
                            
                        };
                        lista.Add(s);
                    }
                }
            }
            return lista;
        }

    }
}