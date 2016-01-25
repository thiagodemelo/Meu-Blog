using blog.DAO;
using blog.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato

        private ContatoDAO dao;

        public ContatoController()
        {
            this.dao = new ContatoDAO();
        }
        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult Enviar(String name,String phone,String email, String message)
        {
            Contato contato = new Contato() { nome=name,telefone=phone,email=email,mensagem=message};
            
            EnviarEmail(contato);
            return Json("sucess");
        }

     


        public int EnviarEmail(Contato obj)
        {

            ////Define o corpo do e-mail.
            String conteudo = "Thiago o Sr. /Sra " + obj.nome + ", <br /><br />";
           // conteudo += "entrou em contato sobre: " + subject + " <br /><br />";
            conteudo += obj.mensagem + " <br /><br />";

            conteudo += "Por favor, use estes contatos para dar um retorno:<br /><br />";
            conteudo += "Tel: " + obj.telefone + "<br />";
            conteudo += "Email: " + obj.email + "<br />";
            string validado = obj.newsletter == 1 ? "Aceita" : "Não Aceita";
            conteudo += "Newsletter: " + validado + "<br /><br /><br />";

            //Cria objeto com dados do e-mail.
            System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();

            //Define o remetente do e-mail.01:03
            objEmail.From = new System.Net.Mail.MailAddress("Thiago de Melo Lima <thiago@novatela.com.br>");

            //Define os destinatários do e-mail.
            //foreach (String destinatario in obj.getDestinatario())
            objEmail.To.Add("Thiago <thiago_melo1993@hotmail.com>");

            //Enviar cópia para.
            //foreach (String destinatario in obj.getDestinatario())
                objEmail.To.Add(obj.email);

            //Enviar cópia oculta para.
            objEmail.Bcc.Add("Thiago <thiago@novatela.com.br>");

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //string fullpath = MapPath("~\\TestFile.txt");
            //objEmail.Attachments.Add(new Attachment("C:\\srv\\httpd\\merck.novatela.com.br\\merck\\public\\teste.txt"));
            //objEmail.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~/manual/usuario.txt"));
            //Define título do e-mail.
            objEmail.Subject = "Contato pelo Blog Estudante .NET"; //obj.getAssunto().ToString();

            //Define o corpo do e-mail.
            conteudo += obj.mensagem;




            //conteudo += "NovaTela Solutions<br /><br />";
            conteudo += "<br /><br /><br />Este é um e-mail automático utilizado somente para envio. <br /><br />";

            conteudo += "Data envio: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "";

            objEmail.Body = conteudo;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            MAIL mail = new MAIL();
            return mail.Enviar(objEmail, "enviar email");
        }

    }


}
