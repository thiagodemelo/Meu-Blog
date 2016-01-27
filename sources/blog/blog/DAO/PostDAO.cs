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
    public class PostDAO
    {
        ConectarBD AcessaDados;
        public PostDAO()
        {
            AcessaDados = new ConectarBD();
        }

        public int Adiciona(Post Post)
        {
            String comando = @"INSERT INTO thiagodesenv.Posts(titulo,subtitulo,caminhoImg,texto,autor,data) 
            VALUES(@titulo,@subTitulo,@caminhoImg,@texto,@autor,@data)";
            MySqlCommand cmd = new MySqlCommand(comando);
            cmd.Parameters.AddWithValue("@titulo", Post.titulo);
            cmd.Parameters.AddWithValue("@subTitulo", Post.subtitulo);
            cmd.Parameters.AddWithValue("@caminhoImg", Post.caminhoImg);
            cmd.Parameters.AddWithValue("@texto", Post.texto);
            cmd.Parameters.AddWithValue("@autor", Post.autor);
            cmd.Parameters.AddWithValue("@data", Post.data);
            return AcessaDados.ExecutaComandoSQL(cmd, "AdicionaSobre");
        }

        public int Remove(int id)
        {
            String comando = @"DELETE FROM thiagodesenv.Posts where id = @id";
            MySqlCommand cmd = new MySqlCommand(comando);
            cmd.Parameters.AddWithValue("@id", id);
            return AcessaDados.ExecutaComandoSQL(cmd, "RemovePost");
        }

        public int Atualiza(Post Post)
        {
            String comando = @"UPDATE FROM thiagodesenv.Posts 
            SET titulo = @titulo,subTitulo = @subTitulo,
            caminhoImg = @caminhoImg,texto = @texto 
            autor = @autor,data = @data
            where id = @id";
            MySqlCommand cmd = new MySqlCommand(comando);
            cmd.Parameters.AddWithValue("@titulo", Post.titulo);
            cmd.Parameters.AddWithValue("@subTitulo", Post.subtitulo);
            cmd.Parameters.AddWithValue("@caminhoImg", Post.caminhoImg);
            cmd.Parameters.AddWithValue("@texto", Post.texto);
            cmd.Parameters.AddWithValue("@autor", Post.autor);
            cmd.Parameters.AddWithValue("@data", Post.data);
            cmd.Parameters.AddWithValue("@id", Post.id);

            return AcessaDados.ExecutaComandoSQL(cmd, "AtualizaSobre");
        }

        public Post BuscaPorId(int id)
        {
            String comando = "SELECT id,titulo,subtitulo,caminhoImg,texto,autor,data FROM thiagodesenv.Posts";
            MySqlCommand cmd = new MySqlCommand(comando);
            DataSet tds = AcessaDados.ConsultaSQL(cmd, "BuscaPorIdPost");
            Post p = new Post()
            {
                id = int.Parse(tds.Tables[0].Rows[0].ItemArray[0].ToString()),
                titulo = tds.Tables[0].Rows[0].ItemArray[1].ToString(),
                subtitulo = tds.Tables[0].Rows[0].ItemArray[2].ToString(),
                caminhoImg = tds.Tables[0].Rows[0].ItemArray[3].ToString(),
                texto = tds.Tables[0].Rows[0].ItemArray[4].ToString(),
                autor = tds.Tables[0].Rows[0].ItemArray[5].ToString(),
                data = DateTime.Parse(tds.Tables[0].Rows[0].ItemArray[6].ToString()),
            };
            return p;
        }

        public IEnumerable<Post> Lista()
        {
            String comando = "SELECT id,titulo,subtitulo,caminhoImg,texto,autor,data FROM thiagodesenv.Posts";
            MySqlCommand cmd = new MySqlCommand(comando);
            MySqlDataReader dr = AcessaDados.ConsultaSQL2(cmd, "ListaPost");
            List<Post> lista = new List<Post>();
            if (dr != null)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Post p = new Post()
                        {
                            id = int.Parse(dr[0].ToString()),
                            titulo = dr[1].ToString(),
                            subtitulo = dr[2].ToString(),
                            caminhoImg = dr[3].ToString(),
                            texto = dr[4].ToString(),
                            autor = dr[5].ToString(),
                            data = DateTime.Parse(dr[6].ToString()),
                        };
                        lista.Add(p);
                    }
                }
            }
            return lista;

        }


    }
}