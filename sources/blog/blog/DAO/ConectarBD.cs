using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace blog.dao
{
    public class ConectarBD
    {
        private static MySqlConnection SQLConexao;
        static ConectarBD instancia;

        // string mysql acessa o banco do servidor de hospedagem
        //private String stringconnection1 = "server=179.188.16.99;User Id = thiagodesenv; password=blog14122003;database=thiagodesenv";

        //string mysql rodando na maquina do desenvolvedor.
        //private String stringconnection2 = “server=localhost;User Id = seuid; password=suasenha;database=suainstancialocalmysql”;


        public ConectarBD()
        {
            SQLConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionstringsprod"].ConnectionString);
        }

        public static ConectarBD Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ConectarBD();
                return instancia;
            }
        }
        #region metodos que tentam abrir conexao com projeto rodando local ou hospedado

        //public void tentarAbrirConexaoLocal()
        //        {
        //            objConexao = new MySqlConnection();
        //            objConexao.ConnectionString = stringconnection1;
        //            objConexao.Open();
        //        }

        public void ConectaDataBase()
        {
            SQLConexao.Open();
        }
        #endregion


        public static void DesconectaDataBase()
        {
            SQLConexao.Close();
        }

        public int ExecutaComandoSQL(MySqlCommand sqlCommand, string Rotina)
        {
            int LinhasAfetadas = 0;

            try
            {
                ConectaDataBase();
                sqlCommand.Connection = SQLConexao;
                LinhasAfetadas = sqlCommand.ExecuteNonQuery();
                DesconectaDataBase();
                return LinhasAfetadas;
            }
            catch (Exception ex)
            {

                //log4net.Config.XmlConfigurator.Configure();
                //log.Error(Rotina,ex);
                System.Web.HttpContext.Current.Session.Add("erro", ex);
                DesconectaDataBase();
                //System.Web.HttpContext.Current.Response.Redirect("erro.aspx?erro=" + Rotina, true);
                return (0);
            }
        }

        public DataSet ConsultaSQL(MySqlCommand sqlCommand, string Rotina)
        {
            DataSet ds = new DataSet();

            try
            {
                ConectaDataBase();
                sqlCommand.Connection = SQLConexao;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sqlCommand;
                da.Fill(ds);

                DesconectaDataBase();
                return ds;
            }
            catch (Exception ex)
            {

                //log4net.Config.XmlConfigurator.Configure();
                //log.Error(Rotina, ex);
                System.Web.HttpContext.Current.Session.Add("erro", ex);
                //System.Web.HttpContext.Current.Response.Redirect("erro.aspx?erro=" + Rotina, true);
                DesconectaDataBase();
                return ds;
            }
        }



        public MySqlDataReader ConsultaSQL2(MySqlCommand sqlCommand, string Rotina)
        {
            MySqlDataReader dr = null;
            try
            {
                ConectaDataBase();
                sqlCommand.Connection = SQLConexao;
                dr = sqlCommand.ExecuteReader();


                return dr;
            }
            catch (Exception ex)
            {

                //log4net.Config.XmlConfigurator.Configure();
                //log.Error(Rotina, ex);
                System.Web.HttpContext.Current.Session.Add("erro", ex);
                DesconectaDataBase();
                //System.Web.HttpContext.Current.Response.Redirect("erro.aspx?erro=" + Rotina, true);
                return dr;
            }
        }



        public MySqlDataReader Reader(MySqlCommand cmd)
        {
            MySqlDataReader dr = null;
            try
            {
                ConectaDataBase();
                cmd.Connection = SQLConexao;

                dr = cmd.ExecuteReader();


                return dr;
            }
            catch (Exception ex)
            {
                //log4net.Config.XmlConfigurator.Configure();
                //log.Error("Log de Erro - merck",ex);
                return dr;
            }

        }

       

    }
}