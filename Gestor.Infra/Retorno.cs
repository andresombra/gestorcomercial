using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.Infra
{
    public class Retorno
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string MensagemBasica { get; set; }
        public Guid Id { get; set; }
        public Exception Erro { get; set; }

        public string Alert { get { return Codigo == 1 ? "alert-success" : "alert-danger"; } }

        public Retorno()
        {

        }
        public Retorno(string msg, int codigo=1)
        {
            this.Codigo = codigo;
            this.Mensagem = msg;
        }

        public Retorno(Exception ex)
        {
            this.Erro = ex;
            this.Codigo = -1;
            string msg = ex.InnerException != null ? ex.InnerException.Message + "," + ex.Message : ex.Message;
            this.Mensagem = $"Erro: { msg }";
            this.MensagemBasica = $"Erro: { ex.Message }";
        }
        public Retorno Ok(string msg)
        {
            this.Codigo = 1;
            this.Mensagem = msg;
            return this;
        }
        public Retorno Error(Exception ex)
        {
            this.Codigo = -1;
            string msg = ex.InnerException != null ? ex.InnerException.Message + "," + ex.Message : ex.Message;
            this.Mensagem = $"Erro: { msg }";
            this.MensagemBasica = $"Erro: { ex.Message }";
            return this;
        }
    }
}
