using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gestor.Web.Models;
using Gestor.Data;

namespace Gestor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly GestorContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GestorContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            //try
            //{
            //    var cli = new Dominio.Entidades.Cliente() { Nome = "Antonio Teste da Silva" };
            //    _context.Clientes.Add(cli);
            //    _context.SaveChanges();
            //    ViewBag.Nome = _context.Clientes.Find(cli.Id).Nome;
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Nome = ex.Message;
            //    return View();
            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
