using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gestor.Web.Models
{
    public class ExclusaoViewModel
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string MensagemPadrao { get; set; }
        public ExclusaoViewModel()
        {

        }
        public ExclusaoViewModel(string controller)
        {
            this.Controller = controller;
        }

        public string Json(int id, string msg = "", string titulo = "Excluir")
        {
            this.Id = id;
            this.Titulo = titulo;
            this.MensagemPadrao = $"Deseja realmente excluir ";
            this.Mensagem = msg;
            return JsonConvert.SerializeObject(this);
        }
    }
}
