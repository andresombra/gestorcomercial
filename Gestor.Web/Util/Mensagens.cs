using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Gestor.Infra;

namespace Gestor.Web.Util
{
    public class Mensagens : Controller, IMensagens
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        //public Mensagens()
        //{
        //    TempData["Msg"] = "";
        //}
        public Mensagens()
        {

        }
        public Mensagens(string msg)
        {
            HttpContext.Session.SetString("Msg", msg);
        }
        public void Set(string msg)
        {
            HttpContext.Session.SetString("Msg", msg);
        }
        //public Mensagens(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //public void Msg(string msg)
        //{
        //    _session.SetString("Msg", msg);
        //}

        //public void Erro(string msgerro)
        //{
        //    _session.SetString("Erro", msgerro);
        //}

        //public void GetMsg()
        //{
        //    var message = _session.GetString("Msg");
        //}
        //public void GetErro()
        //{
        //    var message = _session.GetString("Erro");
        //}

    }
}
