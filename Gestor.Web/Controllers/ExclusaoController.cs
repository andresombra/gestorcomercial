using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestor.Infra;
using Gestor.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Gestor.Dominio.Entidades;

namespace Gestor.Web.Controllers
{
    public class ExclusaoController : Controller
    {
        public IActionResult Excluir(string exc)
        {
            var exclusaoviewmodel = JsonConvert.DeserializeObject<ExclusaoViewModel>(exc);
            return View("Exclusao", exclusaoviewmodel);
        }

        [HttpPost]
        public IActionResult Excluir(ExclusaoViewModel exc)
        {
            //Redireciona para o controller que chamou acao de excluir
            
            return RedirectToAction("Index", exc.Controller);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}