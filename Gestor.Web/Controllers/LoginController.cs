using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestor.Web.Extensions;
using Gestor.Web.Models;
using Gestor.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Gestor.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TentarNovamente()
        {
            ViewBag.Msg = "Dados invalidos, tente novamente... !";
            return View("Index");
        }

        public IActionResult Confirmar(LoginViewModel lg)
        {
            using (var ctx = new Gestor.Data.GestorContext())
            {
                var usuario = ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(lg.login) && x.Senha.Equals(lg.senha));
                if (usuario != null)
                {
                    this.HttpContext.Session.SetAutorizacao("1", usuario.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("TentarNovamente");
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.SetAutorizacao("0");
            ViewBag.Msg = "Logout efetuado com sucesso.";
            return View("Index");
        }
    }
}